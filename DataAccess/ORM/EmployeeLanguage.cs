using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class EmployeeLanguage
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public int EmployeeId { get; set; }

    public int LanguageId { get; set; }

    public DateTime Createdate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;
}
