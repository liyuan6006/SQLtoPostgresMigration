using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFDBfirst.Models.EntityFramework;

public partial class AdventureWorksDw2022Context : DbContext
{
    public AdventureWorksDw2022Context()
    {
    }

    public AdventureWorksDw2022Context(DbContextOptions<AdventureWorksDw2022Context> options)
        : base(options)
    {
    }

   // public virtual DbSet<AdventureWorksDwbuildVersion> AdventureWorksDwbuildVersions { get; set; }

    public virtual DbSet<DatabaseLog> DatabaseLogs { get; set; }

    public virtual DbSet<DimAccount> DimAccounts { get; set; }

    public virtual DbSet<DimCurrency> DimCurrencies { get; set; }

    public virtual DbSet<DimCustomer> DimCustomers { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<DimDepartmentGroup> DimDepartmentGroups { get; set; }

    public virtual DbSet<DimEmployee> DimEmployees { get; set; }

    public virtual DbSet<DimGeography> DimGeographies { get; set; }

    public virtual DbSet<DimOrganization> DimOrganizations { get; set; }

    public virtual DbSet<DimProduct> DimProducts { get; set; }

    public virtual DbSet<DimProductCategory> DimProductCategories { get; set; }

    public virtual DbSet<DimProductSubcategory> DimProductSubcategories { get; set; }

    public virtual DbSet<DimPromotion> DimPromotions { get; set; }

    public virtual DbSet<DimReseller> DimResellers { get; set; }

    public virtual DbSet<DimSalesReason> DimSalesReasons { get; set; }

    public virtual DbSet<DimSalesTerritory> DimSalesTerritories { get; set; }

    public virtual DbSet<DimScenario> DimScenarios { get; set; }

    public virtual DbSet<FactAdditionalInternationalProductDescription> FactAdditionalInternationalProductDescriptions { get; set; }

    public virtual DbSet<FactCallCenter> FactCallCenters { get; set; }

    public virtual DbSet<FactCurrencyRate> FactCurrencyRates { get; set; }

    public virtual DbSet<FactFinance> FactFinances { get; set; }

    public virtual DbSet<FactInternetSale> FactInternetSales { get; set; }

    public virtual DbSet<FactProductInventory> FactProductInventories { get; set; }

    public virtual DbSet<FactResellerSale> FactResellerSales { get; set; }

    public virtual DbSet<FactSalesQuotum> FactSalesQuota { get; set; }

    public virtual DbSet<FactSurveyResponse> FactSurveyResponses { get; set; }

    public virtual DbSet<NewFactCurrencyRate> NewFactCurrencyRates { get; set; }

    public virtual DbSet<ProspectiveBuyer> ProspectiveBuyers { get; set; }

    //public virtual DbSet<VAssocSeqLineItem> VAssocSeqLineItems { get; set; }

    //public virtual DbSet<VAssocSeqOrder> VAssocSeqOrders { get; set; }

    //public virtual DbSet<VDmprep> VDmpreps { get; set; }

   // public virtual DbSet<VTargetMail> VTargetMails { get; set; }

    //public virtual DbSet<VTimeSeries> VTimeSeries { get; set; }


}
