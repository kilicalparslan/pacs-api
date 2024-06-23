using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.UserDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class UserService : AutoMapperService, IUserService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public UserService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<UserDto>> GetList()
		{
			var result = await _repositoryFactory.CreateUserDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<UserDto>();
			}
			return Mapper.Map<IList<User>, IList<UserDto>>(result);
		}

		public async Task<IResult> Create(UserAddDto userAddDto)
		{
			var userControl = await _repositoryFactory.CreateUserDal.GetAsync(x => x.Username.Equals(userAddDto.Username) && x.EmployeeId.Equals(userAddDto.EmployeeId));
			if (userControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<UserAddDto, User>(userAddDto);
			var result = await _repositoryFactory.CreateUserDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(UserUpdateDto userUpdateDto)
		{
			var user = await _repositoryFactory.CreateUserDal.GetAsync(x => x.Id == userUpdateDto.Id);
			if (user is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var userControl = await _repositoryFactory.CreateUserDal.GetAsync(x => (x.Username == userUpdateDto.Username && x.EmployeeId.Equals(userUpdateDto.EmployeeId)) && x.Id != userUpdateDto.Id);
			if (userControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(userUpdateDto, user);
			Result isOk = await _repositoryFactory.CreateUserDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var User = await _repositoryFactory.CreateUserDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (User is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			User.Isdelete = true;
			User.Isactive = false;

			return await _repositoryFactory.CreateUserDal.Update(User) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<UserDto> GetUserById(int? userId)
		{
			if (userId == null) return new UserDto();
			var result = await _repositoryFactory.CreateUserDal.GetAsync(x => x.Id == userId);
			return Mapper.Map<User, UserDto>(result);
		}
		public async Task<UserDto> GetUserByEmployeeId(int? employeeId)
		{
			if (employeeId == null) return new UserDto();
			var result = await _repositoryFactory.CreateUserDal.GetAsync(x => x.EmployeeId == employeeId);
			return Mapper.Map<User, UserDto>(result);
		}
	}
}