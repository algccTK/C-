using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//多線程版
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
    class Programzzz
    {
        public static void aaaaa()
        {
            //Program zz = new Program();
            // Console.WriteLine(@"請輸入一個數");
            // string in_str = Console.ReadLine();
            
            //ulong aa = 100;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Parallel.For(100, 1000000000, aa =>//999999999999999999
            {
                
                string in_str = aa.ToString();
                long a = 0;
                for (int i = 0; i < in_str.Length; i++)
                {
                    a = a + long.Parse((Math.Pow(double.Parse(in_str[i].ToString()), in_str.Length)).ToString());
                }
                if (a == aa) Console.WriteLine(aa + "是水仙花數");
            });
            sw.Stop();


            Console.WriteLine(@"
運行時間：{0}
請按回車鍵退出程序",sw.Elapsed);
            Console.ReadLine();
        }
        /* public void out1(int y)
         {
             for (int i=0;i<y;i++)
             {
                 Console.Write("*");
             }
         }*/

    }
}
