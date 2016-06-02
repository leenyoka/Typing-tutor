using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Typing_Tutor
{
    class LoadAssist
    {
        DispatcherTimer partone;

        public DispatcherTimer Partone
        {
            get { return partone; }
            set { partone = value; }
        }
        DispatcherTimer parttwo;

        public DispatcherTimer Parttwo
        {
            get { return parttwo; }
            set { parttwo = value; }
        }
        DispatcherTimer partthree;

        public DispatcherTimer Partthree
        {
            get { return partthree; }
            set { partthree = value; }
        }
        DispatcherTimer partFour;

        public DispatcherTimer PartFour
        {
            get { return partFour; }
            set { partFour = value; }
        }

        bool[] done = new bool[4] { false, false, false, false };

        public bool[] Done
        {
            get { return done; }
            set { done = value; }
        }

        public LoadAssist()
        {
        }
    }
}
