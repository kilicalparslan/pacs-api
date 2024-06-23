using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLanguageDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface IEmployeeLanguageService
	{
		Task<IResult> Create(EmployeeLanguageAddDto employeeLanguageAddDto);
		Task<IResult> Delete(int id);
		Task<IList<EmployeeLanguageDto>> GetList();
		Task<EmployeeLanguageDto> GetEmployeeLanguageById(int? employeeLanguageId);
		Task<IResult> Update(EmployeeLanguageUpdateDto employeeLanguageUpdateDto);
	}
}
