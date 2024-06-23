using ViewLibrary.Pdks.Dtos.Pdks.EmployeeReferanceDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IEmployeeReferanceService
	{
		Task<IResult> Create(EmployeeReferanceAddDto employeeReferanceAddDto);
		Task<IResult> Delete(int id);
		Task<IList<EmployeeReferanceDto>> GetList();
		Task<EmployeeReferanceDto> GetEmployeeReferanceById(int? employeeReferanceId);
		Task<IResult> Update(EmployeeReferanceUpdateDto employeeReferanceUpdateDto);
	}
}
