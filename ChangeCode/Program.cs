using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace changecode
{
    class Program
    {
        static void Main(string[] args)
        {
           


            changecode.Rename(args[0]);
        }
    }

    public class changecode
    {
        public static void Rename(object path)
        {
            DirectoryInfo TheFolder;
            if (path is string)
            {
                string patht = path as string;
                TheFolder = new DirectoryInfo(patht);
            }
            else TheFolder = path as DirectoryInfo;

            foreach (FileInfo item in TheFolder.GetFiles())                                        //遍歷當前目錄下的文件
            {
                string k = chang(item.Name);
                File.Move(item.FullName, item.Directory + @"\"+k);
            }

            foreach (DirectoryInfo item in TheFolder.GetDirectories())//遞歸
            {
                string thenewFolder = chang(item.ToString());
                string thenewPath = item.Parent.FullName + @"\" + thenewFolder;
                item.MoveTo(thenewPath);
                Rename(thenewPath);
            }

        }


        private static string chang(string source)
        {

            byte[] bsq = Encoding.GetEncoding(936).GetBytes(source);
            return  Encoding.GetEncoding(932).GetString(bsq);
            
        }
    }
}


