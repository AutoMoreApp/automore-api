using System;
using System.Collections.Generic;

namespace AutoMore.Api.Models;

public partial class AppDefinition
{
    public int AppId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public string? AuthMethod { get; set; }

    public string? AvailableTriggers { get; set; }

    public string? AvailableActions { get; set; }
}
