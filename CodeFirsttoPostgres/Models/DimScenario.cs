using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDBfirst.Models.EntityFramework;

public partial class DimScenario
{
    [Key]
    public int ScenarioKey { get; set; }

    public string? ScenarioName { get; set; }
}
