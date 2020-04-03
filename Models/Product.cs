using System.ComponentModel.DataAnnotations;

namespace Bid_A_Product_MVC.Models
{
    //Product information
    public class Product
    {
        //Primary key 
        public int Id { get; set; }

        //Name of the product
        [Required]
        public string ProductName { get; set; }

        //Product registration external identifier.
        public string ProductRegistrationId
        {

            get
            {

                return "PRODUCT-" + Id + "-" + ProductName;
            }
        }

        //Starting bid price of the product
        public decimal StartingPrice { get; set; }

        //Flag indicating product is sold or not.
        public bool IsSold { get; set; }

    }
}
