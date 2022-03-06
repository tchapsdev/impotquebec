using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace impotquebec.Web.Models
{
    public class Declaration
    {
        public int DeclarationId { get; set; }
        public short FiscalYear { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalDeductions { get; set; }
        [DataType(DataType.Currency)]
        public decimal NetIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal TaxableIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal NonRefundableTaxCredits { get; set; }
        [DataType(DataType.Currency)]
        public decimal IncomeTaxAndContributions { get; set; }
        [DataType(DataType.Currency)]
        public decimal Refund { get; set; }
        [DataType(DataType.Currency)]
        public decimal BalanceDue { get; set; }


        public int TaxFormId { get; set; }
        public TaxForm? TaxForm { get; set; }

        public string UserId { get; set; }
        public IdentityUser? User { get; set; }


        public string History { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public IList<DeclarationDetail> Details { get; set; }
    }
}
