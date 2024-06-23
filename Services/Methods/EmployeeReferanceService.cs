using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeReferanceDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class EmployeeReferanceService : AutoMapperService, IEmployeeReferanceService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public EmployeeReferanceService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<EmployeeReferanceDto>> GetList()
		{
			var result = await _repositoryFactory.CreateEmployeeReferanceDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<EmployeeReferanceDto>();
			}
			return Mapper.Map<IList<EmployeeReferance>, IList<EmployeeReferanceDto>>(result);
		}

		public async Task<IResult> Create(EmployeeReferanceAddDto employeeReferanceAddDto)
		{
			var EmployeeReferanceControl = await _repositoryFactory.CreateEmployeeReferanceDal.GetAsync(x => x.Name.Equals(employeeReferanceAddDto.Name));
			if (EmployeeReferanceControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<EmployeeReferanceAddDto, EmployeeReferance>(employeeReferanceAddDto);
			var result = await _repositoryFactory.CreateEmployeeReferanceDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(EmployeeReferanceUpdateDto employeeReferanceUpdateDto)
		{
			var employeeReferance = await _repositoryFactory.CreateEmployeeReferanceDal.GetAsync(x => x.Id == employeeReferanceUpdateDto.Id);
			if (employeeReferance is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var employeeReferanceControl = await _repositoryFactory.CreateEmployeeReferanceDal.GetAsync(x => x.Name == employeeReferanceUpdateDto.Name && x.Id != employeeReferanceUpdateDto.Id);
			if (employeeReferanceControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(employeeReferanceUpdateDto, employeeReferance);
			Result isOk = await _repositoryFactory.CreateEmployeeReferanceDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var employeeReferance = await _repositoryFactory.CreateEmployeeReferanceDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (employeeReferance is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			employeeReferance.Isdelete = true;
			employeeReferance.Isactive = false;

			return await _repositoryFactory.CreateEmployeeReferanceDal.Update(employeeReferance) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<EmployeeReferanceDto> GetEmployeeReferanceById(int? employeeReferanceId)
		{
			if (employeeReferanceId == null) return new EmployeeReferanceDto();
			var result = await _repositoryFactory.CreateEmployeeReferanceDal.GetAsync(x => x.Id == employeeReferanceId);
			return Mapper.Map<EmployeeReferance, EmployeeReferanceDto>(result);
		}
	}
}