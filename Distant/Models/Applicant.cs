using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public int? ApplicantsCode { get; set; }

    public string? Passport { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<SystemOkko> SystemOkkos { get; set; } = new List<SystemOkko>();
}
