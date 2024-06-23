using pdksApi.Core.DataAccess.Repository;
using pdksApi.DataAccess.Abstract;
using pdksApi.DataAccess.ORM;

namespace pdksApi.DataAccess.Concreate
{
    public class CountyDal : GenericRepositoryBase<County, pdksContext>, ICountyDal
    {
      
    }
}
