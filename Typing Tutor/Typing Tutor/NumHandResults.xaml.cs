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

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for NumHandResults.xaml
    /// </summary>
    public partial class NumHandResults : Window
    {
        public NumHandResults()
        {
            InitializeComponent();
        }

        theme mytheme = new theme();
        string background = "";
        public NumHandResults(List<PressWatcher> pw, UserResults results)
        {
            InitializeComponent();
            testPressWatcher = pw;
            addFingers();
            currentUser = results.CurrentUser;
            this.Results = results;
            this.mystate = results.Mystate;
            AddInformationToFingers();
        }
        public NumHandResults(List<PressWatcher> pw, UserResults results, string background)
        {
            InitializeComponent();
            testPressWatcher = pw;
            addFingers();
            currentUser = results.CurrentUser;
            this.Results = results;
            this.mystate = results.Mystate;
            AddInformationToFingers();

            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }
        }

        List<PressWatcher> testPressWatcher;
        List<fingerDetails> fingers = new List<fingerDetails>();
        string currentUser;
        UserResults Results;
        myState mystate;

        QwertyEnglish qtw = new QwertyEnglish();

        public void AddInformationToFingers()
        {
            foreach (PressWatcher keypress in testPressWatcher)
            {
                keypress.Hand = "right";
                keypress.Finger = qtw.GetNumFinger(keypress.Keyname.ToLower());
                addinformationtoFingers2(keypress);
            }
        }
        public void CalculateSpeeds()
        {
            foreach (fingerDetails finger in fingers)
            {
                TypingSpeed tt = new TypingSpeed(finger.KeyCount, int.Parse((Math.Round(finger.Seconds)).ToString()),
                    finger.ErorrCount, wpm());

                finger.Speed = tt.GetTypingSpeed();
                finger.Accuracy = tt.CalculateAccuracy(finger.KeyCount, finger.ErorrCount);
            }

        }
        public bool wpm()
        {
            


            if (mystate.Speed == "wpm")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void showDetails()
        {
            foreach (fingerDetails finger in fingers)
            {
                //right hand
                if (finger.Name == "pinkie" && finger.Hand == "right")
                {
                    #region right pinkie
                    if (finger.KeyCount > 0)
                    {
                        speedrightpinkie.Content = finger.Speed.ToString();
                        accrightpinkie.Content = finger.Accuracy.ToString();
                        countrightpinkie.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedrightpinkie.Visibility = System.Windows.Visibility.Hidden;
                        accrightpinkie.Visibility = System.Windows.Visibility.Hidden;
                        countrightpinkie.Visibility = System.Windows.Visibility.Hidden;

                    }
                    #endregion right pinke

                    //MessageBox.Show("speed:" + finger.Speed.ToString() +
                    //    " accuracy:" + finger.Accuracy.ToString() +
                    //    " count: " + finger.KeyCount);
                }
                else if (finger.Name == "ring" && finger.Hand == "right")
                {
                    #region right ring
                    if (finger.KeyCount > 0)
                    {
                        speedrightring.Content = finger.Speed.ToString();
                        accrightring.Content = finger.Accuracy.ToString();
                        countrightring.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedrightring.Visibility = System.Windows.Visibility.Hidden;
                        accrightring.Visibility = System.Windows.Visibility.Hidden;
                        countrightring.Visibility = System.Windows.Visibility.Hidden;
                    }

                    #endregion right ring
                }
                else if (finger.Name == "middle" && finger.Hand == "right")
                {
                    #region right middle
                    if (finger.KeyCount > 0)
                    {
                        speedrightmiddle.Content = finger.Speed.ToString();
                        accrightmiddle.Content = finger.Accuracy.ToString();
                        countrightmiddle.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedrightmiddle.Visibility = System.Windows.Visibility.Hidden;
                        accrightmiddle.Visibility = System.Windows.Visibility.Hidden;
                        countrightmiddle.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion right ring
                }
                else if (finger.Name == "index" && finger.Hand == "right")
                {
                    #region right index
                    if (finger.KeyCount > 0)
                    {
                        speedrightindex.Content = finger.Speed.ToString();
                        accrightindex.Content = finger.Accuracy.ToString();
                        countrightindex.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedrightindex.Visibility = System.Windows.Visibility.Hidden;
                        accrightindex.Visibility = System.Windows.Visibility.Hidden;
                        countrightindex.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion right index
                }
                else if (finger.Name == "thumb" && finger.Hand == "right")
                {
                    #region right thumb
                    if (finger.KeyCount > 0)
                    {
                        speedrightthumb.Content = finger.Speed.ToString();
                        accrightthumb.Content = finger.Accuracy.ToString();
                        countrightthumb.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedrightthumb.Visibility = System.Windows.Visibility.Hidden;
                        accrightthumb.Visibility = System.Windows.Visibility.Hidden;
                        countrightthumb.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion right thumb
                }
            }
        }

        public void addinformationtoFingers2(PressWatcher keypress)
        {
            foreach (fingerDetails finger in fingers)
            {
                if (keypress.Finger == finger.Name &&
                    keypress.Hand == finger.Hand /*&& finger.Name != "thumb"*/)
                {


                    finger.Seconds += keypress.ReactionTime;
                    finger.KeyCount++;

                    if (keypress.Missed1)
                    {
                        finger.ErorrCount++;
                    }
                    break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateSpeeds();
            showDetails();
            MyUnits();

        }
        public void MyUnits()
        {
            bool mywpm = wpm();

            if (mywpm)
            {
                lblSpeed.Content += " (in WPM)";
            }
            else
            {
                lblSpeed.Content += " (in CPM)";
            }
        }
        public void addFingers()
        {
            fingers.Add(new fingerDetails("pinkie", "right"));
            fingers.Add(new fingerDetails("ring", "right"));
            fingers.Add(new fingerDetails("middle", "right"));
            fingers.Add(new fingerDetails("index", "right"));
            fingers.Add(new fingerDetails("thumb", "right"));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
