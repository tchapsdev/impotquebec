namespace Tchaps.Impotquebec.Models
{
    public class DeclarationDetail
    {
        public int DeclarationId { get; set; }
        public float DeclarationDetailId { get; set; }
        public float LineNumber { get; set; }
        public string Value { get; set; }
        public DateTime Modified { get; set; }
    }
}
