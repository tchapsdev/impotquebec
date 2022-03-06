using impotquebec.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace impotquebec.Web.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Declaration>().Property(p => p.BalanceDue).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.IncomeTaxAndContributions).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.NetIncome).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.NonRefundableTaxCredits).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.Refund).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.TaxableIncome).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.TotalDeductions).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Declaration>().Property(p => p.TotalIncome).HasColumnType("decimal(18,4)");
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxForm>().HasData(
                new TaxForm
                {
                    TaxFormId = 1,
                    Code = "TP-1.D-V",
                    Name = "INCOME TAX RETURN",
                    Description = ""
                });

            modelBuilder.Entity<TaxFormSection>().HasData(
                new TaxFormSection
                {
                    TaxFormSectionId = 1,
                    TaxFormId = 1,
                    InternalName = "TotalIncome",
                    Name = "Total income",
                    LineNumbers = "[101,105-164]",
                    Description = "Add lines 101 and 105 through 164. "
                },
                new TaxFormSection
                {
                    TaxFormSectionId = 2,
                    TaxFormId = 1,
                    InternalName = "TotalDeductions",
                    Name = "Net income",
                    LineNumbers = "[201-207,214-231,234-252]",
                    Description = "Add lines 201 through 207, 214 through 231, and 234 through 252. "
                }, new TaxFormSection
                {
                    TaxFormSectionId = 3,
                    TaxFormId = 1,
                    InternalName = "TotalDeductions",
                    Name = "Taxable income",
                    LineNumbers = "[287-297]",
                    Description = "Add lines 287 through 297"
                }, new TaxFormSection
                {
                    TaxFormSectionId = 4,
                    TaxFormId = 1,
                    InternalName = "TotalIncome",
                    Name = "Non-refundable tax credits",
                    LineNumbers = "",
                    Description = ""
                }, new TaxFormSection
                {
                    TaxFormSectionId = 5,
                    TaxFormId = 1,
                    InternalName = "IncomeTaxAndContributions",
                    Name = "Income tax and contributions",
                    LineNumbers = "",
                    Description = ""
                }
                , new TaxFormSection
                {
                    TaxFormSectionId = 6,
                    TaxFormId = 1,
                    InternalName = "RefundOrBalanceDue",
                    Name = "Refund or balance due",
                    LineNumbers = "",
                    Description = ""
                });
        }
    }
}
