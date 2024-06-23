using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Country
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
