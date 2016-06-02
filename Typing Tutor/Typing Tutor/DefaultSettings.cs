using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessLayer;

namespace Typing_Tutor
{
    public class DefaultSettings
    {
        List<UserSettings> defaults;

        public List<UserSettings> Defaults
        {
            get { return defaults; }
            set { defaults = value; }
        }

        public DefaultSettings()
        {
            Defaults = new List<UserSettings>();
            addMyDefaults();
        }

        public void addMyDefaults()
        {
            defaults.Add(new UserSettings("Speed", "wpm"));
            defaults.Add(new UserSettings("Testtime", "Count down"));
            defaults.Add(new UserSettings("Testduration", "1"));

            defaults.Add(new UserSettings("DefaultKeyboardView", "keys"));
            defaults.Add(new UserSettings("Errorsound", "true"));

            defaults.Add(new UserSettings("Recordspeed", "0"));
            defaults.Add(new UserSettings("Showinstructions", "true"));
            defaults.Add(new UserSettings("Showkeyboard", "true"));
            defaults.Add(new UserSettings("Victorysound", "true"));
            defaults.Add(new UserSettings("Vocalinstructions", "false"));
            defaults.Add(new UserSettings("Backgroundmusic", "false"));

            defaults.Add(new UserSettings("Backgroundimage", "background43"));
            defaults.Add(new UserSettings("Textcolor", "yellow"));
            
                      
        }

    }
}
