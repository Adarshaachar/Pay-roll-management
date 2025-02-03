using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string? Title { get; set; }

    public DateTime GeneratedDate { get; set; }

    public string? ReportData { get; set; }
}
