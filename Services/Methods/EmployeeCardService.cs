using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeCardDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class EmployeeCardService : AutoMapperService, IEmployeeCardService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public EmployeeCardService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<EmployeeCardDto>> GetList()
        {
            var result = await _repositoryFactory.CreateEmployeeCardDal.GetListAsync(r => r.Isactive && !r.Isdelete);
            
            if (result is null)
            {
                return new List<EmployeeCardDto>();
            }
            return Mapper.Map<IList<EmployeeCard>, IList<EmployeeCardDto>>(result);
        }

        public async Task<IResult> Create(EmployeeCardAddDto employeeCardAddDto)
        {
            var employeeCardControl = await _repositoryFactory.CreateEmployeeCardDal.GetAsync(x => x.EmployeeId.Equals(employeeCardAddDto.EmployeeId) && x.CardId.Equals(employeeCardAddDto.CardId));
            if (employeeCardControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<EmployeeCardAddDto, EmployeeCard>(employeeCardAddDto);
            var result = await _repositoryFactory.CreateEmployeeCardDal.Add(mapper);
            return result ?
                new SuccessResult(Message.Added, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(EmployeeCardUpdateDto employeeCardUpdateDto)
        {
            var employeeCard = await _repositoryFactory.CreateEmployeeCardDal.GetAsync(x => x.Id == employeeCardUpdateDto.Id);
            if (employeeCard is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var employeeCardControl = await _repositoryFactory.CreateEmployeeCardDal.GetAsync(x => (x.EmployeeId.Equals(employeeCardUpdateDto.EmployeeId) && x.CardId.Equals(employeeCardUpdateDto.CardId)) && x.Id != employeeCardUpdateDto.Id);
            if (employeeCardControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(employeeCardUpdateDto, employeeCard);
            Result isOk = await _repositoryFactory.CreateEmployeeCardDal.Update(mapper) ?
                new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
            return isOk;
        }
        public async Task<IResult> Delete(int id)
        {
            var employeeCard = await _repositoryFactory.CreateEmployeeCardDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (employeeCard is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            employeeCard.Isdelete = true;
            employeeCard.Isactive = false;

            return await _repositoryFactory.CreateEmployeeCardDal.Update(employeeCard) ?
                new SuccessResult(Message.Deleted, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<EmployeeCardDto> GetEmployeeCardById(int? employeeCardId)
        {
            if (employeeCardId == null) return new EmployeeCardDto();
            var result = await _repositoryFactory.CreateEmployeeCardDal.GetAsync(x => x.Id == employeeCardId);
            return Mapper.Map<EmployeeCard, EmployeeCardDto>(result);
        }
    }
}
