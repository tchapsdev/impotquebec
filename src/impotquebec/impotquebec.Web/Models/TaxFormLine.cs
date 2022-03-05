namespace impotquebec.Web.Models
{
    public class TaxFormLine: NamedEntity
    {
        public int TaxFormLineId { get; set; }
       
        public float LineNumber { get; set; }
        public bool IsActive { get; set; }


        public int TaxFormId { get; set; }
        public TaxForm TaxForm { get; set; }
    }
}
