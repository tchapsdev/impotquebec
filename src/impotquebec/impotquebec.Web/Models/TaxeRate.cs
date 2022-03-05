namespace impotquebec.Web.Models
{
    public class TaxeRate
    {
        public int TaxeRateId { get; set; }
        public string Year { get; set; }
        public string State { get; set; }

        public decimal Minimum { get; set; }    
        public decimal Maximun { get; set; }

        public decimal Rate { get; set; }

        public int TaxFormId { get; set; }

    }
}
