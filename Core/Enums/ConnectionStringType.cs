using System.ComponentModel.DataAnnotations;

namespace pdksApi.Core.Enums
{
    public enum ConnectionStringType
    {
        ProductionDb = 1,
        TestDb = 2       
    }


    public enum Esort
    {
        [Display(Name = "OrderBy")]
        ASC = 1,
        [Display(Name = "OrderByDescending")]
        DESC = 2,
    }

}
