using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class User
    {
        string username;
        string password;



        //Constructor
        public User(string uname, string pword)
        {
            username = uname;
            password = pword;
        }
        public User()
        {

        }
        //Properties
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
