using EOrderProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EOrderProject.Models
{
    public class Staff:IEntityBase
    {

        [Key]
        public int Id { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a desciption!")]
        public string Description { get; set; }

        
    }
}
