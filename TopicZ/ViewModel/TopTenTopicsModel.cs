using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TopicZ.ViewModel.Objects;

namespace TopicZ.ViewModel
{
    public class TopTenTopicsModel
    {


        SqlDataReader rdr;
        SqlConnection dbconn;

        public TopTenTopicsModel()
        {
            SetTenLatestTopics();
        }



        private void SetTenLatestTopics()
        {
            using(var db = new TopicZContext())
            {
                IEnumerable<Topic> topicList = db.Topics.ToList().OrderByDescending(topic=> topic.TopicDateTime);
                TenLatestTopics = topicList;
                
            }

            //dbconn = new SqlConnection("Server=(Local);DataBase=TopicZ;Integrated Security=SSPI");
            //dbconn.Open();
            //rdr = new SqlCommand("Select TopicHeadline, TopicDateTime, TopicId From Topic Order By TopicDateTime DESC", dbconn).ExecuteReader();



            //if (rdr.HasRows)
            //{
            //   // List<string> rows = new List<string>();
            //    List<TopicObject> topicObjectList = new List<TopicObject>();

            //    while (rdr.Read())
            //    {
            //        TopicObject to = new TopicObject() { TopicHeadline = rdr.GetString(0), TopicDate = rdr.GetDateTime(1).ToShortDateString(), TopicTime = rdr.GetDateTime(1).ToShortTimeString(), TopicId = rdr.GetInt32(2) };
            //        topicObjectList.Add(to);
            //        //rows.Add(rdr.GetString(0));
            //    }
            //    rdr.Close();

            //    TenLatestTopics = topicObjectList;
            



        }
    
        private IEnumerable<Topic> _tenLatestTopics;

        public IEnumerable<Topic> TenLatestTopics
        {
            get
            {
                return _tenLatestTopics;
            }
            set
            {
                _tenLatestTopics = value;
            }
        }

    }
}