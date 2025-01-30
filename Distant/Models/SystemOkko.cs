using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class SystemOkko
{
    public int Id { get; set; }

    public int StatementId { get; set; }

    public int ApplicantsId { get; set; }

    public int EmployeesId { get; set; }

    public virtual Applicant Applicants { get; set; } = null!;

    public virtual Employee Employees { get; set; } = null!;

    public virtual Statement Statement { get; set; } = null!;
}
