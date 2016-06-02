using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Typing_Tutor
{
    public class MySoundPlayer: SoundPlayer
    {
        string charactor;
        //bool stoppedplaying = false;
        // = new EventHandler(stopped);

        
    
        

        public string Charactor
        {
            get { return charactor; }
            set { charactor = value; }
        }
        string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public MySoundPlayer()
        {
            
        }
        public MySoundPlayer(string voicename, string path)
        {
            charactor = voicename;
            filePath = path;
            
            
        }
        //public void stopped(object sender, EventArgs e)
        //{
        //    stoppedplaying = true;
        //}
    }
}
