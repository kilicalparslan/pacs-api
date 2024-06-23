using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class City
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int CountryId { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<County> Counties { get; set; } = new List<County>();

    public virtual Country Country { get; set; } = null!;
}
