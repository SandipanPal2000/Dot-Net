using System;
using System.Collections.Generic;

namespace EntityFramework1.Models;

public partial class StudentTb
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Department { get; set; }

    public string? Course { get; set; }
}
