using System.ComponentModel.DataAnnotations;

namespace impotquebec.Web.Models
{
    public abstract class NamedEntity
    {
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
