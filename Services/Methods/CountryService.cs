using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.CountryDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class CountryService : AutoMapperService, ICountryService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public CountryService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<CountryDto>> GetList()
        {
            var result = await _repositoryFactory.CreateCountryDal.GetListAsync(r => !r.Isdelete);
            if (result is null)
            {
                return new List<CountryDto>();
            }
            return Mapper.Map<IList<Country>, IList<CountryDto>>(result);
        }

        public async Task<IResult> Create(CountryAddDto CountryAddDto)
        {
            var CountryControl = await _repositoryFactory.CreateCountryDal.GetAsync(x => x.Name == CountryAddDto.Name);
            if (CountryControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<CountryAddDto, Country>(CountryAddDto);
            var result = await _repositoryFactory.CreateCountryDal.Add(mapper);
            return result ?
               new SuccessResult(Message.Added, MessageType.Info) :
               new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(CountryUpdateDto countryUpdateDto)
        {
            var country = await _repositoryFactory.CreateCountryDal.GetAsync(x => x.Id == countryUpdateDto.Id);
            if (country is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var countryControl = await _repositoryFactory.CreateCountryDal.GetAsync(x => x.Name == countryUpdateDto.Name && x.Id != countryUpdateDto.Id);
            if (countryControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(countryUpdateDto, country);
            return await _repositoryFactory.CreateCountryDal.Update(mapper) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Delete(int id)
        {
            var country = await _repositoryFactory.CreateCountryDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (country is null) return new SuccessResult(Message.NotFoundSystem, MessageType.Warning);
            country.Isdelete = true;
            country.Isactive = false;

            return await _repositoryFactory.CreateCountryDal.Update(country) ?
                 new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<CountryDto> GetCountryById(int? countryId)
        {
            if (countryId == null) return new CountryDto();
            var result = await _repositoryFactory.CreateCountryDal.GetAsync(x => x.Id == countryId);
            var mapper = Mapper.Map<Country, CountryDto>(result);
            return mapper;
        }
    }
}
