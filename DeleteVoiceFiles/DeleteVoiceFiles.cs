//删除程序所在路径下，所有（含子路径）是ogg和wav的文件
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace test_ConsoleApplication
{
    class DeleteVoiceFiles
    {
        public static void Strat()
        {
            Console.WriteLine("輸入‘y’確認刪除音頻文件");
            string Input = Console.ReadLine();
            if (Input == "y")
            {
                Delete(GetPath());

            }
        }

        private static string GetPath()//取程序所在路徑
        {
            string path = Directory.GetCurrentDirectory();
            return path;
        }

        private static void Delete(object path)
        {
            DirectoryInfo TheFolder;
            if (path is string)
            {
                string patht = path as string;
                TheFolder = new DirectoryInfo(patht);
            }
            else TheFolder =path as DirectoryInfo;
            
            foreach (FileInfo item in TheFolder.GetFiles())//遍歷當前目錄下的文件
            {
                if (item.Extension == ".ogg" || item.Extension == ".wav" )
                {
                    File.Delete(item.FullName);
                }
            }

            foreach (DirectoryInfo item in TheFolder.GetDirectories())//遞歸
            {
                Delete(item);
            }

        }
    }
}
