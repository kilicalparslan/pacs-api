using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class EmployeeLeave
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Createdate { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public byte? Statu { get; set; }

    public DateTime? Approvedate { get; set; }

    public bool? Revise { get; set; }

    public string? Detail { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<RevisedLeave> RevisedLeaves { get; set; } = new List<RevisedLeave>();
}
