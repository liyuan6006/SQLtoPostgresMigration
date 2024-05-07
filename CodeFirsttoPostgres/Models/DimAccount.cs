﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDBfirst.Models.EntityFramework;

public partial class DimAccount
{
    [Key]
    public int AccountKey { get; set; }

    public int? ParentAccountKey { get; set; }

    public int? AccountCodeAlternateKey { get; set; }

    public int? ParentAccountCodeAlternateKey { get; set; }

    public string? AccountDescription { get; set; }

    public string? AccountType { get; set; }

    public string? Operator { get; set; }

    public string? CustomMembers { get; set; }

    public string? ValueType { get; set; }

    public string? CustomMemberOptions { get; set; }

    //public virtual ICollection<DimAccount> InverseParentAccountKeyNavigation { get; set; } = new List<DimAccount>();

    public virtual DimAccount? ParentAccountKeyNavigation { get; set; }
}
