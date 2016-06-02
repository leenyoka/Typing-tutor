using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class PracticeDifficultKeys
    {
        string userName;
        string skillID;
        string keyName;

        //constructor
        public PracticeDifficultKeys(string username, string skillid, string key)
        {
            userName = username;
            skillID = skillid;
            keyName = key;
        }

        //Properties
        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }
        

        public string SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        

        public string Keyname
        {
            get { return keyName; }
            set { keyName = value; }
        }
    }
}
