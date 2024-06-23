using ViewLibrary.Pdks.Dtos.Pdks.CardDtos;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Interface
{
	public interface ICardService
    {
        Task<IResult> Create(CardAddDto cardAddDto);
        Task<IResult> Delete(int id, bool? cancelled);
        Task<CardDto> GetCardById(int? cardId);
        Task<IList<CardDto>> GetList(CardActiveDeleteDto value);
        Task<IResult> Update(CardUpdateDto cardUpdateDto);
    }
}
