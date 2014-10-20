using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public enum WatchfaceRendererErrorSeverity
    {
        Information = 0,
        Warning = 1,
        Error = 2
    }
    
    public class WatchfaceRendererError
    {
        public WatchfaceRendererErrorSeverity Severity;
        public string Object;
        public string Message;
    }
}
