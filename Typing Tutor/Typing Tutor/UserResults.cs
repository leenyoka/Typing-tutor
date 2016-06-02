using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class UserResults
    {

        int speed;

        List<PressWatcher> testkeywatcher;

        public List<PressWatcher> Testkeywatcher
        {
            get { return testkeywatcher; }
            set { testkeywatcher = value; }
        }

        myState mystate;

        public myState Mystate
        {
            get { return mystate; }
            set { mystate = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int seconds;

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        int strokes;

        public int Strokes
        {
            get { return strokes; }
            set { strokes = value; }
        }
        int errors;

        public int Errors
        {
            get { return errors; }
            set { errors = value; }
        }
        int accuracy;

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        string difficultKeys;

        public string DifficultKeys
        {
            get { return difficultKeys; }
            set { difficultKeys = value; }
        }

        string currentUser;

        public string CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        string skill;

        public string Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        public UserResults(int spid, int secs, int strok, int errs, int acc)
        {
            Speed = spid;
            Seconds = secs;
            Strokes = strok;
            Errors = errs;
            Accuracy = acc;
        }
        public UserResults(int spid, int secs, int strok, int errs, int acc, List<PressWatcher> pw)
        {
            Speed = spid;
            Seconds = secs;
            Strokes = strok;
            Errors = errs;
            Accuracy = acc;

            Testkeywatcher = pw;
        }

        public UserResults(int spid, int secs, int strok, int errs, int acc, List<PressWatcher> pw, string difficultkeys)
        {
            Speed = spid;
            Seconds = secs;
            Strokes = strok;
            Errors = errs;
            Accuracy = acc;

            Testkeywatcher = pw;

            this.difficultKeys = difficultkeys;
        }


    }
}
