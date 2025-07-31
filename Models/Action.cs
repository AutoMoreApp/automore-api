using System;
using System.Collections.Generic;

namespace AutoMore.Api.Models;

public partial class Action
{
    public int ActionId { get; set; }

    public int? WorkflowId { get; set; }

    public string? Type { get; set; }

    public string? Config { get; set; }

    public int? Order { get; set; }

    public virtual Workflow? Workflow { get; set; }
}
