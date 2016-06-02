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
using System.Windows.Threading;
using BussinessLayer;

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for WordTris.xaml
    /// </summary>
    public partial class WordTris : Window
    {
        //private int timeBeforeSpeedIncrease = 0;
        //private DispatcherTimer countdonwTimer;
        //private int dispatcherspeed = 1000;

        public WordTris()
        {
            InitializeComponent();
            //countdonwTimer = new DispatcherTimer();
            //countdonwTimer.Interval = new TimeSpan(0, 0, 0, 0, dispatcherspeed);
            //countdonwTimer.Tick += new EventHandler(CountdownTimerStep);


            manageMe.Countdown = new DispatcherTimer();
            manageMe.Countdown.Interval = new TimeSpan(0, 0, 0, 0, manageMe.Speed);
            manageMe.Countdown.Tick += new EventHandler(CountdownTimerStep);


            manageMe.Mywatch = new DispatcherTimer();
            manageMe.Mywatch.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            manageMe.Mywatch.Tick += new EventHandler(WatchMyLevels);
        }

        bool soundOn = false;
        theme mythem = new theme();

        string backgroundColor;
        string textcolor;
        public WordTris(bool sound, string name, string textco)
        {
            InitializeComponent();


            image1.Source = mythem.wordtrisBackground(name);
            bgbackground.Background = mythem.getMyBackground(name);
            MenuBackground.Source = mythem.getMyBackground(name, 1);
            gridScoreBoard.Background = mythem.getMyBackground(name);

            backgroundColor = name;
            textcolor = textco;


            
            //countdonwTimer = new DispatcherTimer();
            //countdonwTimer.Interval = new TimeSpan(0, 0, 0, 0, dispatcherspeed);
            //countdonwTimer.Tick += new EventHandler(CountdownTimerStep);


            manageMe.Countdown = new DispatcherTimer();
            manageMe.Countdown.Interval = new TimeSpan(0, 0, 0, 0, manageMe.Speed);
            manageMe.Countdown.Tick += new EventHandler(CountdownTimerStep);


            manageMe.Mywatch = new DispatcherTimer();
            manageMe.Mywatch.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            manageMe.Mywatch.Tick += new EventHandler(WatchMyLevels);

            this.soundOn = sound;
        }

        public void quit()
        {
            manageMe.Countdown.Stop();
            manageMe.Mywatch.Stop();
            clearAllRows();

            PauseGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        //check when its time to increase the level
        public void WatchMyLevels(object sender, EventArgs e)
        {
            manageMe.MyCounter++;
            manageMe.Seconds++;
            int decreamentMe = manageMe.DecreaseSpeed();

            if (manageMe.MyCounter >= manageMe.TimeBeforeSpeedIncrease && decreamentMe >=0)
            {
                manageMe.MyCounter = 0;
                manageMe.Countdown.Interval = new TimeSpan(0, 0, 0, 0, decreamentMe);
            }

            //show time
            showTime(manageMe.Seconds);
        }
        public void showTime(int seconds)
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
        }

        public void showTime1(int seconds)
        {
            int myseconds = seconds;
            int myminutes = 0;
            int myhours = 0;
            string temptime = "";

            do
            {
                if (myseconds > 60)
                {
                    myminutes += 1;
                    myseconds -= 60;
                }

            }
            while (myseconds >= 60);


            do
            {
                if (myminutes > 60)
                {
                    myhours += 1;
                    myminutes -= 60;
                }
            }
            while (myminutes >= 60);

            

            if (myhours > 0)
            {
                temptime = prepare(myhours.ToString()).ToString() + ":" + prepare(myminutes.ToString()).ToString() +
                    ":" + prepare( myseconds.ToString()).ToString();
            }
            else
            {
                temptime = prepare(myminutes.ToString()).ToString() +
                    ":" + prepare(myseconds.ToString()).ToString();
            }

            lblTimer.Content = temptime;


            
        }
        public int prepare(string tempvalue)
        {
            string thisvalue = "";
            if (tempvalue.Length  < 2)
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

            return int.Parse(thisvalue);
        }


        private void CountdownTimerStep(object sender, EventArgs e)
        {
            //if (timeBeforeSpeedIncrease >= 1)
            //{

            //    timeBeforeSpeedIncrease = 0;

            //    //clearAllRows();
            if (manageMe.GameStarted)
            {
                moveDown2();
            }

            //}

            //timeBeforeSpeedIncrease++;


        }

        public void startMyTimer()
        {
            rows.Visibility = System.Windows.Visibility.Visible;
            myMenuGrid.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreBoard.Visibility = System.Windows.Visibility.Visible;
            gridScoreBoard.Visibility = System.Windows.Visibility.Visible;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Visible;
            image1.Visibility = System.Windows.Visibility.Visible;
            //countdonwTimer.Start();
            ClearScoreBoard();
            if (soundOn)
            {
                sound.playIntro();
            }
            manageMe.Countdown.Start();
            manageMe.Mywatch.Start();

            manageMe.GameStarted = true;
            //timeBeforeSpeedIncrease = 0;
            LaunchNewWord();


            manageMe.Seconds = 0;

        }
        public void stopMytimer()
        {
            nowPlaying = false;
           manageMe.GameStarted = false;
            //countdonwTimer.Stop();
            manageMe.Countdown.Stop();
            manageMe.Mywatch.Stop(); 
            
            rows.Visibility = System.Windows.Visibility.Hidden;
            myMenuGrid.Visibility = System.Windows.Visibility.Visible;
            PauseGrid.Visibility = System.Windows.Visibility.Hidden;
            clearAllRows();

            rows.Visibility = System.Windows.Visibility.Hidden;
            myMenuGrid.Visibility = System.Windows.Visibility.Visible;
            gridScoreBoard.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Hidden;
            image1.Visibility = System.Windows.Visibility.Hidden;

            


        }

        bool nowPlaying = false;
        public void pause()
        {
            if (nowPlaying)
            {
                if (manageMe.GameStarted)
                {
                    manageMe.GameStarted = false;
                    //countdonwTimer.Stop();
                    manageMe.Countdown.Stop();
                    manageMe.Mywatch.Stop();

                    PauseGrid.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    manageMe.GameStarted = true;
                    //countdonwTimer.Stop();
                    manageMe.Countdown.Start();
                    manageMe.Mywatch.Start();

                    PauseGrid.Visibility = System.Windows.Visibility.Hidden;
                }
            }

            //rows.Visibility = System.Windows.Visibility.Hidden;
            //myMenuGrid.Visibility = System.Windows.Visibility.Visible;
            //clearAllRows();

            //rows.Visibility = System.Windows.Visibility.Hidden;
            //myMenuGrid.Visibility = System.Windows.Visibility.Visible;
            //gridScoreBoard.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Hidden;
            //image1.Visibility = System.Windows.Visibility.Hidden;
        }

        public void ClearScoreBoard()
        {
            lblCompleted.Content = "0 Words";
            lblErrors.Content = "0 Mistake(s)";
            lblPoints.Content = "0 Points";
            lblTimer.Content = "00:00";
        }
        helpmetest hp = new helpmetest();
        GameSounds sound = new GameSounds();


        //checks if the passed letter's index is between zero and six
        public bool isInRange(string a)
        {
            int index = hp.getMyIndex(a);

            if (index >= 0 && index <= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //checks if the block is the last one( last of the pilling blocks)
        public bool thereIsANextRow(string row)
        {
            if (row.Substring(3, 1).ToLower() == "l")
            {
                return false;
            }
            return true;
        }


        //checks if the block passed is the last block(the first of the pilling blocks)
        public bool isLastBlock(string row)
        {
            if (row.Substring(3, 1).ToLower() == "g")
            {
                return true;
            }
            return false;
        }
        public bool rowIsEmptyb(Label[] a)
        {
            bool yes = true;
            foreach (Label lbl in a)
            {
                //yes = true;
                try
                {
                    if (/*(string)lbl.Content != " " && (string)lbl.Content != ""
                    &&*/ lbl.Content.ToString().ToLower() != "" &&
                        lbl.Content.ToString().ToLower() != " ")
                    {
                        yes = false;
                        break;
                    }
                }
                catch
                {
                    return true;
                }
                
            }



            return yes;
        }

        public void myWordtrisResults()
        {
            int errors = myScores.Errors;
            int strokes = myScores.Strokes + errors;
            int duration = manageMe.Seconds;
            manageMe.Mywatch.Stop();

            //MessageBox.Show("still working on your score..lol",
            //    "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);

            wordtrisResults rs = new wordtrisResults(myScores.Points, myScores.CompletedWords,
                myScores.Missedwords, errors, lblTimer.Content.ToString(), backgroundColor, textcolor);

            rs.ShowDialog();



            //TypingSpeed tt = new TypingSpeed(strokes + errors, duration, errors, wpm());

            //myScores.Speed = tt.GetTypingSpeed();

            //UserResults rts = new UserResults(myScores.Speed, duration, strokes, errors, 0);

            //Results results = new Results(rts);

            //results.ShowDialog();
        }
        BussinessLayer.DataAccess da = new DataAccess();
        public bool wpm()
        {
            if (da.GetAnOption("Speed").MoValue == "wpm")
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        Grid currentgrid;

        //move the word displayed a block down
        public void moveDown2()
        {


            if (thereIsANextRow(mystatetris.CurrentRow))
            {
                Label[] a = getgrid(mystatetris.getCurrentRow());

                if (rowIsEmptyb(a))
                {
                    LaunchNewWord();
                }

                Label[] b = getgrid(mystatetris.RowToMoveTo());

                //what if the row a is blank

                wordWatcher.CurrentRow = mystatetris.getCurrentRow();//testing


                if (manageMe.MoveToNextRow(a, b))
                {
                    currentgrid = getgrid1(mystatetris.getCurrentRow());
                    //move successful
                }
                else//row is not empty, or current row is empty
                {

                    if (isLastBlock(mystatetris.getCurrentRow()))
                    {
                        //game over'
                        if (soundOn)
                        {
                            sound.playbomb();
                        }

                        if (manageMe.GameStarted)
                        {
                            //MessageBox.Show("game over");
                            myWordtrisResults();
                        }
                        
                        
                        stopMytimer();
                    }
                    else
                    {
                        manageMe.Speed = manageMe.Normalspeed;//reset speed after a word 
                        //has been missed

                        //launch new
                        myScores.Missedwords++;
                        //sound.playError();
                        LaunchNewWord();
                        //playdrop
                        if (soundOn)
                        {
                            sound.playDrop();
                        }
                    }
                }
            }
            else
            {
                //lastrow
                //check if its the last block
                //if its not the last block then launch another word
                if (isLastBlock(mystatetris.getCurrentRow()))
                {
                    if (manageMe.GameStarted)
                    {
                        //MessageBox.Show("game over");
                        myWordtrisResults();
                    }

                    if (soundOn)
                    {
                        sound.playbomb();
                    }
                    stopMytimer();
                }
                else
                {
                    //reset speed, how?
                    manageMe.Speed = manageMe.Normalspeed;//reset speed after a word 
                    myScores.Missedwords++;
                    LaunchNewWord();
                    //sound.playError();
                    //launch new
                    //play drop
                    if (soundOn)
                    {
                        sound.playDrop();
                    }
                }
            }
        }

        //returns a list of labels that are in the grid of the passed name
        public Label[] getgrid(string gridname)
        {
            Label[] a = new Label[0];

            foreach (Grid grid in rows.Children)
            {
                if (grid.Name == gridname)
                {

                    return manageMe.GenerateList(grid);
                }

            }
            return a;

        }
        public Grid getgrid1(string gridname)
        {
            Grid a = new Grid();

            foreach (Grid grid in rows.Children)
            {
                if (grid.Name == gridname)
                {

                    return grid;
                }

            }
            return a;

        }

        #region Old Move
        //public void moveDown()
        //{
        //    string hpwor = "";
        //    string[] word = manageMe.getCurrentword();

        //    try
        //    {
        //        hpwor = hp.getkey().ToString();  
        //    }
        //    catch//index out of range
        //    {
        //        manageMe.fillspot(hp.getCurrentIndex());
        //        //there is no next row
        //        hp.resetMe();
        //        LaunchNewWord();
        //        //make that position anavailable
        //    }


        //    foreach (Grid grid in rows.Children)
        //    {
        //        if (grid.Name.Substring(3, 1) == hpwor)
        //        {
        //            Label[] labels = manageMe.GenerateList(grid);

        //            if (isInRange(grid.Name.Substring(3, 1)))
        //            {
        //                #region InRange
        //                //index check before you can fill the row
        //                //do the follow if the index is empty
        //                if (manageMe.CheckAvialability(hp.getMyIndex(grid.Name.Substring(3, 1))))  //hp.getMyIndex(hpwor)))hp.getNextIndex())) 
        //                {

        //                    clearPreviousRow();
        //                    manageMe.fillRow(labels, word);
        //                    //manageMe.fillspot(hp.getCurrentIndex());
        //                }
        //                else
        //                {
        //                    //leave at
        //                    //
        //                    LaunchNewWord();
        //                    hp.resetMe();

        //                }
        //                #endregion InRange

        //            }
        //            else
        //            {
        //                manageMe.fillRow(labels, word);
        //                clearPreviousRow();
        //            }




        //            break;
        //        }
        //    }

        //}



        //public void clearPreviousRow()
        //{
        //    string hpwor = hp.previousv();

        //    foreach (Grid grid in rows.Children)
        //    {
        //        if (grid.Name.Substring(3, 1) == hpwor)
        //        {
        //            if (isInRange(grid.Name.Substring(3, 1)))
        //            {
        //                if (manageMe.CheckAvialability(hp.getMyIndex(grid.Name.Substring(3, 1))))
        //                {

        //                    clearRow(grid);
        //                }
        //            }
        //            else
        //            {
        //                clearRow(grid);
        //            }
        //        }
        //    }
        //}
        #endregion Old Move
        myStateTris mystatetris;
        WordWatcher wordWatcher;

        public string arrayInString(string[] a)
        {
            string myvalue= "";
            foreach(string mychar in a)
            {
                if (mychar != "" && mychar != " ")
                {
                    myvalue += mychar;
                }
            }
            return myvalue;
        }

        //adjusts the speed(depending on words lenght)
        public void setWordSpeed(string[] word)
        {

            int tempLegnth = arrayInString(word).Length;
            int speed = manageMe.Speed;
            

            int myvalue = 0;

            int mypercent = getPercent(tempLegnth);

            if (mypercent != 0)
            {
                myvalue = (speed * mypercent) / 100;
                speed = speed + (myvalue);
            }

            if (speed >= 0)
            {
                manageMe.Countdown.Interval = new TimeSpan(0, 0, 0, 0, speed);
            }

            
        }

        public void ResetSpeed()
        {
            manageMe.Countdown.Interval = new TimeSpan(0, 0, 0, 0, manageMe.Speed);
        }

        //returns the slowing percentage of a word of passed legnth
        public int getPercent(int length)
        {
            if (length == 3)
            {
                return -15;
            }
            else if (length == 4)
            {
                return -14;
            }
            else if (length == 5)
            {
                return -13;
            }
            else if (length == 6)
            {
                return -12;
            }
            else if (length == 7)
            {
                return -11;
            }
            else if (length == 8)
            {
                return 0;
            }
            else if (length == 9)
            {
                return 10;
            }
            else if (length == 10)
            {
                return 12;
            }
            else if (length == 11)
            {
                return 13;
            }
            else if (length == 12)
            {
                return 14;
            }
            else if (length == 13)
            {
                return 15;
            }
            else if (length == 14)
            {
                return 16;
            }
            else if (length == 15)
            {
                return 17;
            }
            else
            {
                return 0;
            }
        }

        //displays a new word in the screen
        public void LaunchNewWord()
        {
            CheckBeforeLaunch();
            ResetSpeed(); 
            clearFirstRow();
            mystatetris = new myStateTris();
            wordWatcher = new WordWatcher();


            manageMe.setCurrentWord();

            wordWatcher.setCurrentWord(manageMe.getCurrentword());//testing
            setWordSpeed(manageMe.getCurrentword());
            string[] word = manageMe.getCurrentword();
            dodgeFalseLaunch(word);


            hp.resetMe();

            string hpwor = hp.getkey().ToString();  //mystate.RowToMoveTo(); 

            foreach (Grid grid in rows.Children)
            {
                if (grid.Name.Substring(3, 1) == hpwor)
                {
                    wordWatcher.CurrentRow = grid.Name;//testing

                    Label[] labels = manageMe.GenerateList(grid);
                    manageMe.fillRow(labels, word);
                    currentgrid = grid;
                    break;
                }
            }
            //launch done

        }


        ManageMe manageMe = new ManageMe();

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        //clears all the rows 
        public void clearAllRows()
        {
            foreach (Grid grid in rows.Children)
            {

                clearRow(grid);
            }
        }
        //sets the label's content in the passed grid to an empty string
        public void clearRow(Grid grid)
        {

            foreach (Label lbl in grid.Children)
            {
                lbl.Content = " ";
                lbl.Foreground = Brushes.White;
                lbl.Background = null;
            }
        }

        public void CleanAfterCorrectWord()
        {
            foreach (Grid grid in rows.Children)
            {
                if (isInRange(grid.Name.Substring(3, 1)))
                {
                    if (RowBelowIsEmpty(grid) && grid.Name != "Rowl")
                    {
                        clearRow(grid);
                    }

                }
                else
                {
                    clearRow(grid);
                }
            }
        }

        public bool RowBelowIsEmpty(Grid grid)
        {
            if (thereisARowBelow(grid))
            {
                foreach (Grid grid2 in rows.Children)
                {
                    if (grid2.Name == getnextRow(grid))
                    {
                        foreach (Label lbl in grid2.Children)
                        {
                            if ((string)lbl.Content != " " && (string)lbl.Content != "")
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }
        bool rowIsEmpty(Grid grid)
        {
            foreach (Label lbl in grid.Children)
            {
                if ((lbl.Content.ToString() != " " && lbl.Content.ToString() != ""))
                {
                    return false;
                }
            }
            return true;
        }

        public bool thereisARowBelow(Grid grid)
        {
            //if (grid.Name == "rowf")
            //{
            //    return true;
            //}
            foreach (Grid grid2 in rows.Children)
            {
                if (grid.Name == grid2.Name)
                {
                    if (getnextRow(grid2) == "" || getnextRow(grid2) == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string getnextRow(Grid grid)
        {
            string a = grid.Name.Substring(3, 1);
            //the index of the row in the array
            if (a == "l")
            {
                //index 0
                return "";
            }
            else if (a == "k")
            {
                //index 1
                return "Rowl";
            }
            else if (a == "j")
            {
                //index 2
                return "Rowk";
            }
            else if (a == "i")
            {
                //index 3
                return "Rowj";
            }
            else if (a == "h")
            {
                //index 4
                return "Rowi";
            }
            else if (a == "g")
            {
                //index 5
                return "Rowh";
            }
            else if (a == "f")
            {
                //index 6
                return "Rowg";
            }
            else
            {
                return "";
            }
        }

        WordTrisScores myScores;
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            myScores = new WordTrisScores();

            nowPlaying = true;

            //clearAllRows();
            //writeMe();
            //LaunchNewWord();
            startMyTimer();
            //button2.Content = "stop";
            manageMe.GameStarted = true;

            PauseGrid.Visibility = System.Windows.Visibility.Hidden;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clearAllRows();
            swaloFont();
            ShowMenu();
            //label1.Foreground = Brushes.Gold;

        }
        public void ShowMenu()
        {
            PauseGrid.Visibility = System.Windows.Visibility.Hidden;
            myMenuGrid.Visibility = System.Windows.Visibility.Visible;
            rows.Visibility = System.Windows.Visibility.Hidden;
            gridInstructions.Visibility = System.Windows.Visibility.Hidden;
            gridScoreBoard.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Hidden;
            image1.Visibility = System.Windows.Visibility.Hidden;
            MenuBackground.Visibility = System.Windows.Visibility.Visible;
            clearAllRows();
        }
        public void showInstructions()
        {
            myMenuGrid.Visibility = System.Windows.Visibility.Hidden;
            rows.Visibility = System.Windows.Visibility.Hidden;
            gridScoreBoard.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Hidden;
            image1.Visibility = System.Windows.Visibility.Hidden;
            MenuBackground.Visibility = System.Windows.Visibility.Visible;
            clearAllRows();
            gridInstructions.Visibility = System.Windows.Visibility.Visible;
            //show instructions

            rtbInstructions.Document.Blocks.Clear();

            rtbInstructions.AppendText("WordTris");
            rtbInstructions.AppendText( Environment.NewLine + 
                "Goal: The goal of the game is " +
                "to type the word before it reaches the bottom of the " +
                "blocks, a missed word fills up the last free block");
            
            rtbInstructions.AppendText(Environment.NewLine +
                "Controls:"+ Environment.NewLine + "Press the keys " +
                "matching the charactors of the moving word. " +
                "press space to kill a typed word");

            rtbInstructions.AppendText(Environment.NewLine +
                "Press enter to pause");
            
        }
        public void showHighScores()
        {
            myMenuGrid.Visibility = System.Windows.Visibility.Hidden;
            rows.Visibility = System.Windows.Visibility.Hidden;
            gridScoreBoard.Visibility = System.Windows.Visibility.Hidden;
            //gridScoreboard2.Visibility = System.Windows.Visibility.Hidden;
            MenuBackground.Visibility = System.Windows.Visibility.Visible;
            clearAllRows();
            gridInstructions.Visibility = System.Windows.Visibility.Visible;
            

            //showHighScores
            rtbInstructions.Document.Blocks.Clear();

            rtbInstructions.AppendText("HighScores");
            rtbInstructions.AppendText(Environment.NewLine +
                "scores here");



        }
        
    
        public void wordTypingComplete()
        {
            if (manageMe.GameStarted)
            {
                if (rowIsEmpty(Rowf) || RowBelowIsEmpty(Rowf))
                {
                    //if RowBelowIsEmpy(rowf
                    //i changed this because it wasnt clearing the last row
                    string myname = currentgrid.Name;
                    if (/*thereisARowBelow(currentgrid)&&*/  RowBelowIsEmpty(currentgrid) && myname != "Rowl")
                    {

                        #region word completion content
                        if (wordWatcher.UserWord != "" && wordWatcher.UserWord != " ")
                        {
                            //there is something
                            string userword = wordWatcher.UserWord.ToLower();
                            string expectedword = convertCurrentWordToString();
                            if (userword == expectedword)
                            {
                                //word typing complete
                                //clean up and launch new word
                                myScores.CompletedWords++;
                                myScores.Points += myScores.ScoreIncrease;
                                lblPoints.Content = myScores.Points + " Points";
                                lblCompleted.Content = myScores.CompletedWords.ToString() + " Words";
                                CleanAfterCorrectWord();
                                LaunchNewWord();
                                if (soundOn)
                                {
                                    sound.playHit();
                                }
                            }
                            else
                            {
                                myScores.IncorrectSubmitions++;

                                if (myScores.Points >= myScores.ScoreDecrease)
                                {
                                    myScores.Points -= myScores.ScoreDecrease;
                                }
                                lblPoints.Content = myScores.Points.ToString() + " Points";
                                if (soundOn)
                                {
                                    sound.playError();
                                }
                            }


                        }
                        #endregion word completion content
                    }
                    else
                    {
                        //game over from word completion
                    }
                }
            }
        }

        public string convertCurrentWordToString()
        {
            string a = "";

            foreach (string b in wordWatcher.CurrentWord)
            {
                if (b != "" && b != " ")
                {
                    a += b;
                }
            }
            return a.ToLower();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                pause();
            }
            if (e.Key.ToString() == "RightShift" || e.Key.ToString() == "LeftShift")
            {
                //i don't handle this event for shift keys
                e.Handled = false;
            }
            else if (e.Key.ToString().ToLower() == "escape")
            {
                if(manageMe.GameStarted)
                stopMytimer();
            }
            else if (!((e.Key < Key.A) || (e.Key > Key.Z)))
            {
                //alf
                if(manageMe.GameStarted)
                userInput(e.Key.ToString());
            }
            else if (!((e.Key < Key.D0) || (e.Key > Key.D9)))
            {
                //number
                if(manageMe.GameStarted)
                userInput(e.Key.ToString());
            }
            else if (e.Key.ToString().ToLower() == "space")
            {
                if (manageMe.GameStarted)
                {
                    wordTypingComplete();
                    e.Handled = true;
                }
            }



        }
        //called when a user has pressed a key that could be in the text displayed
        public void userInput(string e)
        {
            //finds the row and then call the function that finds the label
            foreach (Grid grid in rows.Children)
            {
                if (grid.Name == wordWatcher.CurrentRow)
                {
                    doSomethingOnLabel(grid, e);
                    break;
                }
            }
        }
        //called when a row has been found, finds the label that has the text in the row 
        public void doSomethingOnLabel(Grid grid, string key)
        {
            myScores.Strokes += 1;

            foreach (Label lbl in grid.Children)
            {
                int myindex = getIndex(lbl);

                if (wordWatcher.CurrentIndex == myindex)
                {
                    //getword at indexlbl.Content.ToString().ToLower()
                    string partofIndex = wordWatcher.getWordAtCurrentIndex();

                    if (partofIndex.ToLower() == key.ToLower())
                    {
                        RedNextLabel(grid, lbl.Name);//need to red the next label, how can i do that

                        //lbl.Foreground = Brushes.Red;
                        //MessageBox.Show(lbl.Name);
                        wordWatcher.UserWord += partofIndex;
                        wordWatcher.CurrentIndex++;
                        myScores.Points++;
                        lblPoints.Content = myScores.Points + " Points";
                        
                        break;
                    }
                    else
                    {
                        //error, typo
                        myScores.Points--;
                        myScores.Errors += 1;
                        lblErrors.Content = myScores.Errors + " Mistake(s)";
                        if (myScores.Points >= 0)
                        {
                            lblPoints.Content = myScores.Points + " Points";
                        }
                    }
                }
            }
        }

        public void RedNextLabel(Grid grid, string lblname)
        {
            Label lbl = findNextLabel(lblname, grid);
            RedLabel(lbl.Name, grid);
        }
        public void RedLabel(string lblname, Grid grid)
        {
            foreach (Label lbl in grid.Children)
            {
                //lbl.Foreground = Brushes.White;
                if (lblname == lbl.Name)
                {
                    manageMe.setImage2(lbl.Content.ToString().ToLower(), lbl);//to be tested
                    lbl.Foreground = Brushes.Gold;
                    break;
                }
            }
        }

        //public Label getLabel(Grid grid, string
        //{
        //    foreach (Label lbl in grid.Children)
        //    {

        //    }
        //}
        public int getIndex(Label lbl)
        {

            int startpos = lbl.Name.Length;

            if (lbl.Name.Substring(startpos - 1, 1) == "1")
            {

                //index 1
                return 1;

            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "2")
            {
                //index 2
                return 2;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "3")
            {
                //index 3
                return 3;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "4")
            {
                //index 4
                return 4;

            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "5")
            {
                //index 5
                return 5;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "6")
            {
                //index 6
                return 6;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "7")
            {
                //index7
                return 7;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "8")
            {
                //index 8
                return 8;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "9")
            {
                //index 9
                return 9;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "a")
            {
                //index 10
                return 10;

            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "b")
            {
                //index11
                return 11;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "c")
            {
                //index 12
                return 12;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "d")
            {
                //index 13
                return 13;

            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "e")
            {
                //index 14
                return 14;
            }
            else if (lbl.Name.Substring(startpos - 1, 1) == "f")
            {
                //index 15
                return 15;
            }


            return 16;




        }

        public void clearFirstRow()
        {
            foreach (Label lbl in Rowa.Children)
            {
                lbl.Foreground = Brushes.White;
            }
        }

        public Label findNextLabel(string prevName, Grid grid)
        {
            int count = 0;
            Label lbll = new Label();

            foreach (Label lbl in grid.Children)
            {
                count++;
                if (lbl.Name == prevName)
                {
                    lbll = (Label)grid.Children[count];
                }
            }

            return lbll;
        }
        public event EventHandler Closing1;

        

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Closing1 != null)
            {
                Closing1(this, new EventArgs());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNewGame_MouseEnter(object sender, MouseEventArgs e)
        {

            
            //btnNewGame.Content = "New Game";
        }

        private void btnNewGame_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnNewGame.Content = "";
        }

        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            //showInstructions
            showInstructions();
            //MenuBackground.Visibility = System.Windows.Visibility.Visible;
            //image1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            ShowMenu();
        }

        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            showHighScores();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            PauseGrid.Visibility = System.Windows.Visibility.Hidden;
            stopMytimer();

        }

        public void swaloFont()
        {
            for (int a = 0; a < rows.Children.Count; a++ )
            {
                continueswalo((Grid)rows.Children[a]);
            }
        }


        public void continueswalo(Grid grid)
        {
            for (int a = 0; a < grid.Children.Count; a++)
            {
                swalo((Label)grid.Children[a]);
            }
        }

        public void swalo(Label lbl)
        {
            lbl.FontSize = 0.1;
            lbl.Height = 38;
        }

        public void CheckBeforeLaunch()
        {
           bool yes =  rowIsEmptyb(manageMe.GenerateList(Rowf));

           if (!yes)
           {
               if (soundOn)
               {
                   sound.playbomb();
               }
               stopMytimer();
           }
            
        }

        public void dodgeFalseLaunch(string[] word)
        {

            if ((arrayIsEmpty(word)))
            {
                LaunchNewWord();
            }

            //LaunchNewWord();
        }
        public bool arrayIsEmpty(string[] arr)
        {
            bool yes = true;

            for (int m = 0; m < arr.Length; m++)
            {
                if (!(arr[m] == " ") && !( arr[m] == ""))
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }

    }
}

