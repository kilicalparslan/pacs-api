using ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IEmployeeService
    {
        Task<IResult> Create(EmployeeAddDto employeeAddDto);
        Task<IResult> Delete(int id);
		Task<EmployeeDto> GetEmployeeById(int? employeeId);
		Task<IList<EmployeeDto>> GetList();
		Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto);
    }
}
