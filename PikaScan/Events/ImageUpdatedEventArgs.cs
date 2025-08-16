using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Events
{
    public class ImageUpdatedEventArgs : EventArgs
    {
        public int Index { get; set; }

        public string Source { get; set; }
    }
}
