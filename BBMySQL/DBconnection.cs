using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;

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

        public Project SelectProject()
        {
            string query = "SELECT * FROM projects";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Project project = null;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string uId = dataReader["id"].ToString();
                    string uName = dataReader["name"].ToString();
                    string uDescription = dataReader["description"].ToString();
                    string uHomepage = dataReader["homepage"].ToString();
                    string uIs_public = dataReader["is_public"].ToString();
                    string uParent_id = dataReader["parent_id"].ToString();
                    string uCreated_on = dataReader["created_on"].ToString();
                    string uUpdated_on = dataReader["updated_on"].ToString();
                    string uIdentifier = dataReader["identifier"].ToString();
                    string uStatus = dataReader["status"].ToString();
                    string uLft = dataReader["lft"].ToString();
                    string uRgt = dataReader["rgt"].ToString();
                    string uInherit_members = dataReader["inherit_members"].ToString();
                    string uDefault_version_id = dataReader["default_version_id"].ToString();
                    string uDefault_assigned_to_id = dataReader["default_assigned_to_id"].ToString();
                    if (uId != null)
                    {
                        project = new Project(uId, uName, uDescription, uHomepage, uIs_public, uParent_id, uCreated_on, uUpdated_on, uIdentifier, uStatus, uLft, uRgt, uInherit_members, uDefault_version_id, uDefault_assigned_to_id);
                        //send to api 
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return project;
            }
            else
            {
                return null;
            }
        }

        public Issue SelectIssue()
        {
            string query = "SELECT * FROM issues";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Issue issue = null;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string uId = dataReader["id"].ToString();
                    string uTracker_id = dataReader["tracker_id"].ToString();
                    string uProject_id = dataReader["project_id"].ToString();
                    string uSubject = dataReader["subject"].ToString();
                    string uDescription = dataReader["description"].ToString();
                    string uDue_date = dataReader["due_date"].ToString();
                    string uCategory_id = dataReader["category_id"].ToString();
                    string uStatus_id = dataReader["status_id"].ToString();
                    string uAssigned_to_id = dataReader["assigned_to_id"].ToString();
                    string uPriority_id = dataReader["Priority_id"].ToString();
                    string uFixed_versions_id = dataReader["Fixed_version_id"].ToString();
                    string uAuthor_id = dataReader["author_id"].ToString();
                    string uLock_version = dataReader["lock_version"].ToString();
                    string uCreated_on = dataReader["created_on"].ToString();
                    string uUpdated_on = dataReader["updated_on"].ToString();
                    string uStart_date = dataReader["start_date"].ToString();
                    string uDone_ratio = dataReader["done_ratio"].ToString();
                    string uEstimated_hours = dataReader["estimated_hours"].ToString();
                    string uParent_id = dataReader["parent_id"].ToString();
                    string uRoot_id = dataReader["root_id"].ToString();
                    string uLft = dataReader["lft"].ToString();
                    string uRgt = dataReader["rgt"].ToString();
                    string uIs_private = dataReader["is_private"].ToString();
                    string uClosed_on = dataReader["closed_on"].ToString();
                    if (uId != null)
                    {
                        issue = new Issue(uId, uTracker_id, uProject_id, uSubject, uDescription, uDue_date, uCategory_id, uStatus_id, uAssigned_to_id, uPriority_id, uFixed_versions_id, uAuthor_id, uLock_version, uCreated_on, uUpdated_on, uStart_date, uDone_ratio, uEstimated_hours, uParent_id, uRoot_id, uLft, uRgt, uIs_private, uClosed_on);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return issue;
            }
            else
            {
                return null;
            }
        }

        public TimeEntries SelectTimeEntries()
        {
            string query = "SELECT * FROM time_entries";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                TimeEntries time = null;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string uId = dataReader["id"].ToString();
                    string uProject_id = dataReader["project_id"].ToString();
                    string uUser_id = dataReader["user_id"].ToString();
                    string uHours = dataReader["hours"].ToString();
                    string uComments = dataReader["comments"].ToString();
                    string uActivity_id = dataReader["activity_id"].ToString();
                    string uSpent_on = dataReader["spent_on"].ToString();
                    string uTyear = dataReader["tyear"].ToString();
                    string uTmonth = dataReader["tmonth"].ToString();
                    string uTweek = dataReader["tweek"].ToString();
                    string uCreated_on = dataReader["created_on"].ToString() ;
                    string uUpdated_on = dataReader["updated_on"].ToString();
                    if (uId != null)
                    {
                        time = new TimeEntries(uId, uProject_id, uUser_id, uHours, uComments, uActivity_id, uSpent_on, uTyear, uTmonth, uTweek, uCreated_on, uUpdated_on);
                        
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return time;
            }
            else
            {
                return null;
            }
        }
        
        public Attachments SelectAttachments()
        {
            string query = "SELECT * FROM attachments";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Attachments file = null;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string uId = dataReader["id"].ToString();
                    string uContainer_id = dataReader["container_id"].ToString();
                    string uContainer_type = dataReader["container_type"].ToString();
                    string uFilename = dataReader["filename"].ToString();
                    string uDisk_filename = dataReader["disk_filename"].ToString();
                    string uFilesize = dataReader["filesize"].ToString();
                    string uContent_type = dataReader["content_type"].ToString();
                    string uDigest = dataReader["digest"].ToString();
                    string uDownloads = dataReader["downloads"].ToString();
                    string uAuthor_id = dataReader["author_id"].ToString();
                    string uCreated_on = dataReader["created_on"].ToString();
                    string uDescription = dataReader["description"].ToString();
                    string uDisk_directory = dataReader["disk_directory"].ToString();

                    if (uId != null)
                    {
                        file = new Attachments(uId, uContainer_id, uContainer_type, uFilename, uDisk_filename, uFilesize, uContent_type, uDigest, uDownloads, uAuthor_id, uCreated_on, uDescription, uDisk_directory);
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
