using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Card
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public byte Type { get; set; }

    public string Cardno { get; set; } = null!;

	public bool? Cancelled { get; set; }
    public DateTime? Cancelleddate { get; set; }
    public virtual ICollection<EmployeeCard> EmployeeCards { get; set; } = new List<EmployeeCard>();
}
