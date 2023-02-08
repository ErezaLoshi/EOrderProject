using EOrderProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EOrderProject.Models
{
    public class Issue:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter a surname!")]
        public string Surname { get; set; }

        [Display(Name = "Issues")]
        [Required(ErrorMessage = "Please enter an issue!")]
        public string Issues { get; set; }

        [Display(Name = "Suggestion")]
        [Required(ErrorMessage = "Please enter a suggestion!")]
        public string Suggestion { get; set; }
    }
}
