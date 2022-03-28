namespace Tchaps.Impotquebec.Models
{
    public class TaxForm: NamedEntity
    {
        public TaxForm()
        {
            TaxFormSections = new List<TaxFormSection>();
        }
        public int TaxFormId { get; set; }

        public string Code { get; set; }

        //public IList<TaxFormLine> TaxFormLines { get; set; }
        public IList<TaxFormSection> TaxFormSections { get; set; }

        public bool Active { get; set; }
    }
}
