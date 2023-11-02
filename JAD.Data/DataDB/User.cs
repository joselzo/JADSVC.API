using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public int? CurrentServiceLevelId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<UserFeature> UserFeatures { get; set; } = new List<UserFeature>();
}
