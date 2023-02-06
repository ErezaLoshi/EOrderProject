using EOrderProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EOrderProject.Models
{
    public class ComingSoon:IEntityBase
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

    }
}
