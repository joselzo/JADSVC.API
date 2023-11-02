using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class Feature
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public bool? IsAlaCarteOnly { get; set; }

    public decimal? Price { get; set; }

    public int? ServiceId { get; set; }

    public int? ServiceLevelId { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ServiceLevel? ServiceLevel { get; set; }

    public virtual ICollection<ServiceOrderFeature> ServiceOrderFeatures { get; set; } = new List<ServiceOrderFeature>();

    public virtual ICollection<UserFeature> UserFeatures { get; set; } = new List<UserFeature>();
}
