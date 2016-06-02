using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using BussinessLayer;

namespace Typing_Tutor
{
    public class ManageTest
    {
        #region Fields
        string text;
        int focusPosition;
        int length;
        bool practiceSession = false;
        bool difficultkeys = false;

       
        bool skillSession = false;        
        int strokes = 0;
        int errors = 0;
        bool sessionInProgress = false;
        bool initailPress = true;
        string skill;
        string lastFilename;
        bool keyboardshown;
        bool hasBeenStarted;
        int counter = 0;
        bool countdown = true;
        bool errorSound = true;
        bool victorySound = true;
        bool runningNow = false;
        bool wasPaused = false;
        int _time;
        string errorSoundFile;

        int vocalCount = 6;

        public int VocalCount
        {
            get { return vocalCount; }
            set { vocalCount = value; }
        }

        DispatcherTimer vocalSeconds;

        public DispatcherTimer VocalSeconds
        {
            get { return vocalSeconds; }
            set { vocalSeconds = value; }
        }

        bool moving = false;

        public bool Moving
        {
            get { return moving; }
            set { moving = value; }
        }


        List<PressWatcher> testkeypressInfor = new List<PressWatcher>();

        DispatcherTimer vocalinstructionstimer;

        public DispatcherTimer Vocalinstructionstimer
        {
            get { return vocalinstructionstimer; }
            set { vocalinstructionstimer = value; }
        }
        bool soundStillPlaying;

        int playCount = 0;

        public int PlayCount
        {
            get { return playCount; }
            set { playCount = value; }
        }

        public bool SoundStillPlaying
        {
            get { return soundStillPlaying; }
            set { soundStillPlaying = value; }
        }

        public List<PressWatcher> TestkeypressInfor
        {
            get { return testkeypressInfor; }
            set { testkeypressInfor = value; }
        }

        public bool Difficultkeys
        {

            get { return difficultkeys; }
            set { difficultkeys = value; }
        }

        List<PracticeDifficultKeys> myPracticeDifficultKeys = new List<PracticeDifficultKeys>();

        public List<PracticeDifficultKeys> MyPracticeDifficultKeys
        {
            get { return myPracticeDifficultKeys; }
            set { myPracticeDifficultKeys = value; }
        }

        List<TestDifficultKeys> myTestDifficultKeys = new List<TestDifficultKeys>();

        public List<TestDifficultKeys> MyTestDifficultKeys
        {
            get { return myTestDifficultKeys; }
            set { myTestDifficultKeys = value; }
        }

        bool vocalInstructionsOn = true;

        public bool VocalInstructionsOn
        {
            get { return vocalInstructionsOn; }
            set { vocalInstructionsOn = value; }
        }





        public string ErrorSoundFile
        {
            get { return errorSoundFile; }
            set { errorSoundFile = value; }
        }

        private DispatcherTimer countDown;

        private DispatcherTimer soundsimulation;

        public DispatcherTimer Soundsimulation
        {
            get { return soundsimulation; }
            set { soundsimulation = value; }
        }

        SoundManager soundSimulator;

        internal SoundManager SoundSimulator
        {
            get { return soundSimulator; }
            set { soundSimulator = value; }
        }

        #endregion Fields

        #region Properties

        public DispatcherTimer CountDown
        {
            get { return countDown; }
            set { countDown = value; }
        }

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public bool WasPaused
        {
            get { return wasPaused; }
            set { wasPaused = value; }
        }

        public bool RunningNow
        {
            get { return runningNow; }
            set { runningNow = value; }
        }


        public bool VictorySound
        {
            get { return victorySound; }
            set { victorySound = value; }
        }

        public bool ErrorSound
        {
            get { return errorSound; }
            set { errorSound = value; }
        }

        public bool Countdown
        {
            get { return countdown; }
            set { countdown = value; }
        }

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public bool HasBeenStarted
        {
            get { return hasBeenStarted; }
            set { hasBeenStarted = value; }
        }

