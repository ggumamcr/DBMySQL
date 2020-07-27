using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMySQL
{
    class Attachments
    {
        public string Id { get; set; }
        public string Container_id { get; set; }
        public string Container_type { get; set; }
        public string Filename { get; set; }
        public string Disk_filename { get; set; }
        public string Filesize { get; set; }
        public string Content_type { get; set; }
        public string Digest { get; set; }
        public string Downloads { get; set; }
        public string Author_id { get; set; }
        public string Created_on { get; set; }
        public string Description { get; set; }
        public string Disk_directory { get; set; }

        public Attachments(string id, string container_id, string container_type, string filename, string disk_filename, string filesize, string content_type, string digest, string downloads, string author_id, string created_on, string description, string disk_directory)
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

        }
    }
}
