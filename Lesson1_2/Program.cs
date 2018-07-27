using System;

namespace Lesson1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 问题描述: 实现冒泡排序

            int[] inputsInts = { 6, 1, 3, 0, 5, 3, 5, 2, 8 };
            var bubbleSortAsc = BubbleSortAsc(inputsInts);
            foreach (var i in bubbleSortAsc)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-------------华丽的分割线------------------");

            int[] inputs = { 6, 1, 3, 0, 5, 3, 5, 2, 8 };
            var bubbleSortDesc = BubbleSortDesc(inputs);
            foreach (var i in bubbleSortDesc)
            {
                Console.WriteLine(i);
            }
        }

        private static int[] BubbleSortAsc(int[] inputsInts)
        {
            // 循环每个输入数组的元素,每一趟找出一个最小数
            for (int i = 0; i < inputsInts.Length; i++)
            {
                // 依次比较当前元素arr[i]与身后的元素,符合条件就交换位置
                for (int j = i + 1; j < inputsInts.Length; j++)
                {
                    if (inputsInts[i] > inputsInts[j])
                    {
                        var temp = inputsInts[i];
                        inputsInts[i] = inputsInts[j];
                        inputsInts[j] = temp;
                    }
                }
            }
            return inputsInts;
        }

        private static int[] BubbleSortDesc(int[] inputsInts)
        {
            // 循环每个输入数组的元素,每一趟找出一个最大数
            for (int i = 0; i < inputsInts.Length; i++)
            {
                // 依次比较当前元素arr[i]与身后的元素,符合条件就交换位置
                for (int j = i + 1; j < inputsInts.Length; j++)
                {
                    if (inputsInts[i] < inputsInts[j])
                    {
                        var temp = inputsInts[i];
                        inputsInts[i] = inputsInts[j];
                        inputsInts[j] = temp;
                    }
                }
            }
            return inputsInts;
        }
    }
}
