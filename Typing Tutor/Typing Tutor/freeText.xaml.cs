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
    /// Interaction logic for freeText.xaml
    /// </summary>
    public partial class freeText : Window
    {
        public freeText()
        {
            InitializeComponent();
        }

        public freeText(string background, int a, Brush mycolor)
        {
            InitializeComponent();

            label1.Foreground = mycolor;
            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }
        }

        string CurrentUser;
        bool loggedin = false;
        public freeText(string currentUser)
        {
            InitializeComponent();
            this.CurrentUser = currentUser;
            loggedin = true;
        }
        public freeText(string currentUser, string background)
        {
            InitializeComponent();
            this.CurrentUser = currentUser;
            loggedin = true;

            

            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }
        }
        string background = "";

        theme mytheme = new theme();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            bool yes = false;


            try
            {
                text = ConvertRichTextBoxContentsToString(txtUserText);
                yes = true;
            }
            catch
            {
                //index out of range
                MessageBox.Show("You need to enter text to continue",
                    "Text Too Short", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (yes)
            {
                if (text.Length >= 10 && !StringIsEmpty(text))
                {
                    mayContinue = true;
                    writeToFile(text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("your text should have more than ten charactors", "text to short",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            //close this
            //right to a file


        }
        public event EventHandler Closing3;
        public event EventHandler Closing4;

        //public string ConvertRichTextBoxContentsToString(RichTextBox rtb)
        //{

        //    TextRange textRange = new TextRange(rtb.Document.ContentStart,

        //        rtb.Document.ContentEnd);

        //    return textRange.Text;

        //}

        public bool StringIsEmpty(string mystring)
        {
            bool yes = true;

            foreach (char mychar in mystring)
            {
                if (mychar.ToString() != "" && mychar.ToString() != " ")
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }

        public string ConvertRichTextBoxContentsToString(RichTextBox rtb)
        {
            string a = "";

            foreach (Paragraph ph in rtb.Document.Blocks)
            {
                TextRange myrange = new TextRange(ph.ContentStart, ph.ContentEnd);

                a += " " + ChopSpaces(myrange.Text.ToString());
            }

            return a.Substring(1 , a.Length -1);
        }
        public string ChopSpaces(string a)
        {
            string mystring = a;

            if (mystring.Substring(0, 1) == " ")
            {
                mystring.Substring(1, mystring.Length - 1);
            }

            if (mystring.Substring(mystring.Length - 2, 1) == " ")
            {
                mystring.Substring(0, mystring.Length - 2);
            }
            //foreach (char mychar in a)
            //{
            //    if (mychar.ToString() != " " && mychar.ToString() != "")
            //    {
            //        mystring += mychar;
            //    }
            //}

            return mystring;
        }



        public void writeToFile(string text)
        {
            var filename = "";
            if (loggedin)
            {
                filename = CurrentUser + "_free.txt";
            }
            else
            {
                filename = "free.txt";
                
            }


            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            System.IO.File.WriteAllText(path, text);

        }

        bool mayContinue = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mayContinue)
            {
                if (Closing3 != null)
                {
                    Closing3(this, new EventArgs());
                }
            }
            else
            {
                if (Closing4 != null)
                {
                    Closing4(this, new EventArgs());
                }

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
