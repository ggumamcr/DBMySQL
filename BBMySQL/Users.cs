using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMySQL
{
    class Users
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Hashed_password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Admin { get; set; }
        public string Status { get; set; }
        public string Last_login_on { get; set; }
        public string Language { get; set; }
        public string Auth_source_id { get; set; }
        public string Created_on { get; set; }
        public string Updated_on { get; set; }
        public string Type { get; set; }
        public string Identity_url { get; set; }
        public string Mail_notification { get; set; }
        public string Salt { get; set; }
        public string Must_change_passwd { get; set; }
        public string Passwd_changed_on { get; set; }
        public string Lock_comment { get; set; }

        public Users(string id, string login, string hashed_password, string firstname, string lastname, string admin, string status, string last_login_on, string language, string auth_source_id , string created_on, string updated_on, string type, string identity_url , string mail_notification , string salt, string must_change_passwd, string passwd_changed_on , string lock_comment)
        {
            Id = id;
            Login = login;
            Hashed_password = hashed_password;
            Firstname = firstname;
            Lastname = lastname;
            Admin = admin;
            Status = status;
            Last_login_on = last_login_on;
            Language = Language;
            Auth_source_id = auth_source_id;
            Created_on = created_on;
            Updated_on = updated_on;
            Type = type;
            Identity_url = identity_url;
            Mail_notification = mail_notification;
            Salt = salt;
            Must_change_passwd = must_change_passwd;
            Passwd_changed_on = passwd_changed_on;
            Lock_comment = lock_comment;

    }
    }
}
