using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication34.Models
{
    public enum state
    {
        upload = 1,
        cart = 2,
        bought = 3
    }

    public class ProductsModel
    {
        [DisplayName("Date Added: ")]
        public DateTime date { get; set; }

        [Key]
        public long ID;

        public state status;

        public long userID;

        public long ownerID;
        
        [ForeignKey(nameof(userID))]
        public UsersModel user;

        [ForeignKey(nameof(ownerID))]
        public UsersModel owner;

        public DateTime dateAddedToCart { get; set; }
        public ProductsModel()
        {
            date = DateTime.Now;
            status = state.upload;
            isChecked = true;
        }

        [DisplayName("Title: ")]
        [Required(ErrorMessage = "Please enter a title to your product.")]
        [StringLength(50, ErrorMessage = "Product title must be less than {1} characters")]
        public string title { get; set; }

        [DisplayName("Short Description: ")]
        [StringLength(500, ErrorMessage = "Your description can include only {1} characters")]
        public string shortDescription { get; set; }

        [StringLength(4000, ErrorMessage = "Your description can include only {1} characters")]
        [DisplayName("Long Description: ")]
        [DataType(DataType.MultilineText)]
        public string longDescription { get; set; }

        [DisplayName("Price: ")]
        [RegularExpression("^[0-9]{1,18}$", ErrorMessage = "You can only enter positive number between 0 and 18 characters")]
        [Required(ErrorMessage = "Please enter the price of your product.")]
        public decimal price { get; set; }

        [DisplayName("Image 1: ")]
        public string image1 { get; set; }
        
        [DisplayName("Image 2: ")]
        public string image2 { get; set; }
        
        [DisplayName("Image 3: ")]
        public string image3 { get; set; }


        public bool isChecked { get; set; }
    }
}