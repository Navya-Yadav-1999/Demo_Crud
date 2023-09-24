using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCrudOperations.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Price")]
        public int Price { get; set; }
        public int CustomerId { get; set; }
    }
}
