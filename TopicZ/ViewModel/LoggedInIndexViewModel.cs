using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TopicZ.ViewModel;

namespace TopicZ.ViewModel
{
    public class LoggedInIndexViewModel
    {

        public LoggedInIndexViewModel()
        {
            TopTenTopics = new TopTenTopicsModel();
        }


        public int TopicId { get; set; }

        private TopTenTopicsModel _topTenTopics;

        public TopTenTopicsModel TopTenTopics {
            get { return _topTenTopics;}
            set { _topTenTopics =value;} 
        }






    }
}