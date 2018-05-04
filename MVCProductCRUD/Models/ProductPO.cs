using System.ComponentModel.DataAnnotations;

namespace MVCProductCRUD.Models
{
    public class ProductPO
    {
        //Declaring class properties for a ProductPO
        public int ProductID { get; set; }

        [Required]
        [StringLength(40,ErrorMessage ="Product name must be less than 40 characters long!")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Quantity per unit must less than 20 characters long!")]
        public string QuantityPerUnit { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short UnitsInStock { get; set; }

        [Required]
        public short UnitsOnOrder { get; set; }
    }
}