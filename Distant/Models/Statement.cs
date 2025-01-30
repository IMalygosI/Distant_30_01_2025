using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class Statement
{
    public int Id { get; set; }

    public string PersonalFileNumber { get; set; } = null!;

    public DateOnly SubmissionDate { get; set; }

    public TimeOnly SubmissionTime { get; set; }

    public int ApplicantCode { get; set; }

    public int SelectedSpecialties { get; set; }

    public int Passport { get; set; }

    public int DiplomaOfEducation { get; set; }

    public int NumberOfPoints { get; set; }

    public virtual YesNo DiplomaOfEducationNavigation { get; set; } = null!;

    public virtual YesNo PassportNavigation { get; set; } = null!;

    public virtual Speciality SelectedSpecialtiesNavigation { get; set; } = null!;

    public virtual ICollection<SystemOkko> SystemOkkos { get; set; } = new List<SystemOkko>();
}
