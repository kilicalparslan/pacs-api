using pdksApi.AutoMapper;
using pdksApi.Core.Utilities.Messages;
using pdksApi.Core.Utilities.Results;
using pdksApi.DataAccess.ORM;
using ViewLibrary.Pdks.Dtos.Pdks.BranchDtos;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using IResult = pdksApi.Core.Utilities.Results.IResult;

namespace pdksApi.Services.Methods
{
    public class BranchService : AutoMapperService, IBranchService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public BranchService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IList<BranchDto>> GetList(int companyId)
        {
            var result = await _repositoryFactory.CreateBranchDal.GetListAsync(r => r.Isactive && !r.Isdelete && r.CompanyId==companyId);
            
            if (result is null)
            {
                return new List<BranchDto>();
            }
            return Mapper.Map<IList<Branch>, IList<BranchDto>>(result);
        }

        public async Task<IResult> Create(BranchAddDto branchAddDto)
        {
            var branchControl = await _repositoryFactory.CreateBranchDal.GetAsync(x => x.Name.Equals(branchAddDto.Name));
            if (branchControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map<BranchAddDto, Branch>(branchAddDto);
            var result = await _repositoryFactory.CreateBranchDal.Add(mapper);
            return result ?
                new SuccessResult(Message.Added, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<IResult> Update(BranchUpdateDto branchUpdateDto)
        {
            var branch = await _repositoryFactory.CreateBranchDal.GetAsync(x => x.Id == branchUpdateDto.Id);
            if (branch is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            var branchControl = await _repositoryFactory.CreateBranchDal.GetAsync(x => x.Name == branchUpdateDto.Name && x.Id != branchUpdateDto.Id);
            if (branchControl is not null)
            {
                return new ErrorResult(Message.SameRecord, MessageType.Warning);
            }
            var mapper = Mapper.Map(branchUpdateDto, branch);
            Result isOk = await _repositoryFactory.CreateBranchDal.Update(mapper) ?
                new SuccessResult(Message.Updated, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
            return isOk;
        }
        public async Task<IResult> Delete(int id)
        {
            var branch = await _repositoryFactory.CreateBranchDal.GetAsync(x => x.Id == id && !x.Isdelete);
            if (branch is null) return new ErrorResult(Message.NotFoundSystem, MessageType.Warning);
            branch.Isdelete = true;
            branch.Isactive = false;

            return await _repositoryFactory.CreateBranchDal.Update(branch) ?
                new SuccessResult(Message.Deleted, MessageType.Info) :
                new ErrorResult(Message.Error, MessageType.Error);
        }
        public async Task<BranchDto> GetBranchById(int? branchId)
        {
            if (branchId == null) return new BranchDto();
            var result = await _repositoryFactory.CreateBranchDal.GetAsync(x => x.Id == branchId);
            return Mapper.Map<Branch, BranchDto>(result);
        }
    }
}
