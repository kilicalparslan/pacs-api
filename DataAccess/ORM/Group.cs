using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Group
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();
}
