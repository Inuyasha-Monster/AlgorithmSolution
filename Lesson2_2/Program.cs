using System;
using System.Linq;

namespace Lesson2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 第2节　解密回文——栈
            //    栈究竟有哪些作用呢？我们来看一个例子。“xyzyx”是一个回文字符串，所谓回文字符
            //    串就是指正读反读均相同的字符序列，如“席主席”、“记书记”、“aha”和“ahaha”均是回
            //    文，但“ahah”不是回文。通过栈这个数据结构我们将很容易判断一个字符串是否为回文

            string input = "gfeabccbaefg";
            var b = IsPlalindrome(input);
            Console.WriteLine(b);
        }

        private static bool IsPlalindrome(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            if (str.Length == 1)
            {
                return false;
            }

            var array = str.ToArray();

            int mediumIndex = array.Length / 2 - 1;

            int f;
            if (array.Length % 2 != 0)
            {
                f = mediumIndex + 2;
            }
            else
            {
                f = mediumIndex + 1;
            }

            for (int i = mediumIndex; i >= 0; i--)
            {
                if (array[i] != array[f])
                {
                    return false;
                }
                f++;
            }

            return true;
        }
    }
}
