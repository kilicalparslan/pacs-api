using Microsoft.EntityFrameworkCore;
using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.UserRoleDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class UserRoleService : AutoMapperService, IUserRoleService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public UserRoleService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<UserRoleDto>> GetList(int userId)
		{
			var result = await _repositoryFactory.CreateUserRoleDal.GetIncludable(r => r.Isactive && !r.Isdelete && r.UserId==userId, t=>t.Include(e=>e.Role)).ToListAsync();

			if (result is null)
			{
				return new List<UserRoleDto>();
			}
			return Mapper.Map<IList<UserRole>, IList<UserRoleDto>>(result);
		}

		public async Task<IResult> Create(UserRoleAddDto userRoleAddDto)
		{
			var userRoleControl = await _repositoryFactory.CreateUserRoleDal.GetAsync(x => x.UserId.Equals(userRoleAddDto.UserId) && x.RoleId.Equals(userRoleAddDto.RoleId));
			if (userRoleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<UserRoleAddDto, UserRole>(userRoleAddDto);
			var result = await _repositoryFactory.CreateUserRoleDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(UserRoleUpdateDto userRoleUpdateDto)
		{
			var userRole = await _repositoryFactory.CreateUserRoleDal.GetAsync(x => x.Id == userRoleUpdateDto.Id);
			if (userRole is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var userRoleControl = await _repositoryFactory.CreateUserRoleDal.GetAsync(x => (x.UserId.Equals(userRoleUpdateDto.UserId) && x.RoleId.Equals(userRoleUpdateDto.RoleId)) && x.Id != userRoleUpdateDto.Id);
			if (userRoleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(userRoleUpdateDto, userRole);
			Result isOk = await _repositoryFactory.CreateUserRoleDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var userRole = await _repositoryFactory.CreateUserRoleDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (userRole is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			userRole.Isdelete = true;
			userRole.Isactive = false;

			return await _repositoryFactory.CreateUserRoleDal.Update(userRole) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<UserRoleDto> GetUserRoleById(int? userRoleId)
		{
			if (userRoleId == null) return new UserRoleDto();
			var result = await _repositoryFactory.CreateUserRoleDal.GetAsync(x => x.Id == userRoleId);
			return Mapper.Map<UserRole, UserRoleDto>(result);
		}
	}
}