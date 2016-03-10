using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopicZ.ViewModel
{
    public class CreateTopicModel
    {

        [Required(ErrorMessage="Topic must contain atleast 1 character")]
        [Display(Name = "Topic ")]
        [MaxLength(100)]
        public string TopicHeader { get; set; }
    }
}