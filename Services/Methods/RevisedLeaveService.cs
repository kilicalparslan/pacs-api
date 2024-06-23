using pdksApi.AutoMapper;
using pdksApi.Core.Enums;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.RevisedLeaveDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class RevisedLeaveService : AutoMapperService, IRevisedLeaveService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public RevisedLeaveService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<RevisedLeaveDto>> GetList()
		{
			var result = await _repositoryFactory.CreateRevisedLeaveDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<RevisedLeaveDto>();
			}
			return Mapper.Map<IList<RevisedLeave>, IList<RevisedLeaveDto>>(result);
		}

		public async Task<IResult> Create(RevisedLeaveAddDto revisedLeaveAddDto)
		{
			//var RevisedLeaveControl = await _repositoryFactory.CreateRevisedLeaveDal.GetAsync(x => x.Id != RevisedLeaveAddDto.Id);
			//if (RevisedLeaveControl is not null)
			//{
			//	return new ErrorResult(Message.SameRecord, MessageType.Warning);
			//}
			var mapper = Mapper.Map<RevisedLeaveAddDto, RevisedLeave>(revisedLeaveAddDto);
			var result = await _repositoryFactory.CreateRevisedLeaveDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(RevisedLeaveUpdateDto revisedLeaveUpdateDto)
		{
			var revisedLeave = await _repositoryFactory.CreateRevisedLeaveDal.GetAsync(x => x.Id == revisedLeaveUpdateDto.Id);
			if (revisedLeave is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			//var RevisedLeaveControl = await _repositoryFactory.CreateRevisedLeaveDal.GetAsync(x => (x.EmployeeId == RevisedLeaveUpdateDto.EmployeeId && x.Statu >= (int)EnumData.Statu.Taslak && x.Statu < (int)EnumData.Statu.Tamamlandi) && x.Id != RevisedLeaveUpdateDto.Id);
			//if (RevisedLeaveControl is not null)
			//{
			//	return new ErrorResult(Message.SameRecord, MessageType.Warning);
			//}
			var mapper = Mapper.Map(revisedLeaveUpdateDto, revisedLeave);
			Result isOk = await _repositoryFactory.CreateRevisedLeaveDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var revisedLeave = await _repositoryFactory.CreateRevisedLeaveDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (revisedLeave is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			revisedLeave.Isdelete = true;
			revisedLeave.Isactive = false;

			return await _repositoryFactory.CreateRevisedLeaveDal.Update(revisedLeave) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<RevisedLeaveDto> GetRevisedLeaveById(int? revisedLeaveId)
		{
			if (revisedLeaveId == null) return new RevisedLeaveDto();
			var result = await _repositoryFactory.CreateRevisedLeaveDal.GetAsync(x => x.Id == revisedLeaveId);
			return Mapper.Map<RevisedLeave, RevisedLeaveDto>(result);
		}
	}
}