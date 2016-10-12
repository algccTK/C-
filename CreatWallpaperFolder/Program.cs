using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace test_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            new creatfo();
        }
    }
    public class creatfo
    {
        public creatfo()
        {

            string DesktopPath =System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            List<string> needcreats = new List<string>();
            needcreats.Add(DesktopPath + @"\123\320");
            needcreats.Add(DesktopPath + @"\123\321");
            needcreats.Add(DesktopPath + @"\123\322");
            needcreats.Add(DesktopPath + @"\123\323");
            foreach (string sPath in needcreats)
            {
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
            }
        }
    }
}
