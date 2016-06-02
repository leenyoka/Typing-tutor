using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
   public class UserSkill
    {
        string userName;
        string skillID;
        string speed;
        string accuracy;  

       //constructor
        public UserSkill(string name, string id, string sp, string acc)
        {
            userName = name;
            skillID = id;
            speed = sp;
            accuracy = acc;
        }
        public UserSkill()
        {
        }


       //Properties
       public string Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }
       public string Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        

        public string SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }

    }
}
