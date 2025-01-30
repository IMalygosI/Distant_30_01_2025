using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeesId { get; set; } = null!;

    public int JobTitle { get; set; }

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly LastLogin { get; set; }

    public int InputType { get; set; }

    public virtual InputType InputTypeNavigation { get; set; } = null!;

    public virtual JobTitle JobTitleNavigation { get; set; } = null!;

    public virtual ICollection<SystemOkko> SystemOkkos { get; set; } = new List<SystemOkko>();
}
