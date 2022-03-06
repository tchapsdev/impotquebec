namespace impotquebec.Web.Models
{
    public class TaxForm: NamedEntity
    {
        public TaxForm()
        {
            TaxFormLines = new List<TaxFormLine>();
        }
        public int TaxFormId { get; set; }

        public string Code { get; set; }

        public IList<TaxFormLine> TaxFormLines { get; set; }
        public IList<TaxFormSection> TaxFormSections { get; set; }
    }
}
