using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class User
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoleCreatedusers { get; set; } = new List<UserRole>();

    public virtual ICollection<UserRole> UserRoleUsers { get; set; } = new List<UserRole>();
}
