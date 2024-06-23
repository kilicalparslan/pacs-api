using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.AccessPointDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class AccessPointService : AutoMapperService, IAccessPointService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public AccessPointService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<AccessPointDto>> GetList()
        {

            var result = await _repositoryFactory.CreateAccessPointDal.GetListAsync(r => r.Isactive && !r.Isdelete);
            if (result is null)
            {
                return new List<AccessPointDto>();
            }
            return Mapper.Map<IList<AccessPoint>, IList<AccessPointDto>>(result);
        }        

        public async Task<IResult> Create(AccessPointAddDto accessPointAddDto)
        {
            var accessPointControl = await _repositoryFactory.CreateAccessPointDal.GetAsync(x => x.Name == accessPointAddDto.Name && x.LevelId.Equals(accessPointAddDto.LevelId));
            if (accessPointControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<AccessPointAddDto, AccessPoint>(accessPointAddDto);
            var result = await _repositoryFactory.CreateAccessPointDal.Add(mapper);
            return result ?
                new SuccessResult(Message.Added, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(AccessPointUpdateDto accessPointUpdateDto)
        {
            var accessPoint = await _repositoryFactory.CreateAccessPointDal.GetAsync(x => x.Id == accessPointUpdateDto.Id);
            if (accessPoint is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var accessPointControl = await _repositoryFactory.CreateAccessPointDal.GetAsync(x => (x.Name == accessPointUpdateDto.Name && x.LevelId.Equals(accessPointUpdateDto.LevelId) && x.Id != accessPointUpdateDto.Id));
            if (accessPointControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(accessPointUpdateDto, accessPoint);
            Result isOk = await _repositoryFactory.CreateAccessPointDal.Update(mapper) ?
                new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
            return isOk;
        }
        public async Task<IResult> Delete(int id)
        {
            var accessPoint = await _repositoryFactory.CreateAccessPointDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (accessPoint is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            accessPoint.Isdelete = true;
            accessPoint.Isactive = false;

            return await _repositoryFactory.CreateAccessPointDal.Update(accessPoint) ?
                new SuccessResult(Message.Deleted, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<AccessPointDto> GetAccessPointById(int? accessPointId)
        {
            if (accessPointId == null) return new AccessPointDto();
            var result = await _repositoryFactory.CreateAccessPointDal.GetAsync(x => x.Id == accessPointId);
            return Mapper.Map<AccessPoint, AccessPointDto>(result);
        }
    }
}
