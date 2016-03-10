using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopicZ.ViewModel.Objects
{
    public class TopicObject
    {

        public int TopicId { get; set; }
        public string TopicHeadline { get; set; }

        public string TopicDate { get; set; }

        public string TopicTime { get; set; }

        public int AuthorId { get; set; }
    }
}