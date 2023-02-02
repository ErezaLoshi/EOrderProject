using System.ComponentModel.DataAnnotations;

namespace EOrderProject.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int Id { get; set; }

        public Menu Menu { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
