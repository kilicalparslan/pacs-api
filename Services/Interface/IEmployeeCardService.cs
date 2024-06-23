
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeCardDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface IEmployeeCardService
    {
        Task<IResult> Create(EmployeeCardAddDto employeeCardAddDto);
        Task<IResult> Delete(int id);
        Task<EmployeeCardDto> GetEmployeeCardById(int? employeeCardId);
        Task<IList<EmployeeCardDto>> GetList();
        Task<IResult> Update(EmployeeCardUpdateDto employeeCardUpdateDto);
    }
}
