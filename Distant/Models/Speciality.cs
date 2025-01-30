using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class Speciality
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string NameOfTheSspecialty { get; set; } = null!;

    public int NumberOfSeats { get; set; }

    public int FormOfEducation { get; set; }

    public int Price { get; set; }

    public virtual FormOfEducation FormOfEducationNavigation { get; set; } = null!;

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
