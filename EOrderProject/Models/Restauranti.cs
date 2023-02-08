using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EOrderProject.Models
{
    public class Restauranti
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        public int? PikatId { get; set; }
        [ForeignKey("PikatId")]
        public Pikat Pikas { get; set; }
    }
}
