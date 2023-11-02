using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class ServiceOrderFeature
{
    public int Id { get; set; }

    public int ServiceOrderId { get; set; }

    public int FeatureId { get; set; }

    public virtual Feature Feature { get; set; } = null!;

    public virtual ServiceOrder ServiceOrder { get; set; } = null!;
}
