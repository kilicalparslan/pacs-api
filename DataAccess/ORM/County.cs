using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class County
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public int CityId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
