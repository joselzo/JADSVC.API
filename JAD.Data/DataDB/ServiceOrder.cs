using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class ServiceOrder
{
    public int Id { get; set; }

    public DateTime DateAdded { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public int? ServiceLevelId { get; set; }

    public string? FeaturesAlc { get; set; }

    public decimal? Amount { get; set; }

    public int? TxnId { get; set; }

    public string? Status { get; set; }

    public decimal? FeeAmount { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ServiceLevel? ServiceLevel { get; set; }

    public virtual ICollection<ServiceOrderFeature> ServiceOrderFeatures { get; set; } = new List<ServiceOrderFeature>();

    public virtual User? User { get; set; }
}
