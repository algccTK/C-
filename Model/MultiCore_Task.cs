using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;//Task類

namespace test2
{
    class MultiCore_Task
    {
        static void Main(string[] args)
        {
            //Programzz.aaa();//MAX
            //Programzzz.aaaaa();//MAX_MultiCore
            //Task t1 = new Task(ww); 這種创建方法無法利用多核
            Task t1 = Task.Factory.StartNew(delegate { ww(); });
            Task t2 = Task.Factory.StartNew(delegate { ww(); });
            Task.WaitAll(t1, t2);
        }

        static void ww()
        {
            while (true) ;
        }
    }
}
