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

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        public Progress()
        {
            InitializeComponent();
        }
        string background = "";
        myState results;

        public Progress(myState results)
        {
            InitializeComponent();
            currentUser = results.CurrentUser;
            this.results = results;

            InitaileAssist();
            StartAssist();

            //skills = da.GetAllSkills();//parttwo
            //myskills = da.GetUserSkills(currentUser);//parttree
            //GetMyTestInformation();
            //DisplaySkills();
            //ShowSkillsCompletion();
        }

        public Progress(myState results, string background)
        {
            InitializeComponent();
            currentUser = results.CurrentUser;
            this.results = results;

            InitaileAssist();
            StartAssist();

            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }

            //skills = da.GetAllSkills();//parttwo
            //myskills = da.GetUserSkills(currentUser);//parttree
            //GetMyTestInformation();
            //DisplaySkills();
            //ShowSkillsCompletion();
        }
        theme mytheme = new theme();

        BussinessLayer.DataAccess da = new DataAccess();
        List<Test> myTests;

        public void GetMyTestInformation()
        {
            //myTests = da.GetUserTests(currentUser);//partone
            DisplayBestTest(myTests);
            DisplayTopSpeed(myTests);
            DisplayWeakKeys(myTests);

            DisplayPracticeWeakKeys(da.GetPracticeDifficultKeys());
            DisplayPracticeAveAccuracy(myskills);
            DisplayPracticeAverageSpeed();


        }

        public void InitaileAssist()
        {
            ld.Partone = new System.Windows.Threading.DispatcherTimer();
            ld.Partone.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ld.Partone.Tick += new EventHandler(PartOneWork);

            ld.Parttwo = new System.Windows.Threading.DispatcherTimer();
            ld.Parttwo.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ld.Parttwo.Tick += new EventHandler(PartTwoWork);

            ld.Partthree = new System.Windows.Threading.DispatcherTimer();
            ld.Partthree.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ld.Partthree.Tick += new EventHandler(PartThreeWork);

            ld.PartFour = new System.Windows.Threading.DispatcherTimer();
            ld.PartFour.Interval = new TimeSpan(0, 0, 0, 0, 2);
            ld.PartFour.Tick += new EventHandler(PartFourWork);


        }

        public void StartAssist()
        {
            ld.Partone.Start();
            ld.Parttwo.Start();
            ld.Partthree.Start();
            ld.PartFour.Start();
        }
        public void StopAssist()
        {
            ld.Partone.Stop();
            ld.Parttwo.Stop();
            ld.Partthree.Stop();
            ld.PartFour.Stop();
        }
        public void PartOneWork(object sender, EventArgs e)
        {
            gridWait.Visibility = System.Windows.Visibility.Visible;
            if (ld.Done[0] == false)
            {
                //dowork
                myTests = da.GetUserTests(currentUser);
                ld.Done[0] = true;
            }
        }
        public void PartTwoWork(object sender, EventArgs e)
        {
            if (ld.Done[1] == false)
            {
                //dowork
                skills = da.GetAllSkills();
                ld.Done[1] = true;
            }
        }
        public void PartThreeWork(object send, EventArgs e)
        {
            if (ld.Done[2] == false  /*&& ld.Done[1] == true &&ld.Done[0] == true*/)
            {
                //dowork
                myskills = da.GetUserSkills(currentUser);
                ld.Done[2] = true;
            }
        }
        public void PartFourWork(object send, EventArgs e)
        {
            if (ld.Done[3] == false && ld.Done[1] && ld.Done[0] == true && ld.Done[2] == true)
            {
                //dowork
                GetMyTestInformation();
                DisplaySkills();
                ShowSkillsCompletion();
                StrongRows();
                TestStrongRows();
                testAccuracy();
                ld.Done[3] = true;
                gridWait.Visibility = System.Windows.Visibility.Hidden;
                StopAssist();
            }
        }


        LoadAssist ld = new LoadAssist();

        public void DisplayWeakKeys(List<Test> tests)
        {
            List<string> tempWeak = new List<string>();
            //List<DifficultKeys> difkeys = new List<DifficultKeys>();

            foreach (Test mytest in tests)
            {
                List<TestDifficultKeys> dk = da.GetAllDiffucultkeys(); //= da.GetTestsDiffucultkeys(mytest.TestID);

                foreach (TestDifficultKeys mykey in dk)
                {
                    if (IsInTest(mytest, mykey))
                    {
                        tempWeak.Add(mykey.Keyname);
                        //lstWeekkeys.Items.Add(mykey.Keyname);
                    }
                }
            }

            string mykeys = distinct(tempWeak);

            foreach (char mychar in mykeys)
            {
                lstWeekkeys.Items.Add(mychar);
            }
            if (lstWeekkeys.Items.Count <= 0)
            {
                lstWeekkeys.Items.Add("None");
            }

            //List<string> a = tempWeak.Distinct<string>();

        }
        public string distinct(List<string> a)
        {
            string mystring = "";

            foreach (string mychar in a)
            {
                if (!IsInString(mychar, mystring))
                {
                    mystring += mychar;
                }
            }

            return mystring;
        }
        public bool IsInString(string a, string longstring)
        {
            bool yes = false;

            foreach (char mychar in longstring)
            {
                if (mychar.ToString() == a)
                {
                    yes = true;
                }
            }
            return yes;

        }

        public void DisplayPracticeWeakKeys(List<PracticeDifficultKeys> a)
        {
            List<string> tempweak = new List<string>();

            foreach (PracticeDifficultKeys mykey in a)
            {
                if (mykey.Username.ToLower() == currentUser.ToLower())
                {
                    if (mykey.Keyname == " ")
                    {
                        //tempweak.Add("Space"); how am i going to add?
                    }
                    else
                    {
                        tempweak.Add(mykey.Keyname);
                    }
                }
            }

            string tempkeys = distinct(tempweak);

            foreach (char mychar in tempkeys)
            {
                lstPracticeWeak.Items.Add(mychar.ToString());
            }
            if (lstPracticeWeak.Items.Count <= 0)
            {
                lstPracticeWeak.Items.Add("None");
            }
        }

        public void DisplayPracticeAverageSpeed()
        {
            int totalspeed = 0;
            int temp = 0;

            foreach (UserSkill myskill in myskills)
            {
                totalspeed += int.Parse(myskill.Speed);
            }
            try
            {
                temp = totalspeed / myskills.Count;  //myskills.Count) / 100;
            }
            catch
            {
                temp = 0;
            }

            if (wpm())
            {
                txtAveSpeed.Text = temp.ToString();
                lblAveSpeedUnit.Content = "wpm";
            }
            else
            {
                txtAveSpeed.Text = (temp * 5).ToString();
                lblAveSpeedUnit.Content = "cpm";
            }
            //if (wpm())
            //{
            //    txtAveSpeed.Text = ave.ToString();
            //    
            //}
            //else
            //{
            //    txtAveSpeed.Text = (ave * 5).ToString();
            //    
            //}

        }


        //if (dk.Count >= 1)
        //{
        //    //lstWeekkeys.Items.Add
        //    //add test difficult keys to difficult keys
        //    //AddkeysToDifficultKeys(difkeys, dk);
        //}


        public bool IsInTest(Test a, TestDifficultKeys b)
        {
            bool yes = false;

            if (a.TestID == b.TestID)
            {
                yes = true;
            }
            return yes;
        }

        public void AddkeysToDifficultKeys(List<DifficultKeys> a, List<TestDifficultKeys> b)
        {
            foreach (TestDifficultKeys key in b)
            {



            }
        }

        public Test GetBestTest(List<Test> a)
        {
            Test bestTest = new Test();
            int lastspeed = 0;
            int lastErrorRate = 100;

            foreach (Test mytest in a)
            {
                int errors = int.Parse(mytest.NumberOfinccorrectKeyStrokes);
                TypingSpeed tp = new TypingSpeed(int.Parse(mytest.TotalNumberOfKeyStrokes),
                    int.Parse(mytest.Duration), int.Parse(mytest.NumberOfinccorrectKeyStrokes), wpm());

                if (tp.GetTypingSpeed() >= lastspeed && errors <= lastErrorRate)
                {
                    lastspeed = tp.GetTypingSpeed();
                    lastErrorRate = errors;
                    bestTest = mytest;
                }
            }
            return bestTest;

        }

        public void DisplayBestTest(List<Test> a)
        {
            Test Best = GetBestTest(a);
            if (a.Count > 0)
            {

                TypingSpeed tp = new TypingSpeed(int.Parse(Best.TotalNumberOfKeyStrokes),
                    int.Parse(Best.Duration), int.Parse(Best.NumberOfinccorrectKeyStrokes), wpm());

                txtSpeedBestTest.Text = tp.GetTypingSpeed().ToString();

                txtErrorsBestTest.Text = Best.NumberOfinccorrectKeyStrokes;

            }

        }
        public bool wpm()
        {
            #region Old
            //if (da.GetChoice(currentUser, "Speed").MoValue == "wpm")
            //{
            //    lblSpeedUnits.Content = "wpm";
            //    lblSpeedUnits2.Content = "wpm";
            //    lblSpeed3.Content = "wpm";
            //    return true;

            //}
            //else
            //{
            //    lblSpeedUnits.Content = "cpm";
            //    lblSpeedUnits2.Content = "cpm";
            //    lblSpeed3.Content = "cpm";
            //    return false;

            //}
            #endregion Old

            if (results.Speed.ToLower() == "wpm")
            {
                if (firsttime)
                {
                    setter("wpm");
                }
                return true;
                

            }
            else
            {
                if (firsttime)
                {
                    setter("cpm");
                }
                return false;
            }
        }
        bool firsttime = true;

        public void setter(string unit)
        {
            if (unit.ToLower() == "wpm")
            {
                lblSpeedUnits2.Content = "wpm";
                lblSpeedUnits.Content = "wpm";
                lblSpeed3.Content = "wpm";
            }
            else
            {
                lblSpeedUnits2.Content = "cpm";
                lblSpeedUnits.Content = "cpm";
                lblSpeed3.Content = "cpm";
            }
            firsttime = false;
        }

        public void DisplayTopSpeed(List<Test> a)
        {
            int topSpeed = GetTopSpeed(a);

            txtTopSpeed.Text = topSpeed.ToString();



        }


        #region Practice
        List<UserSkill> myskills;// = da.GetUserSkills(currentUser);
        public void DisplaySkills()
        {
            List<string> tempSkills = new List<string>();


            foreach (UserSkill myskill in myskills)
            {
                tempSkills.Add(GetSkillName(myskill.SkillID));
            }

            foreach (string mystring in tempSkills)
            {
                if (mystring != "" && mystring != " ")
                {
                    LstUserSkills.Items.Add(mystring);
                }
            }

        }
        List<Skill> skills; // = da.GetAllSkills();
        public string GetSkillName(string skillID)
        {

            string a = "";

            foreach (Skill myskill in skills)
            {
                if (myskill.SkillID == skillID)
                {
                    a = myskill.SkillName;
                }
            }
            return a;
        }

        public void ShowSkillsCompletion()
        {

            List<UserSkill> sk = new List<UserSkill>();

            foreach (UserSkill myskill in myskills)
            {
                if (IsNotIn(sk, myskill.SkillID))
                {
                    sk.Add(myskill);
                }
            }

            txtSkillsCompetion.Text = sk.Count + "/" + skills.Count;
        }
        public bool IsNotIn(List<UserSkill> a, string skillid)
        {
            bool yes = true;
            foreach (UserSkill myskill in a)
            {
                if (myskill.SkillID == skillid)
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }

        #endregion Practice
        int speedTotal = 0;

        public int GetTopSpeed(List<Test> a)
        {
            int top = 0;

            foreach (Test mytest in a)
            {
                TypingSpeed tp = new TypingSpeed(int.Parse(mytest.TotalNumberOfKeyStrokes),
                    int.Parse(mytest.Duration), int.Parse(mytest.NumberOfinccorrectKeyStrokes), wpm());
                int speed = tp.GetTypingSpeed();
                speedTotal += speed;
                if (speed >= top)
                {
                    top = speed;
                }
            }

            showTestAveSpeed();

            return top;
        }

        string currentUser;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridWait.Visibility = System.Windows.Visibility.Hidden;
            //GetMyTestInformation();


        }
        public void showTestAveSpeed()
        {
            int ave; // = speedTotal / myTests.Count;
            try
            {
                ave = speedTotal / myTests.Count;
            }
            catch
            {
                ave = 0;
            }

            txtTestAveSpeed.Text = ave.ToString();
            //MessageBox.Show(ave.ToString());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //if (!(loggedin))
            //{
            //    TouchType tt = new TouchType();
            //    this.Close();
            //    tt.ShowDialog();
            //}
            //else
            //{
            //    TouchType tt = new TouchType(currentUser);
            //    this.Close();
            //    tt.ShowDialog();
            //}
        }

        public void DisplayAveTypingSpeed(List<Test> mytests)
        {
            int temptotal = 0;
            int tempAve = 0;
            List<TypingSpeed> a = new List<TypingSpeed>();

            foreach (Test mytest in mytests)
            {
                a.Add(new TypingSpeed(int.Parse(mytest.TotalNumberOfKeyStrokes), int.Parse(mytest.Duration),
                    int.Parse(mytest.NumberOfinccorrectKeyStrokes), wpm()));
            }

            if (a.Count > 0)
            {
                foreach (TypingSpeed speed in a)
                {
                    temptotal += speed.GetTypingSpeed();
                }

                tempAve = (temptotal * a.Count) / 100;

            }


        }

        public void DisplayPracticeAveAccuracy(List<UserSkill> myskills)
        {
            int number = myskills.Count;
            int ave = 0;
            int totoal = 0;

            foreach (UserSkill myskill in myskills)
            {
                totoal += int.Parse(myskill.Accuracy);
            }
            try
            {
                ave = totoal / number;// / 100
            }
            catch
            {
                ave = 0;
            }
            txtAveAccuracy.Text = ave.ToString();


        }

        public void StrongRows()
        {
            //List<string> skillname = new List<string>();
            List<string> diffkeys = new List<string>();

            if (int.Parse(txtSkillsCompetion.Text.Substring(0, 1)) <= 0)
            {
                lststrongrowsPractice.Items.Add("None");
            }
            else
            {

                for (int m = 0; m < lstPracticeWeak.Items.Count; m++)
                {
                    diffkeys.Add(lstPracticeWeak.Items[m].ToString());
                }

                List<string> strongRows = mykeboard.getStrongRows(diffkeys);

                foreach (string mystring in strongRows)
                {
                    lststrongrowsPractice.Items.Add(mystring);
                }

                if (strongRows.Count < 1)
                {
                    lststrongrowsPractice.Items.Add("None");
                }
            }


        }

        public void TestStrongRows()
        {
            //List<string> skillname = new List<string>();
            List<string> diffkeys = new List<string>();


            if (myTests.Count <= 0)
            {
                lstStrongRow.Items.Add("None");
            }
            else
            {

                for (int m = 0; m < lstWeekkeys.Items.Count; m++)
                {
                    diffkeys.Add(lstWeekkeys.Items[m].ToString());
                }

                List<string> strongRows = mykeboard.getStrongRows(diffkeys);

                foreach (string mystring in strongRows)
                {
                    lstStrongRow.Items.Add(mystring);
                }

                if (strongRows.Count < 1)
                {
                    lstStrongRow.Items.Add("None");
                }
            }


        }

        MyKeybaord mykeboard = new MyKeybaord();

        public void testAccuracy()
        {
            int tempacc = 0;

            int strokes = totalStrokes(myTests);

            int errors = totalNumberofincorrectStrokes(myTests);


            TypingSpeed tt = new TypingSpeed();

            tempacc = tt.CalculateAccuracy(strokes, errors);


            txtTestAveAcc.Text = tempacc.ToString() + " %";
        }
        public int totalStrokes(List<Test> a)
        {
            int temptotal = 0;

            foreach (Test mytest in a)
            {
                temptotal += int.Parse(mytest.TotalNumberOfKeyStrokes);
            }
            return temptotal;
        }
        public int totalNumberofincorrectStrokes(List<Test> a)
        {
            int temptotal = 0;

            foreach (Test mytest in a)
            {
                temptotal += int.Parse(mytest.NumberOfinccorrectKeyStrokes);
            }
            return temptotal;
        }

        private void GetHelp()
        {

            //var filename = "TypingTutorHelp.CHM"; //da.GetAControl("Help").ControlValue;
            try
            {
                var filename = da.GetAnOption("Help").MoValue;

                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                System.Diagnostics.Process.Start(filename);
            }
            catch
            {
                //ErrorReadingPersonalSettings();
            }
        }

         private void Window_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.Key == Key.F1)
             {
                 GetHelp();
             }
         }

         private void btnHelp_Click(object sender, RoutedEventArgs e)
         {
             GetHelp();
         }
        //#endregion Help

    }
}
