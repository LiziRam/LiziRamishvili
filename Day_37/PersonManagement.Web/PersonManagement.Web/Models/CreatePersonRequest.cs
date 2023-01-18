using PersonManagement.Web.Infrastructure.Attributes;
using PersonManagement.Web.Infrastructure.Localizations;
using System.ComponentModel.DataAnnotations;

namespace PersonManagement.Web.Models
{
    public class CreatePersonRequest
    {
        [GeorgianOnlyAttribute]
        public string CityName { get; set; }

        [GeorgianOnlyAttribute]
        public string FirstName { get; set; }

        [GeorgianOnlyAttribute]
        public string LastName { get; set; }

        [StringLength(11, ErrorMessage = "{0} value must be between {2} and {1}", MinimumLength = 9)]
        public string Identifier { get; set; }

        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }
    }

}
