using ViewLibrary.Pdks.Dtos.Pdks.EmployeeTitleDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IEmployeeTitleService
	{
		Task<IResult> Create(EmployeeTitleAddDto employeeTitleAddDto);
		Task<IResult> Delete(int id);
		Task<IList<EmployeeTitleDto>> GetList();
		Task<EmployeeTitleDto> GetEmployeeTitleById(int? employeeTitleId);
		Task<IResult> Update(EmployeeTitleUpdateDto employeeTitleUpdateDto);
	}
}
