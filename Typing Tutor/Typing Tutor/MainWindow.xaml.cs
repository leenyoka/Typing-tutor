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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BussinessLayer;

namespace Typing_Tutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Close();
            register.ShowDialog();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            TouchType touch = new TouchType();
            this.Close();
            touch.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            Login();
        }

        public void Login()
        {
            this.Hide();
            if (isValidInput())
            {
                if (userFound(txtUsername.Text))
                {
                    if (hasRightPassword(txtUsername.Text, txtPassword.Password))
                    {
                        //user can login
                        //pass name to know who is logged in
                        TouchType tt = new TouchType(txtUsername.Text);
                        this.Close();
                        tt.ShowDialog();
                    }
                    else
                    {
                        
                        MessageBox.Show("Your password is incorrect", "Wrong Password",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Could not find a user with that username, " +
                        "Please check your username", "User Not found", MessageBoxButton.OK,
                        MessageBoxImage.Information);

                }
            }
            else
            {
                
                MessageBox.Show("Please enter user name and password, username can not be a number.",
                    "Invalid information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                this.ShowDialog();
            }
            catch
            {
                //do nothing if you cant show this.
            }
        }

        //checks whether the user pressed login without entering anything first
        //or the user entered a number value in the user name textbox
        public bool isValidInput()
        {
            bool answer = false;

            if (txtUsername.Text != "" && txtPassword.Password != "")
            {
                answer = true;
                try
                {
                    int t = int.Parse(txtUsername.Text);
                    answer = false;
                }
                catch
                {
                    answer = true;
                }


            }
            return answer;
        }
        //checks if the user has a right password
        public bool hasRightPassword(string username, string password)
        {
            User user = da.GetaUser(username);
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        //checks if the pass username matches a user in the database
        public bool userFound(string username)
        {
            List<User> users = da.GetAllUsers();

            foreach (User user in users)
            {
                if (username == user.Username)
                {
                    return true;
                }
            }
            return false;
        }
        BussinessLayer.DataAccess da;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            da = new DataAccess();
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
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
            var filename = da.GetAnOption("Help").MoValue;// "TypingTutorHelp.CHM"; //da.GetAControl("Help").ControlValue;

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.Diagnostics.Process.Start(filename);
        }
        #endregion Help

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Learn ln = new Learn();
            ln.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
