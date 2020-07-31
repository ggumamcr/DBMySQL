using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBMySQL
{
    [XmlRoot("issue")]
    public class Issue
    {
        public string id { get; set; }        
        public string project_id { get; set; }
        public string tracker_id { get; set; }
        public string status_id { get; set; }
        public string priority_id { get; set; }
        public string author_id { get; set; }
        public string assigned_to_id { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        //public string start_date { get; set; }
        //public string due_date { get; set; }
        public string done_ratio { get; set; }
        public string estimated_hours { get; set; }

        /*public string category_id { get; set; }
        public string fixed_versions_id { get; set; }
        public string lock_version { get; set; }
        public string created_on { get; set; }
        public string updated_on { get; set; }
        public string parent_id { get; set; }
        public string root_id { get; set; }
        public string lft { get; set; }
        public string rgt { get; set; }
        public string is_private { get; set; }
        public string closed_on { get; set; }*/

        /*public Issue(string id, string tracker_id, string project_id, string subject, string description, string due_date, string category_id, string status_id, string assigned_to_id, string priority_id, string fixed_versions_id, string author_id, string lock_version, string created_on, string updated_on, string start_date, string done_ratio, string estimated_hours, string parent_id, string root_id, string lft, string rgt, string is_private, string closed_on)
        {
            Id = id;
            Tracker_id = tracker_id;
            Project_id = project_id;
            Subject = subject;
            Description = description;
            Due_date = due_date;
            Category_id = category_id;
            Status_id = status_id;
            Assigned_to_id = assigned_to_id;
            Priority_id = priority_id;
            Fixed_versions_id = fixed_versions_id;
            Author_id = author_id;
            Lock_version = lock_version;
            Created_on = created_on;
            Updated_on = updated_on;
            Start_date = start_date;
            Done_ratio = done_ratio;
            Estimated_hours = estimated_hours;
            Parent_id = parent_id;
            Root_id = root_id;
            Lft = lft;
            Rgt = rgt;
            Is_private = is_private;
            Closed_on = closed_on;

        }*/
    }

    public class IssueReturn
    {
        public string id { get; set; }
    }
}
