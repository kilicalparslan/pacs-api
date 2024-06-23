using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Branch
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; }

    public int CompanyId { get; set; }

    public string? Address { get; set; }

    public int? CountyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual County? County { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
