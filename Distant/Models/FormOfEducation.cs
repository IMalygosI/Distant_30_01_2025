using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class FormOfEducation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
}
