using Microsoft.AspNetCore.Identity;

namespace impotquebec.Web.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; } // M/F
        public string Language { get; set; } // fr/en
        public string Ssn { get; set; }

        public string AddressApartment { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressStreetName { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressMunicipality { get; set; }
        public string AddressProvince { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
