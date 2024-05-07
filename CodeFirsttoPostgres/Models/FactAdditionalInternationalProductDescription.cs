using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDBfirst.Models.EntityFramework;

public partial class FactAdditionalInternationalProductDescription
{
    [Key]
    public int ProductKey { get; set; }

    public string CultureName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;
}
