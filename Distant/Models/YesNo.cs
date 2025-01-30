using System;
using System.Collections.Generic;

namespace Distant.Models;

public partial class YesNo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Statement> StatementDiplomaOfEducationNavigations { get; set; } = new List<Statement>();

    public virtual ICollection<Statement> StatementPassportNavigations { get; set; } = new List<Statement>();
}
