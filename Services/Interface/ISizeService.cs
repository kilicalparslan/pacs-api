using ViewLibrary.Pdks.Dtos.Pdks.SizeDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ISizeService
	{
		Task<IResult> Create(SizeAddDto sizeAddDto);
		Task<IResult> Delete(int id);
		Task<IList<SizeDto>> GetList();
		Task<SizeDto> GetSizeById(int? sizeId);
		Task<IResult> Update(SizeUpdateDto sizeUpdateDto);
	}
}
