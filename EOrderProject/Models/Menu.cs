using EOrderProject.Data.Base;
using EOrderProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EOrderProject.Models
{
    public class Menu:IEntityBase
    {

        [Key]
        public int Id { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter price")]
        public double Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select category")]
        public MenuCategory MenuCategory { get; set; }

    }
}
