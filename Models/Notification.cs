using System;
using System.Collections.Generic;

namespace PayRollmanagementSystem_Backend.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public string Message { get; set; } = null!;

    public bool? IsRead { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual User? User { get; set; }
}
