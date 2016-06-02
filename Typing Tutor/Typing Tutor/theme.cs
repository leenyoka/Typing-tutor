using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Typing_Tutor
{
    public class theme
    {
        public theme()
        {
        }

        public ImageBrush getMyBackground(string choice)
        {
            ImageBrush bi = new ImageBrush();
            bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/" + choice + ".png"));
            //bi.Stretch = Stretch.Fill;
            //bi.Stretch = Stretch.Uniform;

            return bi;
        }

        

        public BitmapImage getMyBackground(string choice, int a)
        {
            BitmapImage bi = new BitmapImage();
            bi = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/Backgrounds/" + choice + ".png"));
            //bi.Stretch = Stretch.Fill;
            //bi.Stretch = Stretch.Uniform;

            return bi;
        }

        public Brush getmyTextColor(string colorname)
        {
            if (colorname.ToLower() == "black")
            {
                return Brushes.Black;
            }
            else if (colorname.ToLower() == "blue")
            {
                return Brushes.Blue;
            }
            else if (colorname.ToLower() == "green")
            {
                return Brushes.Green;
            }
            else
            {
                return Brushes.Yellow;
            }
        }

        public BitmapImage wordtrisBackground(string choice)
        {
            string tempcolor = getcolorname(choice);
            BitmapImage bi = new BitmapImage();
            bi = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/BackgroundsWordtris/" + tempcolor + ".png"));
            //bi.Stretch = Stretch.Fill;
            //bi.Stretch = Stretch.Uniform;

            return bi;
        }


        public string getcolorname(string name)
        {
            string tempvalue = "";
            if (name.ToLower() == "background41")
            {
                tempvalue = "Red";
            }
            else if (name.ToLower() == "background42")
            {
                tempvalue = "Blue";
            }
            else if (name.ToLower() == "background43")
            {
                tempvalue = "Black";
            }
            else if (name.ToLower() == "background44")
            {
                tempvalue = "DarkRed";
            }
            else if (name.ToLower() == "background45")
            {
                tempvalue = "Green";
            }
            else if (name.ToLower() == "background46")
            {
                tempvalue = "Purple";
            }
            return tempvalue;
        }


    }
}
