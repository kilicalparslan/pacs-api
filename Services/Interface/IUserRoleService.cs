using ViewLibrary.Pdks.Dtos.Pdks.UserRoleDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IUserRoleService
	{
		Task<IResult> Create(UserRoleAddDto userRoleAddDto);
		Task<IResult> Delete(int id);
		Task<IList<UserRoleDto>> GetList(int userId);
		Task<UserRoleDto> GetUserRoleById(int? userRoleId);
		Task<IResult> Update(UserRoleUpdateDto userRoleUpdateDto);
	}
}
