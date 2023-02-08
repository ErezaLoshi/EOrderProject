using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EOrderProject.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name!")]
        public string Name { get; set; }

        public int? PikaId { get; set; }
        [ForeignKey("PikaId")]
        public Pika Pika { get; set; }

}
}
