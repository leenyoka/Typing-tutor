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
    /// Interaction logic for handResults.xaml
    /// </summary>
    public partial class handResults : Window
    {
        public handResults()
        {
            InitializeComponent();
        }
        List<PressWatcher> testPressWatcher;
        List<fingerDetails> fingers = new List<fingerDetails>();
        string currentUser;
        UserResults Results;
        myState mystate;
        public handResults(List<PressWatcher> pw, UserResults results)
        {
            InitializeComponent();
            testPressWatcher = pw;
            addFingers();
            AddInformationToFingers();
            currentUser = results.CurrentUser;
            this.Results = results;
            this.mystate = results.Mystate;
            
        }

        public handResults(List<PressWatcher> pw, UserResults results, string background)
        {
            InitializeComponent();
            testPressWatcher = pw;
            addFingers();
            AddInformationToFingers();
            currentUser = results.CurrentUser;
            this.Results = results;
            this.mystate = results.Mystate;


            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }

        }
        theme mytheme = new theme();

        public void addFingers()
        {
            fingers.Add(new fingerDetails("pinkie", "left"));
            fingers.Add(new fingerDetails("ring", "left"));
            fingers.Add(new fingerDetails("middle", "left"));
            fingers.Add(new fingerDetails("index", "left"));
            fingers.Add(new fingerDetails("thumb", "left"));

            fingers.Add(new fingerDetails("pinkie", "right"));
            fingers.Add(new fingerDetails("ring", "right"));
            fingers.Add(new fingerDetails("middle", "right"));
            fingers.Add(new fingerDetails("index", "right"));
            fingers.Add(new fingerDetails("thumb", "right"));
        }

        public void AddInformationToFingers()
        {
            foreach (PressWatcher keypress in testPressWatcher)
            {
                addinformationtoFingers2(keypress);
            }
        }

        public void addinformationtoFingers2(PressWatcher keypress)
        {
            foreach (fingerDetails finger in fingers)
            {
                if (keypress.Finger.ToLower() == finger.Name.ToLower() &&
                    keypress.Hand.ToLower() == finger.Hand.ToLower() /*&& finger.Name != "thumb"*/)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateSpeeds();
            showDetails();
            MyUnits();
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

                //left hand
                else if (finger.Name == "pinkie" && finger.Hand == "left")
                {
                    #region left pinkie
                    if (finger.KeyCount > 0)
                    {
                        speedleftpinkie.Content = finger.Speed.ToString();
                        accleftpinkie.Content = finger.Accuracy.ToString();
                        countleftpinkie.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedleftpinkie.Visibility = System.Windows.Visibility.Hidden;
                        accleftpinkie.Visibility = System.Windows.Visibility.Hidden;
                        countleftpinkie.Visibility = System.Windows.Visibility.Hidden;
                    }

                    #endregion left pinkie
                }
                else if (finger.Name == "ring" && finger.Hand == "left")
                {
                    #region left ring
                    if (finger.KeyCount > 0)
                    {

                        speedleftring.Content = finger.Speed.ToString();
                        accleftring.Content = finger.Accuracy.ToString();
                        countleftring.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedleftring.Visibility = System.Windows.Visibility.Hidden;
                        accleftring.Visibility = System.Windows.Visibility.Hidden;
                        countleftring.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion left ring
                }
                else if (finger.Name == "middle" && finger.Hand == "left")
                {
                    #region left middle
                    if (finger.KeyCount > 0)
                    {
                        speedleftmiddle.Content = finger.Speed.ToString();
                        accleftmiddle.Content = finger.Accuracy.ToString();
                        countleftmiddle.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedleftmiddle.Visibility = System.Windows.Visibility.Hidden;
                        accleftmiddle.Visibility = System.Windows.Visibility.Hidden;
                        countleftmiddle.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion left middle
                }
                else if (finger.Name == "index" && finger.Hand == "left")
                {
                    #region left index
                    if (finger.KeyCount > 0)
                    {
                        speedleftindex.Content = finger.Speed.ToString();
                        accleftindex.Content = finger.Accuracy.ToString();
                        countleftindex.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedleftindex.Visibility = System.Windows.Visibility.Hidden;
                        accleftindex.Visibility = System.Windows.Visibility.Hidden;
                        countleftindex.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion left index
                }
                else if (finger.Name == "thumb" && finger.Hand == "left")
                {
                    #region left thumb
                    if (finger.KeyCount > 0)
                    {
                        speedleftthumb.Content = finger.Speed.ToString();
                        accleftthumb.Content = finger.Accuracy.ToString();
                        countleftthumb.Content = finger.KeyCount.ToString();
                    }
                    else
                    {
                        speedleftthumb.Visibility = System.Windows.Visibility.Hidden;
                        accleftthumb.Visibility = System.Windows.Visibility.Hidden;
                        countleftthumb.Visibility = System.Windows.Visibility.Hidden;
                    }
                    #endregion left thumb
                }
            }

            
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

        BussinessLayer.DataAccess da = new DataAccess();
        public bool wpm()
        {
            #region Old
            //if (currentUser != null && currentUser != " "
            //    && currentUser != "")
            //{
            //    if (da.GetChoice(currentUser, "Speed").MoValue == "wpm")
            //    {

            //        return true;

            //    }
            //    else
            //    {

            //        return false;

            //    }
            //}
            //else
            //{
            //    if (da.GetAnOption("Speed").MoValue == "wpm")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;

            //    }
            //}
            #endregion Old


            if (mystate.Speed == "wpm")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

    }
}
