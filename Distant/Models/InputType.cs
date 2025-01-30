using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class InputType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
