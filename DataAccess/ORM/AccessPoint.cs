using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class AccessPoint
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime Creatadate { get; set; }

    public int LevelId { get; set; }

    public virtual Level Level { get; set; } = null!;
}