        public bool Keyboardshown
        {
            get { return keyboardshown; }
            set { keyboardshown = value; }
        }


        public string LastFilename
        {
            get { return lastFilename; }
            set { lastFilename = value; }
        }

        public string Skill
        {
            get { return skill; }
            set { skill = value; }
        }
        public bool InitailPress
        {
            get { return initailPress; }
            set { initailPress = value; }
        }
        public bool SkillSession
        {
            get { return skillSession; }
            set { skillSession = value; }
        }

        public bool SessionInProgress
        {
            get { return sessionInProgress; }
            set { sessionInProgress = value; }
        }
        public int Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public int Strokes
        {
            get { return strokes; }
            set { strokes = value; }
        }
        public bool PracticeSession
        {
            get { return practiceSession; }
            set { practiceSession = value; }
        }
       
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int FocusPosition
        {
            get { return focusPosition; }
            set { focusPosition = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        #endregion Properties

        #region Constructor
        //constructor
        //pass the name of the file here
        public ManageTest(string testText, int startpos)
        {
            text = testText;
            focusPosition = startpos;
            length = text.Length;
            clearPressWatchers();
            
        }
        public ManageTest()
        {
            clearPressWatchers();

        }
        #endregion Constructor


        #region Methods
        //methods


        public void clearPressWatchers()
        {
            testkeypressInfor = new List<PressWatcher>();
            //foreach (PressWatcher press in testkeypressInfor)
            //{
            //    testkeypressInfor.Remove(press);
            //}
        }

        #region start test
        public void Start(Label pos1, Label pos2, Label pos3, Label pos4, Label pos5, Label pos6, Label pos7,
            Label pos8, Label pos9, Label pos10, Label pos11, Label pos12, Label pos13, Label pos14, Label pos15)
        {
            pos8.Content = GetText(Text, FocusPosition);
            pos9.Content = GetText(Text, FocusPosition + 1);
            pos10.Content = GetText(Text, FocusPosition + 2);
            pos11.Content = GetText(Text, FocusPosition + 3);
            pos12.Content = GetText(Text, FocusPosition + 4);
            pos13.Content = GetText(Text, FocusPosition + 5);
            pos14.Content = GetText(Text, FocusPosition + 6);
            pos15.Content = GetText(Text, FocusPosition + 7);

            pos1.Content = "";
            pos2.Content = "";
            pos3.Content = "";
            pos4.Content = "";
            pos5.Content = "";
            pos6.Content = "";
            pos7.Content = "";


        }
        #endregion start test

        #region  bool start test
        public bool Startb(Label pos1, Label pos2, Label pos3, Label pos4, Label pos5, Label pos6, Label pos7,
            Label pos8, Label pos9, Label pos10, Label pos11, Label pos12, Label pos13, Label pos14, Label pos15)
        {
            bool yes = true;

            try
            {
                pos8.Content = GetText(Text, FocusPosition);
                pos9.Content = GetText(Text, FocusPosition + 1);
                pos10.Content = GetText(Text, FocusPosition + 2);
                pos11.Content = GetText(Text, FocusPosition + 3);
                pos12.Content = GetText(Text, FocusPosition + 4);
                pos13.Content = GetText(Text, FocusPosition + 5);
                pos14.Content = GetText(Text, FocusPosition + 6);
                pos15.Content = GetText(Text, FocusPosition + 7);


                pos1.Content = "";
                pos2.Content = "";
                pos3.Content = "";
                pos4.Content = "";
                pos5.Content = "";
                pos6.Content = "";
                pos7.Content = "";
            }
            catch
            {
                yes = false;
            }
            return yes;

        }
        #endregion bool start test

        #region Long path starter

        public bool StartLong(Label pos18, Label pos19,Label pos1, Label pos2, 
            Label pos3, Label pos4, Label pos5, Label pos6, Label pos7,Label pos8,
            Label pos9, Label pos10,Label pos11, Label pos12, Label pos13, Label pos14,
            Label pos15, Label pos16, Label pos17)
        {
            bool yes = true;

            try
            {
                pos8.Content = GetText(Text, FocusPosition);
                pos9.Content = GetText(Text, FocusPosition + 1);
                pos10.Content = GetText(Text, FocusPosition + 2);
                pos11.Content = GetText(Text, FocusPosition + 3);
                pos12.Content = GetText(Text, FocusPosition + 4);
                pos13.Content = GetText(Text, FocusPosition + 5);
                pos14.Content = GetText(Text, FocusPosition + 6);
                pos15.Content = GetText(Text, FocusPosition + 7);
                pos16.Content = GetText(Text, FocusPosition + 8);
                pos17.Content = GetText(Text, FocusPosition + 9);


                pos18.Content = "";
                pos19.Content = "";
                pos1.Content = "";
                pos2.Content = "";
                pos3.Content = "";
                pos4.Content = "";
                pos5.Content = "";
                pos6.Content = "";
                pos7.Content = "";
            }
            catch
            {
                yes = false;
            }
            return yes;

        }
        #endregion Long path starter

        #region Move
        public void Move(Label pos1, Label pos2, Label pos3, Label pos4, Label pos5, Label pos6, Label pos7,
            Label pos8, Label pos9, Label pos10, Label pos11, Label pos12, Label pos13, Label pos14, Label pos15)
        {

            //if (FocusPosition + 7 <= Length)
            //{
                #region Left
                FocusPosition = FocusPosition + 1;

                if (FocusPosition - 7 < 0)
                {
                    pos1.Content = "";
                }
                else
                {
                    pos1.Content = GetText(Text, FocusPosition - 7);
                }

                if (FocusPosition - 6 < 0)
                {
                    pos2.Content = "";
                }
                else
                {
                    pos2.Content = GetText(Text, FocusPosition - 6);
                }

                if (FocusPosition - 5 < 0)
                {
                    pos3.Content = "";
                }
                else
                {
                    pos3.Content = GetText(Text, FocusPosition - 5);
                }
                if (FocusPosition - 4 < 0)
                {
                    pos4.Content = "";
                }
                else
                {
                    pos4.Content = GetText(Text, FocusPosition - 4);
                }
                if (FocusPosition - 3 < 0)
                {
                    pos5.Content = "";
                }
                else
                {
                    pos5.Content = GetText(Text, FocusPosition - 3);
                }

                if (FocusPosition - 2 < 0)
                {
                    pos6.Content = "";
                }
                else
                {
                    pos6.Content = GetText(Text, FocusPosition - 2);
                }
                if (FocusPosition - 1 < 0)
                {
                    pos7.Content = "";
                }
                else
                {
                    pos7.Content = GetText(Text, FocusPosition - 1);
                }
                #endregion Left

                #region Right
                pos8.Content = GetText(Text, FocusPosition);
                pos9.Content = GetText(Text, FocusPosition + 1);
                pos10.Content = GetText(Text, FocusPosition + 2);
                pos11.Content = GetText(Text, FocusPosition + 3);
                pos12.Content = GetText(Text, FocusPosition + 4);
                pos13.Content = GetText(Text, FocusPosition + 5);
                pos14.Content = GetText(Text, FocusPosition + 6);
                pos15.Content = GetText(Text, FocusPosition + 7);


                #endregion Right

            //}

        }
        #endregion Move

        #region Bool move
        public bool MoveB(Label pos1, Label pos2, Label pos3, Label pos4, Label pos5, Label pos6, Label pos7,
            Label pos8, Label pos9, Label pos10, Label pos11, Label pos12, Label pos13, Label pos14, Label pos15)
        {

            //if (FocusPosition + 7 <= Length)
            //{
            #region Left
            FocusPosition = FocusPosition + 1;

            if (FocusPosition - 7 < 0)
            {
                pos1.Content = "";
            }
            else
            {
                pos1.Content = GetText(Text, FocusPosition - 7);
            }

            if (FocusPosition - 6 < 0)
            {
                pos2.Content = "";
            }
            else
            {
                pos2.Content = GetText(Text, FocusPosition - 6);
            }

            if (FocusPosition - 5 < 0)
            {
                pos3.Content = "";
            }
            else
            {
                pos3.Content = GetText(Text, FocusPosition - 5);
            }
            if (FocusPosition - 4 < 0)
            {
                pos4.Content = "";
            }
            else
            {
                pos4.Content = GetText(Text, FocusPosition - 4);
            }
            if (FocusPosition - 3 < 0)
            {
                pos5.Content = "";
            }
            else
            {
                pos5.Content = GetText(Text, FocusPosition - 3);
            }

            if (FocusPosition - 2 < 0)
            {
                pos6.Content = "";
            }
            else
            {
                pos6.Content = GetText(Text, FocusPosition - 2);
            }
            if (FocusPosition - 1 < 0)
            {
                pos7.Content = "";
            }
            else
            {
                pos7.Content = GetText(Text, FocusPosition - 1);
            }
            #endregion Left

            #region Right
            if (FocusPosition >= Length)
            {
                //cant move anymore
                return false;
            }
            else
            {
                pos8.Content = GetText(Text, FocusPosition);
            }
            //
            if (FocusPosition + 1 >= Length)
            {
                pos9.Content = "";
            }
            else
            {
                pos9.Content = GetText(Text, FocusPosition + 1);
            }
            //
            if (FocusPosition + 2 >= Length)
            {
                pos10.Content = "";
            }
            else
            {
                pos10.Content = GetText(Text, FocusPosition + 2);
            }
            //
            if (FocusPosition + 3 >= Length)
            {
                pos11.Content = "";
            }
            else
            {
                pos11.Content = GetText(Text, FocusPosition + 3);
            }
            //
            if (FocusPosition + 4 >= Length)
            {
                pos12.Content = "";
            }
            else
            {
                pos12.Content = GetText(Text, FocusPosition + 4);
            }
            //
            if (FocusPosition + 5 >= Length)
            {
                pos13.Content = "";
            }
            else
            {
                pos13.Content = GetText(Text, FocusPosition + 5);
            }
            //
            if (FocusPosition + 6 >= Length)
            {
                pos14.Content = "";
            }
            else
            {
                pos14.Content = GetText(Text, FocusPosition + 6);
            }
            //

            if (FocusPosition + 7 >= Length)
            {
                pos15.Content = "";
            }
            else
            {
                pos15.Content = GetText(Text, FocusPosition + 7);
            }


            #endregion Right

            //}
            return true;

        }
        #endregion Bool move

        #region Long Mover
        //has 19 positions compared to the 15 positions i had initailly

        public bool MoveLong(Label pos18, Label pos19, Label pos1, Label pos2,
            Label pos3, Label pos4, Label pos5, Label pos6, Label pos7, Label pos8,
            Label pos9, Label pos10, Label pos11, Label pos12, Label pos13, Label pos14,
            Label pos15, Label pos16, Label pos17)
        {
            #region Left
            FocusPosition = FocusPosition + 1;


            if (FocusPosition - 9 < 0)
            {
                pos18.Content = "";
            }
            else
            {
                pos18.Content = GetText(Text, FocusPosition - 9);
            }


            if (FocusPosition - 8 < 0)
            {
                pos19.Content = "";
            }
            else
            {
                pos19.Content = GetText(Text, FocusPosition - 8);
            }

            if (FocusPosition - 7 < 0)
            {
                pos1.Content = "";
            }
            else
            {
                pos1.Content = GetText(Text, FocusPosition - 7);
            }

            if (FocusPosition - 6 < 0)
            {
                pos2.Content = "";
            }
            else
            {
                pos2.Content = GetText(Text, FocusPosition - 6);
            }

            if (FocusPosition - 5 < 0)
            {
                pos3.Content = "";
            }
            else
            {
                pos3.Content = GetText(Text, FocusPosition - 5);
            }
            if (FocusPosition - 4 < 0)
            {
                pos4.Content = "";
            }
            else
            {
                pos4.Content = GetText(Text, FocusPosition - 4);
            }
            if (FocusPosition - 3 < 0)
            {
                pos5.Content = "";
            }
            else
            {
                pos5.Content = GetText(Text, FocusPosition - 3);
            }

            if (FocusPosition - 2 < 0)
            {
                pos6.Content = "";
            }
            else
            {
                pos6.Content = GetText(Text, FocusPosition - 2);
            }
            if (FocusPosition - 1 < 0)
            {
                pos7.Content = "";
            }
            else
            {
                pos7.Content = GetText(Text, FocusPosition - 1);
            }
            #endregion Left

            #region Right
            if (FocusPosition >= Length)
            {
                //cant move anymore
                return false;
            }
            else
            {
                pos8.Content = GetText(Text, FocusPosition);
            }
            //
            if (FocusPosition + 1 >= Length)
            {
                pos9.Content = "";
            }
            else
            {
                pos9.Content = GetText(Text, FocusPosition + 1);
            }
            //
            if (FocusPosition + 2 >= Length)
            {
                pos10.Content = "";
            }
            else
            {
                pos10.Content = GetText(Text, FocusPosition + 2);
            }
            //
            if (FocusPosition + 3 >= Length)
            {
                pos11.Content = "";
            }
            else
            {
                pos11.Content = GetText(Text, FocusPosition + 3);
            }
            //
            if (FocusPosition + 4 >= Length)
            {
                pos12.Content = "";
            }
            else
            {
                pos12.Content = GetText(Text, FocusPosition + 4);
            }
            //
            if (FocusPosition + 5 >= Length)
            {
                pos13.Content = "";
            }
            else
            {
                pos13.Content = GetText(Text, FocusPosition + 5);
            }
            //
            if (FocusPosition + 6 >= Length)
            {
                pos14.Content = "";
            }
            else
            {
                pos14.Content = GetText(Text, FocusPosition + 6);
            }
            //

            if (FocusPosition + 7 >= Length)
            {
                pos15.Content = "";
            }
            else
            {
                pos15.Content = GetText(Text, FocusPosition + 7);
            }

            if (FocusPosition + 8 >= Length)
            {
                pos16.Content = "";
            }
            else
            {
                pos16.Content = GetText(Text, FocusPosition + 8);
            }

            if (FocusPosition + 9 >= Length)
            {
                pos17.Content = "";
            }
            else
            {
                pos17.Content = GetText(Text, FocusPosition + 9);
            }


            #endregion Right



            return true;
        }
        #endregion Long Mover


        //Returns the charactor in the position passed
        public string GetText(string textfile, int pos)
        {
            string text = "";
            //try
            //{
                text = textfile.Substring(pos, 1);
            //}
            //catch
            //{
            //    throw new ApplicationException("end of file");
              
            //}

            return text;
        }

        //checks if the passed key was pressed during the test
        public bool keyWasPressed(string key)
        {
            bool yes = false;

            foreach (PressWatcher mypress in TestkeypressInfor)
            {
                if (mypress.Keyname.ToLower() == key.ToLower())
                {
                    yes = true;
                    break;
                }
            }

            return yes;
        }


        public void ResetVocalInstructionsDelay()
        {
            this.vocalCount = 6;
        }
        public bool VocalDelayCountDown()
        {
            if (this.vocalCount <= 0)
            {
                return false;
            }
            else
            {
                this.vocalCount--;
                return true;
            }
        }

        #endregion Methods


    }
}
