using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? EmployeeId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime DateSubmitted { get; set; }

    public virtual Employee? Employee { get; set; }
}
