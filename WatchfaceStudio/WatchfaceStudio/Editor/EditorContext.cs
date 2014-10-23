using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchfaceStudio.Entities;

namespace WatchfaceStudio.Editor
{
    public static class EditorContext
    {
        public static FacerWatchface SelectedWatchface;
        
        public static EWatchfaceOverlay Overlay
        {
            get
            {
                var wo = Properties.Settings.Default.WatchfaceOverlay;
                return (EWatchfaceOverlay)wo;
            }
            set
            {
                Properties.Settings.Default.WatchfaceOverlay = (int)value;
                Properties.Settings.Default.Save();
            }
        }

        public static EWatchType WatchType
        {
            get
            {
                var wt = Properties.Settings.Default.Watchtype;
                if (!Enum.IsDefined(typeof(EWatchType), wt))
                    wt = (int)default(EWatchType);
                return (EWatchType)wt;
            }
            set
            {
                Properties.Settings.Default.Watchtype = (int)value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
