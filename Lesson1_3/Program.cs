using System;

namespace Lesson1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuickSort:");
            Console.WriteLine("原始数组:");
            int[] arr = new[]
            {
                6, 1, 2, 7, 9, 3, 4, 5, 10, 8
            };
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine("---------我是分割线--------");

            Console.WriteLine("排序之后:");
            var result = QuickSort(arr);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        private static int[] QuickSort(int[] arr)
        {
            InternalQuickSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void InternalQuickSort(int[] arr, int left, int right)
        {
            // i=>哨兵i j=>哨兵j temp=>基准数
            int i, j, temp;
            // 初始化哨兵i是最左边数的坐标
            i = left;
            // 初始化哨兵j是最右边数的坐标
            j = right;
            // 初始化基准数是最左边的数
            temp = arr[left];
            // 如果哨兵i>=哨兵j表示不需要排序直接弹出
            if (i >= j)
            {
                return;
            }

            // 一直循环等待找到基准数的最终位置,当哨兵i与哨兵j相遇的时候就是找到基准数的目的地
            while (i != j)
            {
                // 哨兵j从右向左移动,哨兵j需要找到比temp小的数
                while (arr[j] >= temp && i < j)
                {
                    j--;
                }

                // 哨兵i从左向右移动,哨兵i需要找到比temp大的数
                while (arr[i] <= temp && i < j)
                {
                    i++;
                }

                // 双方哨兵找到需要交换的数据
                if (i < j)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }

            // 将基准数与目的位置数交换位置
            arr[left] = arr[i];
            arr[i] = temp;

            // 开始拆解基准数左边的数块,注意right的坐标是当前基准数的前一位
            InternalQuickSort(arr, left, i - 1);
            // 开始拆解基准数右边的数块,注意left的坐标是当前基准数的后一位
            InternalQuickSort(arr, i + 1, right);
        }
    }
}
