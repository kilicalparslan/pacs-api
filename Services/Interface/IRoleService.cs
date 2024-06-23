using ViewLibrary.Pdks.Dtos.Pdks.RoleDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IRoleService
	{
		Task<IResult> Create(RoleAddDto roleAddDto);
		Task<IResult> Delete(int id);
		Task<IList<RoleDto>> GetList();
		Task<RoleDto> GetRoleById(int? roleId);
		Task<IResult> Update(RoleUpdateDto roleUpdateDto);
	}
}
