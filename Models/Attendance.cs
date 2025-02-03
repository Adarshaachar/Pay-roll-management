using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
