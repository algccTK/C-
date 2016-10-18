using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace test2
{
    class Txt_Write
    {
        public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write("Hello World!!!!");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
