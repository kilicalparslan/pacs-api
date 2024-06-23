using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Language
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; } = null!;

    public string? Flag { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; } = new List<EmployeeLanguage>();
}
