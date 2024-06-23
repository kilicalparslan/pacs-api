using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeTitleDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class EmployeeTitleService : AutoMapperService, IEmployeeTitleService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public EmployeeTitleService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<EmployeeTitleDto>> GetList()
		{
			var result = await _repositoryFactory.CreateEmployeeTitleDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<EmployeeTitleDto>();
			}
			return Mapper.Map<IList<EmployeeTitle>, IList<EmployeeTitleDto>>(result);
		}

		public async Task<IResult> Create(EmployeeTitleAddDto employeeTitleAddDto)
		{
			var employeeTitleControl = await _repositoryFactory.CreateEmployeeTitleDal.GetAsync(x => x.EmployeeId.Equals(employeeTitleAddDto.EmployeeId) && x.TitleId.Equals(employeeTitleAddDto.TitleId));
			if (employeeTitleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<EmployeeTitleAddDto, EmployeeTitle>(employeeTitleAddDto);
			var result = await _repositoryFactory.CreateEmployeeTitleDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(EmployeeTitleUpdateDto employeeTitleUpdateDto)
		{
			var employeeTitle = await _repositoryFactory.CreateEmployeeTitleDal.GetAsync(x => x.Id == employeeTitleUpdateDto.Id);
			if (employeeTitle is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var employeeTitleControl = await _repositoryFactory.CreateEmployeeTitleDal.GetAsync(x => (x.EmployeeId.Equals(employeeTitleUpdateDto.EmployeeId) && x.TitleId.Equals(employeeTitleUpdateDto.TitleId)) && x.Id != employeeTitleUpdateDto.Id);
			if (employeeTitleControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(employeeTitleUpdateDto, employeeTitle);
			Result isOk = await _repositoryFactory.CreateEmployeeTitleDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var employeeTitle = await _repositoryFactory.CreateEmployeeTitleDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (employeeTitle is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			employeeTitle.Isdelete = true;
			employeeTitle.Isactive = false;

			return await _repositoryFactory.CreateEmployeeTitleDal.Update(employeeTitle) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<EmployeeTitleDto> GetEmployeeTitleById(int? employeeTitleId)
		{
			if (employeeTitleId == null) return new EmployeeTitleDto();
			var result = await _repositoryFactory.CreateEmployeeTitleDal.GetAsync(x => x.Id == employeeTitleId);
			return Mapper.Map<EmployeeTitle, EmployeeTitleDto>(result);
		}
	}
}