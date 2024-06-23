using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Level
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public int GroupId { get; set; }

    public virtual ICollection<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>();

    public virtual Group Group { get; set; } = null!;
}
