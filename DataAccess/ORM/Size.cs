using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Size
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
