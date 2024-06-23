using System;
using System.Collections.Generic;

namespace pdksApi.DataAccess.ORM;

public partial class Company
{
    public int Id { get; set; }

    public bool Isactive { get; set; }

    public bool Isdelete { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string? Address { get; set; }

    public int? CountyId { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
