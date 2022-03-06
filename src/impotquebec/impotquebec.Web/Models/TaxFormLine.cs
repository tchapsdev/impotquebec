namespace impotquebec.Web.Models
{
    public class TaxFormLine: NamedEntity
    {
        public int TaxFormLineId { get; set; }
        public int TaxFormId { get; set; }
        public virtual TaxForm? TaxForm { get; set; }
        
        public string LineNumber { get; set; }
        public short Rank { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsReadOnly { get; set; }
        public int? TaxFormSectionId { get; set; }
        public virtual TaxFormSection? TaxFormSection { get; set; }
    }
}
