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
    /// Interaction logic for Learn.xaml
    /// </summary>
    public partial class Learn : Window
    {
        public Learn()
        {
            InitializeComponent();
        }
        public Learn(string username)
        {
            InitializeComponent();
            currentUser = username;
            //loggedin = true;
        }

        string currentUser;
        //bool loggedin = false;

        DataAccess da = new DataAccess();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string filename = "index.html"; //da.GetAControl("Learn").ControlValue;
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename); 
            wbLearn.Navigate(path);
        }

        private void Keydown(object sender, KeyEventArgs e)
        {
            #region Help
            //get help
            if (e.Key == Key.F1)
            {
                GetHelp(sender, e);
            }
            #endregion help
        }

        #region Help

        private void GetHelp(object sender, RoutedEventArgs e)
        {
            var filename = "TypingTutorHelp.CHM"; //da.GetAControl("Help").ControlValue;

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.Diagnostics.Process.Start(filename);
        }
        #endregion Help

        

        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
            
        //}

        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    //take the user back to the main typing window
        //    //need to persist login state
        //    if (!(loggedin))
        //    {
        //        TouchType tt = new TouchType();
        //        tt.ShowDialog();
        //    }
        //    else
        //    {
        //        TouchType tt = new TouchType(currentUser);
        //        tt.ShowDialog();
        //    }
        //}
    }
}
