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
    /// Interaction logic for wordtrisResults.xaml
    /// </summary>
    public partial class wordtrisResults : Window
    {
        public wordtrisResults()
        {
            InitializeComponent();
        }
        theme mytheme = new theme();
        Brush mytextcolor;
        
        public wordtrisResults(int points, int correct, int missed,
            int numberofErrors, string duration, string background, string textcolor)
        {
            InitializeComponent();
            lblpoints.Content = points.ToString();
            lblcorrect.Content = correct.ToString();
            //lblmissed.Content = missed.ToString();
            lblerrors.Content = numberofErrors.ToString();
            lblduration.Content = duration;


            mytextcolor = mytheme.getmyTextColor(textcolor);
            this.Background = mytheme.getMyBackground(background);


            try
            {
                foreach (Label lbl in myLabels.Children)
                {
                    lbl.Foreground = mytextcolor;
                }
            }
            catch
            {

            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
