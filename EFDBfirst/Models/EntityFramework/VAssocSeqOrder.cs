﻿using System;
using System.Collections.Generic;

namespace EFDBfirst.Models.EntityFramework;

public partial class VAssocSeqOrder
{
    public string OrderNumber { get; set; } = null!;

    public int CustomerKey { get; set; }

    public string? Region { get; set; }

    public string IncomeGroup { get; set; } = null!;
}
