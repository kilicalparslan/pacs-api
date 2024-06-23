using pdksApi.Core.DataAccess.Repository;
using pdksApi.DataAccess.Abstract;
using pdksApi.DataAccess.ORM;

namespace pdksApi.DataAccess.Concreate
{
    public class EmployeeTitleDal : GenericRepositoryBase<EmployeeTitle, pdksContext>, IEmployeeTitleDal
    {
    }
}
