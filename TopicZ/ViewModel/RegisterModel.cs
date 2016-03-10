using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;


namespace TopicZ.ViewModel
{
    public class RegisterModel
    {

        


        [Required]
        [EmailAddress] //Typen
        [StringLength(200)] //Kolla propertyn för email
        [Display(Name = "Email adress ")]
        [Remote("CheckUserName", "Home", ErrorMessage = "Already in use!")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]  //Datatypen
        [MaxLength(50), MinLength(6)]
        [Display(Name = "Password ")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Name ")]
        [MaxLength(50)]
        public string Name { get; set; }


        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The comfirmed password does not match")]
        public string ConfirmedPassword { get; set; }

    }
}