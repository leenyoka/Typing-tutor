using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class myState
    {
        bool loggedin;

        public bool Loggedin
        {
            get { return loggedin; }
            set { loggedin = value; }
        }
        string currentUser;

        public string CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }


        int stateFocusPos;

        public int StateFocusPos
        {
            get { return stateFocusPos; }
            set { stateFocusPos = value; }
        }
        bool paused = false;

        public bool Paused
        {
            get { return paused; }
            set { paused = value; }
        }
        int totalTime;

        public int TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }
        int remainingTime;

        public int RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; }
        }

        #region Choice
        bool backgroundmusic = false;

        public bool Backgroundmusic
        {
            get { return backgroundmusic; }
            set { backgroundmusic = value; }
        }
        string textcolor = "red";

        public string Textcolor
        {
            get { return textcolor; }
            set { textcolor = value; }
        }

        string backgroundimage = "background43";

        public string Backgroundimage
        {
            get { return backgroundimage; }
            set { backgroundimage = value; }
        }


        string detaultkeyboardview = "keys";

        public string Detaultkeyboardview
        {
            get { return detaultkeyboardview; }
            set { detaultkeyboardview = value; }
        }
        bool errorsound = true;

        public bool Errorsound
        {
            get { return errorsound; }
            set { errorsound = value; }
        }
        int recordspeed = 0;

        public int Recordspeed
        {
            get { return recordspeed; }
            set { recordspeed = value; }
        }
        bool showinstructions = true;

        public bool Showinstructions
        {
            get { return showinstructions; }
            set { showinstructions = value; }
        }
        bool showkeyboard = false;

        public bool Showkeyboard
        {
            get { return showkeyboard; }
            set { showkeyboard = value; }
        }
        string speed = "wpm";

        public string Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int testduration = 1;

        public int Testduration
        {
            get { return testduration; }
            set { testduration = value; }
        }
        string testtime = "Count down";

        public string Testtime
        {
            get { return testtime; }
            set { testtime = value; }
        }
        bool victorysound = false;

        public bool Victorysound
        {
            get { return victorysound; }
            set { victorysound = value; }
        }
        bool vocalinstructions = false;

        public bool Vocalinstructions
        {
            get { return vocalinstructions; }
            set { vocalinstructions = value; }
        }



        #endregion Choice


        //constructor
        public myState()
        {
        }


    }
}
