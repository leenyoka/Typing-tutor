using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BussinessLayer;
using System.Windows.Threading;
using System.Media;
using System.ComponentModel;
using System.Threading;

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for TouchType.xaml
    /// </summary>
    public partial class TouchType : Window
    {
        
        #region Timer

        public void resume()
        {
            manageTest.FocusPosition = mystate.StateFocusPos - 1;

            manageTest.MoveB(position1, position2, position3, position4, position5, position6,
                position7, position8, position9, position10, position11, position12, position13,
                position14, position15);

            
            manageTest.InitailPress = true;
            //_time = mystate.RemainingTime;
            mystate.Paused = false;
            //_countdownTimer.Start();
            manageTest.RunningNow = true;
            manageTest.WasPaused = true;

            simulateKeyPress(((string)position8.Content).ToLower());
            if (gridhands.Visibility == System.Windows.Visibility.Visible)
            {
                simulateHandPress(((string)position8.Content));
            }
            //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

            if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
            {
                simulateNumPress((string)position8.Content);
            }
            
        }

        //public int getRemainingTime()
        //{
        //    int remaining = 0;

        //    //if (da.GetAnOption("Testtime").MoValue == "Count down")
        //    //{
        //        remaining = mystate.TotalTime - manageTest.Counter;
        //    //}
        //    //else
        //    //{
                
        //    //}
        //        return remaining;
        //}

        public void pause()
        {
            mystate.StateFocusPos = manageTest.FocusPosition;
            try
            {
                if (!mystate.Loggedin)
                {
                    mystate.TotalTime = int.Parse(da.GetAnOption("Testduration").MoValue);
                }
                else
                {
                    mystate.TotalTime = int.Parse(da.GetChoice(mystate.CurrentUser, "Testduration").MoValue);
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            mystate.RemainingTime = manageTest.Counter;
            mystate.Paused = true;
            manageTest.RunningNow = false; 
            
            //_countdownTimer.Stop();
            manageTest.CountDown.Stop();
            manageTest.Soundsimulation.Stop();
            pressWatcher.pause();
            //lblTimer.Content ="00:" + mystate.RemainingTime.ToString() + " s";
            showTime(mystate.RemainingTime);

            ShowPuased();

            BrownButtons();
            hideDots();
            //btnInstructions.Content = "";
        }

        public void ShowPuased()
        {
            pos18.Content = "";
            pos19.Content = "";
            position1.Content = " ";
            position2.Content = " ";
            position3.Content = "E";
            position4.Content = "N";
            position5.Content = "T";
            position6.Content = "E";
            position7.Content = "R";
            position8.Content = ":";
            position9.Content = "R";
            position10.Content = "E";
            position11.Content = "S";
            position12.Content = "U";
            position13.Content = "M";
            position14.Content = "E";
            position15.Content = " ";
            pos16.Content = "";
            pos17.Content = "";
        }

        //public int _time;

        public int setTime()
        {
            try
            {
                if (!mystate.Loggedin)
                {
                    return minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue));
                }
                else
                {
                    return minutesintseconds(int.Parse(da.GetChoice(mystate.CurrentUser,"Testduration").MoValue));
                }
            }
            catch
            {
                return 60;
            }
        }

        //Thread speedThread;
        //called when show time is called
        public void showSpeed()
        {
            List<PressWatcher> testinfor = manageTest.TestkeypressInfor;
            int speed = GetSpeed(testinfor);

            //lblspeed.Content = "Speed: " + speed;

            
        }



        public int GetSpeed(List<PressWatcher> testInfor)
        {

            TypingSpeed tt = new TypingSpeed();

            int myspeed = tt.GetSpeed(testInfor);

            return myspeed;
           
        }

        public void showTime1(int seconds)
        {
            int mySeconds = seconds;
            int myMinutes = 0;
            string secondsstring = "";
            string minutestring = "";

            

            if (seconds < 60)
            {
                minutestring = "00";
                #region seconds
                if (mySeconds < 10)
                {
                    secondsstring = "0" + mySeconds.ToString();
                }
                else
                {
                    secondsstring = mySeconds.ToString();
                }
                #endregion seconds

            }
            else
            {
                do
                {
                    myMinutes += 1;
                    mySeconds -= 60;

                }
                while (mySeconds >= 60);
                #region minuties
                if (myMinutes > 10)
                {
                    minutestring = myMinutes.ToString();
                }
                else
                {
                    minutestring = "0" + myMinutes.ToString();
                }
                #endregion minutes

                #region seconds
                if (mySeconds < 10)
                {
                    secondsstring = "0" + mySeconds.ToString();
                }
                else
                {
                    secondsstring = mySeconds.ToString();
                }
                #endregion seconds

            }
            lblTimer.Content = minutestring + ":" + secondsstring;

            if (manageTest.RunningNow)
            {
                //showSpeed();
            }
        }
        public void showTime(int seconds)
        {
            int myseconds = seconds;
            int myminutes = 0;
            int myhours = 0;
            string temptime = "";

            do
            {
                if (myseconds >= 60)
                {
                    myminutes += 1;
                    myseconds -= 60;
                }

            }
            while (myseconds >= 60);


            do
            {
                if (myminutes >= 60)
                {
                    myhours += 1;
                    myminutes -= 60;
                }
            }
            while (myminutes >= 60);



            if (myhours > 0)
            {
                temptime = prepare(myhours.ToString()).ToString() + ":" + prepare(myminutes.ToString()).ToString() +
                    ":" + prepare(myseconds.ToString()).ToString();
            }
            else
            {
                temptime = prepare(myminutes.ToString()).ToString() +
                    ":" + prepare(myseconds.ToString()).ToString();
            }

            lblTimer.Content = temptime;



        }
        public string prepare(string tempvalue)
        {
            string thisvalue = "";
            if (tempvalue.Length < 2)
            {
                thisvalue = "0" + tempvalue;
            }
            if (tempvalue.Length == 2)
            {
                thisvalue = tempvalue;
            }

            if (tempvalue.Length > 2)
            {
                thisvalue = tempvalue;
            }

            return thisvalue;
        }
        //private DispatcherTimer _countdownTimer;
        int elapsedsec = 0;

        public void initaiteTimer()
        {
            
            try
            {
                if (!mystate.Loggedin)
                {
                    if (da.GetAnOption("Testtime").MoValue == "Count down")
                    {
                        manageTest.Countdown = true;
                        manageTest.Counter = setTime();
                    }
                    else
                    {
                        manageTest.Countdown = false;
                        manageTest.Counter = 0;
                    }
                }
                else
                {
                    if (da.GetChoice(mystate.CurrentUser, "Testtime").MoValue == "Count down")
                    {
                        manageTest.Countdown = true;
                        manageTest.Counter = setTime();
                    }
                    else
                    {
                        manageTest.Countdown = false;
                        manageTest.Counter = 0;
                    }
                }
                //_time = setTime();
                manageTest.Time = setTime();

                if (manageTest.SessionInProgress)
                {
                    showTime(manageTest.Counter);
                }
            }
            catch
            {
                MessageBox.Show("Error Initaiting timer", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool MyTick()
        {

            if (manageTest.Countdown)
            {
                manageTest.Counter--;
                if (manageTest.Counter <= 0)
                {
                    return false;
                }
            }
            else
            {
                manageTest.Counter++;
                if (manageTest.Counter >= manageTest.Time /*_time*/)
                {
                    return false;
                }
            }
            return true;
        }

        private void PressDelayAssist(object sender, EventArgs e)
        {
            //if (manageTest.RunningNow)
            //{
                if (!manageTest.VocalDelayCountDown() && !manageTest.Moving)
                {
                    try
                    {
                        if (manageTest.VocalInstructionsOn && manageTest.PracticeSession
                            && !(manageTest.Skill.ToLower() == "num"))
                        {
                            threadVocalInstructions();
                        }
                        manageTest.ResetVocalInstructionsDelay();
                    }
                    catch
                    {
                        //threadVocalInstructions();
                    }
                }

                manageTest.Moving = false;
            //}
        }

        private void CountdownTimerStep(object sender, EventArgs e)
        {

            if (MyTick())
            {
                //_time--;
                //this.lblTimer.Content ="00:" + _time + " s";
                showTime(manageTest.Counter);
                elapsedsec++;

                
            }
            else
            {
                stopMytimer();
            }
        }

        
        public void simulateSound(object sender, EventArgs e)//try and do this on a different thread
        {
            //if instructions are on.
            //soundSimulator.Play((string)position8.Content);
            //manageTest.SoundSimulator.Play((string)position8.Content);

            //Thread.Sleep(new TimeSpan(0, 0, 20));

            //threadsound();
        }

        public void startMyTimer()
        {
            
            manageTest.RunningNow = true;
            //_countdownTimer.Start();
            manageTest.CountDown.Start();
            //manageTest.CountDown.Start();
            manageTest.Soundsimulation.Start();
            manageTest.Soundsimulation.Start();

            if (manageTest.WasPaused)
            {
                manageTest.WasPaused = false;
            }
            else
            {
                elapsedsec = 0;
            }

            sessionTimer.Start();
        }
        public void stopMytimer()
        {
            manageTest.VocalSeconds.Stop();
            manageTest.RunningNow = false;
            //_countdownTimer.Stop();
            manageTest.CountDown.Stop();
            manageTest.Soundsimulation.Stop();


            manageTest.SessionInProgress = false;
            BrownButtons();
            hideDots();
            //btnInstructions.Content = "";

            sessionTimer.Stop();
            lblTimer.Content = " ";
            //lblspeed.Content = " ";
            hideNumHandImages();

            //MessageBox.Show("your difficult keys were:"  + dk.GetDifficultKeys(), "Diff keys"); works perfectly!!

            //give test results


            if (!manageTest.PracticeSession && !manageTest.Difficultkeys)
            {
                TestSessionResults();
                displayRecord();
            }
            else
            {
                //test results
                PracticeSessionResult();
                

            }
        }
        public void quit()
        {
            manageTest.VocalSeconds.Stop();
            //_countdownTimer.Stop();
            manageTest.CountDown.Stop();
            manageTest.Soundsimulation.Stop();
            manageTest.RunningNow = false;

            sessionTimer.Stop();
            lblTimer.Content = " ";
            //lblspeed.Content = "";
            displayRecord();

            //btnInstructions.Content = "";

            manageTest.SessionInProgress = false;
        }

        public int minutesintseconds(int minutes)
        {
            int theseSeconds = 0;

            theseSeconds = minutes * 60;

            return theseSeconds;
        }
        

        #endregion Timer

        #region Constructor
        //persisting login state
        //bool loggedin;
        //string currentUser;

        public TouchType()
        {
            //Guest login
            //loggedin = false;
            
            InitializeComponent();
            mystate.Loggedin = false;
            RemoveProgressOption();
            initateMyDispatcher();
            //SetMyOptions();
            SetMyOptions1();

            setmyScreen();
            //qalisa();
        }

        public void setmyScreen()
        {
            int width =(int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int height = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

            //MainScreen.Width = width;
            //MainScreen.Height = height -40;

            //mainMenu.Margin = new Thickness( 0, 0, 0, 0);
            mainMenu.Width = width - 10;

            

        }

        public void RemoveProgressOption()
        {
            for(int m = 0; m < mainMenu.Items.Count; m++)
            {
                MenuItem temp = (MenuItem)mainMenu.Items[m];
                if (temp.Name == "userProgressMenuItem")
                {
                    mainMenu.Items.Remove(temp);
                    break;
                }
            }

        }
        public TouchType(string username)
        {
            
            //loggedin = true;
            mystate.Loggedin = true;
            //currentUser = username;
            mystate.CurrentUser = username;
            InitializeComponent();

            initateMyDispatcher();
            //SetMyOptions();
            SetMyOptions1();
            GetMyInformation();
            //qalisa();
            setmyScreen();
        }

        public void qalisa()
        {
            foreach (UIElement child in cnTest.Children)
            {
                Button btn = (Button)child;
                buttons.Add(btn);
            }

            foreach (UIElement child in Numpadkeys.Children)
            {
                Button btn = (Button)child;
                numbuttons.Add(btn);
            }

        }

        bool learner = false;
        public TouchType(string username, bool learner)
        {
            //loggedin = true;
            mystate.Loggedin = true;
            //currentUser = username;
            mystate.CurrentUser = username;
            InitializeComponent();

            initateMyDispatcher();
            if (learner)
            {
                this.learner = true;
                //GoToLearningPage();
            }

            setDefaultSettings(username);

            //SetMyOptions();
            SetMyOptions1();
            setmyScreen();
            
        }

        public void initateMyDispatcher()
        {
            //_countdownTimer = new DispatcherTimer();
            //_countdownTimer.Interval = new TimeSpan(0, 0, 1);
            //_countdownTimer.Tick += new EventHandler(CountdownTimerStep);

            manageTest.CountDown = new DispatcherTimer();
            manageTest.CountDown.Interval = new TimeSpan(0, 0, 1);
            manageTest.CountDown.Tick += new EventHandler(CountdownTimerStep);

            manageTest.VocalSeconds = new DispatcherTimer();
            manageTest.VocalSeconds.Interval = new TimeSpan(0, 0, 0, 1);
            manageTest.VocalSeconds.Tick += new EventHandler(PressDelayAssist);

            manageTest.Soundsimulation = new DispatcherTimer();
            manageTest.Soundsimulation.Interval = new TimeSpan(0, 0, 0, 5);
            manageTest.Soundsimulation.Tick += new EventHandler(simulateSound);
        }

        #endregion Constructor

        public void GetMyInformation()
        {
            manageTest.MyPracticeDifficultKeys = da.GetusersPracticeDifficultKeys(mystate.CurrentUser);
            List<Test> mytests = da.GetUserTests(mystate.CurrentUser);

            List<TestDifficultKeys> mytestdif = new List<TestDifficultKeys>();

            List<TestDifficultKeys> allTestdif = da.GetAllDiffucultkeys();

            foreach (TestDifficultKeys key in allTestdif)
            {
                if(testIdIsIn(mytests, key.TestID))
                {
                    mytestdif.Add(key);
                }
            }
            manageTest.MyTestDifficultKeys = mytestdif;

        }
        public bool testIdIsIn(List<Test> a, string testId)
        {
            foreach (Test mytest in a)
            {
                if (testId == mytest.TestID)
                {
                    return true;
                }
            }
            return false;
        }
       

        #region display Record speed
        public void displayRecord1()
        {
            //string record = (78).ToString(); //da.GetAControl("Recordspeed").ControlValue;
            string record = "";


            try
            {
                #region write record
                position2.Content = "R";
                position3.Content = "E";
                position4.Content = "C";
                position5.Content = "O";
                position6.Content = "R";
                position7.Content = "D";
                position8.Content = ":";

                string wpm = "wpm";

                if (mystate.Loggedin)
                {
                    wpm = da.GetChoice(mystate.CurrentUser, "Speed").MoValue;
                }
                else
                {
                    wpm = da.GetAnOption("Speed").MoValue;
                }


                if (wpm.ToLower() == "wpm")
                {

                    if (!mystate.Loggedin)
                    {
                        record = da.GetAnOption("Recordspeed").MoValue;
                    }
                    else
                    {
                        record = da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue;
                    }

                    position12.Content = "W";
                    position13.Content = "P";
                    position14.Content = "M";
                }
                if (wpm == "cpm")
                {
                    if (!mystate.Loggedin)
                    {
                        record = (int.Parse(da.GetAnOption("Recordspeed").MoValue) * 5).ToString();
                    }
                    else
                    {
                        record = (int.Parse(da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue) * 5).ToString();
                    }

                    position12.Content = "C";
                    position13.Content = "P";
                    position14.Content = "M";
                }

                #endregion write record

                #region write speed
                if (int.Parse(record) > 99)
                {
                    position9.Content = record.Substring(0, 1);
                    position10.Content = record.Substring(1, 1);
                    position11.Content = record.Substring(2, 1);

                }
                else if (int.Parse(record) < 10)
                {
                    position9.Content = "";
                    position10.Content = record.Substring(0, 1);
                    position11.Content = "";//record.Substring(1, 1);

                }
                else
                {
                    position10.Content = record.Substring(0, 1);
                    position11.Content = record.Substring(1, 1);
                }
                #endregion write speed
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            #region Clear
            position1.Content = "";
            position15.Content = "";
            if (int.Parse(record) < 100)
            {
                position9.Content = "";
            }

            #endregion Clear

            BrownButtons();
            hideDots();
            hideNumHandImages();
            //gridWait.Visibility = System.Windows.Visibility.Hidden;
            //whenLoaded();
        }

        public void displayRecord()
        {
            //string record = (78).ToString(); //da.GetAControl("Recordspeed").ControlValue;
            string record = "";


            try
            {
                #region write record
                pos18.Content = "";
                pos19.Content = "";
                position2.Content = "R";
                position3.Content = "E";
                position4.Content = "C";
                position5.Content = "O";
                position6.Content = "R";
                position7.Content = "D";
                position8.Content = ":";
                pos16.Content = "";
                pos17.Content = "";

                string wpm = "wpm";

                if (mystate.Loggedin)
                {
                   // wpm = da.GetChoice(mystate.CurrentUser, "Speed").MoValue;
                    wpm = mystate.Speed;
                }
                else
                {
                    //wpm = da.GetAnOption("Speed").MoValue;
                    wpm = mystate.Speed;
                }


                if (wpm.ToLower() == "wpm")
                {

                    //if (!mystate.Loggedin)
                    //{
                    //    record = da.GetAnOption("Recordspeed").MoValue;
                    //}
                    //else
                    //{
                    //    record = da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue;
                    //}
                    record = mystate.Recordspeed.ToString();

                    position12.Content = "W";
                    position13.Content = "P";
                    position14.Content = "M";
                }
                if (wpm.ToLower() == "cpm")
                {
                    //if (!mystate.Loggedin)
                    //{
                    //    record = (int.Parse(da.GetAnOption("Recordspeed").MoValue) * 5).ToString();
                    //}
                    //else
                    //{
                    //    record = (int.Parse(da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue) * 5).ToString();
                    //}

                    record = (mystate.Recordspeed * 5).ToString();

                    position12.Content = "C";
                    position13.Content = "P";
                    position14.Content = "M";
                }

                #endregion write record

                #region write speed
                if (int.Parse(record) > 99)
                {
                    position9.Content = record.Substring(0, 1);
                    position10.Content = record.Substring(1, 1);
                    position11.Content = record.Substring(2, 1);

                }
                else if (int.Parse(record) < 10)
                {
                    position9.Content = "";
                    position10.Content = record.Substring(0, 1);
                    position11.Content = "";//record.Substring(1, 1);

                }
                else
                {
                    position10.Content = record.Substring(0, 1);
                    position11.Content = record.Substring(1, 1);
                }
                #endregion write speed
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            #region Clear
            position1.Content = "";
            position15.Content = "";
            if (int.Parse(record) < 100)
            {
                position9.Content = "";
            }

            #endregion Clear

            BrownButtons();
            hideDots();
            hideNumHandImages();
            //gridWait.Visibility = System.Windows.Visibility.Hidden;
            //whenLoaded();
        }
        #endregion display Record speed

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manageTest.Vocalinstructionstimer = new DispatcherTimer();
            manageTest.Vocalinstructionstimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            manageTest.Vocalinstructionstimer.Tick += new EventHandler(VocalPlayManager);
            manageTest.Vocalinstructionstimer.Start();
            //disablekeyboardbuttons();

            

            foreach (UIElement child in cnTest.Children)
            {
                Button btn = (Button)child;
                buttons.Add(btn);
            }
            BrownButtons();

            

            //if (!(/*loggedin*/ mystate.Loggedin))
            //{
            //    //if the user is not loggedin the progress menu item must be disabled
            //    //userProgressMenuItem.IsEnabled = false;
            //}

            //display record speed
            displayRecord();
            //SetMyOptions();

            //soundSimulator = new SoundManager(manageTest.ErrorSoundFile);
            manageTest.SoundSimulator = new SoundManager(manageTest.ErrorSoundFile);
            whenLoaded();


            if (learner)
            {
                GoToLearningPage();
            }
        }

        public void VocalPlayManager(object sender, EventArgs e)
        {
            if (manageTest.PlayCount <= 0)
            {
                manageTest.SoundStillPlaying = false;
            }
            else
            {
                manageTest.PlayCount--;
                manageTest.SoundStillPlaying = true;
            }
        }




        Thread mythread;
        public void threadVocalInstructions()
        {
            //if (!manageTest.SoundStillPlaying)
            //{
            //    manageTest.PlayCount = 200;
            //    if (manageTest.SessionInProgress && manageTest.PracticeSession
            //        )
            //    {
            //        try
            //        {
            //if (manageTest.Skill.ToLower() != "num")
            //{
                mythread = new Thread(initaiteWork);

                string[] me = new string[2] { (string)position8.Content, (string)position7.Content };

                mythread.Start(me);
            //}
            

            //        }
            //        catch
            //        {
            //            mythread = new Thread(initaiteWork);

            //            mythread.Start((string)position8.Content);
            //        }
            //    }
            //}
        }
        public void initaiteWork(object data)
        {
            //bw.DoWork += new DoWorkEventHandler(simulateSound);
            try
            {
                if (manageTest.Skill.ToLower() != "num")
                {
                    string[] me =(string[])data;
                    manageTest.SoundSimulator.Play(me[0], me[1]);
                }
                else
                {
                    //manageTest.SoundSimulator.PlayNum((string)data);
                }
            }
            catch
            {
                MessageBox.Show("could not play sound", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //static BackgroundWorker bw = new BackgroundWorker();

        public void whenLoaded()
        {
            if (mystate.Loggedin && UserhasDiffultkeys())
            {
                if (!difficultKeysMenuItemAreadyExists())
                {
                    //if logged in and has difficult keys on test or userskil table
                    MenuItem myitem = new MenuItem();
                    myitem.Header = "Difficult keys";
                    myitem.Click += new RoutedEventHandler(PracticeDifficultKeys);

                    practiceMenu.Items.Add(myitem);
                }
            }
            else
            {
                foreach (MenuItem myitem in practiceMenu.Items)
                {
                    if ((string)myitem.Header == "Diffucult keys")
                    {
                        practiceMenu.Items.Remove(myitem);
                    }
                }
            }
        }


        public bool difficultKeysMenuItemAreadyExists()
        {
            bool yes = false;

            foreach (MenuItem myitem in practiceMenu.Items)
            {
                if (myitem.Header.ToString() == "Difficult keys")
                {
                    yes = true;
                    break;
                }
            }

            return yes;
        }
        public bool UserhasDiffultkeys()
        {
            if (manageTest.MyPracticeDifficultKeys.Count <= 0 ||
                manageTest.MyTestDifficultKeys.Count <= 0)
            {
                return false;
            }
            return true;

        }


        private void PracticeDifficultKeys(object sender, RoutedEventArgs e)
        {

            string allmydifficultkeys = "";


            for (int m = 0; m <= 5; m++)
            {

                foreach (TestDifficultKeys mykey in manageTest.MyTestDifficultKeys)
                {
                    if (mykey.Keyname != " " && mykey.Keyname != "")
                    {
                        allmydifficultkeys += mykey.Keyname.ToLower() + " ";

                    }
                }
                foreach (PracticeDifficultKeys mykey in manageTest.MyPracticeDifficultKeys)
                {
                    if (mykey.Keyname != " " && mykey.Keyname != "")
                    {
                        allmydifficultkeys += mykey.Keyname.ToLower() + " ";
                    }
                }
            }
            writeToFile(allmydifficultkeys);


            //start difficult practice
            try
            {
                StartDiffultKeysPractice();
            }
            catch
            {
                MessageBox.Show("You don't have any difficult keys."+ Environment.NewLine+ "Continue with your practice",
                    "Difficult keys", MessageBoxButton.OK, MessageBoxImage.Information);
                whenLoaded();
            }
            
            //Practice difficult keys here
            //launch
            //MessageBox.Show("it works", "Test");
        }

        public void StartDiffultKeysPractice()
        {
            var filename = "difficult.txt";
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            try
            {
                Start(path, "keys");
            }
            catch
            {
                throw new ApplicationException();
            }
            
        }
        public void writeToFile(string text)
        {
            var filename = "difficult.txt";
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.IO.File.WriteAllText(path, text);

        }
        

        
        
        #region Options
        public void SetMyOptions1()
        {
            if (mystate.Loggedin)
            {
                setMyPersonOptions();
            }
            else
            {
                setGeneraOptions();
            }

            try
            {
                #region Keyboard
                if (mystate.Showkeyboard.ToString().ToLower() == "true")
                {
                    //showkeyboard
                    if (manageTest.SessionInProgress && manageTest.PracticeSession
                        && manageTest.Skill.ToLower() != "num")
                    {
                        #region if Content

                        ShowKeyboard2();

                        simulateKeyPress(((string)position8.Content).ToLower());

                        if (gridhands.Visibility == System.Windows.Visibility.Visible)
                        {
                            simulateHandPress(((string)position8.Content));
                        }
                        //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

                        if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
                        {
                            simulateNumPress((string)position8.Content);
                        }

                        initaiteTimer();
                        //_time = setTime();
                        manageTest.Time = setTime();
                        showTime(manageTest.Counter);
                        //showTime(minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue)));

                        #endregion if Content
                    }

                    if (!manageTest.SessionInProgress)
                    {
                        ShowKeyboard2();

                    }
                    else
                    {
                        initaiteTimer();
                        //_time = setTime();
                        manageTest.Time = setTime();
                        showTime(manageTest.Counter);

                        //_time = minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue));
                        //showTime(minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue)));
                    }
                }
                else
                {
                    HideKeyboard();
                }
                #endregion Keyboard
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            //rbkeys.IsChecked = true;
            //btnInstructions.Visibility = System.Windows.Visibility.Hidden;

            initaiteTimer();

            //showTime(manageTest.Counter);

            try
            {
                if (mystate.Errorsound.ToString().ToLower() == "true")
                {
                    manageTest.ErrorSound = true;
                }
                else
                {
                    manageTest.ErrorSound = false;
                }

                manageTest.ErrorSoundFile = da.GetAnOption("Errorsoundfile").MoValue;

                if (mystate.Vocalinstructions.ToString().ToLower() == "true")
                {
                    manageTest.VocalInstructionsOn = true;
                }
                else
                {
                    manageTest.VocalInstructionsOn = false;
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            if (!manageTest.SessionInProgress)
            {
                displayRecord();
            }

            if (mystate.Detaultkeyboardview == "hands")
            {
                //rbhands.IsChecked = true;
            }
            else
            {
                //rbkeys.IsChecked = true;
            }
            setMyBackground();

            setMyMainBackColor();

            //gridWait.Visibility = System.Windows.Visibility.Hidden;


        }

        public void setMyPersonOptions()
        {
            if (da.GetChoice(mystate.CurrentUser, "Backgroundmusic").MoValue == "true")
            {
                mystate.Backgroundmusic = true;
            }
            else
            {
                mystate.Backgroundmusic = false;
            }

            if(da.GetChoice(mystate.CurrentUser, "Errorsound").MoValue == "true")
            {
                mystate.Errorsound = true;
            }
            else
            {
                mystate.Errorsound = false;
            }

            mystate.Recordspeed =int.Parse(da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue);

            if (da.GetChoice(mystate.CurrentUser, "Showinctructions").MoValue == "true")
            {
                mystate.Showinstructions = true;
            }
            else
            {
                mystate.Showinstructions = false;
            }

            if (da.GetChoice(mystate.CurrentUser, "Showkeyboard").MoValue == "true"
                )
            {
                mystate.Showkeyboard = true;
            }
            else
            {
                mystate.Showkeyboard = false;
            }

            mystate.Speed = da.GetChoice(mystate.CurrentUser, "Speed").MoValue;

            mystate.Testduration =int.Parse( da.GetChoice(mystate.CurrentUser, "Testduration").MoValue);

            mystate.Testtime = da.GetChoice(mystate.CurrentUser, "Testtime").MoValue;

            if (da.GetChoice(mystate.CurrentUser, "Victorysound").MoValue == "true")
            {
                mystate.Victorysound = true;
            }
            else
            {
                mystate.Victorysound = false;
            }

            if (da.GetChoice(mystate.CurrentUser, "Vocalinstructions").MoValue == "true")
            {
                mystate.Vocalinstructions = true;
            }
            else
            {
                mystate.Vocalinstructions = false;
            }

            mystate.Backgroundimage = da.GetChoice(mystate.CurrentUser, "Backgroundimage").MoValue;

            mystate.Detaultkeyboardview = da.GetChoice(mystate.CurrentUser, "DefaultKeyboardView").MoValue;

            mystate.Textcolor = da.GetChoice(mystate.CurrentUser, "Textcolor").MoValue;





        }
        public void setGeneraOptions()
        {
            if (da.GetAnOption("Backgroundmusic").MoValue == "true")
            {
                mystate.Backgroundmusic = true;
            }
            else
            {
                mystate.Backgroundmusic = false;
            }

            if (da.GetAnOption("Errorsound").MoValue == "true")
            {
                mystate.Errorsound = true;
            }
            else
            {
                mystate.Errorsound = false;
            }

            mystate.Recordspeed = int.Parse(da.GetAnOption("Recordspeed").MoValue);

            if (da.GetAnOption("Showinctructions").MoValue == "true")
            {
                mystate.Showinstructions = true;
            }
            else
            {
                mystate.Showinstructions = false;
            }

            if (da.GetAnOption("Showkeyboard").MoValue == "true")
            {
                mystate.Showkeyboard = true;
            }
            else
            {
                mystate.Showkeyboard = false;
            }

            mystate.Speed = da.GetAnOption("Speed").MoValue;

            mystate.Testduration = int.Parse(da.GetAnOption("Testduration").MoValue);

            mystate.Testtime = da.GetAnOption("Testtime").MoValue;

            if (da.GetAnOption("Victorysound").MoValue == "true")
            {
                mystate.Victorysound = true;
            }
            else
            {
                mystate.Victorysound = false;
            }

            if (da.GetAnOption("Vocalinstructions").MoValue == "true")
            {
                mystate.Vocalinstructions = true;
            }
            else
            {
                mystate.Vocalinstructions = false;
            }

            mystate.Backgroundimage = da.GetAnOption("Backgroundimage").MoValue;

            mystate.Detaultkeyboardview = da.GetAnOption("DefaultKeyboardView").MoValue;

            mystate.Textcolor = da.GetAnOption("Textcolor").MoValue;
        }

        #endregion Options

        #region Navigage away(different window)

        #region View Progress


        private void ViewProgress(object sender, RoutedEventArgs e)
        {
            //waiting();
            ////gridWait.Visibility = System.Windows.Visibility.Visible;
            //loadProgress(); 
            loadProgress();
        }

        
        public void loadProgress()
        {
            if (manageTest.RunningNow)
            {
                pause();
            }


            if (mystate.Loggedin)
            {
                //userProgressMenuItem.IsEnabled = true;
                //load progress window here
                //pass user name of the user whos currently logged in

                Progress pr = new Progress(mystate, mystate.Backgroundimage);
                //waiting();
                
                pr.ShowDialog();

                //gridWait.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                //GuestProgress pr = new GuestProgress();

                //pr.ShowDialog();
                /////userProgressMenuItem.IsEnabled = false;
                ////user is not logged in and can not see progress window
            }
        }
        #endregion View Progress


        private void LearnToType(object sender, RoutedEventArgs e)
        {
            //will need to pass the username if the user is loged in
            //Learn learn = new Learn();
            ////this.Close();
            //learn.ShowDialog();
            if (manageTest.RunningNow)
            {
                pause();
            }

            GoToLearningPage();
        }

        private void optionsClosing(object sender, EventArgs e)
        {
            //SetMyOptions();
            SetMyOptions1();
        }

        private void LoadOptionsWindow(object sender, RoutedEventArgs e)
        {
            if (manageTest.RunningNow || mystate.Paused)
            {
                quit();
            }

            Options op;


            if (mystate.Loggedin)
            {
                op = new Options(mystate.CurrentUser, mystate.Backgroundimage);
            }
            else
            {
                op = new Options(mystate.Backgroundimage, 1);
            }

            op.closing += new EventHandler(optionsClosing);
            op.ShowDialog();


        }

        #region WordTris

        private void playWordtris(object sender, RoutedEventArgs e)
        {
            if (manageTest.RunningNow)
            {
                pause();
            }

            this.Hide();
            WordTris wordtris = new WordTris(mystate.Backgroundmusic,mystate.Backgroundimage, mystate.Textcolor);
            wordtris.Closing1 += new EventHandler(childClosing7);
            wordtris.ShowDialog();
        }

        private void childClosing7(object sender, EventArgs e)
        {

            this.ShowDialog();

        }
        #endregion WordTris

        #region Bubble words

        private void playBubble(object sender, RoutedEventArgs e)
        {
            if (manageTest.RunningNow)
            {
                pause();
            }

            GameOn.MainWindow mB = new GameOn.MainWindow(mystate.Backgroundmusic, mystate.Backgroundimage, mytheme.getmyTextColor(mystate.Textcolor));
            this.Hide();

            mB.Closing1 += new EventHandler(childClosing7);
            mB.ShowDialog();
        }

        #endregion Bubble words


        #endregion Navigate away(different window)


        #region Accuracy
        public int CalculateAccuracy(int totalStrokes, int ErrorsMade)
        {
            int tempAcc = 0;

            if (ErrorsMade > 0)
            {
                //tempAcc = (totalStrokes / ErrorsMade) * 10;
                int tempAcc2 = (ErrorsMade * 100) / totalStrokes;
                tempAcc = 100 - tempAcc2;
            }
            else
            {
                tempAcc = 100;
            }

            return tempAcc;

        }


        #endregion Accuracy
        #region Choose test file

        //choose file for the test
        private void ChooseFile(object sender, RoutedEventArgs e)
        {
            if (manageTest.SessionInProgress)
            {
                quit();
            }
            HideKeyboard();
            //let the user chose th file
            //open the chosen file
            //load the chosen file onto the screen
            try
            {
                manageTest.Skill = "PH";
                Start(GetFileName());
            }
            catch
            {
                MessageBox.Show("File not selected", "Select File", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region  Get External file name
        //Gets the name of the external file chosen by the user
        public String GetFileName()
        {

            string filename = "";

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension(txt)

            // Show open file dialog box
            try
            {
                Nullable<bool> result = dlg.ShowDialog();
                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    filename = dlg.FileName;
                }

            }
            catch
            {
                MessageBox.Show("An error");
            }
            return filename;
        }
        #endregion Get External file name

        #endregion Choose test file


        #region Practice based on progress
        private void PracticeBasedOnPracticeProgress(object sender, RoutedEventArgs e)
        {
            //check keyboard options
            ShowKeyboard();

            if (/*loggedin*/ mystate.Loggedin)
            {
                try
                {
                    List<UserSkill> userskills = da.GetUserSkills(mystate.CurrentUser/*currentUser*/);
                    //load skills based on the user's progress
                    #region Load Right Practice Drill for a logged in user
                    if (!hasSkill(userskills, "HR"))//user has not taken the home row drill practice
                    {
                        manageTest.Skill = "HR";
                        StartPractice("HR", false);
                    }
                    else if (!hasSkill(userskills, "HRATR"))
                    {
                        manageTest.Skill = "HRATR";
                        StartPractice("HRATR", false);
                    }
                    else if (!hasSkill(userskills, "HRAFR"))
                    {
                        manageTest.Skill = "HRAFR";
                        StartPractice("HRAFR", false);

                    }
                    else if (!hasSkill(userskills, "AROL"))
                    {
                        manageTest.Skill = "AROL";
                        StartPractice("AROL", false);
                    }
                    else if (!hasSkill(userskills, "AROLS"))
                    {
                        manageTest.Skill = "AROLS";
                        StartPractice("AROLS", false);
                    }
                    else if (!hasSkill(userskills, "AROLP"))
                    {
                        manageTest.Skill = "AROLP";
                        StartPractice("AROLP", false);
                    }
                    else
                    {
                        //MessageBox
                        MessageBox.Show("You completed all the skills! please choose a skill "+
                    "you are not comfortable with from the skills list", "Skills Completed",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        if (manageTest.SessionInProgress)
                        {
                            quit();
                        }
                        //skills session maybe? after the user has completed the skills
                    }

                    //string drillname = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
                    //Start(drillname);
                    #endregion Load right practice Drill for a logged in user
                }
                catch
                {
                    ErrorReadingPersonalSettings();
                }
            }
            else
            {

                //load the skills by order starting with the first one
                StartPractice(manageskill.getNextSkill(), true);
                
            }
        }
        #endregion Practice based on progress


        #region Own text
        bool practiceclicked = true;
        
        private void childClosing3(object sender, EventArgs e)
        {
            //read from file free
            //practice
            //not a session
            loadmytext();
           

        }
        private void childClosing4(object sender, EventArgs e)
        {
            
            //text not updated
            if (manageTest.SessionInProgress)
            {
                quit();
                
            }
            //what esle should i do here?
        }


        private void WriterText(object sender, RoutedEventArgs e)
        {
            if (manageTest.SessionInProgress)
            {
                quit();
            }

            manageTest.Skill = "PH";

            //write new text then practice that text
            practiceclicked = true;
            freeText free;
            if (!mystate.Loggedin)
            {
                free = new freeText(mystate.Backgroundimage, 1, mytheme.getmyTextColor(mystate.Textcolor));
            }
            else
            {
                free = new freeText(mystate.CurrentUser, mystate.Backgroundimage);
            }




            free.Closing3 += new EventHandler(childClosing3);
            free.Closing4 += new EventHandler(childClosing4);
            free.ShowDialog();
        }


        private void testOnMytext(object sender, RoutedEventArgs e)
        {
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;
            //test on my own text
            practiceclicked = false;
            manageTest.Skill = "PH";
            loadmytext();
        }

        public void loadmytext()
        {
            var filename = "";
            //read from file free
            //practice
            //not a session
            if (!mystate.Loggedin)
            {
                filename = "free.txt";
            }
            else
            {
                filename = mystate.CurrentUser + "_free.txt";
            }

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);


            if (practiceclicked)
            {
                //practice

                ShowKeyboard();
                Start(path, false);
                
            }
            else
            {
                //test
                try
                {
                    Start(path);
                }
                catch
                {
                    newTextForTest();
                }
                HideKeyboard();
            }
        }

        private void newTextForTest(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "PH";
            newTextForTest();
        }
        public void newTextForTest()
        {
            if (manageTest.SessionInProgress)
            {
                quit();
            }
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;
            //test me on my new text
            practiceclicked = false;

            freeText free;// = new freeText();

            if (!mystate.Loggedin)
            {
                free = new freeText(mystate.Backgroundimage, 1, mytheme.getmyTextColor(mystate.Textcolor));
            }
            else
            {
                free = new freeText(mystate.CurrentUser, mystate.Backgroundimage);
            }

            free.Closing3 += new EventHandler(childClosing3);
            free.Closing4 += new EventHandler(childClosing4);
            free.ShowDialog();
        }

        private void PracticeMyOwnText(object sender, RoutedEventArgs e)
        {
            practiceclicked = true;
            loadmytext();
            manageTest.Skill = "PH";
        }

        #endregion Own text

        //gives the user an option to continue practicing the skill or move to the next skill
        #region EndOfAnotherSkill
        private void childClosing(object sender, EventArgs e)
        {


            //next
            BrownButtons();
            //BrownButtons2();

            #region Next Skill
            //continue to the next skill in the skills array
            try
            {
                //BrownButtons();
                //BrownButtons2();

                StartPractice(manageskill.getNextSkill(), true);


            }
            catch (IndexOutOfRangeException)
            {
                //there is no next skill
                MessageBox.Show("You have completed all the skills! please choose a "+
                    "you are not comfortable with from the skills list", "Skills completed",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                displayRecord();
            }
            #endregion Next Skill

            
        }
        private void childClosing1(object sender, EventArgs e)
        {


            //same
            BrownButtons();
            //BrownButtons2();

            //loads the same skill
            StartPractice(manageskill.CurrentSkill, true);

            
        }

        private void childClosing2(object sender, EventArgs e)
        {
            quit();
        }


        //public bool PracticeYes = true;
        public void endOfAnotherSkill(int speed)
        {
            
            manageTest.SkillSession = true;

            #region Practice Result window 
            //from test results
            int seconds = elapsedsec;

            TypingSpeed speed1 = new TypingSpeed((manageTest.Strokes + manageTest.Errors), seconds, manageTest.Errors, wpm());
            int sp = speed1.GetTypingSpeed();
            //from test results

            #region New way
            UserResults results = new UserResults(sp, seconds, manageTest.Strokes, manageTest.Errors, 0, manageTest.TestkeypressInfor, dk.GetDistinctKeys());
            results.Skill = manageTest.Skill;
            if (mystate.Loggedin)
            {
                results.CurrentUser = mystate.CurrentUser;
            }
            results.Skill = manageTest.Skill;
            
            skillsResult sk2 = new skillsResult(results, mystate.Backgroundimage, mytheme.getmyTextColor(mystate.Textcolor));
            sk2.Closing1 += new EventHandler(childClosing);
            sk2.Closing2 += new EventHandler(childClosing1);
            sk2.Closing3 += new EventHandler(childClosing2);
            sk2.ShowDialog();

            #endregion New way


            #region Old way

            //skillsResult sk = new skillsResult(seconds, manageTest.Strokes, sp, manageTest.Errors);
            ////need to include the speed and the accuracy in the message box
            //sk.Closing1 += new EventHandler(childClosing);
            //sk.Closing2 += new EventHandler(childClosing1);

            //sk.ShowDialog();
            #endregion Old way


            #endregion Practice Results window

            #region Practice Results dialog

            //BrownButtons2();

            //string result;
            //result = MessageBox.Show("Speed:\t"+ speed.ToString()+" wpm\nErrors:\t" + 
            //    manageTest.Errors+ " \ngo to the next one?", 
            //    "Skills", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            //if (result.ToLower() == "yes")
            //{
            //    #region Next Skill
            //    //continue to the next skill in the skills array
            //    try
            //    {
            //        //BrownButtons();
            //        //BrownButtons2();

            //        StartPractice(manageskill.getNextSkill(), true);


            //    }
            //    catch(IndexOutOfRangeException)
            //    {
            //        //there is no next skill
            //        MessageBox.Show("You have completed all the skills", "Skills completed",
            //            MessageBoxButton.OK,MessageBoxImage.Information);
            //        displayRecord();
            //    }
            //    #endregion Next Skill

            //}
            //else
            //{
            //    BrownButtons();
            //    //loads the same skill
            //    StartPractice(manageskill.CurrentSkill, true);
            //}
            #endregion Practice results dialog

        }
        #endregion

        
        //check if the skill passed is in the list of the user's skills
        #region hasSkill
        
        public bool hasSkill(List<UserSkill> a, string skillId)
        {
            foreach (UserSkill ski in a)
            {
                if (ski.SkillID.ToString() == skillId)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion hasSkill


        //called when a key that was pressed is a symbol key, first function and shift function
        #region Symbol key
        public void handleSymbolInput(string key)
        {

            if (key == "Oem1" || key == "OemColon" || key == "OemSemicolon")
            {
                #region colon
                //colon and semi colon key was pressed(;, :)
                if ((string)position8.Content == ";" || (string)position8.Content == ":")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(:)
                        if ((string)position8.Content == ":")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                        
                    }
                    else
                    {
                        if ((string)position8.Content == ";")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion colon

            }
            else if (key == "Oem2" || key == "OemQuestion" || key == "OemForwardSlash")
            {
                #region question mark, forward slash
                //forward slesh key was pressed(?, /)
                if ((string)position8.Content == "?" || (string)position8.Content == "/")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(?)
                        if ((string)position8.Content == "?")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "/")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                        
                    }
                }
                else
                {
                    typo();
                }
                #endregion
            }
            else if (key == "Oem3" || key == "Oemtilde")
            {
                #region tilde
                //tidle key was pressed(~, `)
                if ((string)position8.Content == "`" || (string)position8.Content == "~")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(~)
                        if ((string)position8.Content == "~")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "`")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion tilde
            }
            else if (key == "Oem4" || key == "OemOpenBrackets")
            {
                #region Open Brackets
                //open blackets key was pressed({, [)
                if ((string)position8.Content == "{" || (string)position8.Content == "[")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function({)
                        if ((string)position8.Content == "{")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "[")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Open Brackets
            }
            else if (key == "Oem5" || key == "OemBackslash")
            {
                #region Backslash
                //back slash key was pressed(\,|)
                if ((string)position8.Content == "\\" || (string)position8.Content == "|")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(|)
                        if ((string)position8.Content == "|")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "\\")
                        {
                            Move();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion backslash
            }
            else if (key == "Oem6" || key == "OemCloseBrackets")
            {
                #region Close Brackets
                //close curly brace key was pressed(}, ])
                if ((string)position8.Content == "]" || (string)position8.Content == "}")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(})
                        if ((string)position8.Content == "}")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "]")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Close Brackets
            }
            else if (key == "Oem7" || key == "OemQuotes")
            {
                #region Quotes
                //the quote key was pressed(', ")
                if ((string)position8.Content == "'" || (string)position8.Content == "\"")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(")
                        if ((string)position8.Content == "\"")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "'")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Quotes
            }
            else if (key == "OemComma")
            {
                #region Comma
                //the comman key was pressed(, , <)
                if ((string)position8.Content == "," || (string)position8.Content == "<")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(<)
                        if ((string)position8.Content == "<")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == ",")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Comma
            }
            else if (key == "OemPeriod")
            {
                #region Period
                //the Period key was presssed(., >)
                if ((string)position8.Content == "." || (string)position8.Content == ">")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(>)
                        if ((string)position8.Content == ">")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == ".")
                        {
                            Move();
                        }
                        else
                        {
                            typo();
                        }
                        
                    }
                }
                else
                {
                    typo();
                }
                #endregion Period
            }
            else if (key == "OemMinus")
            {
                #region Minus
                //the minus key wa pressed(_, -)
                if ((string)position8.Content == "_" || (string)position8.Content == "-")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(_)
                        if ((string)position8.Content == "_")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "-")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Minus
            }
            else if (key == "OemPlus")
            {
                #region Plus
                //the plus key was pressed(+,=)
                if ((string)position8.Content == "+" || (string)position8.Content == "=")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        //key second function(+)
                        if ((string)position8.Content == "+")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else
                    {
                        if ((string)position8.Content == "=")
                        {
                            Move();
                            ClearErrors();
                        }
                        else
                        {
                            typo();
                        }
                    }
                }
                else
                {
                    typo();
                }
                #endregion Plus
            }
            else if (key == "Add")
            {
                if ((string)position8.Content == "+")
                {
                    Move();
                }
                else
                {
                    typo();
                }
            }
            else if (key == "Subtract")
            {
                if ((string)position8.Content == "-")
                {
                    Move();
                }
                else
                {
                    typo();
                }
            }
            else if (key == "Multiply")
            {
                if ((string)position8.Content == "*")
                {
                    Move();
                }
                else
                {
                    typo();
                }
            }
            else if (key == "Divide")
            {
                if ((string)position8.Content == "/")
                {
                    Move();
                }
                else
                {
                    typo();
                }
            }
            else if (key == "Decimal")
            {
                if ((string)position8.Content == ".")
                {
                    Move();
                }
                else
                {
                    typo();
                }
            }
            else
            {
                //i dont work with the key that was pressed
                //i wont bother handling this 
            }


        }
        #endregion symbol key

        //adds an error to the manager and gives instructions
        #region Typing error
        DifficultKeys dk;

        public void typo()
        {
            //if (manageTest.SessionInProgress)
            //{
            //    btnInstructions.Content = (qe.GetInstructions((string)position8.Content));
            //}
            //maybe play error sound as well
            manageTest.Errors += 1;

            //testing difficult keys
            dk.AddToMissedKeys((string)position8.Content); //works perfectly!!
            pressWatcher.Missed();
            //PlayErrorSound();

            //soundSimulator.PlayError();
            if (manageTest.ErrorSound)
            {
                manageTest.SoundSimulator.PlayError();
            }
            //if (manageTest.PracticeSession)
            //{
            //    manageTest.SoundSimulator.Play((string)position8.Content);
            //}
            //else
            //{
            //    manageTest.SoundSimulator.PlayError();
            //}
        }

        //public bool PlayErrorSound()
        //{


        //    if (manageTest.ErrorSound)
        //    {
        //        //var filename = "Sound\\key_drop1.wav";
        //        var filename = manageTest.ErrorSoundFile;
        //        mySounds(filename);
        //    }


        //    return true;
        //}

        public void mySounds(string filename)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            SoundPlayer sound = new SoundPlayer(path);

            sound.Play();

        }
        //public void myErrorPlayer
        //{

        //}

        #endregion Typing error

        //clears insctructions
        #region CorrectKey
        public void ClearErrors()
        {
            //if ((string)btnInstructions.Content != "")
            //{
            //    btnInstructions.Content = "";
            //}
        }
        #endregion CorrectKey


        //called when i need to know if the expected key input is a symbol that's in the d(0-9) keys
        #region Did the user have to type a symbol thats in the d keys
        public bool isSymbolExpected(string value)
        {
            string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")" };
            foreach (string sym in symbols)
            {
                if (sym == value)
                    return true;
            }
            return false;
        }
        #endregion symbol in the d keys

        #region Numberkey Press with shift key
        public bool isKeyMatchingSymbol(string key, string value)
        {
            if (value == "!")
            {
                if (key == "D1")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "@")
            {
                if (key == "D2")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "#")
            {
                if (key == "D3")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "$")
            {

                if (key == "D4")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "%")
            {
                if (key == "D5")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "^")
            {
                if (key == "D6")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "&")
            {
                if (key == "D7")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "*")
            {
                if (key == "D8")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == "(")
            {
                if (key == "D9")
                {
                    return true;
                }
                else
                    return false;
            }
            else if (value == ")")
            {
                if (key == "D0")
                {
                    return true;
                }
                else
                    return false;
            }
            return false;


        }
        #endregion Number key with shift key


        //Starts a new session
        #region Start Session


        public void Start(string fileName)
        {
            BrownButtons();
            //BrownButtons2();
            ClearTestManager();

            manageTest.SessionInProgress = true;
            manageTest.Difficultkeys = false;

            dk = new DifficultKeys();
            

            string testText = "";
            //reads the file into a string
            TextFileToString txt = new TextFileToString(fileName);

            try
            {
                //reads the file into a string
                testText = txt.ReadToString();
            }
            catch
            {
                throw new ApplicationException();
            }

            //reset the time

            pressWatcher = new PressWatcher(((string)position8.Content).ToLower(), 
                ((string)position7.Content).ToLower());
            manageTest.Text = testText;
            manageTest.FocusPosition = 0;
            manageTest.Length = testText.Length;

            //bool started = manageTest.Startb(position1, position2, position3, position4, position5, position6,
            //     position7, position8, position9, position10, position11, position12, position13,
            //     position14, position15);

            bool started = manageTest.StartLong(pos18, pos19, position1, position2, position3, position4, position5, position6,
                 position7, position8, position9, position10, position11, position12, position13,
                 position14, position15, pos16, pos17);


            if (!(started))
            {

                quit();
                //file to short
                MessageBox.Show("could not open file, file to short", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                manageTest.HasBeenStarted = true;
                manageTest.LastFilename = fileName;
                simulateKeyPress(((string)position8.Content).ToLower());

                //simulateKeyPressPicture(((string)position8.Content).ToLower());
                if (gridhands.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateHandPress(((string)position8.Content));
                }
                //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

                //showTime(setTime());
                initaiteTimer();
                showTime(manageTest.Counter);

                if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateNumPress((string)position8.Content);
                }
                //manageTest.VocalSeconds.Start();
            }
        }
        //starts a new session for practice
        public void Start(string fileName, bool skillsession)
        {
            BrownButtons();
            //BrownButtons2();
            
            ClearTestManager();
            manageTest.SessionInProgress = true;
            manageTest.PracticeSession = true;
            manageTest.Difficultkeys = false;

            

            dk = new DifficultKeys();

            if (skillsession)
            {
                manageTest.SkillSession = true;
            }

            

            TextFileToString txt = new TextFileToString(fileName);

            string testText = "";

            try
            {
                //reads the file into a string
                testText = txt.ReadToString();
            }
            catch
            {
                MessageBox.Show("Could not read file", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            manageTest.Text = testText;
            manageTest.FocusPosition = 0;
            manageTest.Length = testText.Length;

            
               //bool started =  manageTest.Startb(position1, position2, position3, position4, position5, position6,
               //     position7, position8, position9, position10, position11, position12, position13,
               //     position14, position15);

               bool started = manageTest.StartLong(pos18, pos19, position1, position2, position3, position4, position5, position6,
                    position7, position8, position9, position10, position11, position12, position13,
                    position14, position15, pos16, pos17);

               if (!(started))
               {

                   quit();
                   //file to short
                   MessageBox.Show("could not open file, file to short", "Error",
                       MessageBoxButton.OK, MessageBoxImage.Error);
               }
               else
               {
                   pressWatcher = new PressWatcher(((string)position8.Content).ToLower(),
                       ((string)position7.Content).ToLower());
                   manageTest.HasBeenStarted = true;
                   manageTest.LastFilename = fileName;
                   simulateKeyPress(((string)position8.Content).ToLower());
                   simulateHandPress(((string)position8.Content));
                   //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));
                   //showTime(setTime());
                   initaiteTimer();
                   showTime(manageTest.Counter);
                   if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
                   {
                       simulateNumPress((string)position8.Content);
                   }
                   //if (manageTest.VocalInstructionsOn)
                   //{
                   //    threadVocalInstructions();
                   //}
                   manageTest.VocalSeconds.Start();
                   
               }
            
        }

        public void Start(string fileName, string difkeys)
        {
            BrownButtons();
            //BrownButtons2();
            ClearTestManager();

            manageTest.SessionInProgress = true;
            manageTest.Difficultkeys = true;
            manageTest.PracticeSession = true;

            dk = new DifficultKeys();
            

            string testText = "";
            //reads the file into a string
            TextFileToString txt = new TextFileToString(fileName);
            try
            {
                testText = txt.ReadToString();
            }
            catch
            {
                throw new ApplicationException();
            }

            //reset the time


            manageTest.Text = testText;
            manageTest.FocusPosition = 0;
            manageTest.Length = testText.Length;

            //bool started = manageTest.Startb(position1, position2, position3, position4, position5, position6,
            //     position7, position8, position9, position10, position11, position12, position13,
            //     position14, position15);

            bool started = manageTest.StartLong(pos18, pos19, position1, position2, position3, position4, position5, position6,
                 position7, position8, position9, position10, position11, position12, position13,
                 position14, position15, pos16, pos17);

            if (!(started))
            {

                quit();
                //file to short
                MessageBox.Show("You dont have many difficult keys, continue with your practice!", "Difficult keys",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                pressWatcher = new PressWatcher(((string)position8.Content).ToLower(),
                    ((string)position7.Content).ToLower());
                manageTest.HasBeenStarted = true;
                manageTest.LastFilename = fileName;
                simulateKeyPress(((string)position8.Content).ToLower());
                if (gridhands.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateHandPress(((string)position8.Content));
                }
                //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

                //showTime(setTime());
                initaiteTimer();
                showTime(manageTest.Counter);

                if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateNumPress((string)position8.Content);
                }

                manageTest.VocalSeconds.Start();
                //if (manageTest.VocalInstructionsOn)
                //{
                //    threadVocalInstructions();
                //}
            }
        }

        public void Restart()
        {
            if (manageTest.HasBeenStarted)
            {

                if (manageTest.Keyboardshown)
                {
                    //practice restart
                    Start(manageTest.LastFilename, false);
                }
                else
                {
                    //test restart
                    try
                    {
                        Start(manageTest.LastFilename);
                    }
                    catch
                    {
                        //could not read file?
                    }
                }
            }
        }

        //manage test clean up
        public void ClearTestManager()
        {

            manageTest.PracticeSession = false;
            manageTest.SkillSession = false;
            manageTest.Strokes = 0;
            manageTest.Errors = 0;
            manageTest.SessionInProgress = false;
            manageTest.InitailPress = true;
            manageTest.Difficultkeys = false;
            BrownButtons();

            //_time = setTime();
            manageTest.Time = setTime();
            mystate.Paused = false;
            elapsedsec = 0;
            lblTimer.Content = "";
            //lblspeed.Content = "";
            try
            {
                //_countdownTimer.Stop();
                manageTest.CountDown.Stop();
                manageTest.Soundsimulation.Stop();
            }
            catch
            {
                //timer is not started.
            }


        }
        #endregion Start Session

         
        myState mystate = new myState();
        ManageSkill manageskill = new ManageSkill();
        QwertyEnglish qe = new QwertyEnglish();
        ManageTest manageTest = new ManageTest();
        SessionTimer sessionTimer = new SessionTimer();
        BussinessLayer.DataAccess da = new DataAccess();
        shift shift = new shift();
        NumKeys Nk = new NumKeys();
        PressWatcher pressWatcher;
        //SoundManager soundSimulator;


        #region Move
        //changes the text displayed on the text block
        //moves each of the chars in the labels to the left
        void Move()
        {
            BrownButtons();
            
            #region control
            
            manageTest.Strokes += 1;

            #endregion control

            #region New

            pressWatcher.EndWatch();
            manageTest.TestkeypressInfor.Add(pressWatcher);

            //bool moreMoves = manageTest.MoveB(position1, position2, position3, position4, position5, position6,
            //            position7, position8, position9, position10, position11, position12, position13,
            //            position14, position15);

            bool moreMoves = manageTest.MoveLong(pos18, pos19, position1, position2, position3, position4, position5, position6,
                        position7, position8, position9, position10, position11, position12, position13,
                        position14, position15, pos16, pos17); 

            if (!(moreMoves))
            {

                BrownButtons();
                
                //no more moves
                //stops the timer displayed and gives test results
                stopMytimer();
            }
            else
            {
                //simulate next key press
                BrownButtons();
                pressWatcher = new PressWatcher(((string)position8.Content).ToLower(), 
                    ((string)position7.Content).ToLower());

                simulateKeyPress(((string)position8.Content).ToLower());

                if (gridhands.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateHandPress(((string)position8.Content));
                }
                //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

                if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
                {
                    simulateNumPress((string)position8.Content);
                }

                manageTest.Moving = true;

                //setImages();

                //if (manageTest.VocalInstructionsOn && manageTest.PracticeSession)
                //{
                //    threadVocalInstructions();
                //}
            }
            
            #endregion New

            #region old
            //try
            //{
            //    manageTest.Move(position1, position2, position3, position4, position5, position6,
            //            position7, position8, position9, position10, position11, position12, position13,
            //            position14, position15);

            //    BrownButtons();
            //}
            //catch//index out of range exception
            //{
            //    //BrownButtons();
            //    sessionTimer.Stop();

            //    manageTest.SessionInProgress = false;
            //    if (manageTest.PracticeSession)
            //    {
            //        PracticeSessionResult();
            //    }
            //    else
            //    {
            //        //test results
            //        TestSessionResults();
            //        displayRecord();
                    
            //    }
            //    BrownButtons();
            //}
            #endregion old
            

        }
        #endregion Move

        
        

        #region Session Results
        //shows practices results

        public bool wpm()
        {
            string wpm = "wpm";

            if (mystate.Loggedin)
            {
                //wpm = da.GetChoice(mystate.CurrentUser, "Speed").MoValue;
                wpm = mystate.Speed;
            }
            else
            {
                //wpm = da.GetAnOption("Speed").MoValue;
                wpm = mystate.Speed;
            }

            try
            {
                if (wpm == "wpm")
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }
            return false;
        }


        public void PracticeSessionResult()
        {

            //BrownButtons2();
            BrownButtons();
            //get the time in secondsint 
            //int seconds = int.Parse(sessionTimer.GetDuration());
            int seconds = elapsedsec;
            TypingSpeed speed = new TypingSpeed((manageTest.Strokes + manageTest.Errors), seconds, manageTest.Errors, wpm());

            int sp = speed.GetTypingSpeed();
            if (manageTest.SkillSession)
            {
                BrownButtons();
                //gives the results then loads another skill
                endOfAnotherSkill(sp);

            }
            else
            {
                BrownButtons();
                #region Old results
                //MessageBoxResult result = MessageBox.Show("Your speed:\t" + sp + " wpm\nYour Errors:\t" + manageTest.Errors.ToString() , "Practice Results",
                //    MessageBoxButton.OK, MessageBoxImage.Information);

                #endregion Old Results

                if (!manageTest.Difficultkeys)
                {

                    if (WriteSkillToDb(sp)) //works perfectly just need to deal
                    {
                    }
                    if ((dk.GetDistinctKeys()).Length >= 1)
                    {

                        List<string> difficultkeys = getDifficultKeys();

                        foreach (string key in difficultkeys)
                        {
                            if (key != "\"" && key != " ")
                            {
                                PracticeDifficultKeys pdk = new PracticeDifficultKeys(mystate.CurrentUser, manageTest.Skill, key);
                                try
                                {
                                    da.InsertPracticeDifficultKey(pdk);
                                }
                                catch (Exception)
                                {
                                    //ErrorSavingYourInformation();
                                    //dublicate key?
                                    //MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }

                }

                // with the errors/accuracy thing.
                Results();

                // if (result.ToString() == "OK")
                //{
                //    
                //}
                displayRecord();
                //

            }

        }

        public bool WriteSkillToDb(int speed)
        {
            if (/*loggedin*/ mystate.Loggedin)
            {
                int accuracy = CalculateAccuracy(manageTest.Strokes + manageTest.Errors, manageTest.Errors);
                if (!AlreadyHasSkill())
                {

                    
                    //still need to calculate the accuracy

                    UserSkill userskill = new UserSkill(/*currentUser*/mystate.CurrentUser, manageTest.Skill, speed.ToString(), accuracy.ToString());

                    // //if the user does not have this skill or the user's previous best is smaller than this attempt
                    try
                    {
                        da.InsertUserSkill(userskill);
                        return true;
                    }
                    catch
                    {
                        //fore testing
                        //ErrorSavingYourInformation();
                        //skill is already in the database
                        //need to first check if the skill is already in the database

                        //update if the speed is greater than the one on the database
                        
                    }
                }
                else
                {
                    UpdateSkill(manageTest.Skill, speed, accuracy);
                }
            }
            return false;
        }

        public void UpdateSkill(string skillId, int speed, int accuracy)
        {
            if (newSkillIsBetter(speed, accuracy))
            {
                try
                {
                    UserSkill myskill = new UserSkill(mystate.CurrentUser, manageTest.Skill, speed.ToString(), accuracy.ToString());
                    da.updateUserSkill(myskill);
                }
                catch
                {
                    //what happened?
                }
            }
        }
        public bool newSkillIsBetter(int speed, int accuracy)
        {
            try
            {
                UserSkill myskill = da.GetASkill(manageTest.Skill, mystate.CurrentUser);

                if (int.Parse(myskill.Speed) < speed && int.Parse(myskill.Accuracy) < accuracy)
                {
                    return true;
                }
            }
            catch
            {
                //what happened?
            }

            return false;
        }


        public bool AlreadyHasSkill()
        {
            try
            {
                List<UserSkill> tempSkills = da.GetUserSkills(mystate.CurrentUser);

                foreach (UserSkill myskill in tempSkills)
                {
                    if (myskill.SkillID.ToLower() == manageTest.Skill.ToLower())
                    {
                        return true;
                    }
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }
            return false;
        }

        //shows test results
        public void TestSessionResults()
        {
            int seconds = int.Parse(sessionTimer.GetDuration());
            TypingSpeed speed = new TypingSpeed(manageTest.Strokes, seconds, manageTest.Errors, wpm());
            int sp = speed.GetTypingSpeed();

            #region Old results
            //MessageBox.Show("Your speed:\t" + sp + " wpm\nYour Errors:\t" + manageTest.Errors, "Test Results",
            //  MessageBoxButton.OK, MessageBoxImage.Information);

            #endregion Old results
            try
            {

                if (wpm())
                {
                    #region Wpm
                    if (!mystate.Loggedin)
                    {

                        if (sp > int.Parse(da.GetAnOption("Recordspeed").MoValue))
                        {
                            //new top speed, notify the user
                            //update Recordspeed in the database
                            //show new record
                            ManageOptions nm = new ManageOptions("Recordspeed", sp.ToString());
                            da.updateOption(nm);
                            SetMyOptions1();
                        }
                    }
                    else
                    {
                        if (sp > int.Parse(da.GetChoice( mystate.CurrentUser, "Recordspeed").MoValue))
                        {
                            //new top speed, notify the user
                            //update Recordspeed in the database
                            //show new record
                            //ManageOptions nm = new ManageOptions("Recordspeed", sp.ToString());
                            //da.updateOption(nm);

                            da.updateUserSettings(new UserSettings(mystate.CurrentUser, "Recordspeed", sp.ToString()));
                            SetMyOptions1();
                        }
                    }
                    #endregion Wpm

                }
                else
                {
                    #region Cpm
                    if (!mystate.Loggedin)
                    {

                        if (sp > int.Parse(da.GetAnOption("Recordspeed").MoValue) * 5)
                        {
                            //new top speed, notify the user
                            //update Recordspeed in the database
                            //show new record

                            int changeToWPM = sp / 5;
                            ManageOptions nm = new ManageOptions("Recordspeed", changeToWPM.ToString());
                            da.updateOption(nm);
                            SetMyOptions1();
                        }
                    }
                    else
                    {
                        if (sp > int.Parse(da.GetChoice(mystate.CurrentUser, "Recordspeed").MoValue) * 5)
                        {
                            //new top speed, notify the user
                            //update Recordspeed in the database
                            //show new record

                            int changeToWPM = sp / 5;
                            //ManageOptions nm = new ManageOptions("Recordspeed", changeToWPM.ToString());
                            //da.updateOption(nm);
                            da.updateUserSettings(new UserSettings(mystate.CurrentUser, "Recordspeed", changeToWPM.ToString()));
                            SetMyOptions1();
                        }
                    }
                    #endregion Cpm
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            Results();

        }


        public void Results()
        {
            BrownButtons();
            //BrownButtons2();
            //int seconds = int.Parse(sessionTimer.GetDuration());
            
            int seconds = elapsedsec;
            TypingSpeed speed = new TypingSpeed((manageTest.Strokes + manageTest.Errors), seconds, manageTest.Errors, wpm());
            int sp = speed.GetTypingSpeed();

            //if the user is logged in write the test to the database
            if (mystate.Loggedin/*loggedin*/)
            {
                if (!manageTest.PracticeSession)
                {
                    WriteTestToDb();// works perfectly, just need to deal with
                    //the difficult keys thing first
                }
                else
                {
                    if (!manageTest.Difficultkeys)
                    {
                        WriteSkillToDb(sp);
                        //PracticeSessionResult();
                    }
                    else
                    {
                        //remove keys that were missed
                        RemoveDifficultkeys();
                        
                    }
                }
                //whenLoaded();
            }
            
            #region New way
            UserResults results = new UserResults(sp, seconds, manageTest.Strokes, manageTest.Errors, 0, manageTest.TestkeypressInfor, dk.GetDistinctKeys());

            if (mystate.Loggedin)
            {
                results.CurrentUser = mystate.CurrentUser;
            }
            results.Skill = manageTest.Skill;
            results.Skill = manageTest.Skill;

            results.Mystate = mystate;

            Brush mybrush = mytheme.getmyTextColor(mystate.Textcolor);
            Results rslt = new Results(results, mystate.Backgroundimage, mybrush);
            rslt.ShowDialog();
            manageTest.clearPressWatchers();

            #endregion New way

            #region Old way
            //Results results1 = new Results(seconds, manageTest.Strokes, sp, manageTest.Errors);

            //results1.ShowDialog();
            #endregion Old way
        }

        public void RemoveDifficultkeys()
        {
            List<TestDifficultKeys> removetestkeys = gettestkeystoremove();
            List<PracticeDifficultKeys> removepracticekeys = getpracticekeystoremove();


            foreach (TestDifficultKeys mykey in removetestkeys)
            {
                if (manageTest.keyWasPressed(mykey.Keyname.ToString()))
                {
                    try
                    {
                        da.DeleteTestDifficultKey(mykey);
                    }
                    catch
                    {
                        //swalo
                    }
                }
            }
            foreach (PracticeDifficultKeys mykey in removepracticekeys)
            {
                if (manageTest.keyWasPressed(mykey.Keyname.ToString()))
                {
                    try
                    {
                        da.DeleteTestDifficultKey(mykey);
                    }
                    catch
                    {
                        //swalo
                    }
                }
            }


            GetMyInformation();
            //whenLoaded();

            //how do i remove the keys.
            //MessageBox.Show("Remove keys that were not missed");

            
        }
        public List<TestDifficultKeys> gettestkeystoremove()
        {
            List<TestDifficultKeys> removeFromDb = new List<TestDifficultKeys>();
            string difficultkeys = dk.GetDifficultKeys();

            foreach (TestDifficultKeys dif in manageTest.MyTestDifficultKeys)
            {
                bool found = false;
                foreach (char mychar in difficultkeys)
                {
                    if (mychar.ToString() == dif.Keyname)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    removeFromDb.Add(dif);
                    //manageTest.MyTestDifficultKeys.Remove(dif);
                    //nolongerdifficult
                }
            }
            return removeFromDb;

        }
        public List<PracticeDifficultKeys> getpracticekeystoremove()
        {
            List<PracticeDifficultKeys> removeFromDb = new List<PracticeDifficultKeys>();
            string difficultkeys = dk.GetDifficultKeys();

            foreach (PracticeDifficultKeys dif in manageTest.MyPracticeDifficultKeys)
            {
                bool found = false;
                foreach (char mychar in difficultkeys)
                {
                    if (mychar.ToString() == dif.Keyname)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    removeFromDb.Add(dif);
                    //manageTest.MyTestDifficultKeys.Remove(dif);
                    //nolongerdifficult
                }
            }
            return removeFromDb;

        }

        public void WriteTestToDb()
        {
            try
            {

                Test usertest = new Test((LastTestId() + 1).ToString(), (manageTest.Strokes + manageTest.Errors).ToString(), manageTest.Errors.ToString(),
                    elapsedsec.ToString(), manageTest.Skill, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), mystate.CurrentUser /*currentUser*/);

                da.InsertTest(usertest);

                //also write the difficults keys for the test

                int testId = LastTestId();

                if ((dk.GetDistinctKeys()).Length >= 1)
                {
                    List<string> difficultkeys = getDifficultKeys();

                    foreach (string mystring in difficultkeys)
                    {
                        if (mystring != "\"" && mystring != " ")
                        {
                            TestDifficultKeys td = new TestDifficultKeys(testId.ToString(), mystring);
                            da.InsertTestDifficultKey(td);
                        }
                    }
                }
            }
            catch
            {
                ErrorSavingYourInformation();
            }

            
        }
        public void ErrorSavingYourInformation()
        {
            MessageBox.Show("Error saving your information", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public List<string> getDifficultKeys()
        {
            List<string> a = new List<string>();

            string dif = dk.GetDistinctKeys();

            foreach (char mychar in dif)
            {
                a.Add(mychar.ToString());
            }


            return a;
        }

        #endregion Session Results


        bool isResuming = false;

        #region Window keydown handler
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumLock)
            {
                lblWorning.Content = "";
            }
            else if (manageTest.SessionInProgress)
            {
                #region Session In Progress
                if (!mystate.Paused)
                {
                    //start session timer if its the first keypress
                    if (manageTest.InitailPress)
                    {
                        //starts the countdonw timer displayed on the screen
                        startMyTimer();
                        manageTest.InitailPress = false;

                        if (isResuming)
                        {
                            pressWatcher.resume();
                            isResuming = false;
                        }
                    }


                    if (e.Key.ToString() == "RightShift" || e.Key.ToString() == "LeftShift")
                    {
                        //i don't handle this event for shift keys
                        e.Handled = false;
                    }
                    else if (!((e.Key < Key.A) || (e.Key > Key.Z)))
                    {
                        #region Alpha
                        string currentKey = e.Key.ToString();
                        if (currentKey == ((string)position8.Content).ToUpper())
                        {

                            if (((string)position8.Content).ToUpper() == (string)position8.Content)
                            {
                                if (Keyboard.Modifiers == ModifierKeys.Shift || Console.CapsLock)
                                {

                                    if (!(Keyboard.Modifiers == ModifierKeys.Shift && Console.CapsLock))
                                    {
                                        Move();
                                    }
                                    else
                                    {
                                        typo();
                                    }
                                    //ClearErrors();
                                }
                                else
                                {
                                    typo();
                                }
                            }
                            else
                            {
                                if (!(Console.CapsLock) && (!(Keyboard.Modifiers == ModifierKeys.Shift)))
                                {
                                    Move();
                                    //ClearErrors();
                                }
                                else
                                {
                                    if ((Console.CapsLock) && (Keyboard.Modifiers == ModifierKeys.Shift))
                                    {
                                        Move();
                                    }
                                    else
                                    {
                                        typo();
                                    }
                                }
                            }
                        }
                        else
                        {

                            typo();
                        }
                        #endregion Alpha
                    }
                    else if (!((e.Key < Key.D0) || (e.Key > Key.D9)))
                    {
                        #region D keys

                        string currentKey = e.Key.ToString();
                        //value is between 1 and 9
                        if (!(Keyboard.Modifiers == ModifierKeys.Shift))
                        {
                            #region Number input
                            //user is trying to use first function of the d keys
                            if (currentKey == "D" + ((string)position8.Content).ToUpper())
                            {
                                Move();
                                //ClearErrors();
                            }
                            else
                            {
                                typo();
                            }
                            #endregion Number input
                        }
                        else
                        {
                            #region D key Symbol
                            //does the user have to type a symbol thats in one of the D keys
                            if (isSymbolExpected((string)position8.Content))
                            {
                                //does the d key pressed by the user match the symbol for that key
                                if (isKeyMatchingSymbol(currentKey, (string)position8.Content))
                                {
                                    Move();
                                    //ClearErrors();
                                }
                                else
                                {
                                    //wrong D key
                                    typo();
                                }
                            }
                            else
                            {
                                //wrong key
                                typo();
                            }
                            //shift was pressed with the number key
                            #endregion D key Symbol
                        }

                        #endregion D keys
                    }
                    else if (e.Key.ToString().Length >= 3 &&  e.Key.ToString().Substring(0, 3) == "Num")
                    {
                        // num keys
                        if (Nk.RightKeyPressed(e.Key.ToString(), (string)position8.Content))
                        {
                            Move();
                        }
                        else
                        {
                            typo();
                        }
                    }
                    else if (e.Key.ToString() == "Space")
                    {
                        #region Space

                        //check if the label contains a space
                        if ((string)position8.Content == " ")
                        {
                            Move();
                            //ClearErrors();
                        }
                        else
                        {
                            typo();
                        }

                        //to stop the event from being handled as a click
                        e.Handled = true;
                        #endregion Space
                    }
                    else if (e.Key.ToString() == "Enter" || e.Key.ToString() == "Return")
                    {
                        //start or stop the test
                        //pause resume
                        if (mystate.Paused)
                        {
                            resume();
                        }
                        else
                        {
                            pause();
                        }
                    }
                    else if (e.Key.ToString() == "Escape")
                    {
                        if (elapsedsec > 0)
                        {
                            manageTest.SessionInProgress = false;
                            stopMytimer();
                        }
                        else
                        {
                            //stop without giving results
                            quit();
                        }
                        //stop or maybe close window
                    }
                    else if (e.Key.ToString().Substring(0, 1) == "F")
                    {
                        if (e.Key == Key.F1)
                        {
                            GetHelp(sender, e);
                        }
                        else
                        {
                            //user why are you pressing the f keys?
                        }

                    }
                    else
                    {
                        //key input was a symbol key
                        handleSymbolInput(e.Key.ToString());
                    }
                }//Not paused
                else
                {
                    //paused
                    #region Paused
                    if (e.Key.ToString() == "Enter" || e.Key.ToString() == "Return")
                    {
                        isResuming = true;
                        resume();
                    }
                    else if (e.Key.ToString() == "Escape")
                    {
                        if (elapsedsec > 0)
                        {
                            manageTest.SessionInProgress = false;
                            stopMytimer();
                        }
                        else
                        {
                            //stop without giving results
                            quit();
                        }
                        //stop or maybe close window


                    }
                    #endregion
                }

                //simulateKeyPress(e.Key.ToString());
                #endregion Session In Progress
            }
            else
            {
                //no session in pregress
                if (e.Key.ToString() == "Space")
                {
                    #region Space
                    Restart();
                    //to stop the event from being handled as a click
                    e.Handled = true;
                    #endregion Space
                }
                else if (e.Key == Key.Escape)
                {
                    if (mystate.Paused)
                    {
                        quit();
                    }
                }
                else
                {
                    BrownButtons();
                }
            }


            #region Help
            //get help
            if (e.Key == Key.F1)
            {
                GetHelp(sender, e);
            }
            #endregion help

        }
        #endregion Window keydown handler

        #region Keyboard
        //hides the keyboard
        public void HideKeyboard()
        {
            gridKeyboard.Visibility = System.Windows.Visibility.Hidden;
            //manageTest.Keyboardshown = false;
            //btnInstructions.Visibility = Visibility.Hidden;

            gridNumPad.Visibility = System.Windows.Visibility.Hidden;
            lblWorning.Content = "";

            ////do this for the keybaord's wrapanel as well
            ////button1.Visibility = Visibility.Hidden;
            //foreach (UIElement child in cnTest.Children)
            //{
            //    Button btn = (Button)child;
            //    btn.Visibility = System.Windows.Visibility.Hidden;

            //}
        }
        //show the keyboard
        public void ShowKeyboard()
        {
            try
            {
                if (mystate.Showkeyboard)
                {



                    gridKeyboard.Visibility = System.Windows.Visibility.Visible;
                    cnTest.Visibility = System.Windows.Visibility.Visible;
                    gridhands.Visibility = System.Windows.Visibility.Visible;
                    //btnInstructions.Visibility = System.Windows.Visibility.Hidden;
                    gridNumPad.Visibility = System.Windows.Visibility.Hidden;
                    lblWorning.Content = " ";


                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            BrownButtons();
            
                                    
        }

        public void ErrorReadingPersonalSettings()
        {
            MessageBox.Show("An error occured while reading your settings",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowKeyboard2()
        {
            try
            {
                if (da.GetAnOption("Showkeyboard").MoValue == "true")
                {
                    //if (da.GetAnOption("DefaultKeyboardView").MoValue == "keys")
                    //{
                    //    //rbkeys.IsChecked = true;
                    //}
                    //else
                    //{
                    //    //rbhands.IsChecked = true;
                    //}

                    gridKeyboard.Visibility = System.Windows.Visibility.Visible;
                    //btnInstructions.Visibility = System.Windows.Visibility.Hidden;
                    gridNumPad.Visibility = System.Windows.Visibility.Hidden;
                    lblWorning.Content = " ";

                    #region Old
                    //manageTest.Keyboardshown = true;
                    //btnInstructions.Visibility = Visibility.Visible;
                    ////do this for the keyboard wrap panel as well
                    ////button1.Visibility = Visibility.Visible;

                    //foreach (UIElement child in cnTest.Children)
                    //{
                    //    Button btn = (Button)child;
                    //    btn.Visibility = System.Windows.Visibility.Visible;
                    //    btn.Background = Brushes.SaddleBrown;

                    //}
                    #endregion Old
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }

            BrownButtons();


        }
        
        public void simulateKeyPress(string e)
        {
            bool keyfound = false;

            if (manageTest.SessionInProgress)
            {
                foreach (UIElement child in cnTest.Children)
                {
                    Button btn = (Button)child;

                    if ((string)position8.Content.ToString().ToUpper() == (string)position8.Content.ToString())
                    {
                        //capital
                        if (e.ToLower() == btn.Content.ToString().ToLower() || e.ToLower() == btn.Name.ToString().ToLower())
                        {
                            //btn.Background = Brushes.Red;
                            //cimg.GetButtonsImage(btn, false);
                            cimg.colorMe(" ", btn, false);
                            keyfound = true;
                            //shift
                            if(shift.Leftshift((string)position8.Content.ToString().ToLower()))
                            {
                                //left shift
                                //shiftleft.Background = Brushes.Red;
                                //cimg.GetButtonsImage(shiftleft, false);
                                cimg.colorMe(" ", shiftleft, false);
                            }
                            else if (shift.Rightshift((string)position8.Content.ToString().ToLower()))
                            {
                                //right shift
                                //shiftright.Background = Brushes.Red;
                                //cimg.GetButtonsImage(shiftright, false);
                                cimg.colorMe(" ", shiftright, false);
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (e.ToLower() == btn.Content.ToString().ToLower() || e.ToLower() == btn.Name.ToString().ToLower())
                        {
                            //btn.Background = Brushes.Red;
                            //cimg.GetButtonsImage(btn, false);
                            cimg.colorMe(" ", btn, false);
                            keyfound = true;
                            break;
                        }
                    }
                    

                }
            }
            if (!(keyfound))
            {
                //handleSymbolsimulation(e);
                handleSymbolsimulaion2picture(e);
            }
            

        }


        public void simulateKeyPresspicture(string e)
        {
            bool keyfound = false;

            if (manageTest.SessionInProgress)
            {
                foreach (UIElement child in cnTest.Children)
                {
                    Button btn = (Button)child;

                    if ((string)position8.Content.ToString().ToUpper() == (string)position8.Content.ToString())
                    {
                        //capital
                        if (e.ToLower() == btn.Content.ToString().ToLower() || e.ToLower() == btn.Name.ToString().ToLower())
                        {
                            btn.Background = Brushes.Red;
                            keyfound = true;
                            //shift
                            if (shift.Leftshift((string)position8.Content.ToString().ToLower()))
                            {
                                //left shift
                                shiftleft.Background = Brushes.Red;
                            }
                            else if (shift.Rightshift((string)position8.Content.ToString().ToLower()))
                            {
                                //right shift
                                shiftright.Background = Brushes.Red;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (e.ToLower() == btn.Content.ToString().ToLower() || e.ToLower() == btn.Name.ToString().ToLower())
                        {
                            btn.Background = Brushes.Red;
                            keyfound = true;
                            break;
                        }
                    }


                }
            }
            if (!(keyfound))
            {
                //handleSymbolsimulation(e);
                handleSymbolsimulaion2(e);
            }


        }

        public void handleSymbolsimulaion2(string e)//if the key that needs to be pressed is a symbol
        {

            if (e == ";" || e == ":")
            {
                semicolon.Background = Brushes.Red;

                if (e == ":")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "/" || e == "?")
            {
                forwardslash.Background = Brushes.Red;
                if (e == "?")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "[" || e == "{")
            {
                OpenBraket.Background = Brushes.Red;
                if (e == "{")
                {
                    shiftleft.Background = Brushes.Red;
                }

            }
            else if (e == "]" || e == "}")
            {
                CloseBraket.Background = Brushes.Red;

                if (e == "}")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "\\" || e == "|")
            {
                backslash.Background = Brushes.Red;
                if (e == "|")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "'" || e == "\"")
            {
                singleQoute.Background = Brushes.Red;
                if (e == "\"")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "," || e == "<")
            {
                comma.Background = Brushes.Red;
                if (e == "<")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "." || e == ">")
            {
                period.Background = Brushes.Red;
                if (e == ">")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "-" || e == "_")
            {
                underscore.Background = Brushes.Red;
                if (e == "_")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "=" || e == "+")
            {
                equalto.Background = Brushes.Red;
                if (e == "+")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == " ")
            {
                //space
                space.Background = Brushes.Red;
            }
            else if (e == "(")
            {
                D9.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;

            }
            else if (e == ")")
            {
                D0.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }
            else if (e == "!")
            {
                D1.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "@")
            {
                D2.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "#")
            {
                D3.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "$")
            {
                D4.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;

            }
            else if (e == "%")
            {
                D5.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "^")
            {
                D6.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "&")
            {
                D7.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }
            else if (e == "*")
            {
                D8.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }


            


        }


        public void handleSymbolsimulaion2picture(string e)//if the key that needs to be pressed is a symbol
        {

            if (e == ";" || e == ":")
            {
                //semicolon.Background = Brushes.Red;
                cimg.colorMe("",semicolon, false);

                if (e == ":")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "/" || e == "?")
            {
                //forwardslash.Background = Brushes.Red;
                cimg.colorMe("", forwardslash, false);
                if (e == "?")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("",shiftleft, false);
                }
            }
            else if (e == "[" || e == "{")
            {
                //OpenBraket.Background = Brushes.Red;
                cimg.colorMe("", OpenBraket, false);
                if (e == "{")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("",shiftleft, false);
                }

            }
            else if (e == "]" || e == "}")
            {
                //CloseBraket.Background = Brushes.Red;
                cimg.colorMe("", CloseBraket, false);

                if (e == "}")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "\\" || e == "|")
            {
                //backslash.Background = Brushes.Red;
                cimg.colorMe("",backslash, false);
                if (e == "|")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "'" || e == "\"")
            {
                //singleQoute.Background = Brushes.Red;
                cimg.colorMe("", singleQoute, false);
                if (e == "\"")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "," || e == "<")
            {
                //comma.Background = Brushes.Red;
                cimg.colorMe("", comma, false);
                if (e == "<")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "." || e == ">")
            {
                //period.Background = Brushes.Red;
                cimg.colorMe("", period, false);
                if (e == ">")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "-" || e == "_")
            {
                //underscore.Background = Brushes.Red;
                cimg.colorMe("", underscore, false);
                if (e == "_")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "=" || e == "+")
            {
                //equalto.Background = Brushes.Red;
                cimg.colorMe("", equalto, false);
                if (e == "+")
                {
                    //shiftleft.Background = Brushes.Red;
                    cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == " ")
            {
                //space
                //space.Background = Brushes.Red;
                cimg.colorMe("", space, false);
            }
            else if (e == "(")
            {
                //D9.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D9, false);
                cimg.colorMe("", shiftleft, false);

            }
            else if (e == ")")
            {
                //D0.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D0, false);
                cimg.colorMe("", shiftleft, false);
            }
            else if (e == "!")
            {
                //D1.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D1, false);
                cimg.colorMe("", shiftright, false);
            }
            else if (e == "@")
            {
                //D2.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D2, false);
                cimg.colorMe("", shiftright, false);
            }
            else if (e == "#")
            {
                //D3.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D3, false);
                //cimg.GetButtonsImage(shiftright, false);
                cimg.colorMe("", shiftright, false);
            }
            else if (e == "$")
            {
                //D4.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D4, false);
                cimg.colorMe("", shiftright, false);
            }
            else if (e == "%")
            {
                //D5.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D5, false);
                cimg.colorMe("",shiftright, false);
            }
            else if (e == "^")
            {
                //D6.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D6, false);
                cimg.colorMe("", shiftright, false);
            }
            else if (e == "&")
            {
                //D7.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D7, false);
                cimg.colorMe("", shiftleft, false);
            }
            else if (e == "*")
            {
                //D8.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D8, false);
                cimg.colorMe("",shiftleft, false);
            }





        }

        public void handleSymbolsimulation(string key)
        {

            if (key == "Oem1" || key == "OemColon" || key == "OemSemicolon")
            {

                semicolon.Background = Brushes.Red;

            }
            else if (key == "Oem2" || key == "OemQuestion" || key == "OemForwardSlash")
            {
                forwardslash.Background = Brushes.Red;
            }
            else if (key == "Oem3" || key == "Oemtilde")
            {
                
            }
            else if (key == "Oem4" || key == "OemOpenBrackets")
            {
                OpenBraket.Background = Brushes.Red;
            }
            else if (key == "Oem5" || key == "OemBackslash")
            {
                CloseBraket.Background = Brushes.Red;
            }
            else if (key == "Oem6" || key == "OemCloseBrackets")
            {
               backslash.Background = Brushes.Red; 
            }
            else if (key == "Oem7" || key == "OemQuotes")
            {
                singleQoute.Background = Brushes.Red;
            }
            else if (key == "OemComma")
            {
                comma.Background = Brushes.Red;
            }
            else if (key == "OemPeriod")
            {
                period.Background = Brushes.Red;
            }
            else if (key == "OemMinus")
            {
                underscore.Background = Brushes.Red;
            }
            else if (key == "OemPlus")
            {
                equalto.Background = Brushes.Red;
            }
            


        }

        
        public void simulateNumHand(string e)
        {
            
            numIndex.Visibility = System.Windows.Visibility.Hidden;
            numMiddle.Visibility = System.Windows.Visibility.Hidden;
            numRing.Visibility = System.Windows.Visibility.Hidden;
            numPinkie.Visibility = System.Windows.Visibility.Hidden;
            numThumb.Visibility = System.Windows.Visibility.Hidden;


            if (e != "*" && e != "+" && e != "-" && e != "/")
            {

                string finger = Nk.GetFinger(e);

                if (finger.ToLower() == "index")
                {
                    numIndex.Visibility = System.Windows.Visibility.Visible;
                    
                }
                else if (finger.ToLower() == "middle")
                {
                    numMiddle.Visibility = System.Windows.Visibility.Visible;
                }
                else if (finger.ToLower() == "ring")
                {
                    numRing.Visibility = System.Windows.Visibility.Visible;
                }
                else if (finger.ToLower() == "pinkie")
                {
                    numPinkie.Visibility = System.Windows.Visibility.Visible;
                }
                else if (finger.ToLower() == "thumb")
                {
                    numThumb.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                if (e == "+")
                {
                    numPinkie.Visibility = System.Windows.Visibility.Visible;
                }
                if (e == "-")
                {
                    numPinkie.Visibility = System.Windows.Visibility.Visible;
                }

                if (e == "*")
                {
                    numRing.Visibility = System.Windows.Visibility.Visible;
                }

                if (e == "/")
                {
                    numMiddle.Visibility = System.Windows.Visibility.Visible;
                }
            }
                
            

        }

        public void simulateHandPress(string e)
        {
            bool found = false;

            hideDots();
            string tempname = qe.GetInstructions2(e);
            if (tempname == "space")
            {
                string spaceThumb = qe.thisSpacethumb((string)position7.Content);
                //which thumb to use
                if (spaceThumb.ToLower() == "left")
                {
                    leftThumb.Visibility = System.Windows.Visibility.Visible;
                }
                else if (spaceThumb.ToLower() == "right")
                {
                    rightThumb.Visibility = System.Windows.Visibility.Visible;
                }

                found = true;
            }
            else
            {

                foreach (Image img in gridhands.Children)
                {
                    if (img.Name.ToString().ToLower() == tempname.ToLower())
                    {
                        found = true;
                        img.Visibility = System.Windows.Visibility.Visible;

                        if (e == e.ToUpper())
                        {
                            //shift
                            if (shift.Leftshift(e))
                            {
                                //leftPinkie.Visibility = System.Windows.Visibility.Visible;
                                pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                            }
                            else if (shift.Rightshift(e))
                            {
                                //rightPinkie.Visibility = System.Windows.Visibility.Visible;
                                pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                            }
                            break;
                        }
                    }
                }

            }


            //if (!(found))
            //{
                //could be a symbol or a number
            
                simulatehandSymbol(e);
            
            //}
        }

        public void simulatehandSymbol(string e)
        {
            if (e == ";" || e == ":")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;

                if (e == ":")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "/" || e == "?")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "?")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "[" || e == "{")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "{")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else if (e == "]" || e == "}")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;

                if (e == "}")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "\\" || e == "|")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "|")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "'" || e == "\"")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "\"")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "," || e == "<")
            {
                rightMiddle.Visibility = System.Windows.Visibility.Visible;
                if (e == "<")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "." || e == ">")
            {
                rightRing.Visibility = System.Windows.Visibility.Visible;
                if (e == ">")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "-" || e == "_")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "_")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "=" || e == "+")
            {
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "+")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "(" || e == "9")
            {
                //rightMiddle.Visibility = System.Windows.Visibility.Visible;
                rightRing.Visibility = System.Windows.Visibility.Visible;
                if (e == "(")
                {
                pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == ")" || e == "0")
            {
                //rightMiddle.Visibility = System.Windows.Visibility.Visible;
                rightPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == ")")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else if (e == "!" || e == "1")
            {
                
                leftPinkie.Visibility = System.Windows.Visibility.Visible;
                if (e == "!")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "@" || e == "2")
            {
                //leftPinkie.Visibility = System.Windows.Visibility.Visible;
                leftRing.Visibility = System.Windows.Visibility.Visible;
                if (e == "@")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "#" || e == "3")
            {
                //leftRing.Visibility = System.Windows.Visibility.Visible;
                leftMiddle.Visibility = System.Windows.Visibility.Visible;
                if (e == "#")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "$" || e == "4")
            {
                //leftMiddle.Visibility = System.Windows.Visibility.Visible;
                leftIndex.Visibility = System.Windows.Visibility.Visible;

                if (e == "$")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else if (e == "%" || e == "5")
            {
                leftIndex.Visibility = System.Windows.Visibility.Visible;
                if (e == "%")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "^" || e == "6")
            {
                //leftIndex.Visibility = System.Windows.Visibility.Visible;
                rightIndex.Visibility = System.Windows.Visibility.Visible;

                if (e == "^")
                {
                    pinkierightShift.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (e == "&" || e == "7")
            {
                rightIndex.Visibility = System.Windows.Visibility.Visible;
                
                if (e == "&")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;  
                }
            }
            else if (e == "*" || e == "8")
            {
                //rightIndex.Visibility = System.Windows.Visibility.Visible;
                rightMiddle.Visibility = System.Windows.Visibility.Visible;
                
                if (e == "*")
                {
                    pinkieleftshift.Visibility = System.Windows.Visibility.Visible;
                    
                }
            }
        }

        public void BrownSymbols()
        {


            semicolon.Background = Brushes.SaddleBrown;
            forwardslash.Background = Brushes.SaddleBrown;
            OpenBraket.Background = Brushes.SaddleBrown;
            CloseBraket.Background = Brushes.SaddleBrown;
            backslash.Background = Brushes.SaddleBrown;
            singleQoute.Background = Brushes.SaddleBrown;
            comma.Background = Brushes.SaddleBrown;
            period.Background = Brushes.SaddleBrown;
            underscore.Background = Brushes.SaddleBrown;
            equalto.Background = Brushes.SaddleBrown;




        }

        List<Button> buttons = new List<Button>();

        //changes the background of the keyboard buttons to brown
        public void BrownButtons1()
        {
            #region try one
            //List<Button> mybuttons = new List<Button>();

            //this.Dispatcher.Invoke(new Action(() => mybuttons = buttons), 
            //            DispatcherPriority.Normal, null);

            ////foreach (UIElement child in cnTest.Children)
            ////{
            //for(int m = 0; m < mybuttons.Count; m ++)
            //{
            //    Button btn = (Button)mybuttons[m];
            //    //btn.Background = Brushes.SaddleBrown;

            //    //cimg.GetButtonsImage(btn, true);
            //    cimg.colorMe1(" ", btn, true);
            //    //btn.Foreground = Brushes.Red;
               
            //}
            //    //btn.IsEnabled = false;
            ////btn.Foreground = Brushes.Black;

            #endregion try one

            for (int m = 0; m < buttons.Count; m++)
            {
                //cimg.colorMe1("", buttons[m], true);

                this.Dispatcher.Invoke(new Action(() => buttons[m].Background =
                    cimg.colorMe1("", buttons[m], true)),
                      DispatcherPriority.Normal, null);
            }


            BrownPad1();
        }

        public void BrownButtons1a()
        {
            Thread brown1 = new Thread(brown);
            brown1.SetApartmentState(ApartmentState.STA);

            //threadpress1.SetApartmentState(ApartmentState.STA);

            //threadpress1.Start("a");
            brown1.Start();
        }

        public void BrownButtons()
        {
            for (int m = 0; m < cnTest.Children.Count; m++)
            {
                Button btn = (Button)cnTest.Children[m];
                //btn.IsEnabled = false;
                //btn.Background = Brushes.SaddleBrown;

                cimg.colorMe("", btn, true);
            }
            BrownPad();
        }
        public void brown(object data)
        {
            BrownButtons1();
        }
        public void BrownPad()
        {
            foreach(Button btn in Numpadkeys.Children)
            {
                btn.Background = Brushes.SaddleBrown;
                cimg.colorMe("", btn, true);
                //btn.IsEnabled = false;
                //btn.Foreground = Brushes.Black;
            }
        }
        List<Button> numbuttons = new List<Button>();
        public void BrownPad1()
        {
            //foreach (Button btn in Numpadkeys.Children)
            //{
            for (int m = 0; m < numbuttons.Count; m++)
            {

                //btn.Background = Brushes.SaddleBrown;
                //cimg.colorMe1("", numbuttons[m], true);

                numbuttons[m].Background =
                    cimg.colorMe1("", numbuttons[m], true);
                //btn.IsEnabled = false;
                //btn.Foreground = Brushes.Black;
            }
            //}
        }
        public void BrownPad1b()
        {
            //foreach (Button btn in Numpadkeys.Children)
            //{
            for (int m = 0; m < numbuttons.Count; m++)
            {

                //btn.Background = Brushes.SaddleBrown;
                //cimg.colorMe1("", numbuttons[m], true);

                this.Dispatcher.Invoke(new Action(() => numbuttons[m].Background =
                    cimg.colorMe1("", numbuttons[m], true)),
                      DispatcherPriority.Normal, null);
                //btn.IsEnabled = false;
                //btn.Foreground = Brushes.Black;
            }
            //}
        }
        //public void BrownButtons2()
        //{
        //    a.Background = Brushes.SaddleBrown;
        //    b.Background = Brushes.SaddleBrown;
        //    c.Background = Brushes.SaddleBrown;
        //    d.Background = Brushes.SaddleBrown;
        //    e.Background = Brushes.SaddleBrown;
        //    f.Background = Brushes.SaddleBrown;
        //    g.Background = Brushes.SaddleBrown;
        //    h.Background = Brushes.SaddleBrown;
        //    i.Background = Brushes.SaddleBrown;
        //    j.Background = Brushes.SaddleBrown;
        //    k.Background = Brushes.SaddleBrown;
        //    l.Background = Brushes.SaddleBrown;
        //    m.Background = Brushes.SaddleBrown;
        //    m.Background = Brushes.SaddleBrown;
        //    o.Background = Brushes.SaddleBrown;
        //    p.Background = Brushes.SaddleBrown;
        //    q.Background = Brushes.SaddleBrown;
        //    r.Background = Brushes.SaddleBrown;
        //    s.Background = Brushes.SaddleBrown;
        //    t.Background = Brushes.SaddleBrown;
        //    u.Background = Brushes.SaddleBrown;
        //    v.Background = Brushes.SaddleBrown;
        //    w.Background = Brushes.SaddleBrown;
        //    x.Background = Brushes.SaddleBrown;
        //    y.Background = Brushes.SaddleBrown;
        //    z.Background = Brushes.SaddleBrown;
        //    space.Background = Brushes.SaddleBrown;
        //    shiftleft.Background = Brushes.SaddleBrown;
        //    shiftright.Background = Brushes.SaddleBrown;


        //    BrownSymbols();

        //}

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //bool keyfound = false;
            //foreach (UIElement child in cnTest.Children)
            //{
            //    Button btn = (Button)child;


            //    if (e.Key.ToString().ToLower() == btn.Content.ToString().ToLower() ||
            //        (e.Key.ToString().ToLower()) == btn.Name.ToString().ToLower())
            //    {
            //        btn.Background = Brushes.SaddleBrown;
            //        keyfound = true;
            //    }

            //}

            //if (!(keyfound))
            //{
                
            //}
            //waste

            //BrownButtons();
            //BrownButtons2();
            
            
            
        }

        #endregion Keyboard


        #region Practice Specific skill
        private void PracticehomeRow(object sender, RoutedEventArgs e)
        {
            
            manageTest.Skill = "HR";
            StartPractice("HR", false);

        }
        private void PracticeSymbols(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "SYM";
            StartPractice("SYM", false);
        }

        private void PracticehomeRowAndThird(object sender, RoutedEventArgs e)
        {


            manageTest.Skill = "HRATR";
            StartPractice("HRATR", false);
        }

        private void PracticehomeRowAndFirst(object sender, RoutedEventArgs e)
        {

            manageTest.Skill = "HRAFR";
            StartPractice("HRAFR", false);
        }

        private void PracticeAllRowsOfLetters(object sender, RoutedEventArgs e)
        {


            manageTest.Skill = "AROL";
            StartPractice("AROL", false);
        }

        private void PracticeShifting(object sender, RoutedEventArgs e)
        {


            manageTest.Skill = "AROLS";
            StartPractice("AROLS", false);
        }

        private void PracticePanctuation(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "AROLP";
            StartPractice("AROLP", false);
            
        }

        private void PracticePhrases(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "PH";
            StartPractice("PH", false);
            
        }

        #endregion Practice specific skill

        #region Start Practice
        //gets files of the selected skill and starts the practice
        public void StartPractice(string skillID, bool skillsession)
        {

            if (skillID == "NUM")
            {
                StartNumTest("NUM", true);
            }
            else
            {
                try
                {
                    ShowKeyboard();

                    List<File> files = da.GetSkillFiles(skillID);
                    string name = RandomlyPickFile(files);
                    string filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
                    if (skillsession)
                    {

                        Start(filename, true);
                    }
                    else
                    {

                        Start(filename, false);
                    }
                }
                catch
                {
                    ErrorReadingPersonalSettings();
                }
            }
            //manageTest.PracticeSession = true;
        }
        #endregion Start Practice

        #region Start Test
        //Starts a test
        public void StartTest(string skillID)
        {
            HideKeyboard();
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;

            try
            {
                List<File> files = da.GetSkillFiles(skillID);
                string name = RandomlyPickFile(files);
                string filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);
                Start(filename);
            }
            catch
            {
                MessageBox.Show("Error Opening file", "No file found",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //public void StartNumTest(string skillID)
        //{
        //    try
        //    {
        //        gridKeyboard.Visibility = System.Windows.Visibility.Hidden;


        //        List<File> files = da.GetSkillFiles(skillID);
        //        string name = RandomlyPickFile(files);
        //        string filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);

        //        Start(filename);
        //    }
        //    catch
        //    {
        //        ErrorReadingPersonalSettings();
        //    }
        //}

        public void StartNumTest(string skillID, bool practice)
        {
            try
            {
                //gridKeyboard.Visibility = System.Windows.Visibility.Hidden;
                gridhands.Visibility = System.Windows.Visibility.Hidden;
                cnTest.Visibility = System.Windows.Visibility.Hidden;


                List<File> files = da.GetSkillFiles(skillID);
                string name = RandomlyPickFile(files);
                string filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name);

                if(!(practice))
                {
                Start(filename);
                }
                else
                {
                    Start(filename, false);
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }
        }
        #endregion Start Test

        #region Randomly Pick a file
        //returns a randomly picked file name of the skill files
        public string RandomlyPickFile(List<File> files)
        {
            int count = 0;
            string path;
            foreach (File file in files)
            {
                count++;
            }

            Random r = new Random();
            path = files[r.Next(0, count)].Location;

            return path;
        }

        #endregion Randomly pick a file

        #region Test Specific Skill

        private void TestSymbols(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "SYM";
            StartTest("SYM");
        }

        private void TesthomeRow(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "HR";
            StartTest("HR");
        }

        private void TesthomeRowAndThird(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "HRATR";
            StartTest("HRATR");
        }

        private void TesthomeRowAndFirst(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "HRAFR";
            StartTest("HRAFR");
        }

        private void TestAllRowsOfLetters(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "AROL";
            StartTest("AROL");
        }

        private void TestShifting(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "AROLS";
            StartTest("AROLS");
        }

        private void TestPanctuation(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "AROLP";
            StartTest("AROLP");
        }

        private void PracticeExternalFile(object sender, RoutedEventArgs e)
        {
            if (manageTest.SessionInProgress)
            {
                quit();
            }
            ShowKeyboard();

            try
            {
                manageTest.Skill = "PH";
                Start(GetFileName());
            }
            catch
            {
                MessageBox.Show("File not selected", "Select File", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void testPhrases(object sender, RoutedEventArgs e)
        {
            manageTest.Skill = "PH";
            StartTest("PH");

        }

        #endregion Test Specific skill

        private void shift_MouseEnter(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }
        private void StartTyping(object sender, RoutedEventArgs e)
        {
            //startmenuItem.Header = "Stop";
            //open text file

        }

        #region Help

        private void GetHelp(object sender, RoutedEventArgs e)
        {
            if (manageTest.RunningNow)
            {
                pause();
            }
            //var filename = "TypingTutorHelp.CHM"; //da.GetAControl("Help").ControlValue;
            try
            {
                var filename = da.GetAnOption("Help").MoValue;

                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                System.Diagnostics.Process.Start(filename);
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }
        }
        #endregion Help

        #region Learn

        private void GoToLearningPage()
        {
            #region Browser
            //try
            //{

            //    #region Browser
            //    //var filename = "TouchType.html"; //da.GetAControl("Learn").ControlValue;
            //    var filename = da.GetAnOption("Learn").MoValue;

            //    var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            //    System.Diagnostics.Process.Start(filename);
            //    #endregion Browser
            //}
            //catch
            //{
            //    ErrorReadingPersonalSettings();
            //}
            #endregion Browser

            #region Learning page

            Learn learner = new Learn();
            learner.ShowDialog();

            #endregion Learning page
        }

        #endregion Learn

        private void rbkeys_Checked(object sender, RoutedEventArgs e)
        {
            cnTest.Visibility = System.Windows.Visibility.Visible;
            gridhands.Visibility = System.Windows.Visibility.Hidden;
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;
        }

        private void rbhands_Checked(object sender, RoutedEventArgs e)
        {
            gridhands.Visibility = System.Windows.Visibility.Visible;
            cnTest.Visibility = System.Windows.Visibility.Hidden;
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;
            hideDots();

            if (manageTest.SessionInProgress && (!mystate.Paused))
            {
                simulateHandPress((string)position8.Content);
            }
        }

        #region NumPad
        public void hideDots()
        {
            leftPinkie.Visibility = System.Windows.Visibility.Hidden;
            leftRing.Visibility = System.Windows.Visibility.Hidden;
            leftMiddle.Visibility = System.Windows.Visibility.Hidden;
            leftIndex.Visibility = System.Windows.Visibility.Hidden;
            leftThumb.Visibility = System.Windows.Visibility.Hidden;

            rightPinkie.Visibility = System.Windows.Visibility.Hidden;
            rightRing.Visibility = System.Windows.Visibility.Hidden;
            rightMiddle.Visibility = System.Windows.Visibility.Hidden;
            rightIndex.Visibility = System.Windows.Visibility.Hidden;
            rightThumb.Visibility = System.Windows.Visibility.Hidden;

            pinkieleftshift.Visibility = System.Windows.Visibility.Hidden;
            pinkierightShift.Visibility = System.Windows.Visibility.Hidden;
            //imgHands.Visibility = System.Windows.Visibility.Visible;
        }


        public void hideNumHandImages()
        {
            numIndex.Visibility = System.Windows.Visibility.Hidden;
            numMiddle.Visibility = System.Windows.Visibility.Hidden;
            numRing.Visibility = System.Windows.Visibility.Hidden;
            numPinkie.Visibility = System.Windows.Visibility.Hidden;
            numThumb.Visibility = System.Windows.Visibility.Hidden;
        }
        private void PracticeNumPad(object sender, RoutedEventArgs e)
        {

            
            manageTest.PracticeSession = true;
            numLockWarning();
            hideNumHandImages();
            //launch a new num pad excercise
            try
            {
                if (mystate.Showkeyboard)
                {
                    gridNumPad.Visibility = System.Windows.Visibility.Visible;
                    BrownPad();
                }
            }
            catch
            {
                ErrorReadingPersonalSettings();
            }
            manageTest.Skill = "NUM";
            StartNumTest("NUM", true);
            //Start
        }

        public void numLockWarning()
        {
            bool yes = Console.NumberLock;

           
            if (!yes)
            {
                //numlock
                lblWorning.Content = "Warning: Num Lock is off, turn on Num Lock";
            }
            

        }
        public void simulateNumPress(string e)
        { 
            
            BrownPad();
            foreach (Button btn in Numpadkeys.Children)
            {
                if (e.ToLower() == (string)btn.Content)
                {
                    //btn.Background = Brushes.Red;
                    cimg.colorMe("", btn, false);
                }
            }
            simulateNumHand(e);
        }

        private void testNumPad(object sender, RoutedEventArgs e)
        {
            numLockWarning();
            gridNumPad.Visibility = System.Windows.Visibility.Hidden;

            manageTest.Skill = "Num";
            StartNumTest("NUM", false);
        }
        #endregion NumPad

        public int LastTestId()
        {
            List<Test> mytests = da.GetUserTests();

            List<int> mytestIds = new List<int>();

            foreach (Test test in mytests)
            {
                mytestIds.Add(int.Parse(test.TestID));
            }

            int a = 0;
            foreach (int myint in mytestIds)
            {
                if (a < myint)
                    a = myint;
            }

            return a;
        }

        private void playClouds(object sender, RoutedEventArgs e)
        {
            //if (manageTest.RunningNow)
            //{
            //    pause();
            //}

            //Clouds.CloudStarter mb = new Clouds.CloudStarter(mystate.Backgroundmusic);
            //mb.Closing3 += new EventHandler(cloudsClosing);
            //this.Hide();
            //mb.ShowDialog();


            ////GameOn.MainWindow mB = new GameOn.MainWindow();
            ////this.Hide();

            ////mB.Closing1 += new EventHandler(childClosing7);
            ////mB.ShowDialog();
        }
        public void cloudsClosing(object sender, EventArgs e)
        {
            this.ShowDialog();
        }


        #region Settings

        public void setDefaultSettings(string username)
        {
            DefaultSettings mydefaults = new DefaultSettings();

            foreach (UserSettings dd in mydefaults.Defaults)
            {
                UserSettings myset =new UserSettings(username, dd.MoName, dd.MoValue);
                da.InsertUserSettings(myset);
            }
            initaiteUserFreeText();
        }

        public void setMyBackground()
        {
            //string name = "";
            //if (mystate.Loggedin)
            //{
            //   name = da.GetChoice(mystate.CurrentUser, "Backgroundimage").MoValue;
            //}
            //else
            //{
            //    name = da.GetAnOption("Backgroundimage").MoValue;
            //}

            try
            {
                this.Background = mytheme.getMyBackground(mystate.Backgroundimage);
            }
            catch
            {

            }
            
        }
        theme mytheme = new theme();

        
        public void initaiteUserFreeText()
        {
            var filename = mystate.CurrentUser +"_free.txt";

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.IO.File.WriteAllText(path, "You have not set your own text");
        }

        #endregion Settings


        #region Image

        CharImage cimg = new CharImage();
        public void setImages()
        {
            cimg.MoveImages(position1, position2, position3, position4,
                position5, position6, position7, position8, position9,
                position10, position11, position12, position13,
                position14, position15);
        }
        #endregion Image

        private void ViewKeys(object sender, RoutedEventArgs e)
        {
            Brush mybrush = mytheme.getmyTextColor(mystate.Textcolor);
            ViewKeysForFinger vkf = new ViewKeysForFinger(mystate.Backgroundimage,mybrush);

            vkf.ShowDialog();
        }

        public void setMyMainBackColor()
        {
            foreach (Label lbl in TypingRow.Children)
            {
                if (lbl.Name.ToString().ToLower() != "position8")
                {
                    lbl.Foreground = mytheme.getmyTextColor(mystate.Textcolor);
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }   
}

//public void SetMyOptions()
//{
//    try
//    {
//        #region Keyboard
//        if (da.GetAnOption("Showkeyboard").MoValue == "true")
//        {
//            //showkeyboard
//            if (manageTest.SessionInProgress && manageTest.PracticeSession)
//            {
//                #region if Content
//                ShowKeyboard2();

//                simulateKeyPress(((string)position8.Content).ToLower());

//                if (gridhands.Visibility == System.Windows.Visibility.Visible)
//                {
//                    simulateHandPress(((string)position8.Content));
//                }
//                //btnInstructions.Content = (qe.GetInstructions((string)position8.Content));

//                if (Numpadkeys.Visibility == System.Windows.Visibility.Visible)
//                {
//                    simulateNumPress((string)position8.Content);
//                }

//                initaiteTimer();
//                //_time = setTime();
//                manageTest.Time = setTime();
//                showTime(manageTest.Counter);
//                //showTime(minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue)));

//                #endregion if Content
//            }

//            if (!manageTest.SessionInProgress)
//            {
//                ShowKeyboard2();

//            }
//            else
//            {
//                initaiteTimer();
//                //_time = setTime();
//                manageTest.Time = setTime();
//                showTime(manageTest.Counter);

//                //_time = minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue));
//                //showTime(minutesintseconds(int.Parse(da.GetAnOption("Testduration").MoValue)));
//            }
//        }
//        else
//        {
//            HideKeyboard();
//        }
//        #endregion Keyboard
//    }
//    catch
//    {
//        ErrorReadingPersonalSettings();
//    }

//    //rbkeys.IsChecked = true;
//    btnInstructions.Visibility = System.Windows.Visibility.Hidden;

//    initaiteTimer();

//    //showTime(manageTest.Counter);

//    try
//    {
//        if (da.GetAnOption("Errorsound").MoValue == "true")
//        {
//            manageTest.ErrorSound = true;
//        }
//        else
//        {
//            manageTest.ErrorSound = false;
//        }

//        manageTest.ErrorSoundFile = da.GetAnOption("Errorsoundfile").MoValue;

//        if (da.GetAnOption("Vocalinstructions").MoValue == "true")
//        {
//            manageTest.VocalInstructionsOn = true;
//        }
//        else
//        {
//            manageTest.VocalInstructionsOn = false;
//        }
//    }
//    catch
//    {
//        ErrorReadingPersonalSettings();
//    }

//    if (!manageTest.SessionInProgress)
//    {
//        displayRecord();
//    }

//    //gridWait.Visibility = System.Windows.Visibility.Hidden;


//}