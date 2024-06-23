using ViewLibrary.Pdks.Dtos.Pdks.RevisedLeaveDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IRevisedLeaveService
	{
		Task<IResult> Create(RevisedLeaveAddDto revisedLeaveAddDto);
		Task<IResult> Delete(int id);
		Task<IList<RevisedLeaveDto>> GetList();
		Task<RevisedLeaveDto> GetRevisedLeaveById(int? revisedLeaveId);
		Task<IResult> Update(RevisedLeaveUpdateDto revisedLeaveUpdateDto);
	}
}
