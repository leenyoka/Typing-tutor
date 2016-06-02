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
using System.Media;
using BussinessLayer;

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results()
        {
            InitializeComponent();
        }
        UserResults results;
        public Results(UserResults userResults)
        {
            InitializeComponent();
            results = userResults;
            loadResults();
            
            
        }
        string background = "";

        public Results(UserResults userResults, string background, Brush tc)
        {
            InitializeComponent();
            results = userResults;
            loadResults();
            textcolor = tc;

            this.background = background;
            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }


        }
        theme mytheme = new theme();

        Brush textcolor = Brushes.Blue;
        public void loadResults()
        {
            lblDuration.Content = results.Seconds.ToString() + " Seconds";


            lblStrokes.Content = results.Strokes.ToString() + " Strokes";

            

            lblSpeed.Content = results.Speed.ToString() + " " + spUnits();


            lblErrors.Content = results.Errors.ToString() + " Mistake(s)";
        }

        public void intitializeTextColor()
        {
            //for (int m = 0; m < ShowMain.Children.Count; m++)
            //{
            //    //try
            //    //{
            //        setTextColor((Label)ShowMain.Children[m]);
            //    //}
            //    //catch
            //    //{
            //    //}
            //}

            setTextColor(label1);
            setTextColor(label3);
            setTextColor(label2);
            setTextColor(lblAccurate);
            setTextColor(lblDuration);
            setTextColor(lblStrokes);
            setTextColor(lblSpeed);
            setTextColor(lblErrors);

        }

        public void setTextColor(Label myelement)
        {
            myelement.Foreground = textcolor;
            //also set text size here
        }

        public string spUnits()
        {
            if (wpm())
                return "wpm";
            else
                return "cpm";
        }

        
        public bool wpm()
        {
            #region Old
            //if (results.CurrentUser != null && results.CurrentUser != " "
            //    && results.CurrentUser !="")
            //{
            //    if (da.GetChoice(results.CurrentUser, "Speed").MoValue == "wpm")
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

            #endregion old

            if (results.Mystate.Speed.ToLower() == "wpm")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //public Results(int td, int strokess, int sped, int erros)
        //{
        //    InitializeComponent();

        //    lblDuration.Content = td.ToString();
        //    lblStrokes.Content = strokess.ToString();
        //    lblSpeed.Content = sped.ToString();
        //    lblErrors.Content = erros.ToString();
        //}

        BussinessLayer.DataAccess da = new DataAccess();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //PlayVictorSound();

            intitializeTextColor();
        }

        public void PlayVictorSound()
        {
            if (results.Errors <= 0 && results.Speed > 10)
            {
                //play victor sound
                if (results.CurrentUser != "" && results.CurrentUser != null)
                {
                    if (da.GetChoice(results.CurrentUser, "Victorysound").MoValue == "true")
                    {
                        var filename = "Sound\\Good .mp3";
                        mySounds(filename);
                    }
                }
                else
                {
                    if (da.GetAnOption("Victorysound").MoValue == "true")
                    {
                        var filename = "Sound\\Good .mp3";
                        mySounds(filename);
                    }
                }
            }
        }
        public void mySounds(string filename)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            SoundPlayer sound = new SoundPlayer(path);

            sound.Play();

            //MediaElement mediaElement1 = new MediaElement();

            //mediaElement1.LoadedBehavior = MediaState.Manual;
            //mediaElement1.Source = new Uri(path, UriKind.RelativeOrAbsolute);

            //mediaElement1.Play();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void More(object sender, RoutedEventArgs e)
        {
            ShowMain.Visibility = System.Windows.Visibility.Hidden;
            ShowMore.Visibility = System.Windows.Visibility.Visible;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            ShowMain.Visibility = System.Windows.Visibility.Visible;
            ShowMore.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnFingers_Click(object sender, RoutedEventArgs e)
        {
            if (results.Skill != null)
            {
                //if (results.Seconds > 10)
                //{
                if (results.Skill.ToLower() != "num")
                {
                    handResults hr = new handResults(results.Testkeywatcher, results, background);
                    hr.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Results by finger not available for " + Environment.NewLine +
                    //    "num test", "Finger Results", MessageBoxButton.OK, MessageBoxImage.Stop);

                    NumHandResults num1 = new NumHandResults(results.Testkeywatcher, results, background);
                    num1.ShowDialog();
                }
                //}
                //else
                //{
                //    MessageBox.Show("To see accurate finger results, your test has to \nlast longer than ten seconds.",
                //        "Test To Short", MessageBoxButton.OK, MessageBoxImage.Stop);
                //}
            }
            else
            {
                handResults hr = new handResults(results.Testkeywatcher, results, background);
                hr.ShowDialog();
            }
        }

        private void btnDifficultkeys_Click(object sender, RoutedEventArgs e)
        {
            if (results.DifficultKeys.Length > 0)
            {
                if (results.Skill != null)
                {
                    if (results.Skill.ToLower() != "num")
                    {
                        ViewDifficultKeys vdk = new ViewDifficultKeys(results.DifficultKeys, background, textcolor);
                        vdk.ShowDialog();
                    }
                    else
                    {
                        ViewNumDifficultkeys numer = new ViewNumDifficultkeys(results.DifficultKeys, background);
                        numer.ShowDialog();
                    }
                }
                else
                {
                    //what if its null?
                    ViewDifficultKeys vdk = new ViewDifficultKeys(results.DifficultKeys, background, textcolor);
                    vdk.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You typed well, you didn't have any \n" +
                    " difficult keys", "No Difficult keys", MessageBoxButton.OK,
                    MessageBoxImage.Hand);
            }
        }
    }
}
