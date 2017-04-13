using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C102_RandomPassword
{
    public class RandomPassword
    {
        private static Random r = new Random();

        public static string GetGeneralPassword()
        {
            string password = string.Empty;
            var length = r.Next(15, 21);
            for (int i = 0; i < length; i++)
            {
                if (r.Next(0, 2) == 0) //隨機決定數字或字母
                {
                    password += GetRandomNumber();
                }
                else password += GetRandomAlphabet();
            }
            return password;
        }

        public static string GetSpecialPassword()
        {
            string password = string.Empty;
            var length = r.Next(15, 21);
            for (int i = 0; i < length; i++)
            {
                var index = r.Next(32, 127);
                string x = ((char)index).ToString();
                password += x;
            }
            return password;
        }

        private static string GetRandomNumber()
        {
            return r.Next(0, 10).ToString();
        }

        private static string GetRandomAlphabet()
        {
            var index = r.Next(65, 91);
            string x = ((char)index).ToString();
            if (r.Next(0, 2) == 0)//隨機大小寫英文
            {
                return x.ToLower();
            }
            return x;

        }
    }
}
