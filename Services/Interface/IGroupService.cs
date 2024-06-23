using ViewLibrary.Pdks.Dtos.Pdks.GroupDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IGroupService
	{
		Task<IResult> Create(GroupAddDto groupAddDto);
		Task<IResult> Delete(int id);
		Task<IList<GroupDto>> GetList();
		Task<GroupDto> GetGroupById(int? groupId);
		Task<IResult> Update(GroupUpdateDto groupUpdateDto);
	}
}
