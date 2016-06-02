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
    /// Interaction logic for ViewDifficultKeys.xaml
    /// </summary>
    public partial class ViewDifficultKeys : Window
    {
        public ViewDifficultKeys()
        {
            InitializeComponent();
        }
        string difficultKeys = "";
        public ViewDifficultKeys(string dif)
        {
            InitializeComponent();
            this.difficultKeys = dif;
        }
        string background = "";
        public ViewDifficultKeys(string dif, string backgroundimage, Brush mybrush)
        {
            InitializeComponent();

            label1.Foreground = mybrush;
            this.difficultKeys = dif;
            this.background = backgroundimage;

            try
            {
                this.Background = mytheme.getMyBackground(backgroundimage);
            }
            catch
            {

            }
        }
        theme mytheme = new theme();
        private void shift_MouseEnter(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }
        CharImage cimg = new CharImage();
        public void simulateKeyPress(string e)
        {
            bool keyfound = false;


            foreach (UIElement child in cnTest.Children)
            {
                Button btn = (Button)child;
                if (e.ToLower() == btn.Content.ToString().ToLower() || e.ToLower() == btn.Name.ToString().ToLower())
                {
                    //btn.Background = Brushes.Red;
                    cimg.colorMe("", btn, false);
                    keyfound = true;
                    break;
                }
            }

            if (!keyfound)
            {
                handleSymbolsimulaion2(e);
            }


        }

        public void handleSymbolsimulaion2picture(string e)//if the key that needs to be pressed is a symbol
        {

            if (e == ";" || e == ":")
            {
                semicolon.Background = Brushes.Red;

                if (e == ":")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "/" || e == "?")
            {
                forwardslash.Background = Brushes.Red;
                if (e == "?")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "[" || e == "{")
            {
                OpenBraket.Background = Brushes.Red;
                if (e == "{")
                {
                    shiftleft.Background = Brushes.Red;
                }

            }
            else if (e == "]" || e == "}")
            {
                CloseBraket.Background = Brushes.Red;

                if (e == "}")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "\\" || e == "|")
            {
                backslash.Background = Brushes.Red;
                if (e == "|")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "'" || e == "\"")
            {
                singleQoute.Background = Brushes.Red;
                if (e == "\"")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "," || e == "<")
            {
                comma.Background = Brushes.Red;
                if (e == "<")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "." || e == ">")
            {
                period.Background = Brushes.Red;
                if (e == ">")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "-" || e == "_")
            {
                underscore.Background = Brushes.Red;
                if (e == "_")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == "=" || e == "+")
            {
                equalto.Background = Brushes.Red;
                if (e == "+")
                {
                    shiftleft.Background = Brushes.Red;
                }
            }
            else if (e == " ")
            {
                //space
                space.Background = Brushes.Red;
            }
            else if (e == "(")
            {
                D9.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;

            }
            else if (e == ")")
            {
                D0.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }
            else if (e == "!")
            {
                D1.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "@")
            {
                D2.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "#")
            {
                D3.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "$")
            {
                D4.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;

            }
            else if (e == "%")
            {
                D5.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "^")
            {
                D6.Background = Brushes.Red;
                shiftright.Background = Brushes.Red;
            }
            else if (e == "&")
            {
                D7.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }
            else if (e == "*")
            {
                D8.Background = Brushes.Red;
                shiftleft.Background = Brushes.Red;
            }





        }



        public void handleSymbolsimulaion2(string e)//if the key that needs to be pressed is a symbol
        {

            if (e == ";" || e == ":")
            {
                //semicolon.Background = Brushes.Red;
                cimg.colorMe("", semicolon, false);

                if (e == ":")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "/" || e == "?")
            {
                //forwardslash.Background = Brushes.Red;
                cimg.colorMe("", forwardslash, false);
                if (e == "?")
                {
                    //shiftleft.Background = Brushes.Red;
                    // cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "[" || e == "{")
            {
                //OpenBraket.Background = Brushes.Red;
                cimg.colorMe("", OpenBraket, false);
                if (e == "{")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }

            }
            else if (e == "]" || e == "}")
            {
                //CloseBraket.Background = Brushes.Red;
                cimg.colorMe("", CloseBraket, false);

                if (e == "}")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "\\" || e == "|")
            {
                //backslash.Background = Brushes.Red;
                cimg.colorMe("", backslash, false);
                if (e == "|")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "'" || e == "\"")
            {
                //singleQoute.Background = Brushes.Red;
                cimg.colorMe("", singleQoute, false);
                if (e == "\"")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "," || e == "<")
            {
                //comma.Background = Brushes.Red;
                cimg.colorMe("", comma, false);
                if (e == "<")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "." || e == ">")
            {
                //period.Background = Brushes.Red;
                cimg.colorMe("", period, false);
                if (e == ">")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "-" || e == "_")
            {
                //underscore.Background = Brushes.Red;
                cimg.colorMe("", underscore, false);
                if (e == "_")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == "=" || e == "+")
            {
                //equalto.Background = Brushes.Red;
                cimg.colorMe("", equalto, false);
                if (e == "+")
                {
                    //shiftleft.Background = Brushes.Red;
                    //cimg.colorMe("", shiftleft, false);
                }
            }
            else if (e == " ")
            {
                //space
                //space.Background = Brushes.Red;
                cimg.colorMe("", space, false);
            }
            else if (e == "(")
            {
                //D9.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D9, false);
                //cimg.colorMe("", shiftleft, false);

            }
            else if (e == ")")
            {
                //D0.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D0, false);
                //cimg.colorMe("", shiftleft, false);
            }
            else if (e == "!")
            {
                //D1.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D1, false);
                //cimg.colorMe("", shiftright, false);
            }
            else if (e == "@")
            {
                //D2.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D2, false);
                //cimg.colorMe("", shiftright, false);
            }
            else if (e == "#")
            {
                //D3.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D3, false);
                //cimg.GetButtonsImage(shiftright, false);
            }
            else if (e == "$")
            {
                //D4.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D4, false);
                //cimg.colorMe("", shiftright, false);
            }
            else if (e == "%")
            {
                //D5.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D5, false);
                //cimg.colorMe("", shiftright, false);
            }
            else if (e == "^")
            {
                //D6.Background = Brushes.Red;
                //shiftright.Background = Brushes.Red;

                cimg.colorMe("", D6, false);
                //cimg.colorMe("", shiftright, false);
            }
            else if (e == "&")
            {
                //D7.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D7, false);
                //cimg.colorMe("", shiftleft, false);
            }
            else if (e == "*")
            {
                //D8.Background = Brushes.Red;
                //shiftleft.Background = Brushes.Red;

                cimg.colorMe("", D8, false);
                //cimg.colorMe("", shiftleft, false);
            }





        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BrownButtons();
            foreach (char mychar in difficultKeys)
            {
                simulateKeyPress(mychar.ToString());
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void BrownButtons()
        {
            foreach (UIElement child in cnTest.Children)
            {
                Button btn = (Button)child;
                //btn.Background = Brushes.SaddleBrown;
                cimg.colorMe("", btn, true);
                btn.MouseMove += new MouseEventHandler(mousOverMyKey);
                //btn.IsEnabled = false;
                //btn.Foreground = Brushes.Black;

            }
            
        }
        public void mousOverMyKey(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Foreground == Brushes.Red)
            {
                btn.ToolTip = "Difficultkey";
            }
        }
    }
}
            //if (!(keyfound))
            //{
            //    //handleSymbolsimulation(e);
            //    handleSymbolsimulaion2(e);
            //}
