using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime Birthday { get; set; }

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string BankInformation { get; set; } = null!;

    public int PositionId { get; set; }

    public virtual ICollection<EmployeeMovement> EmployeeMovements { get; set; } = new List<EmployeeMovement>();

    public virtual ICollection<Master> Masters { get; set; } = new List<Master>();

    public virtual Position Position { get; set; } = null!;
}
