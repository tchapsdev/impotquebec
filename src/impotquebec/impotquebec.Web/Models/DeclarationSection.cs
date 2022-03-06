namespace impotquebec.Web.Models
{
    public class TaxFormSection: NamedEntity
    {
        public int TaxFormSectionId { get; set; }
        public int TaxFormId { get; set; }
        public virtual TaxForm? TaxForm { get; set; }
        public string InternalName { get; set; }
        public string LineNumbers { get; set; }// [12,,563, ]
        public int Rank { get; set; }
    }
}
