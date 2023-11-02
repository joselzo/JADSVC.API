using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class UserFeature
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? FeatureId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Feature? Feature { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
