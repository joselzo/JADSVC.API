using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();

    public virtual ICollection<ServiceLevel> ServiceLevels { get; set; } = new List<ServiceLevel>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<UserFeature> UserFeatures { get; set; } = new List<UserFeature>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
