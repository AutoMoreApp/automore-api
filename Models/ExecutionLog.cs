using System;
using System.Collections.Generic;

namespace AutoMore.Api.Models;

public partial class ExecutionLog
{
    public int LogId { get; set; }

    public int? WorkflowId { get; set; }

    public string? TriggerResult { get; set; }

    public string? ActionResult { get; set; }

    public string? Status { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? ErrorMessage { get; set; }

    public virtual Workflow? Workflow { get; set; }
}
