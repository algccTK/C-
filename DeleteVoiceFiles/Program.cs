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
            Console.WriteLine("輸入額外擴展名，無則直接回車");
            var input = Console.ReadLine();
            Gobal.CustomExtension=input.Split(' ');
            
            DeleteVoiceFiles.Strat();

        }
    }
}
