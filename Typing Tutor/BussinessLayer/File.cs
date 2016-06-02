using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class File
    {
        string fileID;
        string fileName;
        string location;
        string skillID;


        //Constructor
        public File(string n, string loc, string skill)
        {
            
            fileName = n;
            location = loc;
            skillID = skill;
        }
        
        //Properties
        public string FileID
        {
            get { return fileID; }
            set { fileID = value; }
        }
        
        public string Name
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        
        public string SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }

    }
}
