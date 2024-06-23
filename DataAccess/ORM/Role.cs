using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Role
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
