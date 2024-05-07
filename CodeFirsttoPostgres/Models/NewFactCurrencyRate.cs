using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDBfirst.Models.EntityFramework;

public partial class NewFactCurrencyRate
{
    [Key]
    public float? AverageRate { get; set; }

    public string? CurrencyId { get; set; }

    public DateOnly? CurrencyDate { get; set; }

    public float? EndOfDayRate { get; set; }

    public int? CurrencyKey { get; set; }

    public int? DateKey { get; set; }
}
