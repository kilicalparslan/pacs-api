using pdksApi.Core.DataAccess.Repository;
using pdksApi.DataAccess.Abstract;
using pdksApi.DataAccess.ORM;

namespace pdksApi.DataAccess.Concreate
{
    public class RevisedLeaveDal : GenericRepositoryBase<RevisedLeave, pdksContext>, IRevisedLeaveDal
    {
    }
}
