using Microsoft.EntityFrameworkCore;
using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class EmployeeService : AutoMapperService, IEmployeeService
	{
		private readonly IRepositoryFactory _repositoryFactory;

		public EmployeeService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<EmployeeDto>> GetList()
		{
			var result = await _repositoryFactory.CreateEmployeeDal.GetIncludable(w=>w.Isactive, 
				t=>t.Include(r=>r.Branch).
				ThenInclude(r=>r.Company).
				Include(y=>y.Users)).
				ToListAsync();
			return Mapper.Map<IList<Employee>, IList<EmployeeDto>>(result);
		}

		public async Task<IResult> Create(EmployeeAddDto employeeAddDto)
		{
			var EmployeeControl = await _repositoryFactory.CreateEmployeeDal.GetAsync(x => x.Name == employeeAddDto.Name);
			if (EmployeeControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<EmployeeAddDto, Employee>(employeeAddDto);
			var result = await _repositoryFactory.CreateEmployeeDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto)
		{
			var employee = await _repositoryFactory.CreateEmployeeDal.GetAsync(x => x.Id == employeeUpdateDto.Id);
			if (employee is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var EmployeeControl = await _repositoryFactory.CreateEmployeeDal.GetAsync(x => x.Name == employeeUpdateDto.Name && x.Id != employeeUpdateDto.Id);
			if (EmployeeControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(employeeUpdateDto, employee);
			return await _repositoryFactory.CreateEmployeeDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Delete(int id)
		{
			var employee = await _repositoryFactory.CreateEmployeeDal.GetAsync(x => x.Id == id);
			if (employee is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			employee.Isdelete = true;
			employee.Isactive = false;

			return await _repositoryFactory.CreateEmployeeDal.Update(employee) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<EmployeeDto> GetEmployeeById(int? employeeId)
		{
			var result = await _repositoryFactory.CreateEmployeeDal.GetIncludable(x => x.Id == employeeId,
				y => y.Include(w => w.Branch).
				ThenInclude(e => e.Company).
				Include(f=>f.EmployeeTitles).
				ThenInclude(f=>f.Title).
				Include(w => w.Users).
				Include(w => w.Counties).
				ThenInclude(w => w.City).
				ThenInclude(w => w.Country)).
				FirstOrDefaultAsync();
			return Mapper.Map<Employee, EmployeeDto>(result);
		}
	}
}
