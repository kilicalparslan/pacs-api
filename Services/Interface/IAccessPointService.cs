using ViewLibrary.Pdks.Dtos.Pdks.AccessPointDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
    public interface IAccessPointService
    {
        Task<IResult> Create(AccessPointAddDto  accessPointAddDto);
        Task<IResult> Delete(int id);
        Task<AccessPointDto> GetAccessPointById(int? accessPointId);
        Task<IList<AccessPointDto>> GetList();   
        Task<IResult> Update(AccessPointUpdateDto accessPointUpdateDto);
    }
}
