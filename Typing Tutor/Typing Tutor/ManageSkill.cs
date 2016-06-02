using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessLayer;

namespace Typing_Tutor
{
    public class ManageSkill
    {
        string currentSkill;
        string[,] skills = new string[3, 7];
        bool firsttime;

        public bool Firsttime
        {
            get { return firsttime; }
            set { firsttime = value; }
        }


        //Constructor
        public ManageSkill()
        {
            currentSkill = "HR";
            initailizeSkills();
            Firsttime = true;
        }

        #region Properties
        //Properties
        public string CurrentSkill
        {
            get { return currentSkill; }
            set { currentSkill = value; }
        }
        

        public string[,] Skills
        {
            get { return skills; }
            set { skills = value; }
        }
        #endregion Properties

        #region Methods
        //adds a skill to the skills array
        public void addSkill(string skillID, int speed, int accuracy)
        {
            try
            {
                    for (int k = 0; k < 6; k++)
                    {
                        if (skills[0, k] == skillID)
                        {
                            
                            skills[1, k] = speed.ToString();
                            skills[2, k] = accuracy.ToString();
                        }
                    }
                
            }
            catch
            {
                throw new ApplicationException("Error adding skill to the skills array");
            }
        }


        //returns the skill id of the skill after the currentskill in the skills array
        public string getNextSkill()
        {
            string nextSkill = currentSkill;

            if (firsttime ==true)
            {
                firsttime = false;
               
            }
            else
            {
                for (int k = 0; k < 7; k++)
                {
                    if (skills[0, k] == CurrentSkill) //&& k + 1 < 6)
                    {
                        try
                        {
                            CurrentSkill = skills[0, k + 1];
                            nextSkill = CurrentSkill;
                            break;
                        }
                        catch(IndexOutOfRangeException)
                        {
                            //throw new ApplicationException();

                            //firsttime = true;
                            //getNextSkill();
                            //still testing this part
                            initailizeSkills();
                        }
                    }
                }

            }
            return nextSkill;
 
            
        }

        

        public void initailizeSkills()
        {
            skills[0, 0] = "HR";
            skills[0, 1] = "HRATR";
            skills[0, 2] = "HRAFR";
            skills[0, 3] = "AROL";
            skills[0, 4] = "AROLS";
            skills[0, 5] = "AROLP";
            skills[0, 6] = "SYM";

            skills[1, 0] = "";
            skills[1, 1] = "";
            skills[1, 2] = "";
            skills[1, 3] = "";
            skills[1, 4] = "";
            skills[1, 5] = "";
            skills[1, 6] = "";

            skills[2, 0] = "";
            skills[2, 1] = "";
            skills[2, 2] = "";
            skills[2, 3] = "";
            skills[2, 4] = "";
            skills[2, 5] = "";
            skills[2, 6] = "";

            firsttime = true;
            CurrentSkill = "HR";

        }



        //over writes the skill in the skills array
        //public bool overWriteSkill(string id, int speed, int accuracy)
        //{
        //    for (int k = 0; k < 7; k++)
        //    {
        //        if (skills[0, k] == id)
        //        {
        //            skills[1, k] = speed.ToString();
        //            skills[2, k] = accuracy.ToString();
        //            return true;
        //        }
        //    }
        //    return false;

        //}

        #endregion Methods

    }
}
