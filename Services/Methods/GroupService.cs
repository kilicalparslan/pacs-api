using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.GroupDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class GroupService : AutoMapperService, IGroupService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public GroupService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<GroupDto>> GetList()
		{
			var result = await _repositoryFactory.CreateGroupDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<GroupDto>();
			}
			return Mapper.Map<IList<Group>, IList<GroupDto>>(result);
		}

		public async Task<IResult> Create(GroupAddDto groupAddDto)
		{
			var groupControl = await _repositoryFactory.CreateGroupDal.GetAsync(x => x.Name.Equals(groupAddDto.Name));
			if (groupControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<GroupAddDto, Group>(groupAddDto);
			var result = await _repositoryFactory.CreateGroupDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(GroupUpdateDto groupUpdateDto)
		{
			var group = await _repositoryFactory.CreateGroupDal.GetAsync(x => x.Id == groupUpdateDto.Id);
			if (group is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var groupControl = await _repositoryFactory.CreateGroupDal.GetAsync(x => x.Name == groupUpdateDto.Name && x.Id != groupUpdateDto.Id);
			if (groupControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(groupUpdateDto, group);
			Result isOk = await _repositoryFactory.CreateGroupDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var group = await _repositoryFactory.CreateGroupDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (group is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			group.Isdelete = true;
			group.Isactive = false;

			return await _repositoryFactory.CreateGroupDal.Update(group) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<GroupDto> GetGroupById(int? groupId)
		{
			if (groupId == null) return new GroupDto();
			var result = await _repositoryFactory.CreateGroupDal.GetAsync(x => x.Id == groupId);
			return Mapper.Map<Group, GroupDto>(result);
		}
	}
}