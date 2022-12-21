using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        
    }
}
