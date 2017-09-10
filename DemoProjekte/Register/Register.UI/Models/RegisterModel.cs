using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Register.UI.Models
{
    public class RegisterModel
    {
        /// Variante - so schauts aus!
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(Messages.required), ErrorMessageResourceType = typeof(Messages))]

        /// Variante - nett
        [StringLength(20, ErrorMessage = "max. 20 Zeichen", MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "Ungültige Mail")]
        [Display(Description = "Benutzername")]
        public string Username { get; set; }

        /// Variante - geht so
        [Required(ErrorMessage = "Pflichtfeld!")]
        public string Password { get; set; }

        /// Variante - super billig
        public string Confirmation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}