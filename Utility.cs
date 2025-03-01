using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWAutosplitter
{
    public static class Utility
    {
        public static void Log(object value)
        {
            if (value == null) value = String.Empty;
            Trace.WriteLine(value.ToString());
        }
    }
}
