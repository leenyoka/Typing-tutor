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
    /// Interaction logic for skillsResult.xaml
    /// </summary>
    public partial class skillsResult : Window
    {
        UserResults results;
        public skillsResult()
        {
            InitializeComponent();
        }

        theme mytheme = new theme();
        string background = "";

        public skillsResult(UserResults userResults)
        {
            InitializeComponent();
            results = userResults;
            loadResults();
        }
        public skillsResult(UserResults userResults, string background, Brush mycolor)
        {
            InitializeComponent();
            results = userResults;
            loadResults();

            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }
            initme(mycolor);
        }

        public void initme(Brush mycolor)
        {
            foreach (Label lbl in grid1.Children)
            {
                lbl.Foreground = mycolor;
            }
        }
        public void loadResults()
        {
            lblDuration.Content = results.Seconds.ToString() + " Seconds";


            lblStrokes.Content = results.Strokes.ToString() + " Strokes";



            lblSpeed.Content = results.Speed.ToString() + " " + spUnits();


            lblErrors.Content = results.Errors.ToString() + " Mistake(s)";
        }

        public string spUnits()
        {
            if (wpm())
                return "wpm";
            else
                return "cpm";
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


        public bool yesclicked = false;

        //public skillsResult(int td, int strokess, int sped, int erros)
        //{
        //    InitializeComponent();
        //    lblDuration.Content = td.ToString();
        //    lblStrokes.Content = strokess.ToString();
        //    lblSpeed.Content = sped.ToString();
        //    lblErrors.Content = erros.ToString();

            
            
        //}

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            //yes was clicked

            somethingclicked = true;
            if (Closing1 != null)
            {
                Closing1(this, new EventArgs());
            }

            //yesclicked = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            somethingclicked = true;
            //no was clicked
            if (Closing2 != null)
            {
                Closing2(this, new EventArgs());
            }
            //yesclicked = false;
            this.Close();

        }
        public event EventHandler Closing1;
        public event EventHandler Closing2;
        public event EventHandler Closing3;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!somethingclicked)
            {
                if (Closing3 != null)
                {
                    Closing3(this, new EventArgs());
                }
            }
            //if (yesclicked)
            //{
                
            //}
            //else
            //{
                
            //}
        }
        bool somethingclicked = false;

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            if (Closing3 != null)
            {
                Closing3(this, new EventArgs());
            }
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
