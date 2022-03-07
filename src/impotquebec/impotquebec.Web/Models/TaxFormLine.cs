namespace impotquebec.Web.Models
{
    public class TaxFormLine: NamedEntity
    {
        public int TaxFormLineId { get; set; }
        public int TaxFormId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TaxForm? TaxForm { get; set; }
        
        public string LineNumber { get; set; }
        public short Rank { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsReadOnly { get; set; }
        public bool IsRequired { get; set; }
        public int? TaxFormSectionId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual TaxFormSection? TaxFormSection { get; set; }

        public int? FormDataTypeId { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual FormDataType? FormDataType { get; set; }

        public string? ItemLists { get; set; }
    }
}
