using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication34.Validiators;

namespace WebApplication34.Models
{
    [UserLoginValidator(ErrorMessage = "The user name or password you’ve entered doesn’t match any account.")]
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter your user name")]
        [DisplayName("User Name")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}