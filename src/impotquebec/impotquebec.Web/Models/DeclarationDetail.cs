namespace Tchaps.Impotquebec.Models
{
    public class DeclarationDetail
    {
        public int DeclarationDetailId { get; set; }
        public int DeclarationId { get; set; }
        public int TaxFormLineId { get; set; }
        public float LineNumber { get; set; }
        public string Value { get; set; } = "";
        public DateTime? Modified { get; set; }

        public override string ToString()
        {
            return $"DetailId: {DeclarationDetailId}, LineId: {TaxFormLineId}, LineNumber: {LineNumber}, Value: {Value}";
        }
    }
}
