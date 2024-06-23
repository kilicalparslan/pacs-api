using ViewLibrary.Pdks.Dtos.Pdks.UserDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IUserService
	{
		Task<IResult> Create(UserAddDto userAddDto);
		Task<IResult> Delete(int id);
		Task<IList<UserDto>> GetList();
		Task<UserDto> GetUserByEmployeeId(int? employeeId);
		Task<UserDto> GetUserById(int? userId);
		Task<IResult> Update(UserUpdateDto userUpdateDto);
	}
}
