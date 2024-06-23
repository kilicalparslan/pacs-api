using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.CountyDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class CountyService : AutoMapperService, ICountyService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public CountyService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<CountyDto>> GetList(int? cityId)
        {
            var result = await _repositoryFactory.CreateCountyDal.GetListAsync(r => !r.Isdelete && r.CityId == cityId);
            if (result is null)
            {
                return new List<CountyDto>();
            }
            return Mapper.Map<IList<County>, IList<CountyDto>>(result);
        }

        public async Task<IResult> Create(CountyAddDto countyAddDto)
        {
            var countyControl = await _repositoryFactory.CreateCountyDal.GetAsync(x => x.Name == countyAddDto.Name);
            if (countyControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<CountyAddDto, County>(countyAddDto);
            var result = await _repositoryFactory.CreateCountyDal.Add(mapper);
            return result ?
               new SuccessResult(Message.Added, MessageType.Info) :
               new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(CountyUpdateDto countyUpdateDto)
        {
            var county = await _repositoryFactory.CreateCountyDal.GetAsync(x => x.Id == countyUpdateDto.Id);
            if (county is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var countyControl = await _repositoryFactory.CreateCountyDal.GetAsync(x => x.Name == countyUpdateDto.Name && x.Id != countyUpdateDto.Id);
            if (countyControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(countyUpdateDto, county);
            return await _repositoryFactory.CreateCountyDal.Update(mapper) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Delete(int id)
        {
            var county = await _repositoryFactory.CreateCountyDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (county is null) return new SuccessResult(Message.NotFoundSystem, MessageType.Warning);
            county.Isdelete = true;
            county.Isactive = false;

            return await _repositoryFactory.CreateCountyDal.Update(county) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<CountyDto> GetCountyById(int? countyId)
        {
            if (countyId == null) return new CountyDto();
            var result = await _repositoryFactory.CreateCountyDal.GetAsync(x => x.Id == countyId);
            var mapper = Mapper.Map<County, CountyDto>(result);
            return mapper;
        }
    }
}
