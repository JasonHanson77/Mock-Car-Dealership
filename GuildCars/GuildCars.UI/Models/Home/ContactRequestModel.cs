using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ContactRequestModel : IValidatableObject
    {   
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [StringLength(13, MinimumLength = 10)]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
        public string VIN { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {
                errors.Add(new ValidationResult("You must enter either a phone number or email to so we can contact you.",
                    new[] { "Email", "Phone" }));
            }

            return errors;
        }
    }
}