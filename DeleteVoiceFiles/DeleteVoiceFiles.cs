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
        private static int count = 0;
        public static void Strat()
        {
            Console.WriteLine("輸入‘y’確認刪除音頻文件");
            string Input = Console.ReadLine();
            if (Input == "y")
            {
                Delete(GetPath());
                Console.WriteLine("操作完成，共删除" + count.ToString() + "个文件");
                Console.ReadLine();

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
            else TheFolder = path as DirectoryInfo;

            foreach (FileInfo item in TheFolder.GetFiles())//遍歷當前目錄下的文件
            {
                if (item.Extension == ".ogg" || item.Extension == ".wav")
                {
                    Console.WriteLine("准备删除:" + item.FullName);
                    File.Delete(item.FullName);
                    count++;
                    Console.WriteLine("删除 " + item.FullName + "完成");
                }
            }

            foreach (DirectoryInfo item in TheFolder.GetDirectories())//遞歸
            {
                Delete(item);
            }
            if (TheFolder.GetDirectories().Length == 0 && TheFolder.GetFiles().Length == 0)  //空文件夾
            {
                Console.WriteLine("准备删除空文件夾:" + TheFolder.FullName);
                TheFolder.Delete();
                Console.WriteLine("删除空文件夾 " + TheFolder.FullName + "完成");
            }
        }

        private static bool IsCustomExtension(string fileExtension)
        {
            if (Gobal.CustomExtension == null || Gobal.CustomExtension.Length == 0) return false;
            foreach (var item in Gobal.CustomExtension)
            {
                if (fileExtension == item) return true;
            }
            return false;
        }
    }

    class Gobal
    {
        public static string[] CustomExtension { get; set; }
    }
}
