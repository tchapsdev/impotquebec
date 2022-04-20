using System.ComponentModel.DataAnnotations;

namespace Tchaps.Impotquebec.Models
{
    public class TaxFormSection: NamedEntity
    {
        public TaxFormSection()
        {
            TaxFormLines = new List<TaxFormLine>();
        }
        public int TaxFormSectionId { get; set; }

        public int TaxFormId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TaxForm? TaxForm { get; set; }

        [Display(Name = "Internal Name")]
        public string InternalName { get; set; }

        [Display(Name = "Line Number")]
        public string LineNumbers { get; set; }// [12,,563, ]

        public int Rank { get; set; }
        public virtual IList<TaxFormLine> TaxFormLines { get; set; }
    }
}
