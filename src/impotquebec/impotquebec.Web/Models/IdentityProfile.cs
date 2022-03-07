using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tchaps.Impotquebec.Models
{
    public class IdentityProfile
    {
        public int IdentityProfileId { get; set; }
        public string UserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual IdentityUser? User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; } // M/F
        public string Language { get; set; } // fr/en
        public string Ssn { get; set; }

        public string AddressApartment { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressStreetName { get; set; }
        [DataType(DataType.PostalCode)]
        public string AddressPostalCode { get; set; }
        public string AddressMunicipality { get; set; }
        public string AddressProvince { get; set; }       
    }
}
