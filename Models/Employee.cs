using System;
using System.Collections.Generic;

namespace APIRefresher.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Photo { get; set; }

    public string? Notes { get; set; }
}
