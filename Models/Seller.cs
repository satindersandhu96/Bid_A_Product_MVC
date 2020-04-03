using System.ComponentModel.DataAnnotations;

namespace Bid_A_Product_MVC.Models
{
    //Seller information
    public class Seller
    {
        //Seller primary key
        public int Id { get; set; }

        //Seller name
        [Required]
        public string SellerName { get; set; }

        //Seller external registration number.
        public string SellerRegistrationNumber
        {
            get
            {

                return "SELLER-" + Id + "-" + SellerName;
            }
        }

        //Seller contact information
        public string ContactNumber { get; set; }



    }
}
