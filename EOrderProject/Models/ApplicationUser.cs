using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="FUll name")]

        public string FullName { get; set; }
    }
}
