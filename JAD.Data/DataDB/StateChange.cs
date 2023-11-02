using System;
using System.Collections.Generic;

namespace JADSVC.Data.DataDB;

public partial class StateChange
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ActionType { get; set; }

    public string? ActionDescription { get; set; }

    public DateTime? ActionDate { get; set; }
}
