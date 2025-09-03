using System;
using System.Collections.Generic;

namespace BlueOcktopus.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public DateOnly? BirthDate { get; set; }
}
