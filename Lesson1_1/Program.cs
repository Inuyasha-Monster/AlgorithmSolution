using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 问题描述: 0-10分考试,对下列分数按照从小到大排序

            int[] inputsInts = { 5, 3, 5, 2, 8 };

            var sampleBucketSort = SampleBucketSort(inputsInts);

            // 从小到大
            Console.WriteLine("从小到大:");
            for (int j = 0; j < sampleBucketSort.Length; j++)
            {
                for (int i = 0; i < sampleBucketSort[j]; i++)
                {
                    Console.WriteLine(j);
                }
            }

            Console.WriteLine("-------------华丽的分割线------------------");

            // 从大到小
            Console.WriteLine("从大到小:");
            for (int i = sampleBucketSort.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < sampleBucketSort[i]; j++)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static int[] SampleBucketSort(int[] inputsInts)
        {
            // 申请一个固定长度的数组(当作许多桶)
            int[] bucket = new int[11];
            // 初始化每个桶中的分数出现的次数为0
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = 0;
            }
            // 将数组中的分数出现的次数累积到对应桶中去
            for (int i = 0; i < inputsInts.Length; i++)
            {
                bucket[inputsInts[i]]++;
            }
            // 返回桶集合
            return bucket;
        }
    }
}
