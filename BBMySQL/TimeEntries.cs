using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBMySQL
{
    [XmlRoot("time_entry")]
    public class TimeEntries
    {
        //public string Id { get; set; }
        //public string project_id { get; set; }
        //public string user_id { get; set; }
        public string issue_id { get; set; }
        public string hours { get; set; }
        /*public string comments { get; set; }
        public string activity_id { get; set; }
        public string spent_on { get; set; }
        public string tyear { get; set; }
        public string tmonth { get; set; }
        public string tweek { get; set; }
        public string created_on { get; set; }
        public string updated_on { get; set; }

        /*public TimeEntries(string id, string project_id, string user_id, string hours, string comments, string activity_id, string spent_on, string tyear, string tmonth, string tweek, string created_on, string updated_on)
        {
            Id = id;
            Project_id = project_id;
            User_id = user_id;
            Hours = hours;
            Comments = comments;
            Activity_id = activity_id;
            Spent_on = spent_on;
            Tyear = tyear;
            Tmonth = tmonth;
            Tweek = tweek;
            Created_on = created_on;
            Updated_on = updated_on;

        }*/

    }
}
