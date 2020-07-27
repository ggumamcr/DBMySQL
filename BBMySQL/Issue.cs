using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMySQL
{
    class Issue
    {
        public string Id { get; set; }
        public string Tracker_id { get; set; }
        public string Project_id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Due_date { get; set; }
        public string Category_id { get; set; }
        public string Status_id { get; set; }
        public string Assigned_to_id { get; set; }
        public string Priority_id { get; set; }
        public string Fixed_versions_id { get; set; }
        public string Author_id { get; set; }
        public string Lock_version { get; set; }
        public string Created_on { get; set; }
        public string Updated_on { get; set; }
        public string Start_date { get; set; }
        public string Done_ratio { get; set; }
        public string Estimated_hours { get; set; }
        public string Parent_id { get; set; }
        public string Root_id { get; set; }
        public string Lft { get; set; }
        public string Rgt { get; set; }
        public string Is_private { get; set; }
        public string Closed_on { get; set; }

        public Issue(string id, string tracker_id, string project_id, string subject, string description, string due_date, string category_id, string status_id, string assigned_to_id, string priority_id, string fixed_versions_id, string author_id, string lock_version, string created_on, string updated_on, string start_date, string done_ratio, string estimated_hours, string parent_id, string root_id, string lft, string rgt, string is_private, string closed_on)
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

        }
    }
}
