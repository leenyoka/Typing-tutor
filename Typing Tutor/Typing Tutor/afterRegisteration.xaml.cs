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
    /// Interaction logic for afterRegisteration.xaml
    /// </summary>
    public partial class afterRegisteration : Window
    {
        string currentUser;

        public afterRegisteration()
        {
            InitializeComponent();
        }

        public afterRegisteration(string name)
        {
            InitializeComponent();
            currentUser = name;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (rbtutorNLeaner.IsChecked == true)
            {
                //als load the learning page
                TouchType tt = new TouchType(currentUser, true);
                this.Close();
                tt.ShowDialog();

            }
            else
            {

                //load tutor only
                TouchType tt = new TouchType(currentUser, false);
                this.Close();
                tt.ShowDialog();
            }



        }

        #region Learn
        BussinessLayer.DataAccess da = new BussinessLayer.DataAccess();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbtutor.IsChecked = true;
            //this.Background = mytheme.getMyBackground("background43");
        }
        theme mytheme = new theme();
    }
}
