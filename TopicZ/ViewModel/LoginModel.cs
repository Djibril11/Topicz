using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopicZ.ViewModel
{
    public class LoginModel
    {


        [Required]
        [EmailAddress] //Typen
        [StringLength(200)] //Kolla propertyn för email
        [Display(Name = "Email adress ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]  //Datatypen
        [MaxLength(50), MinLength(6)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

    }
}