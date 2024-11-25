using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Model
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal  UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsInOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }


    }
}
