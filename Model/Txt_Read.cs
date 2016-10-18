using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


namespace test2
{
    class ReadTXT
    {
        public void readtxt()
        {

            string txtpath =@"d:\path.txt",line;
            StreamReader sr = new StreamReader(txtpath, Encoding.UTF8);//編碼可不用，會自動識別
            
            while ((line = sr.ReadLine()) != null)//逐行讀取
            {
                
            }
        }
        
    }
}
