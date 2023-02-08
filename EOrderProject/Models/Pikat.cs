using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class Pikat
    {
        [Key]
        public int Id { get; set; }

        public string Qyteti { get; set; }

        public string Info { get; set; }
    }
}
