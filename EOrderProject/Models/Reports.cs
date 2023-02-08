using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class Reports
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter a surname!")]
        public string Surname { get; set; }

        [Display(Name = "Reports")]
        [Required(ErrorMessage = "Please enter an issue!")]
        public string Issues { get; set; }

        [Display(Name = "Suggestions")]
        [Required(ErrorMessage = "Please enter a suggestion!")]
        public string Suggestion { get; set; }
    }
}
