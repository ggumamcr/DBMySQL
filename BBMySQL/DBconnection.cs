using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using DocumentFormat.OpenXml.Drawing;
using System.Globalization;
using Org.BouncyCastle.Asn1.Cms;
using System.Linq;

namespace BBMySQL
{
    class DBconnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBconnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "bitnami_redmineplusagile";
            uid = "root";
            password = "Juliol2020";
            string connStr = "server=localhost;user=root;database=bitnami_redmineplusagile;port=3308;password=Juliol2020";

            connection = new MySqlConnection(connStr);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async System.Threading.Tasks.Task SelectProjectAsync()
        {
            List<Project> pList = new List<Project>();
            pList = ListProjects();

            List<Tuple<string, string>> tIds = new List<Tuple<string, string>>();
            TextWriter tw = new StreamWriter("projects.txt");
            foreach (Project oprg in pList)
            {
                Tuple<string, string> ids = new Tuple<string, string> (oprg.id, await Api.PostProject(oprg, tIds));
                tIds.Add(ids);
                List<Issue> iList = new List<Issue>();
                iList = ListIssue(ids.Item1, ids.Item2);
                tw.WriteLine(ids.Item1 + " " + ids.Item2);



                foreach (Issue i in iList)
                {
                    /*AttachToken token = await Api.PostUploadP();
                    //await Api.PostAttachP(token, returned.id);
                    upload upload = new upload();
                    upload.token = token.token;
                    upload.filename = "provaa.txt";
                    upload.content_type = "text/plain";
                    uploads uploads = new uploads();
                    uploads.type = "array";
                    uploads.upload = upload;
                    i.uploads = uploads;*/
                    List<Attachments> aList = new List<Attachments>();
                    aList = SelectAttachments(i.id);

                    if (aList != null)
                    {
                        int index = 0;
                        uploads uploads = new uploads();
                        uploads.type = "array";
                        uploads.upload = new upload[aList.Count];
                        foreach (Attachments a in aList)
                        {
                            AttachToken token = await Api.PostUpload(a);
                            upload upload = new upload();
                            upload.token = token.token;
                            upload.filename = a.filename;
                            upload.content_type = a.content_type;
                            uploads.upload[index] = upload;
                            i.uploads = uploads; 
                            index++;
                        }
                    }
                    Issue returned = await Api.PostIssue(i);
                    tw.WriteLine("   " + returned.subject);


                    List<TimeEntries> tList = new List<TimeEntries>();
                    tList = ListTimeEntries(i.id, returned.id, i.project_id);

                    foreach (TimeEntries Time in tList)
                    {
                        string returnedTime = await Api.PostTimeEntry(Time);
                        tw.WriteLine("        " + returnedTime);
                    }
                    
                   
                }
            }
            
            MessageBox.Show("Done");
            
        }

        public Project ReadDBProject(MySqlDataReader dataReader)
        {
            Project project = new Project();
            project.id = dataReader["id"].ToString();
            project.name = RemoveDiacritics(dataReader["name"].ToString());
            project.description = RemoveDiacritics(dataReader["description"].ToString());
            project.homepage = dataReader["homepage"].ToString();
            project.is_public = dataReader["is_public"].ToString();
            project.parent_id = dataReader["parent_id"].ToString();
            project.created_on = dataReader["created_on"].ToString();
            project.updated_on = dataReader["updated_on"].ToString();
            project.identifier = dataReader["identifier"].ToString();
            project.status = dataReader["status"].ToString();
            project.lft = dataReader["lft"].ToString();
            project.rgt = dataReader["rgt"].ToString();
            project.inherit_members = dataReader["inherit_members"].ToString();
            project.default_version_id = dataReader["default_version_id"].ToString();
            project.default_assigned_to_id = dataReader["default_assigned_to_id"].ToString();
            return project;
        }

        public List<Project> ListProjects()
        {
            string query = "SELECT * FROM projects WHERE id<100";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Project> pList = new List<Project>();
                //Public lstReadOF_BBDD As New List(Of CLSLinFormulaDB)

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Project project = new Project();
                    project = ReadDBProject(dataReader);
                    if (project.id != null)
                    {
                        pList.Add(project);
                    }
                    else
                    {
                        bool note = false;
                    }
                }

