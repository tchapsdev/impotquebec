using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tchaps.Impotquebec.Models
{
    public class Declaration
    {
        public int DeclarationId { get; set; }
        [Display(Name = "Fiscal Year")]
        public short FiscalYear { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Income")]
        public decimal TotalIncome { get; set; }

        [Display(Name = "Total Deductions")]
        [DataType(DataType.Currency)]
        public decimal TotalDeductions { get; set; }

        [Display(Name = "Net Income")]
        [DataType(DataType.Currency)]
        public decimal NetIncome { get; set; }

        [Display(Name = "Taxable Income")]
        [DataType(DataType.Currency)]
        public decimal TaxableIncome { get; set; }

        [Display(Name = "Non Refundable Tax Credits")]
        [DataType(DataType.Currency)]
        public decimal NonRefundableTaxCredits { get; set; }

        [Display(Name = "Income Tax And Contributions")]
        [DataType(DataType.Currency)]
        public decimal IncomeTaxAndContributions { get; set; }

       
        [DataType(DataType.Currency)]
        public decimal Refund { get; set; }

        [Display(Name = "Balance Due")]
        [DataType(DataType.Currency)]
        public decimal BalanceDue { get; set; }


        public int TaxFormId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public TaxForm? TaxForm { get; set; }

        public Guid UserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public AppUser? User { get; set; }


        public string History { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public IList<DeclarationDetail> Details { get; set; }


        #region Methods

        public DeclarationDetail GetTaxLine( float lineNumber)
        {
            return Details.FirstOrDefault(d => d.LineNumber == lineNumber);
        }

        public void SetTaxLine(float lineNumber, decimal value)
        {
            var taxLine = GetTaxLine(lineNumber);
            if (taxLine == null) return;
            taxLine.Value = $"{value}";
        }

        public decimal GetSumLines(float[] lineNumbers)
        {
            return Details.Where(d => lineNumbers
                        .Contains(d.LineNumber) && !string.IsNullOrWhiteSpace(d.Value))
                        .Sum(x => GetValueFromLine(x.LineNumber));
        }

        public decimal GetValueFromLine(float lineNumber)
        {
            var taxLine = GetTaxLine(lineNumber);
            if (taxLine == null || string.IsNullOrWhiteSpace(taxLine.Value)) return 0;
            decimal.TryParse(taxLine.Value, out var result);
            return result;
        }

        public decimal GetDiffLines(float lineNumber1, float lineNumber2)
        {
            return GetValueFromLine(lineNumber1) - GetValueFromLine(lineNumber2);
        }
        #endregion


    }
}
