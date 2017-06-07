using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace test_ConsoleApplication
{
    class Story
    {
        public static void Main(string[] args)
        {
            Gobal.CustomExtension=args;
            DeleteVoiceFiles.Strat();

        }
    }
}
