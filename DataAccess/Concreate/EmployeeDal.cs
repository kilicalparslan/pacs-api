using pdksApi.Core.DataAccess.Repository;
using pdksApi.DataAccess.Abstract;
using pdksApi.DataAccess.ORM;

namespace pdksApi.DataAccess.Concreate
{
    public class EmployeeDal : GenericRepositoryBase<Employee, pdksContext>, IEmployeeDal
    {
    }
}
