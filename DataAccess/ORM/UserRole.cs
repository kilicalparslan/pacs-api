using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class UserRole
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime Createdate { get; set; }

    public int? CreateduserId { get; set; }

    public virtual User Createduser { get; set; }

    public virtual Role Role { get; set; }

    public virtual User User { get; set; }
}
