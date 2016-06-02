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
    /// Interaction logic for ViewNumDifficultkeys.xaml
    /// </summary>
    public partial class ViewNumDifficultkeys : Window
    {
        string difficultKeys = "";

        theme mytheme = new theme();
        string background = "";

        public ViewNumDifficultkeys()
        {
            InitializeComponent();
        }
        public ViewNumDifficultkeys(string keys)
        {
            InitializeComponent();
            
            this.difficultKeys = keys;
        }

        public ViewNumDifficultkeys(string keys, string background)
        {
            InitializeComponent();
            this.difficultKeys = keys;
            this.background = background;

            try
            {
                this.Background = mytheme.getMyBackground(background);
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        CharImage cimg = new CharImage();
        public void BrownPad()
        {
            foreach (Button btn in Numpadkeys.Children)
            {
                btn.Background = Brushes.SaddleBrown;
                cimg.colorMe("", btn, true);
                //btn.IsEnabled = false;
                //btn.Foreground = Brushes.Black;
            }
        }
        public void simulateNumPress(string e)
        {

            //BrownPad();
            foreach (Button btn in Numpadkeys.Children)
            {
                if (e.ToLower() == (string)btn.Content)
                {
                    //btn.Background = Brushes.Red;
                    cimg.colorMe("", btn, false);
                }
            }
            //simulateNumHand(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BrownPad();
            foreach (char mychar in difficultKeys)
            {
                simulateNumPress(mychar.ToString());
            }
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
