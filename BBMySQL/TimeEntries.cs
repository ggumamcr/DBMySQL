using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMySQL
{
    class TimeEntries
    {
        public string Id { get; set; }
        public string Project_id { get; set; }
        public string User_id { get; set; }
        public string Issue_id { get; set; }
        public string Hours { get; set; }
        public string Comments { get; set; }
        public string Activity_id { get; set; }
        public string Spent_on { get; set; }
        public string Tyear { get; set; }
        public string Tmonth { get; set; }
        public string Tweek { get; set; }
        public string Created_on { get; set; }
        public string Updated_on { get; set; }

        public TimeEntries(string id, string project_id, string user_id, string hours, string comments, string activity_id, string spent_on, string tyear, string tmonth, string tweek, string created_on, string updated_on)
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

        }

    }
}
