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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
        }

        public Options(string background, int b)
        {
            InitializeComponent();
            this.background = background;
            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }

        }
        //bool loggedin = false;
        string currentUser;
        bool loggedin = false;
        public Options(string username)
        {
            InitializeComponent();
            currentUser = username;
            loggedin = true;
            //loggedin = true;
        }
        string background = "";
        public Options(string username, string background)
        {
            InitializeComponent();
            currentUser = username;
            loggedin = true;

            this.background = background;
            //loggedin = true;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }

        }
        theme mytheme = new theme();
        DataAccess da;
        public event EventHandler closing;
        bool firsttime = true;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            da = new DataAccess();

            if (!loggedin)
            {
                CheckOptions();
            }
            else
            {
                CheckMyPersonalOptions();
            }

            initializeBackgroundoptions();
            initiateTextColors();
        }
        //checks the current options
        

        public void CheckOptions()
        {
            //get test duration
            //txtDuration.Text = da.GetAControl("Testduration").ControlValue;
            txtDuration.Text = da.GetAnOption("Testduration").MoValue;
            //set time format
            if (/*da.GetAControl("Testtime").ControlValue == "Elapsed"*/
                da.GetAnOption("Testtime").MoValue == "Elapsed")
            {
                cmbTime.SelectedIndex = 0;
            }
            else
            {
                cmbTime.SelectedIndex = 1;
            }

            //get speed format
            if (/*da.GetAControl("Speed").ControlValue == "wpm"*/
                da.GetAnOption("Speed").MoValue == "wpm")
            {
                cmbSpeed.SelectedIndex = 0;
            }
            else
            {
                cmbSpeed.SelectedIndex = 1;
            }

            //set keyboard

            if (/*da.GetAControl("Showkeyboard").ControlValue == "True"*/
                da.GetAnOption("Showkeyboard").MoValue == "true")
            {
                cbkeyboard.IsChecked = true;
                //gbKeyboard.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                cbkeyboard.IsChecked = false;
                //gbKeyboard.Visibility = System.Windows.Visibility.Hidden;
            }

            //if (/*da.GetAControl("Showinstructions").ControlValue == "True"*/
            //    da.GetAnOption("Showinstructions").MoValue == "true")
            //{
            //    cbInstructions.IsChecked = true;
            //}
            //else
            //{
            //    cbInstructions.IsChecked = false;
            //}

            //if (da.GetAnOption("DefaultKeyboardView").MoValue == "keys")
            //{
            //    //check keys
            //    rbKeys.IsChecked = true;
            //}
            //else
            //{
            //    //check hands
            //    rbHands.IsChecked = true;
            //}

            if (da.GetAnOption("Backgroundmusic").MoValue == "true")
            {
                cbBackground.IsChecked = true;
            }

            //if (da.GetAnOption("Victorysound").MoValue == "true")
            //{
            //    cbVictorySound.IsChecked = true;
            //}

            if (da.GetAnOption("Errorsound").MoValue == "true")
            {
                cbErrorSound.IsChecked = true;
            }
            if (da.GetAnOption("Vocalinstructions").MoValue == "true")
            {
                cbVocalInstructions.IsChecked = true;
            }

        }

        public void CheckMyPersonalOptions()
        {
            //get test duration
            //txtDuration.Text = da.GetAControl("Testduration").ControlValue;
            txtDuration.Text = da.GetChoice(currentUser,"Testduration").MoValue;
            //set time format
            if (/*da.GetAControl("Testtime").ControlValue == "Elapsed"*/
                da.GetChoice(currentUser, "Testtime").MoValue == "Elapsed")
            {
                cmbTime.SelectedIndex = 0;
            }
            else
            {
                cmbTime.SelectedIndex = 1;
            }

            //get speed format
            if (/*da.GetAControl("Speed").ControlValue == "wpm"*/
                da.GetChoice(currentUser, "Speed").MoValue == "wpm")
            {
                cmbSpeed.SelectedIndex = 0;
            }
            else
            {
                cmbSpeed.SelectedIndex = 1;
            }

            //set keyboard

            if (/*da.GetAControl("Showkeyboard").ControlValue == "True"*/
                da.GetChoice(currentUser, "Showkeyboard").MoValue == "true")
            {
                cbkeyboard.IsChecked = true;
                //gbKeyboard.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                cbkeyboard.IsChecked = false;
                //gbKeyboard.Visibility = System.Windows.Visibility.Hidden;
            }

            //if (/*da.GetAControl("Showinstructions").ControlValue == "True"*/
            //    da.GetChoice(currentUser, "Showinstructions").MoValue == "true")
            //{
            //    cbInstructions.IsChecked = true;
            //}
            //else
            //{
            //    cbInstructions.IsChecked = false;
            //}

            //if (da.GetChoice(currentUser, "DefaultKeyboardView").MoValue == "keys")
            //{
            //    //check keys
            //    rbKeys.IsChecked = true;
            //}
            //else
            //{
            //    //check hands
            //    rbHands.IsChecked = true;
            //}

            if (da.GetChoice(currentUser, "Backgroundmusic").MoValue == "true")
            {
                cbBackground.IsChecked = true;
            }

            //if (da.GetChoice(currentUser, "Victorysound").MoValue == "true")
            //{
            //    cbVictorySound.IsChecked = true;
            //}

            if (da.GetChoice(currentUser, "Errorsound").MoValue == "true")
            {
                cbErrorSound.IsChecked = true;
            }
            if (da.GetChoice(currentUser, "Vocalinstructions").MoValue == "true")
            {
                cbVocalInstructions.IsChecked = true;
            }

        }


        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            bool successful = false;
            #region Save
            //if (changesMade)
            //{
            try
            {
                //save the changes to the control table in the database
                string speed = cmbSpeed.Text;
                string testtime = cmbTime.Text;
                int testduration = int.Parse(txtDuration.Text);
                bool keyboardshown = false;
                bool instructionsgiven = false;

                if (cbkeyboard.IsChecked == true)
                {
                    keyboardshown = true;
                }
                else
                {
                    keyboardshown = false;
                }

                //if (cbInstructions.IsChecked == true)
                //{
                //    instructionsgiven = true;
                //}
                //else
                //{
                //    instructionsgiven = false;
                //}

                if (!loggedin)
                {
                    SaveOptions(testduration, testtime, keyboardshown, instructionsgiven, speed);
                }
                else
                {
                    SaveMyPersonalOptions(testduration, testtime, keyboardshown, instructionsgiven, speed);
                }

                successful = true;
            }
            catch(Exception )
            {
                //MessageBox.Show(ex.Message);
                //couldnt convert or could not find a value, nothing is selected in the combo
                MessageBox.Show("Could not save changes, Please makes sure you selected values,\n" +
                    " Make sure that test duration doesn't contain characters", "error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                successful = false;
            }
            //}
            #endregion Save

            //then take the user back to the main window
            //persist login state
            this.Close();
            if (successful)
            {
                //MessageBox.Show("Changes saved", "Changes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void SaveOptions(int testduration, string testtime,
            bool showKeyboard, bool showInstructions, string speed)
        {
            try
            {
                BussinessLayer.ManageOptions durationControl = new BussinessLayer.ManageOptions("Testduration", testduration.ToString());
                da.updateOption(durationControl);

                BussinessLayer.ManageOptions SpeedControl = new BussinessLayer.ManageOptions("Speed", speed);
                da.updateOption(SpeedControl);

                BussinessLayer.ManageOptions timeControl = new BussinessLayer.ManageOptions("Testtime", testtime);
                da.updateOption(timeControl);

                if (showKeyboard)
                {
                    BussinessLayer.ManageOptions keybaord =new BussinessLayer.ManageOptions("Showkeyboard", "true");
                    da.updateOption(keybaord);
                }
                else
                {
                    BussinessLayer.ManageOptions keybaord = new BussinessLayer.ManageOptions("Showkeyboard", "false");
                    da.updateOption(keybaord);
                }

                if (showInstructions)
                {
                    BussinessLayer.ManageOptions instructions = new BussinessLayer.ManageOptions("Showinstructions", "true");
                    da.updateOption(instructions);
                }
                else
                {
                    BussinessLayer.ManageOptions instructions = new BussinessLayer.ManageOptions("Showinstructions", "false");
                    da.updateOption(instructions);
                }

                //if (rbHands.IsChecked == true)
                //{
                //    BussinessLayer.ManageOptions hands = new ManageOptions("DefaultKeyboardView", "hands");
                //    da.updateOption(hands);
                //}
                //else
                //{
                //    BussinessLayer.ManageOptions keys = new ManageOptions("DefaultKeyboardView", "keys");
                //    da.updateOption(keys);
                //}

                if (cbErrorSound.IsChecked == true)
                {
                    BussinessLayer.ManageOptions erorrs = new ManageOptions("Errorsound", "true");
                    da.updateOption(erorrs);
                }
                else
                {
                    BussinessLayer.ManageOptions erorrs = new ManageOptions("Errorsound", "false");
                    da.updateOption(erorrs);
                }

                //if (cbVictorySound.IsChecked  == true)
                //{
                //    BussinessLayer.ManageOptions victor = new ManageOptions("Victorysound", "true");
                //    da.updateOption(victor);
                //}
                //else
                //{
                //    BussinessLayer.ManageOptions victor = new ManageOptions("Victorysound", "false");
                //    da.updateOption(victor);
                //}

                if (cbBackground.IsChecked == true)
                {
                    BussinessLayer.ManageOptions back = new ManageOptions("Backgroundmusic", "true");
                    da.updateOption(back);
                }
                else
                {
                    BussinessLayer.ManageOptions back = new ManageOptions("Backgroundmusic", "false");
                    da.updateOption(back);
                }
                if (cbVocalInstructions.IsChecked == true)
                {
                    BussinessLayer.ManageOptions vocals = new ManageOptions("Vocalinstructions", "true");
                    da.updateOption(vocals);
                }
                else
                {
                    BussinessLayer.ManageOptions vocals = new ManageOptions("Vocalinstructions", "false");
                    da.updateOption(vocals);
                }

                BussinessLayer.ManageOptions textcolor = new ManageOptions("Backgroundimage", selectedbackground);
                da.updateOption(textcolor);

                BussinessLayer.ManageOptions textcolor1 = new ManageOptions("Textcolor", selectedtextcolor);
                da.updateOption(textcolor1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //MessageBox.Show("could not make changes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
                
        }

        public void SaveMyPersonalOptions(int testduration, string testtime,
            bool showKeyboard, bool showInstructions, string speed)
        {
            try
            {
                //BussinessLayer.ManageOptions durationControl = new BussinessLayer.ManageOptions("Testduration", testduration.ToString());
                UpdateSetting(currentUser, "Testduration", testduration.ToString());

                //BussinessLayer.ManageOptions SpeedControl = new BussinessLayer.ManageOptions("Speed", speed);
                UpdateSetting(currentUser, "Speed", speed);
                //da.updateOption(SpeedControl);

                //BussinessLayer.ManageOptions timeControl = new BussinessLayer.ManageOptions("Testtime", testtime);
                UpdateSetting(currentUser, "Testtime", testtime);
                //da.updateOption(timeControl);

                if (showKeyboard)
                {
                    //BussinessLayer.ManageOptions keybaord =new BussinessLayer.ManageOptions("Showkeyboard", "true");
                    UpdateSetting(currentUser, "Showkeyboard", "true");
                    //da.updateOption(keybaord);
                }
                else
                {
                    //BussinessLayer.ManageOptions keybaord = new BussinessLayer.ManageOptions("Showkeyboard", "false");
                    UpdateSetting(currentUser, "Showkeyboard", "false");
                    //da.updateOption(keybaord);
                }

                if (showInstructions)
                {
                    //BussinessLayer.ManageOptions instructions = new BussinessLayer.ManageOptions("Showinstructions", "true");
                    UpdateSetting(currentUser, "Showinstructions", "true");
                    //da.updateOption(instructions);
                }
                else
                {
                    //BussinessLayer.ManageOptions instructions = new BussinessLayer.ManageOptions("Showinstructions", "false");
                    UpdateSetting(currentUser, "Showinstructions", "false");
                    //da.updateOption(instructions);
                }

                //if (rbHands.IsChecked == true)
                //{
                //    //BussinessLayer.ManageOptions hands = new ManageOptions("DefaultKeyboardView", "hands");
                //    UpdateSetting(currentUser, "DefaultKeyboardView", "hands");
                //    //da.updateOption(hands);
                //}
                //else
                //{
                //    //BussinessLayer.ManageOptions keys = new ManageOptions("DefaultKeyboardView", "keys");
                //    UpdateSetting(currentUser, "DefaultKeyboardView", "keys");
                //    //da.updateOption(keys);
                //}

                if (cbErrorSound.IsChecked == true)
                {
                    //BussinessLayer.ManageOptions erorrs = new ManageOptions("Errorsound", "true");
                    UpdateSetting(currentUser, "Errorsound", "true");
                    //da.updateOption(erorrs);
                }
                else
                {
                    //BussinessLayer.ManageOptions erorrs = new ManageOptions("Errorsound", "false");
                    UpdateSetting(currentUser, "Errorsound", "false");
                    //da.updateOption(erorrs);
                }

                //if (cbVictorySound.IsChecked  == true)
                //{
                //   // BussinessLayer.ManageOptions victor = new ManageOptions("Victorysound", "true");
                //    UpdateSetting(currentUser, "Victorysound", "true");
                //    //da.updateOption(victor);
                //}
                //else
                //{
                //    //BussinessLayer.ManageOptions victor = new ManageOptions("Victorysound", "false");
                //    UpdateSetting(currentUser, "Victorysound", "false");
                //    //da.updateOption(victor);
                //}

                if (cbBackground.IsChecked == true)
                {
                    //BussinessLayer.ManageOptions back = new ManageOptions("Backgroundmusic", "true");
                    UpdateSetting(currentUser, "Backgroundmusic", "true");
                    //da.updateOption(back);
                }
                else
                {
                    //BussinessLayer.ManageOptions back = new ManageOptions("Backgroundmusic", "false");
                    UpdateSetting(currentUser, "Backgroundmusic", "false");
                    //da.updateOption(back);
                }
                if (cbVocalInstructions.IsChecked == true)
                {
                    //BussinessLayer.ManageOptions vocals = new ManageOptions("Vocalinstructions", "true");
                    UpdateSetting(currentUser, "Vocalinstructions", "true");
                    //da.updateOption(vocals);
                }
                else
                {
                    //BussinessLayer.ManageOptions vocals = new ManageOptions("Vocalinstructions", "false");
                    UpdateSetting(currentUser, "Vocalinstructions", "false");
                    //da.updateOption(vocals);
                }

                UpdateSetting(currentUser, "Backgroundimage", selectedbackground);

                UpdateSetting(currentUser, "Textcolor", selectedtextcolor);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //MessageBox.Show("could not make changes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
                
        }

        public void UpdateSetting(string username, string moname, string movalue)
        {
            UserSettings us = new UserSettings(username, moname, movalue);
            da.updateUserSettings(us);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region //i dont want to save changes when the user clicks ok even if the user didn make any changes
        //using a glogal because this i not that important
        //bool changesMade = false;
        #endregion

        private void cmbSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //changesMade = true;
        }

        private void txtDuration_TextChanged(object sender, TextChangedEventArgs e)
        {
            //changesMade = true;

            string mystring = txtDuration.Text;

            if (!firsttime)
            {
                if (!itsText(mystring))
                {
                    if (overLimit(txtDuration.Text))
                    {
                        MessageBox.Show("Can not be longer than 9999 minutes",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtDuration.Text = mystring.Substring(0, 4);

                    }
                }
                else
                {
                    txtDuration.Text = removeText(mystring).ToString();
                }
            }
            else
            {
                firsttime = false;
            }
        }
        string removeText(string txt)
        {
            string temp = "";
            foreach (char mychar in txt)
            {
                if (!itsText(mychar.ToString()))
                {
                    temp += mychar.ToString();
                }
            }

            return temp;
        }
        bool overLimit(string text)
        {
            int tempvalue = 0;
            try
            {
                tempvalue = int.Parse(text);
            }
            catch
            {
                if (txtDuration.Text.Length > 3)
                {
                    txtDuration.Text = txtDuration.Text.Substring(0, txtDuration.Text.Length - 2);
                }
                return false;
            }

            if (tempvalue >= 9999)
            {
                return true;
            }
            return false;
        }

        public bool itsText(string txt)
        {
            try
            {
                int temp = int.Parse(txt);
            }
            catch
            {
                return true;
            }
            return false;

        }

        private void cmbTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //changesMade = true;
        }

        private void cbkeyboard_Checked(object sender, RoutedEventArgs e)
        {
            //changesMade = true;
            //gbKeyboard.Visibility = System.Windows.Visibility.Visible;
        }

        private void cbInstructions_Checked(object sender, RoutedEventArgs e)
        {
            //changesMade = true;
        }

        private void cbkeyboard_Unchecked(object sender, RoutedEventArgs e)
        {
           // gbKeyboard.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (closing != null)
            {
                closing(this, new EventArgs());
            }
        }
        List<ImageBrush> myimages = new List<ImageBrush>();

        public void initializeBackgroundoptions()
        {
            addColorOptions();

            string background = "";
            if (loggedin)
            {
                background = da.GetChoice(currentUser, "Backgroundimage").MoValue;
            }
            else
            {
                background = da.GetAnOption("Backgroundimage").MoValue;
            }

            try
            {
                //image1.Source  = 

                backtemplate.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }

            string color = getcolorname(background);

            int selectedindex = getselectionIndex(color);

            cmbBackgrounds.SelectedIndex = selectedindex;

            selectedbackground = background;
            

        }
        string selectedbackground = "";


        //public void addImagesTotheList()
        //{
        //    ImageBrush bi = new ImageBrush();
            
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background41.png"));
        //    myimages.Add(bi);

        //    ImageBrush bi1 = new ImageBrush();
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background42.png"));
        //    myimages.Add(bi);

        //    ImageBrush bi2 = new ImageBrush();
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background43.png"));
        //    myimages.Add(bi);

        //    ImageBrush bi3 = new ImageBrush();
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background44.png"));
        //    myimages.Add(bi);

        //    ImageBrush bi4 = new ImageBrush();
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background45.png"));
        //    myimages.Add(bi);

        //    ImageBrush bi5 = new ImageBrush();
        //    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/background46.png"));
        //    myimages.Add(bi);
        //}
        


        public string getimagename(string name)
        {
            string tempvalue = "";
            if (name.ToLower() == "red")
            {
                tempvalue =  "background41";
            }
            else if (name.ToLower() == "blue")
            {
                tempvalue = "background42";
            }
            else if (name.ToLower() == "black")
            {
                tempvalue = "background43";
            }
            else if (name.ToLower() == "dark red")
            {
                tempvalue = "background44";
            }
            else if (name.ToLower() == "green")
            {
                tempvalue = "background45";
            }
            else if (name.ToLower() == "purple")
            {
                tempvalue = "background46";
            }
            return tempvalue;
        }

        public string getcolorname(string name)
        {
            string tempvalue = "";
            if (name.ToLower() == "background41")
            {
                tempvalue ="Red";
            }
            else if (name.ToLower() == "background42")
            {
                tempvalue = "Blue";
            }
            else if (name.ToLower() == "background43")
            {
                tempvalue ="Black" ;
            }
            else if (name.ToLower() =="background44" )
            {
                tempvalue = "Dark Red";
            }
            else if (name.ToLower() == "background45")
            {
                tempvalue ="Green" ;
            }
            else if (name.ToLower() == "background46")
            {
                tempvalue ="Purple" ;
            }
            return tempvalue;
        }

        public void addColorOptions()
        {
            cmbBackgrounds.Items.Add("Black");
            cmbBackgrounds.Items.Add("Blue");
            cmbBackgrounds.Items.Add("Dark Red");
            cmbBackgrounds.Items.Add("Green");
            cmbBackgrounds.Items.Add("Purple");
            cmbBackgrounds.Items.Add("Red");
           // cmbBackgrounds.Items.Add("White");
        }

        int getselectionIndex(string colorname)
        {
            if(colorname.ToLower() == "black")
            {
                return 0;
            }
            else if(colorname.ToLower() == "blue")
            {
                return 1;
            }
            else if (colorname.ToLower() == "dark red")
            {
                return 2;
            }
            else if (colorname.ToLower() == "green")
            {
                return 3;
            }
            else if (colorname.ToLower() == "purple")
            {
                return 4;
            }
            else if (colorname.ToLower() == "red")
            {
                return 5;
            }
            else
            {
                return 6;
            }
        
        }

        private void cmbBackgrounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string colorname = cmbBackgrounds.SelectedItem.ToString();

            string imagename = getimagename(colorname);

            selectedbackground = imagename;

            try
            {
                //image1.Source  = 

                backtemplate.Background = mytheme.getMyBackground(imagename);
            }
            catch
            {
                backtemplate.Background = Brushes.White;
            }


        }


        public void loadTextColours()
        {
            cmbTextColour.Items.Add("Black");
            cmbTextColour.Items.Add("Blue");
            cmbTextColour.Items.Add("Green");
            cmbTextColour.Items.Add("Yellow");
            
        }
        public void initiateTextColors()
        {
            loadTextColours();

            string selectedtextcolor = "";

            if (loggedin)
            {
                selectedtextcolor = da.GetChoice(currentUser, "Textcolor").MoValue;
            }
            else
            {
                selectedtextcolor = da.GetAnOption("Textcolor").MoValue;
            }

            this.selectedtextcolor = selectedtextcolor;

            int selectedindex = getSelectedindexTextColor(selectedtextcolor);

            cmbTextColour.SelectedIndex = selectedindex;

            
        }
        string selectedtextcolor = "";
        public int getSelectedindexTextColor(string color)
        {
            if (color.ToLower() == "black")
            {
                return 0;
            }
            else if (color.ToLower() == "blue")
            {
                return 1;
            }
            else if (color.ToLower() == "green")
            {
                return 2;
            }
            else
            {
                return 3;
            }
                
        }

        private void cmbTextColour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedtextcolor = cmbTextColour.SelectedItem.ToString();


        }

        private void txtDuration_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDuration.Text.ToString().ToLower() == "0")
            {
                txtDuration.Text = "1";


                MessageBox.Show("You can not set the duration of the test to 0. \n" +
                    "The duration will be set to one! " , "Test Duration",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            string tempstring = txtDuration.Text;

            if (tempstring.Length <= 0)
            {
                txtDuration.Text = "1";
                MessageBox.Show("You did not set your test duration. \n" +
                    "The duration will be set to one! ", "Test Duration",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            GetHelp();
        }

        public void ErrorReadingPersonalSettings()
        {
            MessageBox.Show("An error occured while reading your settings",
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                GetHelp();
            }
        }

        private void GetHelp()
        {

            
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
        
    }
}
