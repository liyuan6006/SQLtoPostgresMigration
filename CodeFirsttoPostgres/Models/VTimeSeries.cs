﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDBfirst.Models.EntityFramework;

public partial class VTimeSeries
{
    [Key]
    public string? ModelRegion { get; set; }

    public int? TimeIndex { get; set; }

    public int? Quantity { get; set; }

    public decimal? Amount { get; set; }

    public short CalendarYear { get; set; }

    public byte Month { get; set; }

    public DateTime? ReportingDate { get; set; }
}
