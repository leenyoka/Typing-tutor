using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Typing_Tutor
{
    public class ManageMe
    {
        bool gameStarted = false;
        DispatcherTimer countdown;//associated with speed

        public DispatcherTimer Countdown
        {
            get { return countdown; }
            set { countdown = value; }
        }

        int speedDecreaser = 5;

        public int SpeedDecreaser
        {
            get { return speedDecreaser; }
            set { speedDecreaser = value; }
        }


        DispatcherTimer mywatch;//use this to keep time

        public DispatcherTimer Mywatch
        {
            get { return mywatch; }
            set { mywatch = value; }
        }

        private int normalspeed = 1000;

        public int Normalspeed
        {
            get { return normalspeed; }
            set { normalspeed = value; }
        }


        int speed = 1000;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        int seconds;
        //bool[] isAvailable = new bool[7];
        string[] currentWord;

        string[] words;

        int timeBeforeSpeedIncrease = 30;//how many seconds before the speed a speed increament

        public int TimeBeforeSpeedIncrease
        {
            get { return timeBeforeSpeedIncrease; }
            set { timeBeforeSpeedIncrease = value; }
        }

        int myCounter;

        public int MyCounter
        {
            get { return myCounter; }
            set { myCounter = value; }
        }




        #region Constructor

        public ManageMe()
        {
            //freeAllspots();
            setWords();
        }
        #endregion Constructor

        #region Properties
        public bool GameStarted
        {
            get { return gameStarted; }
            set { gameStarted = value; }
        }

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        #endregion Properties

        #region Methods


        #region I wont use these for now
        ////checks if th position is free
        //public bool CheckAvialability(int slot)
        //{
        //    if (slot < isAvailable.Length)
        //    {

        //        if (isAvailable[slot])
        //        {
        //            return true;
        //        }

        //    }
        //    return false;

        //}


        ////sets the value of the isavailable array to false, meaning that spot is no longer free
        //public void fillspot(int slot)
        //{
        //    isAvailable[slot] = false;
        //}


        ////clears the value in the passed spot
        //public void freespot(int slot)
        //{
        //    isAvailable[slot] = true;
        //}

        ////clears all the values in the array isavailable
        //public void freeAllspots()
        //{
        //    for (int x = 0; x <= 6; x++)
        //    {
        //        isAvailable[x] = true;
        //    }
        //}

        #endregion I wont use these for now

        public int DecreaseSpeed()
        {
            speed = speed - speedDecreaser;
            return speed;
        }


        //dis played the text passed as an array in the list of labels passed
        public void fillRow(Label[] labels, string[] arr)
        {
            try
            {
                labels[0].Content = arr[0];
                labels[1].Content = arr[1];
                labels[2].Content = arr[2];
                labels[3].Content = arr[3];
                labels[4].Content = arr[4];
                labels[5].Content = arr[5];
                labels[6].Content = arr[6];
                labels[7].Content = arr[7];
                labels[8].Content = arr[8];
                labels[9].Content = arr[9];
                labels[10].Content = arr[10];
                labels[11].Content = arr[11];
                labels[12].Content = arr[12];
                labels[13].Content = arr[13];
                labels[14].Content = arr[14];
            }
            catch
            {
                //index out of rang? need to think about this
            }

            foreach (Label lbl in labels)
            {
                try
                {
                    setImage(lbl.Content.ToString().ToLower(), lbl);// to be tested
                }
                catch
                {
                    //there is no label
                }
            }
        }

        //checks if any of the labels contains text in its content property
        public bool rowIsEmpty(Label[] grid)
        {
            foreach (Label lbl in grid)
            {
                if ((string)lbl.Content != " " && (string)lbl.Content != "")
                {
                    return false;
                }
            }
            return true;
        }


        //takes the content of the labels in a and sets them to the contents
        //of the labels in b(b being the labels in the next row)
        public bool MoveToNextRow(Label[] a, Label[] b)
        {
            if (rowIsEmpty(b) && !rowIsEmptyb(a))
            {

                for (int m = 0; m < a.Length; m++)
                {
                    b[m].Content = a[m].Content;
                    b[m].Background = a[m].Background;
                    a[m].Content = " ";

                    b[m].Foreground = a[m].Foreground;
                    a[m].Foreground = Brushes.White;
                    a[m].Background = null;
                }
                return true;
            }
            return false;
        }



        //sets the background of the passed label to the image of the
        //char matching the passed char
        public void setImage(string myChar, Label mylabel)
        {
            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color1/" + myChar + ".png"));

                    bi.Stretch = Stretch.Fill;

                    mylabel.Background = bi;
                }
                catch
                {
                    //image not found
                }
            }
        }

        public void setImage2(string myChar, Label mylabel)
        {
            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color2/" + myChar + ".png"));

                    bi.Stretch = Stretch.Fill;

                    mylabel.Background = bi;
                }
                catch
                {
                    //image not found
                }
            }
        }
















        public bool rowIsEmptyb(Label[] a)
        {
            bool yes = true;
            foreach (Label lbl in a)
            {
                if ((string)lbl.Content != " " && (string)lbl.Content != "")
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }


        //makes an array of the passed word
        public string[] myWordArray(string text)
        {
            string[] arr = new string[15];

            if (WordhasRightlengh(text))
            {
                int startat = GetStartIndex(text) - 1;
                int stoppos = startat + text.Length;
                int counter = 0;


                for (int x = 0; x < arr.Length; x++)
                {
                    if (x < startat)
                    {
                        arr[x] = " ";
                    }
                    else if (x >= startat && x < stoppos)
                    {
                        arr[x] = text.Substring(counter, 1);
                        counter++;
                    }
                    else
                    {
                        arr[x] = " ";
                    }

                }

                #region old
                //arr[0] = "";
                //arr[1] = "";
                //arr[2] = "t";
                //arr[3] = "e";
                //arr[4] = "s";
                //arr[5] = "t";
                //arr[6] = "";
                //arr[7] = "w";
                //arr[9] = "o";
                //arr[10] = "r";
                //arr[11] = "d";
                //arr[12] = "";
                //arr[13] = "";
                //arr[14] = "";
                #endregion old
            }

            return arr;

        }

        public bool WordhasRightlengh(string word)
        {
            if (word.Length >= 3 && word.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //returns where the word should start displaying(depends on the legnth of the word)
        public int GetStartIndex(string word)
        {
            int zii = word.Length;

            if (zii == 3 || zii == 4)
            {
                return 7;
            }
            else if (zii == 5 || zii == 6)
            {
                return 6;
            }
            else if (zii == 7 || zii == 8)
            {
                return 5;
            }
            else if (zii == 9 || zii == 10)
            {
                return 4;
            }
            else if (zii == 11 || zii == 12)
            {
                return 3;
            }
            else if (zii == 13)
            {
                return 2;
            }
            else if (zii == 14 || zii == 15)
            {
                return 1;
            }
            else
            {
                return 8;//at the middle
            }
        }


        //makes a list of the labels in the passed grid and returns it
        public Label[] GenerateList(Grid grid)
        {
            Label[] templist = new Label[15];

            //List<Label> templist = new List<Label>(15);

            foreach (Label lbl in grid.Children)
            {

                setposition(lbl, templist);

            }

            return templist;
        }

        //finds the right position for the label passed in the list passed
        public bool setposition(Label lbl, Label[] labels)
        {
            try
            {
                int startpos = lbl.Name.Length;

                if (lbl.Name.Substring(startpos - 1, 1) == "1")
                {

                    //index 1
                    labels[0] = lbl;

                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "2")
                {
                    //index 2
                    labels[1] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "3")
                {
                    //index 3
                    labels[2] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "4")
                {
                    //index 4
                    labels[3] = lbl;

                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "5")
                {
                    //index 5
                    labels[4] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "6")
                {
                    //index 6
                    labels[5] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "7")
                {
                    //index7
                    labels[6] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "8")
                {
                    //index 8
                    labels[7] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "9")
                {
                    //index 9
                    labels[8] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "a")
                {
                    //index 10
                    labels[9] = lbl;

                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "b")
                {
                    //index11
                    labels[10] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "c")
                {
                    //index 12
                    labels[11] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "d")
                {
                    //index 13
                    labels[12] = lbl;

                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "e")
                {
                    //index 14
                    labels[13] = lbl;
                }
                else if (lbl.Name.Substring(startpos - 1, 1) == "f")
                {
                    //index 15
                    labels[14] = lbl;
                }
            }
            catch
            {
                //why
            }


            return true;

        }

        public void setCurrentWord()
        {
            Random rd = new Random();

            bool wordfound = false;

            while (!wordfound)
            {
                string[] word = myWordArray(words[rd.Next(3, words.Length - 3)]);
                //if its not empty
                if (wordIsValid(word))
                {
                    currentWord = word;
                    break;
                }
            }


        }

        public bool wordIsValid(string[] word)
        {
            bool itsvalid = false;

            foreach (string mychar in word)
            {
                if (mychar != " " && mychar != "")
                {
                    return true;
                }
            }
            return itsvalid;
        }

        public string[] getCurrentword()
        {
            return currentWord;
        }

        public bool setWords()
        {
            //take a new word from a word server

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "words.txt");
            TextFileToString txt = new TextFileToString(path);

            string mywords = txt.ReadToString().ToLower();

            words = mywords.Split('#');

            return true;

        }







        #endregion Methods





    }
}
