using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class EmployeeCard
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int EmployeeId { get; set; }

    public int CardId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public byte Status { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
