
using ViewLibrary.Pdks.Dtos.Pdks.CompanyDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface ICompanyService
    {
        Task<IResult> Create(CompanyAddDto companyAddDto);
        Task<IResult> Delete(int id);
        Task<CompanyDto> GetCompanyById(int? companyId);
        Task<IList<CompanyDto>> GetList();
        Task<IResult> Update(CompanyUpdateDto companyUpdateDto);
    }
}
