using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBMySQL
{
    [XmlRoot("attach")]
    public class Attachments
    {
        public string id { get; set; }
        public string container_id { get; set; }
        public string container_type { get; set; }
        public string filename { get; set; }
        public string disk_filename { get; set; }
        public string filesize { get; set; }
        public string content_type { get; set; }
        public string digest { get; set; }
        public string downloads { get; set; }
        public string author_id { get; set; }
        public string created_on { get; set; }
        public string description { get; set; }
        public string disk_directory { get; set; }

        /*public Attachments(string id, string container_id, string container_type, string filename, string disk_filename, string filesize, string content_type, string digest, string downloads, string author_id, string created_on, string description, string disk_directory)
        {
            Id = id;
            Container_id = container_id;
            Container_type = container_type;
            Filename = filename;
            Disk_filename = disk_filename;
            Filesize = filesize;
            Content_type = content_type;
            Digest = digest;
            Downloads = downloads;
            Author_id = author_id;
            Created_on = created_on;
            Description = description;
            Disk_directory = disk_directory;

        }*/
    }
    [XmlRoot("upload")]
    public class AttachToken
    {
        public string id { get; set; }
        public string token { get; set; }
    }

}
