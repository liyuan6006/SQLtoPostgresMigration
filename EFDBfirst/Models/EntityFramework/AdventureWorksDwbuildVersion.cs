using System;
using System.Collections.Generic;

namespace EFDBfirst.Models.EntityFramework;

public partial class AdventureWorksDwbuildVersion
{
    public string? Dbversion { get; set; }

    public DateTime? VersionDate { get; set; }
}
