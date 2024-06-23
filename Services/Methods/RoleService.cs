using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.RoleDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class RoleService : AutoMapperService, IRoleService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public RoleService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<RoleDto>> GetList()
		{
			var result = await _repositoryFactory.CreateRoleDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<RoleDto>();
			}
			return Mapper.Map<IList<Role>, IList<RoleDto>>(result);
		}

		public async Task<IResult> Create(RoleAddDto roleAddDto)
		{
			var roleControl = await _repositoryFactory.CreateRoleDal.GetAsync(x => x.Name.Equals(roleAddDto.Name));
			if (roleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<RoleAddDto, Role>(roleAddDto);
			var result = await _repositoryFactory.CreateRoleDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(RoleUpdateDto roleUpdateDto)
		{
			var role = await _repositoryFactory.CreateRoleDal.GetAsync(x => x.Id == roleUpdateDto.Id);
			if (role is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var roleControl = await _repositoryFactory.CreateRoleDal.GetAsync(x => x.Name == roleUpdateDto.Name && x.Id != roleUpdateDto.Id);
			if (roleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(roleUpdateDto, role);
			Result isOk = await _repositoryFactory.CreateRoleDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var role = await _repositoryFactory.CreateRoleDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (role is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			role.Isdelete = true;
			role.Isactive = false;

			return await _repositoryFactory.CreateRoleDal.Update(role) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<RoleDto> GetRoleById(int? roleId)
		{
			if (roleId == null) return new RoleDto();
			var result = await _repositoryFactory.CreateRoleDal.GetAsync(x => x.Id == roleId);
			return Mapper.Map<Role, RoleDto>(result);
		}
	}
}