using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploEnClase.Model
{
    [Table("Order Details")]
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}
