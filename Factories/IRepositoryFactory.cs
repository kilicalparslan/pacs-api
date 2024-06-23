using pdksApi.DataAccess.Abstract;


namespace pdksApi.Factories
{
    public interface IRepositoryFactory
    {
        ICityDal CreateCityDal { get; set; }
        IBranchDal CreateBranchDal { get; set; }
        ICompanyDal CreateCompanyDal { get; set; }
        ICountyDal CreateCountyDal { get; set; }
        ICountryDal CreateCountryDal { get; set; }
        IEmployeeDal CreateEmployeeDal { get; }       
        IAccessPointDal CreateAccessPointDal { get; }
        ICardDal CreateCardDal { get; }
        IEmployeeCardDal CreateEmployeeCardDal { get; }
        IEmployeeLanguageDal CreateEmployeeLanguageDal { get; }
        IEmployeeLeaveDal CreateEmployeeLeaveDal { get; }   
        IEmployeeTitleDal CreateEmployeeTitleDal { get; }
        IEmployeeReferanceDal CreateEmployeeReferanceDal { get;}
        IGroupDal CreateGroupDal { get; }
        ILanguageDal CreateLanguageDal { get; }
        ILevelDal CreateLevelDal { get; }
        IRevisedLeaveDal CreateRevisedLeaveDal { get; }
        IRoleDal CreateRoleDal { get; }
        ISizeDal CreateSizeDal { get; }
        ITitleDal CreateTitleDal { get; }
        IUserDal CreateUserDal { get; }
        IUserRoleDal CreateUserRoleDal { get; }
     
    }
}
