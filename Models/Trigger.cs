using System;
using System.Collections.Generic;

namespace AutoMore.Api.Models;

public partial class Trigger
{
    public int TriggerId { get; set; }

    public int? WorkflowId { get; set; }

    public string? Type { get; set; }

    public string? Config { get; set; }

    public int? PollInterval { get; set; }

    public DateTime? LastExecutedAt { get; set; }

    public virtual Workflow? Workflow { get; set; }
}
