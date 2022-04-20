using System.ComponentModel.DataAnnotations;

namespace Tchaps.Impotquebec.Models
{
    public class TaxFormLine: NamedEntity
    {
        public int TaxFormLineId { get; set; }
        public int TaxFormId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TaxForm? TaxForm { get; set; }

        [Display(Name = "Line Number")]
        public string LineNumber { get; set; }
        public short Rank { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "ReadOnly")]
        public bool IsReadOnly { get; set; }
        [Display(Name = "Required")]
        public bool IsRequired { get; set; }
        public int? TaxFormSectionId { get; set; }

        [Display(Name = "Section")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TaxFormSection? TaxFormSection { get; set; }

        public int? FormDataTypeId { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        [Display(Name = "Form DataType")]
        public virtual FormDataType? FormDataType { get; set; }

        public string? ItemLists { get; set; }
    }
}
