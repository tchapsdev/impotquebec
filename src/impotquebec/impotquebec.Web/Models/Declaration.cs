using Microsoft.AspNetCore.Identity;

namespace impotquebec.Web.Models
{
    public class Declaration
    {
        public int DeclarationId { get; set; }

        public short FiscalYear { get; set; }

        public decimal TotalIncome { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetIncome { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal NonRefundableTaxCredits { get; set; }
        public decimal IncomeTaxAndContributions { get; set; }
        public decimal Refund { get; set; }
        public decimal BalanceDue { get; set; }


        public int TaxFormId { get; set; }
        public TaxForm TaxForm { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }


        public string History { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
