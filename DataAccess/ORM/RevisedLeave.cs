using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class RevisedLeave
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int EmployeeleaveId { get; set; }

    public DateTime Reviseddate { get; set; }

    public string? Datail { get; set; }

    public virtual EmployeeLeave Employeeleave { get; set; } = null!;
}
