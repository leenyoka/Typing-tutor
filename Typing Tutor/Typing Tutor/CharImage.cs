using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Threading;

namespace Typing_Tutor
{
    public class CharImage
    {




        public CharImage()
        {

        }

        public void MoveImages(Label pos1, Label pos2, Label pos3,
            Label pos4, Label pos5, Label pos6, Label pos7,
            Label pos8, Label pos9, Label pos10, Label pos11,
            Label pos12, Label pos13, Label pos14, Label pos15)
        {
            List<Label> labels = new List<Label>();

            labels.Add(pos1);
            labels.Add(pos2);
            labels.Add(pos3);
            labels.Add(pos4);
            labels.Add(pos5);
            labels.Add(pos6);
            labels.Add(pos7);
            labels.Add(pos8);
            labels.Add(pos9);
            labels.Add(pos10);
            labels.Add(pos11);
            labels.Add(pos12);
            labels.Add(pos13);
            labels.Add(pos14);
            labels.Add(pos15);

            GO(labels);
            
        }

        public void GO(List<Label> labels)
        {
            for (int m = 0; m < labels.Count; m++)
            {
                Label lbl = (Label)labels[m];

                GetImage(lbl);

            }
        }


        public void GetImage(Label lbl)
        {
            string tempkey = (string)lbl.Content.ToString();

            string tempkey2 = (string)lbl.Content.ToString().ToUpper();

            string path = "";

            if (tempkey2 != "\\" && tempkey2 != "/" &&
                tempkey2 != "?" && tempkey2 != "&" &&
                tempkey2 != ":" && tempkey2 != "<" &&
                tempkey2 != ">" && tempkey2 != "." &&
                tempkey2 != "\"" && tempkey2 != "|")
            {
                if (tempkey2 == "" || tempkey2 == " ")
                {

                }
                else
                {
                    if (tempkey == tempkey2)
                    {
                        path += "capital/" + tempkey + ".png";
                    }
                    else
                    {
                        path += "small/" + tempkey + ".png";
                    }
                }
            }
            else
            {
                path += "symbol/" + imagename(tempkey2) + ".png";
            }


            setImage(path, lbl);
        }


        public void GetButtonsImage(Button lbl, bool capital)
        {
            string tempkey = (string)lbl.Content.ToString();

            string tempkey2 = (string)lbl.Content.ToString();

            string path = "";

            if (tempkey2 != "\\" && tempkey2 != "/" &&
                tempkey2 != "?" && tempkey2 != "&" &&
                tempkey2 != ":" && tempkey2 != "<" &&
                tempkey2 != ">" && tempkey2 != "." &&
                tempkey2 != "\"" && tempkey2 != "|")
            {
                if (tempkey2 == "" || tempkey2 == " ")
                {

                }
                else
                {
                    if (capital)
                    {
                        path += "buttonColor1/" + tempkey + ".png";
                    }
                    else
                    {
                        path += "buttonColor2/" + tempkey + ".png";
                    }
                }
            }
            else
            {
                if (capital)
                {
                    path += "buttonColor1/" + imagename(tempkey2) + ".png";
                }
                else
                {
                    path += "buttonColor2/" + imagename(tempkey2) + ".png";
                }
            }


            setImage(path, lbl);
        }

        public string imagename(string symbol)
        {
            symbol = symbol.ToLower();

            if (symbol == "\\")
            {
                return "backslash";
            }
            else if (symbol == "/")
            {
                return "forwardslash";
            }
            else if (symbol == "?")
            {
                return "question";
            }
            else if (symbol == "&")
            {
                return "ampesand";
            }
            else if (symbol == ":")
            {
                return "colon";
            }
            else if (symbol == "<")
            {
                return "lessthan";
            }
            else if (symbol == ">")
            {
                return "greaterthan";
            }
            else if (symbol == "|")
            {
                return "pipe";
            }
            else if (symbol == "\"")
            {
                return "qoute";
            }
            else if (symbol == ".")
            {
                return "period";
            }
            else
            {
                return "";
            }
            
            
        }

        



        public void setImage(string myChar, Label mylabel)
        {
            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    //bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color1/" + myChar + ".png"));

                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/" + myChar));
                    bi.Stretch = Stretch.Fill;

                    mylabel.Background = bi;
                }
                catch
                {
                    //image not found
                    mylabel.Background = null;
                }
            }
        }

        public void setImage(string myChar, Button mylabel)
        {
            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    //bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color1/" + myChar + ".png"));

                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/" + myChar));
                    bi.Stretch = Stretch.Fill;

                    mylabel.Background = bi;
                    mylabel.FontSize = 0.1;
                }
                catch
                {
                    //image not found
                    mylabel.Background = null;
                }
            }
        }

        public void colorMe(string myChar, Button mylabel, bool brown)
        {
            if(brown)
            {
                myChar = "brownbutton.png";
            }
            else
            {
                myChar = "redbutton.png";
            }

            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    //bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color1/" + myChar + ".png"));

                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/buttonBackground/" + myChar));
                    bi.Stretch = Stretch.Fill;

                    mylabel.Background = bi;
                    //mylabel.FontSize = 0.1;
                }
                catch
                {
                    //image not found
                    mylabel.Background = null;
                }
            }
        }

        public ImageBrush colorMe1(string myChar, Button mylabel, bool brown)
        {

            if (brown)
            {
                myChar = "brownbutton.png";
            }
            else
            {
                myChar = "redbutton.png";
            }

            if (myChar != " " && myChar != "")
            {
                try
                {
                    ImageBrush bi = new ImageBrush();
                    //bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/color1/" + myChar + ".png"));

                    bi.ImageSource = new BitmapImage(new Uri(@"pack://application:,,/Typing%20Tutor;component/Images/buttonBackground/" + myChar));
                    bi.Stretch = Stretch.Fill;

                    //mylabel.Background = bi;
                    //mylabel.Dispatcher.Invoke(new Action(() => mylabel.Background = bi),
                      // DispatcherPriority.Normal, null);
                    //mylabel.FontSize = 0.1;
                    return bi;
                }
                catch
                {
                    //image not found
                   // mylabel.Dispatcher.Invoke(new Action(() => mylabel.Background = null),
                        //DispatcherPriority.Normal, null);
                    return null;
                    //mylabel.Background = null;
                }
            }
            return null;
        }
    }
}
