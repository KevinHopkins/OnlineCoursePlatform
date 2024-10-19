using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityFromScratch.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required] 
        
    public string SelectedCountryCode { get; set; }
    
    [Required]
    public List<SelectListItem> CountryCodes = new List<SelectListItem>()
    {
        // English-Speaking Countries
        new SelectListItem { Value = "+44", Text = "United Kingdom (+44)" },
        new SelectListItem { Value = "+1", Text = "United States (+1)" },
        new SelectListItem { Value = "+61", Text = "Australia (+61)" },
        new SelectListItem { Value = "+64", Text = "New Zealand (+64)" },
        new SelectListItem { Value = "+1-242", Text = "Bahamas (+1-242)" },
        new SelectListItem { Value = "+1-246", Text = "Barbados (+1-246)" },
        new SelectListItem { Value = "+1-441", Text = "Bermuda (+1-441)" },
        new SelectListItem { Value = "+1-284", Text = "British Virgin Islands (+1-284)" },
        new SelectListItem { Value = "+1-345", Text = "Cayman Islands (+1-345)" },
        new SelectListItem { Value = "+1-767", Text = "Dominica (+1-767)" },
        new SelectListItem { Value = "+1-473", Text = "Grenada (+1-473)" },
        new SelectListItem { Value = "+1-876", Text = "Jamaica (+1-876)" },
        new SelectListItem { Value = "+1-664", Text = "Montserrat (+1-664)" },
        new SelectListItem { Value = "+1-869", Text = "Saint Kitts and Nevis (+1-869)" },
        new SelectListItem { Value = "+1-758", Text = "Saint Lucia (+1-758)" },
        new SelectListItem { Value = "+1-784", Text = "Saint Vincent and the Grenadines (+1-784)" },
        new SelectListItem { Value = "+1-868", Text = "Trinidad and Tobago (+1-868)" },
        new SelectListItem { Value = "+27", Text = "South Africa (+27)" },

        // EU Member Countries
        new SelectListItem { Value = "+43", Text = "Austria (+43)" },
        new SelectListItem { Value = "+32", Text = "Belgium (+32)" },
        new SelectListItem { Value = "+359", Text = "Bulgaria (+359)" },
        new SelectListItem { Value = "+357", Text = "Cyprus (+357)" },
        new SelectListItem { Value = "+420", Text = "Czech Republic (+420)" },
        new SelectListItem { Value = "+45", Text = "Denmark (+45)" },
        new SelectListItem { Value = "+372", Text = "Estonia (+372)" },
        new SelectListItem { Value = "+358", Text = "Finland (+358)" },
        new SelectListItem { Value = "+33", Text = "France (+33)" },
        new SelectListItem { Value = "+49", Text = "Germany (+49)" },
        new SelectListItem { Value = "+30", Text = "Greece (+30)" },
        new SelectListItem { Value = "+36", Text = "Hungary (+36)" },
        new SelectListItem { Value = "+353", Text = "Ireland (+353)" },
        new SelectListItem { Value = "+39", Text = "Italy (+39)" },
        new SelectListItem { Value = "+371", Text = "Latvia (+371)" },
        new SelectListItem { Value = "+370", Text = "Lithuania (+370)" },
        new SelectListItem { Value = "+352", Text = "Luxembourg (+352)" },
        new SelectListItem { Value = "+356", Text = "Malta (+356)" },
        new SelectListItem { Value = "+31", Text = "Netherlands (+31)" },
        new SelectListItem { Value = "+48", Text = "Poland (+48)" },
        new SelectListItem { Value = "+351", Text = "Portugal (+351)" },
        new SelectListItem { Value = "+40", Text = "Romania (+40)" },
        new SelectListItem { Value = "+421", Text = "Slovakia (+421)" },
        new SelectListItem { Value = "+386", Text = "Slovenia (+386)" },
        new SelectListItem { Value = "+34", Text = "Spain (+34)" },
        new SelectListItem { Value = "+46", Text = "Sweden (+46)" },

        // Non-EU European Country
        new SelectListItem { Value = "+41", Text = "Switzerland (+41)" }
    };
    
}