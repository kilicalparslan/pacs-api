using pdksApi.AutoMapper;
using pdksApi.Core.Enums;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLeaveDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class EmployeeLeaveService : AutoMapperService, IEmployeeLeaveService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public EmployeeLeaveService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<EmployeeLeaveDto>> GetList()
		{
			var result = await _repositoryFactory.CreateEmployeeLeaveDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<EmployeeLeaveDto>();
			}
			return Mapper.Map<IList<EmployeeLeave>, IList<EmployeeLeaveDto>>(result);
		}

		public async Task<IResult> Create(EmployeeLeaveAddDto employeeLeaveAddDto)
		{
			var EmployeeLeaveControl = await _repositoryFactory.CreateEmployeeLeaveDal.GetAsync(x => (x.EmployeeId == employeeLeaveAddDto.EmployeeId && x.Statu >= (int)EnumData.Statu.Taslak && x.Statu < (int)EnumData.Statu.Tamamlandi) && x.Id != employeeLeaveAddDto.Id);
			if (EmployeeLeaveControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<EmployeeLeaveAddDto, EmployeeLeave>(employeeLeaveAddDto);
			var result = await _repositoryFactory.CreateEmployeeLeaveDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(EmployeeLeaveUpdateDto employeeLeaveUpdateDto)
		{
			var employeeLeave = await _repositoryFactory.CreateEmployeeLeaveDal.GetAsync(x => x.Id == employeeLeaveUpdateDto.Id);
			if (employeeLeave is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var employeeLeaveControl = await _repositoryFactory.CreateEmployeeLeaveDal.GetAsync(x => (x.EmployeeId == employeeLeaveUpdateDto.EmployeeId && x.Statu >= (int)EnumData.Statu.Taslak && x.Statu < (int)EnumData.Statu.Tamamlandi) && x.Id != employeeLeaveUpdateDto.Id);
			if (employeeLeaveControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(employeeLeaveUpdateDto, employeeLeave);
			Result isOk = await _repositoryFactory.CreateEmployeeLeaveDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var employeeLeave = await _repositoryFactory.CreateEmployeeLeaveDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (employeeLeave is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			employeeLeave.Isdelete = true;
			employeeLeave.Isactive = false;

			return await _repositoryFactory.CreateEmployeeLeaveDal.Update(employeeLeave) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<EmployeeLeaveDto> GetEmployeeLeaveById(int? employeeLeaveId)
		{
			if (employeeLeaveId == null) return new EmployeeLeaveDto();
			var result = await _repositoryFactory.CreateEmployeeLeaveDal.GetAsync(x => x.Id == employeeLeaveId);
			return Mapper.Map<EmployeeLeave, EmployeeLeaveDto>(result);
		}
	}
}