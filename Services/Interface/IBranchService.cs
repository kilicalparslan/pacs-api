
using ViewLibrary.Pdks.Dtos.Pdks.BranchDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface IBranchService
    {
        Task<IResult> Create(BranchAddDto branchAddDto);
        Task<IResult> Delete(int id);
        Task<BranchDto> GetBranchById(int? branchId);
        Task<IList<BranchDto>> GetList(int companyId);
        Task<IResult> Update(BranchUpdateDto branchUpdateDto);
    }
}
