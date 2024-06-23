using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLeaveDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IEmployeeLeaveService
	{
		Task<IResult> Create(EmployeeLeaveAddDto employeeLeaveAddDto);
		Task<IResult> Delete(int id);
		Task<IList<EmployeeLeaveDto>> GetList();
		Task<EmployeeLeaveDto> GetEmployeeLeaveById(int? employeeLeaveId);
		Task<IResult> Update(EmployeeLeaveUpdateDto employeeLeaveUpdateDto);
	}
}
