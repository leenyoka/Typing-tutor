using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class UserSettings
    {
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string moName;

        public string MoName
        {
            get { return moName; }
            set { moName = value; }
        }
        string moValue;

        public string MoValue
        {
            get { return moValue; }
            set { moValue = value; }
        }


        public UserSettings()
        {
        }
        public UserSettings(string moName, string moValue)
        {
            this.MoName = moName;
            this.MoValue = moValue;
        }
        public UserSettings(string username, string moName, string moValue)
        {
            this.Username = username;
            this.MoName = moName;
            this.moValue = moValue;
        }


    }
}
