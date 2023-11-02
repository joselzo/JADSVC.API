using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class ServiceLevel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? ServiceId { get; set; }

    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();

    public virtual Service? Service { get; set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
