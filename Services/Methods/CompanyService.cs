using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.CompanyDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class CompanyService : AutoMapperService, ICompanyService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public CompanyService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<CompanyDto>> GetList()
        {
            var result = await _repositoryFactory.CreateCompanyDal.GetListAsync(r => r.Isactive && !r.Isdelete);
            
            if (result is null)
            {
                return new List<CompanyDto>();
            }
            return Mapper.Map<IList<Company>, IList<CompanyDto>>(result);
        }

        public async Task<IResult> Create(CompanyAddDto companyAddDto)
        {
            var companyControl = await _repositoryFactory.CreateCompanyDal.GetAsync(x => x.Name.Equals(companyAddDto.Name));
            if (companyControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<CompanyAddDto, Company>(companyAddDto);
            var result = await _repositoryFactory.CreateCompanyDal.Add(mapper);
            return result ?
                new SuccessResult(Message.Added, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(CompanyUpdateDto companyUpdateDto)
        {
            var company = await _repositoryFactory.CreateCompanyDal.GetAsync(x => x.Id == companyUpdateDto.Id);
            if (company is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var companyControl = await _repositoryFactory.CreateCompanyDal.GetAsync(x => x.Name == companyUpdateDto.Name && x.Id != companyUpdateDto.Id);
            if (companyControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(companyUpdateDto, company);
            Result isOk = await _repositoryFactory.CreateCompanyDal.Update(mapper) ?
                new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
            return isOk;
        }
        public async Task<IResult> Delete(int id)
        {
            var Company = await _repositoryFactory.CreateCompanyDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (Company is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            Company.Isdelete = true;
            Company.Isactive = false;

            return await _repositoryFactory.CreateCompanyDal.Update(Company) ?
                new SuccessResult(Message.Deleted, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<CompanyDto> GetCompanyById(int? CompanyId)
        {
            if (CompanyId == null) return new CompanyDto();
            var result = await _repositoryFactory.CreateCompanyDal.GetAsync(x => x.Id == CompanyId);
            return Mapper.Map<Company, CompanyDto>(result);
        }
    }
}
