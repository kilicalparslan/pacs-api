using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.LanguageDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class LanguageService : AutoMapperService, ILanguageService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public LanguageService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<LanguageDto>> GetList()
		{
			var result = await _repositoryFactory.CreateLanguageDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<LanguageDto>();
			}
			return Mapper.Map<IList<Language>, IList<LanguageDto>>(result);
		}

		public async Task<IResult> Create(LanguageAddDto languageAddDto)
		{
			var languageControl = await _repositoryFactory.CreateLanguageDal.GetAsync(x => x.Name.Equals(languageAddDto.Name));
			if (languageControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<LanguageAddDto, Language>(languageAddDto);
			var result = await _repositoryFactory.CreateLanguageDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(LanguageUpdateDto languageUpdateDto)
		{
			var language = await _repositoryFactory.CreateLanguageDal.GetAsync(x => x.Id == languageUpdateDto.Id);
			if (language is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var languageControl = await _repositoryFactory.CreateLanguageDal.GetAsync(x => x.Name == languageUpdateDto.Name && x.Id != languageUpdateDto.Id);
			if (languageControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(languageUpdateDto, language);
			Result isOk = await _repositoryFactory.CreateLanguageDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var language = await _repositoryFactory.CreateLanguageDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (language is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			language.Isdelete = true;
			language.Isactive = false;

			return await _repositoryFactory.CreateLanguageDal.Update(language) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<LanguageDto> GetLanguageById(int? languageId)
		{
			if (languageId == null) return new LanguageDto();
			var result = await _repositoryFactory.CreateLanguageDal.GetAsync(x => x.Id == languageId);
			return Mapper.Map<Language, LanguageDto>(result);
		}
	}
}