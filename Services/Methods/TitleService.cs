using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.TitleDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class TitleService : AutoMapperService, ITitleService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public TitleService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<TitleDto>> GetList()
		{
			var result = await _repositoryFactory.CreateTitleDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<TitleDto>();
			}
			return Mapper.Map<IList<Title>, IList<TitleDto>>(result);
		}

		public async Task<IResult> Create(TitleAddDto titleAddDto)
		{
			var titleControl = await _repositoryFactory.CreateTitleDal.GetAsync(x => x.Name.Equals(titleAddDto.Name));
			if (titleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<TitleAddDto, Title>(titleAddDto);
			var result = await _repositoryFactory.CreateTitleDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(TitleUpdateDto titleUpdateDto)
		{
			var title = await _repositoryFactory.CreateTitleDal.GetAsync(x => x.Id == titleUpdateDto.Id);
			if (title is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var titleControl = await _repositoryFactory.CreateTitleDal.GetAsync(x => x.Name == titleUpdateDto.Name && x.Id != titleUpdateDto.Id);
			if (titleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(titleUpdateDto, title);
			Result isOk = await _repositoryFactory.CreateTitleDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var title = await _repositoryFactory.CreateTitleDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (title is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			title.Isdelete = true;
			title.Isactive = false;

			return await _repositoryFactory.CreateTitleDal.Update(title) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<TitleDto> GetTitleById(int? titleId)
		{
			if (titleId == null) return new TitleDto();
			var result = await _repositoryFactory.CreateTitleDal.GetAsync(x => x.Id == titleId);
			return Mapper.Map<Title, TitleDto>(result);
		}
	}
}