using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMySQL
{
    public class Project
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Homepage { get; set; }
        public string Is_public { get; set; }
        public string Parent_id { get; set; }
        public string Created_on { get; set; }
        public string Updated_on { get; set; }
        public string Identifier { get; set; }
        public string Status { get; set; }
        public string Lft { get; set; }
        public string Rgt { get; set; }
        public string Inherit_members { get; set; }
        public string Default_version_id { get; set; }
        public string Default_assigned_to_id { get; set; }




        public Project(string id, string name, string description, string homepage, string is_public, string parent_id, string created_on, string updated_on, string identifier, string status, string lft, string rgt, string inherit_members, string default_version_id, string default_assigned_to_id)
        {
            Id = id;
            Name = name;
            Description = description;
            Homepage = homepage;
            Is_public = is_public;
            Parent_id = parent_id;
            Created_on = created_on;
            Updated_on = updated_on;
            Identifier = identifier;
            Status = status;
            Lft = lft;
            Rgt = rgt;
            Inherit_members = inherit_members;
            Default_version_id = default_version_id;
            Default_assigned_to_id = default_assigned_to_id;

        }
    }
}
