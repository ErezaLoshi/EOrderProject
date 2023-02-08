using EOrderProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class PikatEShitjes : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter a city!")]
        public string City { get; set; }

        [Display(Name = "Info")]
        [Required(ErrorMessage = "Please enter more Info!")]
        public string Info { get; set; }

    }
}
