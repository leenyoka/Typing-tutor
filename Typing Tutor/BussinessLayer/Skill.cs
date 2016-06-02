using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
   public class Skill
    {
        string skillID;
        string skillName;


       //Constructor
        public Skill(string sk, string skID)
        {
            skillID = skID;
            skillName = sk; 
        }


       //Properties
        public string SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        

        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }

    }
}
