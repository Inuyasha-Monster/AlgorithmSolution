using System;
using System.Collections.Generic;

namespace Lesson2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 解密QQ号:
            // 问题描述:规则是这样的：首先将第 1个数删除，紧接着将第 2 个数放到
            // 这串数的末尾，再将第 3 个数删除并将第 4 个数放到这串数的末尾，再将第 5 个数删除……
            // 直到剩下最后一个数，将最后一个数也删除。按照刚才删除的顺序，把这些[删除的数]连在一
            // 起就是小哈的 QQ啦

            int[] arr = new[] { 6, 3, 1, 7, 5, 8, 9, 2, 4 };
            Console.WriteLine("QQ加密原始数据:");
            foreach (var i in arr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine("----------我是分割线-----------");
            Console.WriteLine("解密出来的QQ号:");

            var qq = GetQQ(arr);
            foreach (var i in qq)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }

        private static int[] GetQQ(int[] arr)
        {
            // QQ号结果数据集
            List<int> result = new List<int>();
            // 初始化一个长数组来方便"移动"数据
            int[] newArr = new int[100];
            arr.CopyTo(newArr, 0);
            // 数据头部
            int head = 0;
            // 数据尾部
            int tail = arr.Length - 1;

            // 当头部没超过尾部的时候
            while (head <= tail)
            {
                // 删除第一个数放在结果集中
                result.Add(newArr[head]);
                // 将head+1坐标的数放在末尾+1的位置
                newArr[tail + 1] = newArr[head + 1];
                // 将头部先后移动两位
                head += 2;
                // 尾巴增加一节
                tail++;
            }

            return result.ToArray();
        }
    }
}
