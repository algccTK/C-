using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
10. 从屏幕输入一个数，判断是否是"水仙花数 "。
所谓 "水仙花数 "是指每个位上的数字的n次幂之和等于它本身的数。例如：153是一个 "水仙花数 "，因为1^3 + 5^3+ 3^3 = 153
 * 三位的水仙花数共有4个：153，370，371，407；  
四位的水仙花数共有3个：1634，8208，9474；   
五位的水仙花数共有3个：54748，92727，93084；   
六位的水仙花数只有1个：548834；   
七位的水仙花数共有4个：1741725，4210818，9800817，9926315；   
八位的水仙花数共有3个：24678050，24678051，88593477 

两位数无水仙花数
 */
namespace _007_MultiCore_Practice
{
    class Programzz
    {
        public static void aaa()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            ulong in_ulong = 100;
            while (in_ulong < 10000000)
            {
                string in_str = in_ulong.ToString();
                ulong a = 0;
                for (int i = 0; i < in_str.Length; i++)
                {
                    a = a + ulong.Parse((Math.Pow(double.Parse(in_str[i].ToString()), in_str.Length)).ToString());
                }
                if (a == in_ulong) Console.WriteLine(in_ulong + "是水仙花數");
                in_ulong++;
            }
            sw.Stop();
            Console.WriteLine(@"
運行時間：{0}
請按回車鍵退出程序", sw.Elapsed);
            Console.ReadLine();
        }
    }
}
