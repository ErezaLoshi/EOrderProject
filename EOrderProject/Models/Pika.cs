using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class Pika
    {
        [Key]
        public int Id { get; set; }

        public string Qyteti { get; set; }

        public string Info { get; set; }


    }
}
