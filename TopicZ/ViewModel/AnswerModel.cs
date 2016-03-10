using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopicZ.ViewModel
{
    public class AnswerModel
    {
        [Required]
        [MaxLength(400), MinLength(5)]
        [Display(Name = "Your Answer ")]
        public string AnswerBody { get; set; }


    }
}