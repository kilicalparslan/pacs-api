using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLanguageDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class EmployeeLanguageService : AutoMapperService, IEmployeeLanguageService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public EmployeeLanguageService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<EmployeeLanguageDto>> GetList()
		{
			var result = await _repositoryFactory.CreateEmployeeLanguageDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<EmployeeLanguageDto>();
			}
			return Mapper.Map<IList<EmployeeLanguage>, IList<EmployeeLanguageDto>>(result);
		}

		public async Task<IResult> Create(EmployeeLanguageAddDto employeeLanguageAddDto)
		{
			var employeeLanguageControl = await _repositoryFactory.CreateEmployeeLanguageDal.GetAsync(x => x.LanguageId.Equals(employeeLanguageAddDto.LanguageId) && x.EmployeeId.Equals(employeeLanguageAddDto.EmployeeId));
			if (employeeLanguageControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<EmployeeLanguageAddDto, EmployeeLanguage>(employeeLanguageAddDto);
			var result = await _repositoryFactory.CreateEmployeeLanguageDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(EmployeeLanguageUpdateDto employeeLanguageUpdateDto)
		{
			var employeeLanguage = await _repositoryFactory.CreateEmployeeLanguageDal.GetAsync(x => x.Id == employeeLanguageUpdateDto.Id);
			if (employeeLanguage is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var employeeLanguageControl = await _repositoryFactory.CreateEmployeeLanguageDal.GetAsync(x => (x.LanguageId.Equals(employeeLanguageUpdateDto.LanguageId) && x.EmployeeId.Equals(employeeLanguageUpdateDto.EmployeeId)) && x.Id != employeeLanguageUpdateDto.Id);
			if (employeeLanguageControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(employeeLanguageUpdateDto, employeeLanguage);
			Result isOk = await _repositoryFactory.CreateEmployeeLanguageDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var employeeLanguage = await _repositoryFactory.CreateEmployeeLanguageDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (employeeLanguage is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			employeeLanguage.Isdelete = true;
			employeeLanguage.Isactive = false;

			return await _repositoryFactory.CreateEmployeeLanguageDal.Update(employeeLanguage) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<EmployeeLanguageDto> GetEmployeeLanguageById(int? employeeLanguageId)
		{
			if (employeeLanguageId == null) return new EmployeeLanguageDto();
			var result = await _repositoryFactory.CreateEmployeeLanguageDal.GetAsync(x => x.Id == employeeLanguageId);
			return Mapper.Map<EmployeeLanguage, EmployeeLanguageDto>(result);
		}
	}
}