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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        BussinessLayer.DataAccess da;

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (isValidInput())
            {
                //User will only be registered if the username has not been taken
                // and the two passwords the user entered match
                if (!usernameTaken(txtUsername.Text))
                {
                    if (passwordMatch(txtPassword.Password, txtRepeatPassword.Password))
                    {
                        #region Register
                        try
                        {
                            //Registration can proceed
                            Successful();

                        }
                        catch (ApplicationException)
                        {
                            //log error
                            MessageBox.Show("Something went terribly wrong", "Error");
                        }
                        #endregion Register
                    }
                    else
                    {
                        //password in txtpassword didnt match password in txtRepeatp pasword
                        MessageBox.Show("Password doesnt match", "Please Check Password",
                            MessageBoxButton.OK, MessageBoxImage.Stop);
                    }


                }
                else
                {
                    //there is already a user using the same username the new user wishes to use
                    MessageBox.Show("Please choose another username", "Username Already taken",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Some of the inforamtion you provided is not valid, Please check" +
                    "\nthat you dont have a number in the useranme field, or" +
                    "it could be that you didnt write anything in one of the fields", "Invalid intoramtion",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        //Checks if the user name has already been taken
        public bool usernameTaken(string username)
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
        //checks if the passwords entered by the user match
        public bool passwordMatch(string password1, string password2)
        {
            if (password1 == password2)
            {
                return true;
            }
            return false;
        }
        

        //validates input
        public bool isValidInput()
        {
            bool answer = false;

            if (txtUsername.Text != "" && txtPassword.Password != "" &&
                txtRepeatPassword.Password != "")
            {
                answer = true;
                try
                {
                    int.Parse(txtUsername.Text);
                    answer = false;
                }
                catch
                {
                    answer = true;
                }
                    
            }

            return answer;
        }

        //Registration is successful
        public void Successful()
        {
            //Register User
            User user = new User(txtUsername.Text, txtPassword.Password);
            da.InsertUser(user);

            afterRegisteration af = new afterRegisteration(txtUsername.Text);
            this.Close();
            af.ShowDialog();

            //Login user

        }

        public string LearningOption()
        {
            string thisisit = "Your Registeration was successful!\n";
            thisisit += "Thank you for Registering!\n";
            thisisit += "Would you like to see a typing background?\n";
            thisisit += "Press yes if you want to learn about typing first\n";
            thisisit += "Press no if you want go to straight to the tutor";

            return thisisit;
        }

        #region Help

        private void GetHelp(object sender, RoutedEventArgs e)
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
        #endregion Help

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

        #region Learn

        private void GoToLearningPage()
        {
            //var filename = "TouchType.html"; //da.GetAControl("Learn").ControlValue;
            var filename = da.GetAnOption("Learn").MoValue;

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.Diagnostics.Process.Start(filename);
        }

        #endregion Learn
    }
}
