using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
   public class Test
    {
        string testID;
       string totalNumberOfKeyStrokes;
       string numberOfinccorrectKeyStrokes;
       string duration;
       string skillID;
       string testtime;
       string testdate;

       

       
       string username;


       #region Constructor

       public Test()
       {
       }
       //Constructor if the user is logged in
       public Test(string strokes, string incorrect,
           string dur, string skill, string tm, string date, string us)
       {
           
           totalNumberOfKeyStrokes = strokes;
           numberOfinccorrectKeyStrokes = incorrect;
           duration = dur;
           skillID = skill;
           testdate = date;
           testtime = tm;
           username = us;
       }
       public Test(string testid,string strokes, string incorrect,
           string dur, string skill, string tm, string date, string us)
       {

           totalNumberOfKeyStrokes = strokes;
           numberOfinccorrectKeyStrokes = incorrect;
           duration = dur;
           skillID = skill;
           testdate = date;
           testtime = tm;
           username = us;
           testID = testid;
       }
       //Constructor if the user is not logged in
       //public Test(string strokes, string incorrect,
       //    string dur, string skill, string dat, string tm)
       //{
           
       //    totalNumberOfKeyStrokes = strokes;
       //    numberOfinccorrectKeyStrokes = incorrect;
       //    duration = dur;
       //    skillID = skill;
       //    testdate = dat;
       //    testtime = tm;
           
       //}
       #endregion Constructor


       //Properties
       #region Properties
       
       public string Date
       {
           get { return testdate; }
           set { testdate = value; }
       }

       public string TestID
        {
            get { return testID; }
            set { testID = value; }
        }
        

        public string TotalNumberOfKeyStrokes
        {
            get { return totalNumberOfKeyStrokes; }
            set { totalNumberOfKeyStrokes = value; }
        }
        

        public string NumberOfinccorrectKeyStrokes
        {
            get { return numberOfinccorrectKeyStrokes; }
            set { numberOfinccorrectKeyStrokes = value; }
        }
        

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        

        public string SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        

        public string Time
        {
            get { return testtime; }
            set { testtime = value; }
        }
        

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
       #endregion Properties

    }
}
