using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication34.Validiators;

namespace WebApplication34.Models
{
    public class UsersModel
    {
        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(50, ErrorMessage = "Your first name must be less than {1} characters")]
        public string firstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(50, ErrorMessage = "Your last name must be less than {1} characters")]
        public string lastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Birth Date: ")]
        [Required(ErrorMessage = "Please enter your birth date.")]
        public DateTime birthDate { get; set; }

        [DisplayName("Email: ")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Your email must be less than {1} characters")]
        [Required(ErrorMessage = "Please enter your email.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Your email must include @ and .")]
        public string email { get; set; }

        [DisplayName("User Name: ")]
        [UserNameValidiation(ErrorMessage = "this user name already exist. Please choose another")]
        [Required(ErrorMessage = "Please enter a user name.")]
        [StringLength(50, ErrorMessage = "Your user name must be less than {1} characters")]
        public string userName { get; set; }

        [StringLength(maximumLength: 18, ErrorMessage = "Your password must be between {2} and {1} characters",
            MinimumLength = 4)]
        [DisplayName("Password: ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }

        [DisplayName("Confirm Your Password: ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password again")]
        [Compare("password", ErrorMessage = "These passwords don't match. Please try again.")]
        public string passwordValidiation { get; set; }


      }
}