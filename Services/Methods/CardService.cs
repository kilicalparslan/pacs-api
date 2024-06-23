using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.CardDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class CardService : AutoMapperService, ICardService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public CardService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<CardDto>> GetList(CardActiveDeleteDto value)
        {
            var result = await _repositoryFactory.CreateCardDal.GetListAsync(r => r.Isactive==value.Isactive && r.Isdelete==value.Isdelete && r.Cancelled != true);
            
            if (result is null)
            {
                return new List<CardDto>();
            }
            return Mapper.Map<IList<Card>, IList<CardDto>>(result);
        }

        public async Task<IResult> Create(CardAddDto cardAddDto)
        {
            var cardControl = await _repositoryFactory.CreateCardDal.GetAsync(x => x.Name.Equals(cardAddDto.Name));
            if (cardControl is not null)
            {
                if (cardControl.Cancelled == true)
                {
					return new ErrorResult(Message.CancelledCard, MessageType.Error);
				}
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<CardAddDto, Card>(cardAddDto);
            var result = await _repositoryFactory.CreateCardDal.Add(mapper);
            return result ?
                new SuccessResult(Message.Added, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(CardUpdateDto cardUpdateDto)
        {
            var card = await _repositoryFactory.CreateCardDal.GetAsync(x => x.Id == cardUpdateDto.Id);
            if (card is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var cardControl = await _repositoryFactory.CreateCardDal.GetAsync(x => x.Name == cardUpdateDto.Name && x.Id != cardUpdateDto.Id);
            if (cardControl is not null)
            {
				if (cardControl.Cancelled == true)
				{
					return new ErrorResult(Message.CancelledCard, MessageType.Error);
				}
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(cardUpdateDto, card);
            Result isOk = await _repositoryFactory.CreateCardDal.Update(mapper) ?
                new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
            return isOk;
        }
        public async Task<IResult> Delete(int id, bool? cancelled)
        {
            var card = await _repositoryFactory.CreateCardDal.GetAsync(x => x.Id == id);
            if (card is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            card.Isdelete = true;
            card.Isactive = false;
            if (cancelled.HasValue)
            {
                card.Cancelled = true;
                card.Cancelleddate = DateTime.Now;
            }

            return await _repositoryFactory.CreateCardDal.Update(card) ?
                new SuccessResult(Message.Deleted, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<CardDto> GetCardById(int? cardId)
        {
            if (cardId == null) return new CardDto();
            var result = await _repositoryFactory.CreateCardDal.GetAsync(x => x.Id == cardId && x.Cancelled != true);
            return Mapper.Map<Card, CardDto>(result);
        }
    }
}
