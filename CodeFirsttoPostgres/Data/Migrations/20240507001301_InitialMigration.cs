using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeFirsttoPostgres.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatabaseLogs",
                columns: table => new
                {
                    DatabaseLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DatabaseUser = table.Column<string>(type: "text", nullable: false),
                    Event = table.Column<string>(type: "text", nullable: false),
                    Schema = table.Column<string>(type: "text", nullable: true),
                    Object = table.Column<string>(type: "text", nullable: true),
                    Tsql = table.Column<string>(type: "text", nullable: false),
                    XmlEvent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLogs", x => x.DatabaseLogId);
                });

            migrationBuilder.CreateTable(
                name: "DimAccounts",
                columns: table => new
                {
                    AccountKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentAccountKey = table.Column<int>(type: "integer", nullable: true),
                    AccountCodeAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    ParentAccountCodeAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    AccountDescription = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    Operator = table.Column<string>(type: "text", nullable: true),
                    CustomMembers = table.Column<string>(type: "text", nullable: true),
                    ValueType = table.Column<string>(type: "text", nullable: true),
                    CustomMemberOptions = table.Column<string>(type: "text", nullable: true),
                    ParentAccountKeyNavigationAccountKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimAccounts", x => x.AccountKey);
                    table.ForeignKey(
                        name: "FK_DimAccounts_DimAccounts_ParentAccountKeyNavigationAccountKey",
                        column: x => x.ParentAccountKeyNavigationAccountKey,
                        principalTable: "DimAccounts",
                        principalColumn: "AccountKey");
                });

            migrationBuilder.CreateTable(
                name: "DimCurrencies",
                columns: table => new
                {
                    CurrencyKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyAlternateKey = table.Column<string>(type: "text", nullable: false),
                    CurrencyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCurrencies", x => x.CurrencyKey);
                });

            migrationBuilder.CreateTable(
                name: "DimDates",
                columns: table => new
                {
                    DateKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullDateAlternateKey = table.Column<DateOnly>(type: "date", nullable: false),
                    DayNumberOfWeek = table.Column<byte>(type: "smallint", nullable: false),
                    EnglishDayNameOfWeek = table.Column<string>(type: "text", nullable: false),
                    SpanishDayNameOfWeek = table.Column<string>(type: "text", nullable: false),
                    FrenchDayNameOfWeek = table.Column<string>(type: "text", nullable: false),
                    DayNumberOfMonth = table.Column<byte>(type: "smallint", nullable: false),
                    DayNumberOfYear = table.Column<short>(type: "smallint", nullable: false),
                    WeekNumberOfYear = table.Column<byte>(type: "smallint", nullable: false),
                    EnglishMonthName = table.Column<string>(type: "text", nullable: false),
                    SpanishMonthName = table.Column<string>(type: "text", nullable: false),
                    FrenchMonthName = table.Column<string>(type: "text", nullable: false),
                    MonthNumberOfYear = table.Column<byte>(type: "smallint", nullable: false),
                    CalendarQuarter = table.Column<byte>(type: "smallint", nullable: false),
                    CalendarYear = table.Column<short>(type: "smallint", nullable: false),
                    CalendarSemester = table.Column<byte>(type: "smallint", nullable: false),
                    FiscalQuarter = table.Column<byte>(type: "smallint", nullable: false),
                    FiscalYear = table.Column<short>(type: "smallint", nullable: false),
                    FiscalSemester = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDates", x => x.DateKey);
                });

            migrationBuilder.CreateTable(
                name: "DimDepartmentGroups",
                columns: table => new
                {
                    DepartmentGroupKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentDepartmentGroupKey = table.Column<int>(type: "integer", nullable: true),
                    DepartmentGroupName = table.Column<string>(type: "text", nullable: true),
                    ParentDepartmentGroupKeyNavigationDepartmentGroupKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDepartmentGroups", x => x.DepartmentGroupKey);
                    table.ForeignKey(
                        name: "FK_DimDepartmentGroups_DimDepartmentGroups_ParentDepartmentGro~",
                        column: x => x.ParentDepartmentGroupKeyNavigationDepartmentGroupKey,
                        principalTable: "DimDepartmentGroups",
                        principalColumn: "DepartmentGroupKey");
                });

            migrationBuilder.CreateTable(
                name: "DimProductCategories",
                columns: table => new
                {
                    ProductCategoryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCategoryAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    EnglishProductCategoryName = table.Column<string>(type: "text", nullable: false),
                    SpanishProductCategoryName = table.Column<string>(type: "text", nullable: false),
                    FrenchProductCategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProductCategories", x => x.ProductCategoryKey);
                });

            migrationBuilder.CreateTable(
                name: "DimPromotions",
                columns: table => new
                {
                    PromotionKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    EnglishPromotionName = table.Column<string>(type: "text", nullable: true),
                    SpanishPromotionName = table.Column<string>(type: "text", nullable: true),
                    FrenchPromotionName = table.Column<string>(type: "text", nullable: true),
                    DiscountPct = table.Column<double>(type: "double precision", nullable: true),
                    EnglishPromotionType = table.Column<string>(type: "text", nullable: true),
                    SpanishPromotionType = table.Column<string>(type: "text", nullable: true),
                    FrenchPromotionType = table.Column<string>(type: "text", nullable: true),
                    EnglishPromotionCategory = table.Column<string>(type: "text", nullable: true),
                    SpanishPromotionCategory = table.Column<string>(type: "text", nullable: true),
                    FrenchPromotionCategory = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MinQty = table.Column<int>(type: "integer", nullable: true),
                    MaxQty = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimPromotions", x => x.PromotionKey);
                });

            migrationBuilder.CreateTable(
                name: "DimSalesReasons",
                columns: table => new
                {
                    SalesReasonKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesReasonAlternateKey = table.Column<int>(type: "integer", nullable: false),
                    SalesReasonName = table.Column<string>(type: "text", nullable: false),
                    SalesReasonReasonType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSalesReasons", x => x.SalesReasonKey);
                });

            migrationBuilder.CreateTable(
                name: "DimSalesTerritories",
                columns: table => new
                {
                    SalesTerritoryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesTerritoryAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    SalesTerritoryRegion = table.Column<string>(type: "text", nullable: false),
                    SalesTerritoryCountry = table.Column<string>(type: "text", nullable: false),
                    SalesTerritoryGroup = table.Column<string>(type: "text", nullable: true),
                    SalesTerritoryImage = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSalesTerritories", x => x.SalesTerritoryKey);
                });

            migrationBuilder.CreateTable(
                name: "DimScenarios",
                columns: table => new
                {
                    ScenarioKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScenarioName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimScenarios", x => x.ScenarioKey);
                });

            migrationBuilder.CreateTable(
                name: "FactAdditionalInternationalProductDescriptions",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CultureName = table.Column<string>(type: "text", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactAdditionalInternationalProductDescriptions", x => x.ProductKey);
                });

            migrationBuilder.CreateTable(
                name: "NewFactCurrencyRates",
                columns: table => new
                {
                    AverageRate = table.Column<float>(type: "real", nullable: false),
                    CurrencyId = table.Column<string>(type: "text", nullable: true),
                    CurrencyDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndOfDayRate = table.Column<float>(type: "real", nullable: true),
                    CurrencyKey = table.Column<int>(type: "integer", nullable: true),
                    DateKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewFactCurrencyRates", x => x.AverageRate);
                });

            migrationBuilder.CreateTable(
                name: "ProspectiveBuyers",
                columns: table => new
                {
                    ProspectiveBuyerKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProspectAlternateKey = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalChildren = table.Column<byte>(type: "smallint", nullable: true),
                    NumberChildrenAtHome = table.Column<byte>(type: "smallint", nullable: true),
                    Education = table.Column<string>(type: "text", nullable: true),
                    Occupation = table.Column<string>(type: "text", nullable: true),
                    HouseOwnerFlag = table.Column<string>(type: "text", nullable: true),
                    NumberCarsOwned = table.Column<byte>(type: "smallint", nullable: true),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    StateProvinceCode = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Salutation = table.Column<string>(type: "text", nullable: true),
                    Unknown = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectiveBuyers", x => x.ProspectiveBuyerKey);
                });

            migrationBuilder.CreateTable(
                name: "DimOrganizations",
                columns: table => new
                {
                    OrganizationKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentOrganizationKey = table.Column<int>(type: "integer", nullable: true),
                    PercentageOfOwnership = table.Column<string>(type: "text", nullable: true),
                    OrganizationName = table.Column<string>(type: "text", nullable: true),
                    CurrencyKey = table.Column<int>(type: "integer", nullable: true),
                    CurrencyKeyNavigationCurrencyKey = table.Column<int>(type: "integer", nullable: true),
                    ParentOrganizationKeyNavigationOrganizationKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimOrganizations", x => x.OrganizationKey);
                    table.ForeignKey(
                        name: "FK_DimOrganizations_DimCurrencies_CurrencyKeyNavigationCurrenc~",
                        column: x => x.CurrencyKeyNavigationCurrencyKey,
                        principalTable: "DimCurrencies",
                        principalColumn: "CurrencyKey");
                    table.ForeignKey(
                        name: "FK_DimOrganizations_DimOrganizations_ParentOrganizationKeyNavi~",
                        column: x => x.ParentOrganizationKeyNavigationOrganizationKey,
                        principalTable: "DimOrganizations",
                        principalColumn: "OrganizationKey");
                });

            migrationBuilder.CreateTable(
                name: "FactCallCenters",
                columns: table => new
                {
                    FactCallCenterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    WageType = table.Column<string>(type: "text", nullable: false),
                    Shift = table.Column<string>(type: "text", nullable: false),
                    LevelOneOperators = table.Column<short>(type: "smallint", nullable: false),
                    LevelTwoOperators = table.Column<short>(type: "smallint", nullable: false),
                    TotalOperators = table.Column<short>(type: "smallint", nullable: false),
                    Calls = table.Column<int>(type: "integer", nullable: false),
                    AutomaticResponses = table.Column<int>(type: "integer", nullable: false),
                    Orders = table.Column<int>(type: "integer", nullable: false),
                    IssuesRaised = table.Column<short>(type: "smallint", nullable: false),
                    AverageTimePerIssue = table.Column<short>(type: "smallint", nullable: false),
                    ServiceGrade = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactCallCenters", x => x.FactCallCenterId);
                    table.ForeignKey(
                        name: "FK_FactCallCenters_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactCurrencyRates",
                columns: table => new
                {
                    CurrencyKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    AverageRate = table.Column<double>(type: "double precision", nullable: false),
                    EndOfDayRate = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrencyKeyNavigationCurrencyKey = table.Column<int>(type: "integer", nullable: false),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactCurrencyRates", x => x.CurrencyKey);
                    table.ForeignKey(
                        name: "FK_FactCurrencyRates_DimCurrencies_CurrencyKeyNavigationCurren~",
                        column: x => x.CurrencyKeyNavigationCurrencyKey,
                        principalTable: "DimCurrencies",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactCurrencyRates_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimProductSubcategories",
                columns: table => new
                {
                    ProductSubcategoryKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductSubcategoryAlternateKey = table.Column<int>(type: "integer", nullable: true),
                    EnglishProductSubcategoryName = table.Column<string>(type: "text", nullable: false),
                    SpanishProductSubcategoryName = table.Column<string>(type: "text", nullable: false),
                    FrenchProductSubcategoryName = table.Column<string>(type: "text", nullable: false),
                    ProductCategoryKey = table.Column<int>(type: "integer", nullable: true),
                    ProductCategoryKeyNavigationProductCategoryKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProductSubcategories", x => x.ProductSubcategoryKey);
                    table.ForeignKey(
                        name: "FK_DimProductSubcategories_DimProductCategories_ProductCategor~",
                        column: x => x.ProductCategoryKeyNavigationProductCategoryKey,
                        principalTable: "DimProductCategories",
                        principalColumn: "ProductCategoryKey");
                });

            migrationBuilder.CreateTable(
                name: "DimEmployees",
                columns: table => new
                {
                    EmployeeKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentEmployeeKey = table.Column<int>(type: "integer", nullable: true),
                    EmployeeNationalIdalternateKey = table.Column<string>(type: "text", nullable: true),
                    ParentEmployeeNationalIdalternateKey = table.Column<string>(type: "text", nullable: true),
                    SalesTerritoryKey = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    NameStyle = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    LoginId = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "text", nullable: true),
                    SalariedFlag = table.Column<bool>(type: "boolean", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    PayFrequency = table.Column<byte>(type: "smallint", nullable: true),
                    BaseRate = table.Column<decimal>(type: "numeric", nullable: true),
                    VacationHours = table.Column<short>(type: "smallint", nullable: true),
                    SickLeaveHours = table.Column<short>(type: "smallint", nullable: true),
                    CurrentFlag = table.Column<bool>(type: "boolean", nullable: false),
                    SalesPersonFlag = table.Column<bool>(type: "boolean", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EmployeePhoto = table.Column<byte[]>(type: "bytea", nullable: true),
                    ParentEmployeeKeyNavigationEmployeeKey = table.Column<int>(type: "integer", nullable: true),
                    SalesTerritoryKeyNavigationSalesTerritoryKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimEmployees", x => x.EmployeeKey);
                    table.ForeignKey(
                        name: "FK_DimEmployees_DimEmployees_ParentEmployeeKeyNavigationEmploy~",
                        column: x => x.ParentEmployeeKeyNavigationEmployeeKey,
                        principalTable: "DimEmployees",
                        principalColumn: "EmployeeKey");
                    table.ForeignKey(
                        name: "FK_DimEmployees_DimSalesTerritories_SalesTerritoryKeyNavigatio~",
                        column: x => x.SalesTerritoryKeyNavigationSalesTerritoryKey,
                        principalTable: "DimSalesTerritories",
                        principalColumn: "SalesTerritoryKey");
                });

            migrationBuilder.CreateTable(
                name: "DimGeographies",
                columns: table => new
                {
                    GeographyKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: true),
                    StateProvinceCode = table.Column<string>(type: "text", nullable: true),
                    StateProvinceName = table.Column<string>(type: "text", nullable: true),
                    CountryRegionCode = table.Column<string>(type: "text", nullable: true),
                    EnglishCountryRegionName = table.Column<string>(type: "text", nullable: true),
                    SpanishCountryRegionName = table.Column<string>(type: "text", nullable: true),
                    FrenchCountryRegionName = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    SalesTerritoryKey = table.Column<int>(type: "integer", nullable: true),
                    IpAddressLocator = table.Column<string>(type: "text", nullable: true),
                    SalesTerritoryKeyNavigationSalesTerritoryKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimGeographies", x => x.GeographyKey);
                    table.ForeignKey(
                        name: "FK_DimGeographies_DimSalesTerritories_SalesTerritoryKeyNavigat~",
                        column: x => x.SalesTerritoryKeyNavigationSalesTerritoryKey,
                        principalTable: "DimSalesTerritories",
                        principalColumn: "SalesTerritoryKey");
                });

            migrationBuilder.CreateTable(
                name: "FactFinances",
                columns: table => new
                {
                    FinanceKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    OrganizationKey = table.Column<int>(type: "integer", nullable: false),
                    DepartmentGroupKey = table.Column<int>(type: "integer", nullable: false),
                    ScenarioKey = table.Column<int>(type: "integer", nullable: false),
                    AccountKey = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccountKeyNavigationAccountKey = table.Column<int>(type: "integer", nullable: false),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    DepartmentGroupKeyNavigationDepartmentGroupKey = table.Column<int>(type: "integer", nullable: false),
                    OrganizationKeyNavigationOrganizationKey = table.Column<int>(type: "integer", nullable: false),
                    ScenarioKeyNavigationScenarioKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactFinances", x => x.FinanceKey);
                    table.ForeignKey(
                        name: "FK_FactFinances_DimAccounts_AccountKeyNavigationAccountKey",
                        column: x => x.AccountKeyNavigationAccountKey,
                        principalTable: "DimAccounts",
                        principalColumn: "AccountKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactFinances_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactFinances_DimDepartmentGroups_DepartmentGroupKeyNavigati~",
                        column: x => x.DepartmentGroupKeyNavigationDepartmentGroupKey,
                        principalTable: "DimDepartmentGroups",
                        principalColumn: "DepartmentGroupKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactFinances_DimOrganizations_OrganizationKeyNavigationOrga~",
                        column: x => x.OrganizationKeyNavigationOrganizationKey,
                        principalTable: "DimOrganizations",
                        principalColumn: "OrganizationKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactFinances_DimScenarios_ScenarioKeyNavigationScenarioKey",
                        column: x => x.ScenarioKeyNavigationScenarioKey,
                        principalTable: "DimScenarios",
                        principalColumn: "ScenarioKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimProducts",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductAlternateKey = table.Column<string>(type: "text", nullable: true),
                    ProductSubcategoryKey = table.Column<int>(type: "integer", nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(type: "text", nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(type: "text", nullable: true),
                    EnglishProductName = table.Column<string>(type: "text", nullable: false),
                    SpanishProductName = table.Column<string>(type: "text", nullable: false),
                    FrenchProductName = table.Column<string>(type: "text", nullable: false),
                    StandardCost = table.Column<decimal>(type: "numeric", nullable: true),
                    FinishedGoodsFlag = table.Column<bool>(type: "boolean", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    SafetyStockLevel = table.Column<short>(type: "smallint", nullable: true),
                    ReorderPoint = table.Column<short>(type: "smallint", nullable: true),
                    ListPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    SizeRange = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    DaysToManufacture = table.Column<int>(type: "integer", nullable: true),
                    ProductLine = table.Column<string>(type: "text", nullable: true),
                    DealerPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Class = table.Column<string>(type: "text", nullable: true),
                    Style = table.Column<string>(type: "text", nullable: true),
                    ModelName = table.Column<string>(type: "text", nullable: true),
                    LargePhoto = table.Column<byte[]>(type: "bytea", nullable: true),
                    EnglishDescription = table.Column<string>(type: "text", nullable: true),
                    FrenchDescription = table.Column<string>(type: "text", nullable: true),
                    ChineseDescription = table.Column<string>(type: "text", nullable: true),
                    ArabicDescription = table.Column<string>(type: "text", nullable: true),
                    HebrewDescription = table.Column<string>(type: "text", nullable: true),
                    ThaiDescription = table.Column<string>(type: "text", nullable: true),
                    GermanDescription = table.Column<string>(type: "text", nullable: true),
                    JapaneseDescription = table.Column<string>(type: "text", nullable: true),
                    TurkishDescription = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ProductSubcategoryKeyNavigationProductSubcategoryKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimProducts", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_DimProducts_DimProductSubcategories_ProductSubcategoryKeyNa~",
                        column: x => x.ProductSubcategoryKeyNavigationProductSubcategoryKey,
                        principalTable: "DimProductSubcategories",
                        principalColumn: "ProductSubcategoryKey");
                });

            migrationBuilder.CreateTable(
                name: "FactSalesQuota",
                columns: table => new
                {
                    SalesQuotaKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeKey = table.Column<int>(type: "integer", nullable: false),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    CalendarYear = table.Column<short>(type: "smallint", nullable: false),
                    CalendarQuarter = table.Column<byte>(type: "smallint", nullable: false),
                    SalesAmountQuota = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    EmployeeKeyNavigationEmployeeKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactSalesQuota", x => x.SalesQuotaKey);
                    table.ForeignKey(
                        name: "FK_FactSalesQuota_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactSalesQuota_DimEmployees_EmployeeKeyNavigationEmployeeKey",
                        column: x => x.EmployeeKeyNavigationEmployeeKey,
                        principalTable: "DimEmployees",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimCustomers",
                columns: table => new
                {
                    CustomerKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeographyKey = table.Column<int>(type: "integer", nullable: true),
                    CustomerAlternateKey = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    NameStyle = table.Column<bool>(type: "boolean", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    Suffix = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalChildren = table.Column<byte>(type: "smallint", nullable: true),
                    NumberChildrenAtHome = table.Column<byte>(type: "smallint", nullable: true),
                    EnglishEducation = table.Column<string>(type: "text", nullable: true),
                    SpanishEducation = table.Column<string>(type: "text", nullable: true),
                    FrenchEducation = table.Column<string>(type: "text", nullable: true),
                    EnglishOccupation = table.Column<string>(type: "text", nullable: true),
                    SpanishOccupation = table.Column<string>(type: "text", nullable: true),
                    FrenchOccupation = table.Column<string>(type: "text", nullable: true),
                    HouseOwnerFlag = table.Column<string>(type: "text", nullable: true),
                    NumberCarsOwned = table.Column<byte>(type: "smallint", nullable: true),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    DateFirstPurchase = table.Column<DateOnly>(type: "date", nullable: true),
                    CommuteDistance = table.Column<string>(type: "text", nullable: true),
                    GeographyKeyNavigationGeographyKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCustomers", x => x.CustomerKey);
                    table.ForeignKey(
                        name: "FK_DimCustomers_DimGeographies_GeographyKeyNavigationGeography~",
                        column: x => x.GeographyKeyNavigationGeographyKey,
                        principalTable: "DimGeographies",
                        principalColumn: "GeographyKey");
                });

            migrationBuilder.CreateTable(
                name: "DimResellers",
                columns: table => new
                {
                    ResellerKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeographyKey = table.Column<int>(type: "integer", nullable: true),
                    ResellerAlternateKey = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    BusinessType = table.Column<string>(type: "text", nullable: false),
                    ResellerName = table.Column<string>(type: "text", nullable: false),
                    NumberEmployees = table.Column<int>(type: "integer", nullable: true),
                    OrderFrequency = table.Column<string>(type: "text", nullable: true),
                    OrderMonth = table.Column<byte>(type: "smallint", nullable: true),
                    FirstOrderYear = table.Column<int>(type: "integer", nullable: true),
                    LastOrderYear = table.Column<int>(type: "integer", nullable: true),
                    ProductLine = table.Column<string>(type: "text", nullable: true),
                    AddressLine1 = table.Column<string>(type: "text", nullable: true),
                    AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    AnnualSales = table.Column<decimal>(type: "numeric", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    MinPaymentType = table.Column<byte>(type: "smallint", nullable: true),
                    MinPaymentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    AnnualRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    YearOpened = table.Column<int>(type: "integer", nullable: true),
                    GeographyKeyNavigationGeographyKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimResellers", x => x.ResellerKey);
                    table.ForeignKey(
                        name: "FK_DimResellers_DimGeographies_GeographyKeyNavigationGeography~",
                        column: x => x.GeographyKeyNavigationGeographyKey,
                        principalTable: "DimGeographies",
                        principalColumn: "GeographyKey");
                });

            migrationBuilder.CreateTable(
                name: "FactProductInventories",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    MovementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitsIn = table.Column<int>(type: "integer", nullable: false),
                    UnitsOut = table.Column<int>(type: "integer", nullable: false),
                    UnitsBalance = table.Column<int>(type: "integer", nullable: false),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    ProductKeyNavigationProductKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactProductInventories", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_FactProductInventories_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactProductInventories_DimProducts_ProductKeyNavigationProd~",
                        column: x => x.ProductKeyNavigationProductKey,
                        principalTable: "DimProducts",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactInternetSales",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDateKey = table.Column<int>(type: "integer", nullable: false),
                    DueDateKey = table.Column<int>(type: "integer", nullable: false),
                    ShipDateKey = table.Column<int>(type: "integer", nullable: false),
                    CustomerKey = table.Column<int>(type: "integer", nullable: false),
                    PromotionKey = table.Column<int>(type: "integer", nullable: false),
                    CurrencyKey = table.Column<int>(type: "integer", nullable: false),
                    SalesTerritoryKey = table.Column<int>(type: "integer", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "text", nullable: false),
                    SalesOrderLineNumber = table.Column<byte>(type: "smallint", nullable: false),
                    RevisionNumber = table.Column<byte>(type: "smallint", nullable: false),
                    OrderQuantity = table.Column<short>(type: "smallint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ExtendedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitPriceDiscountPct = table.Column<double>(type: "double precision", nullable: false),
                    DiscountAmount = table.Column<double>(type: "double precision", nullable: false),
                    ProductStandardCost = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalProductCost = table.Column<decimal>(type: "numeric", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "numeric", nullable: false),
                    Freight = table.Column<decimal>(type: "numeric", nullable: false),
                    CarrierTrackingNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerPonumber = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrencyKeyNavigationCurrencyKey = table.Column<int>(type: "integer", nullable: false),
                    CustomerKeyNavigationCustomerKey = table.Column<int>(type: "integer", nullable: false),
                    DueDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    OrderDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    ProductKeyNavigationProductKey = table.Column<int>(type: "integer", nullable: false),
                    PromotionKeyNavigationPromotionKey = table.Column<int>(type: "integer", nullable: false),
                    SalesTerritoryKeyNavigationSalesTerritoryKey = table.Column<int>(type: "integer", nullable: false),
                    ShipDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactInternetSales", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimCurrencies_CurrencyKeyNavigationCurren~",
                        column: x => x.CurrencyKeyNavigationCurrencyKey,
                        principalTable: "DimCurrencies",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimCustomers_CustomerKeyNavigationCustome~",
                        column: x => x.CustomerKeyNavigationCustomerKey,
                        principalTable: "DimCustomers",
                        principalColumn: "CustomerKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDates_DueDateKeyNavigationDateKey",
                        column: x => x.DueDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDates_OrderDateKeyNavigationDateKey",
                        column: x => x.OrderDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimDates_ShipDateKeyNavigationDateKey",
                        column: x => x.ShipDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimProducts_ProductKeyNavigationProductKey",
                        column: x => x.ProductKeyNavigationProductKey,
                        principalTable: "DimProducts",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimPromotions_PromotionKeyNavigationPromo~",
                        column: x => x.PromotionKeyNavigationPromotionKey,
                        principalTable: "DimPromotions",
                        principalColumn: "PromotionKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactInternetSales_DimSalesTerritories_SalesTerritoryKeyNavi~",
                        column: x => x.SalesTerritoryKeyNavigationSalesTerritoryKey,
                        principalTable: "DimSalesTerritories",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactSurveyResponses",
                columns: table => new
                {
                    SurveyResponseKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateKey = table.Column<int>(type: "integer", nullable: false),
                    CustomerKey = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryKey = table.Column<int>(type: "integer", nullable: false),
                    EnglishProductCategoryName = table.Column<string>(type: "text", nullable: false),
                    ProductSubcategoryKey = table.Column<int>(type: "integer", nullable: false),
                    EnglishProductSubcategoryName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerKeyNavigationCustomerKey = table.Column<int>(type: "integer", nullable: false),
                    DateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactSurveyResponses", x => x.SurveyResponseKey);
                    table.ForeignKey(
                        name: "FK_FactSurveyResponses_DimCustomers_CustomerKeyNavigationCusto~",
                        column: x => x.CustomerKeyNavigationCustomerKey,
                        principalTable: "DimCustomers",
                        principalColumn: "CustomerKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactSurveyResponses_DimDates_DateKeyNavigationDateKey",
                        column: x => x.DateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactResellerSales",
                columns: table => new
                {
                    ProductKey = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDateKey = table.Column<int>(type: "integer", nullable: false),
                    DueDateKey = table.Column<int>(type: "integer", nullable: false),
                    ShipDateKey = table.Column<int>(type: "integer", nullable: false),
                    ResellerKey = table.Column<int>(type: "integer", nullable: false),
                    EmployeeKey = table.Column<int>(type: "integer", nullable: false),
                    PromotionKey = table.Column<int>(type: "integer", nullable: false),
                    CurrencyKey = table.Column<int>(type: "integer", nullable: false),
                    SalesTerritoryKey = table.Column<int>(type: "integer", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "text", nullable: false),
                    SalesOrderLineNumber = table.Column<byte>(type: "smallint", nullable: false),
                    RevisionNumber = table.Column<byte>(type: "smallint", nullable: true),
                    OrderQuantity = table.Column<short>(type: "smallint", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ExtendedAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    UnitPriceDiscountPct = table.Column<double>(type: "double precision", nullable: true),
                    DiscountAmount = table.Column<double>(type: "double precision", nullable: true),
                    ProductStandardCost = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalProductCost = table.Column<decimal>(type: "numeric", nullable: true),
                    SalesAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    TaxAmt = table.Column<decimal>(type: "numeric", nullable: true),
                    Freight = table.Column<decimal>(type: "numeric", nullable: true),
                    CarrierTrackingNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerPonumber = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrencyKeyNavigationCurrencyKey = table.Column<int>(type: "integer", nullable: false),
                    DueDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    EmployeeKeyNavigationEmployeeKey = table.Column<int>(type: "integer", nullable: false),
                    OrderDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false),
                    ProductKeyNavigationProductKey = table.Column<int>(type: "integer", nullable: false),
                    PromotionKeyNavigationPromotionKey = table.Column<int>(type: "integer", nullable: false),
                    ResellerKeyNavigationResellerKey = table.Column<int>(type: "integer", nullable: false),
                    SalesTerritoryKeyNavigationSalesTerritoryKey = table.Column<int>(type: "integer", nullable: false),
                    ShipDateKeyNavigationDateKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactResellerSales", x => x.ProductKey);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimCurrencies_CurrencyKeyNavigationCurren~",
                        column: x => x.CurrencyKeyNavigationCurrencyKey,
                        principalTable: "DimCurrencies",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDates_DueDateKeyNavigationDateKey",
                        column: x => x.DueDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDates_OrderDateKeyNavigationDateKey",
                        column: x => x.OrderDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimDates_ShipDateKeyNavigationDateKey",
                        column: x => x.ShipDateKeyNavigationDateKey,
                        principalTable: "DimDates",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimEmployees_EmployeeKeyNavigationEmploye~",
                        column: x => x.EmployeeKeyNavigationEmployeeKey,
                        principalTable: "DimEmployees",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimProducts_ProductKeyNavigationProductKey",
                        column: x => x.ProductKeyNavigationProductKey,
                        principalTable: "DimProducts",
                        principalColumn: "ProductKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimPromotions_PromotionKeyNavigationPromo~",
                        column: x => x.PromotionKeyNavigationPromotionKey,
                        principalTable: "DimPromotions",
                        principalColumn: "PromotionKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimResellers_ResellerKeyNavigationReselle~",
                        column: x => x.ResellerKeyNavigationResellerKey,
                        principalTable: "DimResellers",
                        principalColumn: "ResellerKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactResellerSales_DimSalesTerritories_SalesTerritoryKeyNavi~",
                        column: x => x.SalesTerritoryKeyNavigationSalesTerritoryKey,
                        principalTable: "DimSalesTerritories",
                        principalColumn: "SalesTerritoryKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DimAccounts_ParentAccountKeyNavigationAccountKey",
                table: "DimAccounts",
                column: "ParentAccountKeyNavigationAccountKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimCustomers_GeographyKeyNavigationGeographyKey",
                table: "DimCustomers",
                column: "GeographyKeyNavigationGeographyKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimDepartmentGroups_ParentDepartmentGroupKeyNavigationDepar~",
                table: "DimDepartmentGroups",
                column: "ParentDepartmentGroupKeyNavigationDepartmentGroupKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimEmployees_ParentEmployeeKeyNavigationEmployeeKey",
                table: "DimEmployees",
                column: "ParentEmployeeKeyNavigationEmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimEmployees_SalesTerritoryKeyNavigationSalesTerritoryKey",
                table: "DimEmployees",
                column: "SalesTerritoryKeyNavigationSalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimGeographies_SalesTerritoryKeyNavigationSalesTerritoryKey",
                table: "DimGeographies",
                column: "SalesTerritoryKeyNavigationSalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimOrganizations_CurrencyKeyNavigationCurrencyKey",
                table: "DimOrganizations",
                column: "CurrencyKeyNavigationCurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimOrganizations_ParentOrganizationKeyNavigationOrganizatio~",
                table: "DimOrganizations",
                column: "ParentOrganizationKeyNavigationOrganizationKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimProducts_ProductSubcategoryKeyNavigationProductSubcatego~",
                table: "DimProducts",
                column: "ProductSubcategoryKeyNavigationProductSubcategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimProductSubcategories_ProductCategoryKeyNavigationProduct~",
                table: "DimProductSubcategories",
                column: "ProductCategoryKeyNavigationProductCategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimResellers_GeographyKeyNavigationGeographyKey",
                table: "DimResellers",
                column: "GeographyKeyNavigationGeographyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactCallCenters_DateKeyNavigationDateKey",
                table: "FactCallCenters",
                column: "DateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactCurrencyRates_CurrencyKeyNavigationCurrencyKey",
                table: "FactCurrencyRates",
                column: "CurrencyKeyNavigationCurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactCurrencyRates_DateKeyNavigationDateKey",
                table: "FactCurrencyRates",
                column: "DateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinances_AccountKeyNavigationAccountKey",
                table: "FactFinances",
                column: "AccountKeyNavigationAccountKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinances_DateKeyNavigationDateKey",
                table: "FactFinances",
                column: "DateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinances_DepartmentGroupKeyNavigationDepartmentGroupKey",
                table: "FactFinances",
                column: "DepartmentGroupKeyNavigationDepartmentGroupKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinances_OrganizationKeyNavigationOrganizationKey",
                table: "FactFinances",
                column: "OrganizationKeyNavigationOrganizationKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactFinances_ScenarioKeyNavigationScenarioKey",
                table: "FactFinances",
                column: "ScenarioKeyNavigationScenarioKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_CurrencyKeyNavigationCurrencyKey",
                table: "FactInternetSales",
                column: "CurrencyKeyNavigationCurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_CustomerKeyNavigationCustomerKey",
                table: "FactInternetSales",
                column: "CustomerKeyNavigationCustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_DueDateKeyNavigationDateKey",
                table: "FactInternetSales",
                column: "DueDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_OrderDateKeyNavigationDateKey",
                table: "FactInternetSales",
                column: "OrderDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_ProductKeyNavigationProductKey",
                table: "FactInternetSales",
                column: "ProductKeyNavigationProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_PromotionKeyNavigationPromotionKey",
                table: "FactInternetSales",
                column: "PromotionKeyNavigationPromotionKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_SalesTerritoryKeyNavigationSalesTerritory~",
                table: "FactInternetSales",
                column: "SalesTerritoryKeyNavigationSalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactInternetSales_ShipDateKeyNavigationDateKey",
                table: "FactInternetSales",
                column: "ShipDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactProductInventories_DateKeyNavigationDateKey",
                table: "FactProductInventories",
                column: "DateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactProductInventories_ProductKeyNavigationProductKey",
                table: "FactProductInventories",
                column: "ProductKeyNavigationProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_CurrencyKeyNavigationCurrencyKey",
                table: "FactResellerSales",
                column: "CurrencyKeyNavigationCurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_DueDateKeyNavigationDateKey",
                table: "FactResellerSales",
                column: "DueDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_EmployeeKeyNavigationEmployeeKey",
                table: "FactResellerSales",
                column: "EmployeeKeyNavigationEmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_OrderDateKeyNavigationDateKey",
                table: "FactResellerSales",
                column: "OrderDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ProductKeyNavigationProductKey",
                table: "FactResellerSales",
                column: "ProductKeyNavigationProductKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_PromotionKeyNavigationPromotionKey",
                table: "FactResellerSales",
                column: "PromotionKeyNavigationPromotionKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ResellerKeyNavigationResellerKey",
                table: "FactResellerSales",
                column: "ResellerKeyNavigationResellerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_SalesTerritoryKeyNavigationSalesTerritory~",
                table: "FactResellerSales",
                column: "SalesTerritoryKeyNavigationSalesTerritoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactResellerSales_ShipDateKeyNavigationDateKey",
                table: "FactResellerSales",
                column: "ShipDateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSalesQuota_DateKeyNavigationDateKey",
                table: "FactSalesQuota",
                column: "DateKeyNavigationDateKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSalesQuota_EmployeeKeyNavigationEmployeeKey",
                table: "FactSalesQuota",
                column: "EmployeeKeyNavigationEmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSurveyResponses_CustomerKeyNavigationCustomerKey",
                table: "FactSurveyResponses",
                column: "CustomerKeyNavigationCustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactSurveyResponses_DateKeyNavigationDateKey",
                table: "FactSurveyResponses",
                column: "DateKeyNavigationDateKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatabaseLogs");

            migrationBuilder.DropTable(
                name: "DimSalesReasons");

            migrationBuilder.DropTable(
                name: "FactAdditionalInternationalProductDescriptions");

            migrationBuilder.DropTable(
                name: "FactCallCenters");

            migrationBuilder.DropTable(
                name: "FactCurrencyRates");

            migrationBuilder.DropTable(
                name: "FactFinances");

            migrationBuilder.DropTable(
                name: "FactInternetSales");

            migrationBuilder.DropTable(
                name: "FactProductInventories");

            migrationBuilder.DropTable(
                name: "FactResellerSales");

            migrationBuilder.DropTable(
                name: "FactSalesQuota");

            migrationBuilder.DropTable(
                name: "FactSurveyResponses");

            migrationBuilder.DropTable(
                name: "NewFactCurrencyRates");

            migrationBuilder.DropTable(
                name: "ProspectiveBuyers");

            migrationBuilder.DropTable(
                name: "DimAccounts");

            migrationBuilder.DropTable(
                name: "DimDepartmentGroups");

            migrationBuilder.DropTable(
                name: "DimOrganizations");

            migrationBuilder.DropTable(
                name: "DimScenarios");

            migrationBuilder.DropTable(
                name: "DimProducts");

            migrationBuilder.DropTable(
                name: "DimPromotions");

            migrationBuilder.DropTable(
                name: "DimResellers");

            migrationBuilder.DropTable(
                name: "DimEmployees");

            migrationBuilder.DropTable(
                name: "DimCustomers");

            migrationBuilder.DropTable(
                name: "DimDates");

            migrationBuilder.DropTable(
                name: "DimCurrencies");

            migrationBuilder.DropTable(
                name: "DimProductSubcategories");

            migrationBuilder.DropTable(
                name: "DimGeographies");

            migrationBuilder.DropTable(
                name: "DimProductCategories");

            migrationBuilder.DropTable(
                name: "DimSalesTerritories");
        }
    }
}
