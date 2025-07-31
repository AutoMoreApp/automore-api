using System;
using System.Collections.Generic;

namespace AutoMore.Api.Models;

public partial class Workflow
{
    public int WorkflowId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual ICollection<ExecutionLog> ExecutionLogs { get; set; } = new List<ExecutionLog>();

    public virtual ICollection<Trigger> Triggers { get; set; } = new List<Trigger>();

    public virtual User? User { get; set; }
}
