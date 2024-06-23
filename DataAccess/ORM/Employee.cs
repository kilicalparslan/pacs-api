namespace pdksApi.DataAccess.ORM;

public partial class Employee
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Identityno { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public byte Gender { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public int? CountyId { get; set; }

    public string? Address { get; set; }

    public string? Servicedetail { get; set; }

    public string? Detail { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual County? Counties { get; set; }

    public virtual ICollection<EmployeeCard> EmployeeCards { get; set; } = new List<EmployeeCard>();

    public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; } = new List<EmployeeLanguage>();

    public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; } = new List<EmployeeLeave>();

    public virtual ICollection<EmployeeTitle> EmployeeTitles { get; set; } = new List<EmployeeTitle>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
