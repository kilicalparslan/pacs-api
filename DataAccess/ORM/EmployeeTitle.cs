using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class EmployeeTitle
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int EmployeeId { get; set; }

    public int TitleId { get; set; }

    public DateTime Createdate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
