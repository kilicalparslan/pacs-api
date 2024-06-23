using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.SizeDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class SizeService : AutoMapperService, ISizeService
	{
		private readonly IRepositoryFactory _repositoryFactory;
		public SizeService(IRepositoryFactory repositoryFactory)
		{
			_repositoryFactory = repositoryFactory;
		}

		public async Task<IList<SizeDto>> GetList()
		{
			var result = await _repositoryFactory.CreateSizeDal.GetListAsync(r => r.Isactive && !r.Isdelete);

			if (result is null)
			{
				return new List<SizeDto>();
			}
			return Mapper.Map<IList<Size>, IList<SizeDto>>(result);
		}

		public async Task<IResult> Create(SizeAddDto sizeAddDto)
		{
			var sizeControl = await _repositoryFactory.CreateSizeDal.GetAsync(x => x.Name.Equals(sizeAddDto.Name));
			if (sizeControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map<SizeAddDto, Size>(sizeAddDto);
			var result = await _repositoryFactory.CreateSizeDal.Add(mapper);
			return result ?
				new SuccessResult(Message.Added, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<IResult> Update(SizeUpdateDto sizeUpdateDto)
		{
			var size = await _repositoryFactory.CreateSizeDal.GetAsync(x => x.Id == sizeUpdateDto.Id);
			if (size is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			var sizeControl = await _repositoryFactory.CreateSizeDal.GetAsync(x => x.Name == sizeUpdateDto.Name && x.Id != sizeUpdateDto.Id);
			if (sizeControl is not null)
			{
				return new ErrorResult(Message.SameRecord, MessageType.Warning);
			}
			var mapper = Mapper.Map(sizeUpdateDto, size);
			Result isOk = await _repositoryFactory.CreateSizeDal.Update(mapper) ?
				new SuccessResult(Message.Updated, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
			return isOk;
		}
		public async Task<IResult> Delete(int id)
		{
			var size = await _repositoryFactory.CreateSizeDal.GetAsync(x => x.Id == id && !x.Isdelete);
			if (size is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
			size.Isdelete = true;
			size.Isactive = false;

			return await _repositoryFactory.CreateSizeDal.Update(size) ?
				new SuccessResult(Message.Deleted, MessageType.Info) :
				new ErrorResult(Message.Error, MessageType.Error);
		}
		public async Task<SizeDto> GetSizeById(int? sizeId)
		{
			if (sizeId == null) return new SizeDto();
			var result = await _repositoryFactory.CreateSizeDal.GetAsync(x => x.Id == sizeId);
			return Mapper.Map<Size, SizeDto>(result);
		}
	}
}