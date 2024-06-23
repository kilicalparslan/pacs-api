using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.CityDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
	public class CityService : AutoMapperService, ICityService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public CityService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<CityDto>> GetList(int? countryId)
        {
            var result = await _repositoryFactory.CreateCityDal.GetListAsync(r => !r.Isdelete && r.CountryId == countryId);
            if (result == null)
            {
                result = await _repositoryFactory.CreateCityDal.GetListAsync(r => !r.Isdelete);
			}
            if (result is null)
            {
                return new List<CityDto>();
            }
            return Mapper.Map<IList<City>, IList<CityDto>>(result);
        }

        public async Task<IResult> Create(CityAddDto cityAddDto)
        {
            var cityControl = await _repositoryFactory.CreateCityDal.GetAsync(x => x.Name == cityAddDto.Name);
            if (cityControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<CityAddDto, City>(cityAddDto);
            var result = await _repositoryFactory.CreateCityDal.Add(mapper);
            return result ?
               new SuccessResult(Message.Added, MessageType.Info) :
               new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(CityUpdateDto cityUpdateDto)
        {
            var city = await _repositoryFactory.CreateCityDal.GetAsync(x => x.Id == cityUpdateDto.Id);
            if (city is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);

            var mapper = Mapper.Map(cityUpdateDto, city);
            return await _repositoryFactory.CreateCityDal.Update(mapper) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Delete(int id)
        {
            var city = await _repositoryFactory.CreateCityDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (city is null) return new SuccessResult(Message.NotFoundSystem, MessageType.Warning);
            city.Isdelete = true;
            city.Isactive = false;

            return await _repositoryFactory.CreateCityDal.Update(city) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<CityDto> GetCityById(int? cityId)
        {
            if (cityId == null) return new CityDto();
            var result = await _repositoryFactory.CreateCityDal.GetAsync(x => x.Id == cityId);
            var mapper = Mapper.Map<City, CityDto>(result);
            return mapper;
        }
    }
}
