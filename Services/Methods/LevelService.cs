using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.LevelDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class LevelService : AutoMapperService, ILevelService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public LevelService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<LevelDto>> GetList()
		{
			var result = await _repositoryFactory.CreateLevelDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<LevelDto>();
			}
			return Mapper.Map<IList<Level>, IList<LevelDto>>(result);
		}

		public async Task<IResult> Create(LevelAddDto levelAddDto)
		{
			var LevelControl = await _repositoryFactory.CreateLevelDal.GetAsync(x => x.GroupId.Equals(levelAddDto.GroupId) && x.Name.Equals(levelAddDto.Name));
			if (LevelControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<LevelAddDto, Level>(levelAddDto);
			var result = await _repositoryFactory.CreateLevelDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(LevelUpdateDto levelUpdateDto)
		{
			var level = await _repositoryFactory.CreateLevelDal.GetAsync(x => x.Id == levelUpdateDto.Id);
			if (level is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var levelControl = await _repositoryFactory.CreateLevelDal.GetAsync(x => (x.GroupId.Equals(levelUpdateDto.GroupId) && x.Name.Equals(levelUpdateDto.Name)) && x.Id != levelUpdateDto.Id);
			if (levelControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(levelUpdateDto, level);
			Result isOk = await _repositoryFactory.CreateLevelDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var level = await _repositoryFactory.CreateLevelDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (level is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			level.Isdelete = true;
			level.Isactive = false;

			return await _repositoryFactory.CreateLevelDal.Update(level) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<LevelDto> GetLevelById(int? levelId)
		{
			if (levelId == null) return new LevelDto();
			var result = await _repositoryFactory.CreateLevelDal.GetAsync(x => x.Id == levelId);
			return Mapper.Map<Level, LevelDto>(result);
		}
	}
}