                dataReader.Close();
                this.CloseConnection();
                return pList;
            }
            else
            {
                return null;
            }
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        
        public List<Issue> ListIssue(string id, string new_id)
        {
            string query = "SELECT * FROM issues WHERE project_id="+id;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Issue> iList = new List<Issue>();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Issue issue = new Issue();
                    issue = ReadDBIssue(dataReader);
                    issue.project_id = new_id;
                    issue.priority_id = "12";
                    issue.author_id = "5";
                    if (issue != null)
                    { 
                        iList.Add(issue);
                    }
                }
                dataReader.Close();
                this.CloseConnection();

                return iList;
            }
            else
            {
                return null;
            }

        }
        public Issue ReadDBIssue(MySqlDataReader dataReader)
        {
            Issue issue = new Issue();
            issue.id = dataReader["id"].ToString();
            issue.tracker_id = dataReader["tracker_id"].ToString();
            issue.project_id = dataReader["project_id"].ToString();
            issue.subject = dataReader["subject"].ToString();
            issue.description = dataReader["description"].ToString();
            //issue.due_date = dataReader["due_date"].ToString();
            //issue.category_id = dataReader["category_id"].ToString();
            issue.status_id = dataReader["status_id"].ToString();
            issue.assigned_to_id = dataReader["assigned_to_id"].ToString();
            issue.priority_id = dataReader["Priority_id"].ToString();
            //issue.fixed_versions_id = dataReader["Fixed_version_id"].ToString();
            issue.author_id = dataReader["author_id"].ToString();
            //issue.lock_version = dataReader["lock_version"].ToString();
            //issue.created_on = dataReader["created_on"].ToString();
            //issue.updated_on = dataReader["updated_on"].ToString();
            //issue.start_date = dataReader["start_date"].ToString();
            issue.done_ratio = dataReader["done_ratio"].ToString();
            issue.estimated_hours = dataReader["estimated_hours"].ToString();
            //issue.parent_id = dataReader["parent_id"].ToString();
            //issue.root_id = dataReader["root_id"].ToString();
            //issue.lft = dataReader["lft"].ToString();
            //issue.rgt = dataReader["rgt"].ToString();
            //issue.is_private = dataReader["is_private"].ToString();
            //issue.closed_on = dataReader["closed_on"].ToString();
            return issue;
        }

        public List<TimeEntries> ListTimeEntries(string issue_id, string new_id, string project_id)
        {
            string query = "SELECT * FROM time_entries WHERE issue_id="+issue_id;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<TimeEntries> tList = new List<TimeEntries>();

                while (dataReader.Read())
                {
                    TimeEntries tEntry = new TimeEntries();
                    tEntry = ReadDBTime(dataReader);
                    tEntry.issue_id = new_id;
                    if (tEntry != null)
                    {
                        tList.Add(tEntry);
                    }
                }
                dataReader.Close();
                this.CloseConnection();

                return tList;
            }
            else
            {
                return null;
            }
        }

        public TimeEntries ReadDBTime(MySqlDataReader dataReader)
        {
            TimeEntries tEntry = new TimeEntries();
            //tEntry.project_id = dataReader["project_id"].ToString();
            //tEntry.user_id = dataReader["user_id"].ToString();
            tEntry.hours = dataReader["hours"].ToString();
            tEntry.issue_id = dataReader["issue_id"].ToString();
            /*tEntry.comments = dataReader["comments"].ToString();
            tEntry.activity_id = dataReader["activity_id"].ToString();
            tEntry.spent_on = dataReader["spent_on"].ToString();
            tEntry.tyear = dataReader["tyear"].ToString();
            tEntry.tmonth = dataReader["tmonth"].ToString();
            tEntry.tweek = dataReader["tweek"].ToString();
            tEntry.created_on = dataReader["created_on"].ToString();
            tEntry.updated_on = dataReader["updated_on"].ToString();*/
            return tEntry;
        }

        public List<Attachments> SelectAttachments(string issue_id)
        {
            string query = "SELECT * FROM attachments WHERE container_type='Issue' and container_id="+issue_id;


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<Attachments> file = new List<Attachments>();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Attachments att = new Attachments();
                    att.id = dataReader["id"].ToString();
                    att.container_id = dataReader["container_id"].ToString();
                    att.container_type = dataReader["container_type"].ToString();
                    att.filename = dataReader["filename"].ToString();
                    att.disk_filename = dataReader["disk_filename"].ToString();
                    att.filesize = dataReader["filesize"].ToString();
                    att.content_type = dataReader["content_type"].ToString();
                    att.digest = dataReader["digest"].ToString();
                    att.downloads = dataReader["downloads"].ToString();
                    att.author_id = dataReader["author_id"].ToString();
                    att.created_on = dataReader["created_on"].ToString();
                    att.description = dataReader["description"].ToString();
                    att.disk_directory = dataReader["disk_directory"].ToString();

                    if (att != null)
                    {
                        file.Add(att);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return file;
            }
            else
            {
                return null;
            }
        }

        public Users SelectUsers()
        {
            string query = "SELECT * FROM users";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Users user = null;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string uId = dataReader["id"].ToString();
                    string uLogin = dataReader["login"].ToString();
                    string uHashed_password = dataReader["hashed_password"].ToString();
                    string uFirstname = dataReader["firstname"].ToString();
                    string uLastname = dataReader["lastname"].ToString();
                    string uAdmin = dataReader["admin"].ToString();
                    string uStatus = dataReader["status"].ToString();
                    string uLast_login_on = dataReader["last_login_on"].ToString();
                    string uLanguage = dataReader["Language"].ToString();
                    string uAuth_source_id = dataReader["auth_source_id"].ToString();
                    string uCreated_on = dataReader["created_on"].ToString();
                    string uUpdated_on = dataReader["updated_on"].ToString();
                    string uType = dataReader["type"].ToString();
                    string uIdentity_url = dataReader["identity_url"].ToString();
                    string uMail_notification = dataReader["mail_notification"].ToString();
                    string uSalt = dataReader["salt"].ToString();
                    string uMust_change_passwd = dataReader["must_change_passwd"].ToString();
                    string uPasswd_changed_on = dataReader["passwd_changed_on"].ToString();
                    string uLock_comment = dataReader["lock_comment"].ToString();

                    if (uId != null)
                    {
                        user = new Users(uId, uLogin, uHashed_password, uFirstname, uLastname, uAdmin, uStatus, uLast_login_on, uLanguage, uAuth_source_id, uCreated_on, uUpdated_on, uType, uIdentity_url, uMail_notification, uSalt, uMust_change_passwd, uPasswd_changed_on, uLock_comment);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
