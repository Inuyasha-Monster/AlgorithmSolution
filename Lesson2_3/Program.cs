using System;
using System.Collections.Generic;

namespace Lesson2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 练习题:
            //星期天小哼和小哈约在一起玩桌游，他们正在玩一个非常古怪的扑克游戏——“小猫钓
            //    鱼”。游戏的规则是这样的：将一副扑克牌平均分成两份，每人拿一份。小哼先拿出手中的
            //    第一张扑克牌放在桌上，然后小哈也拿出手中的第一张扑克牌，并放在小哼刚打出的扑克牌
            //    的上面，就像这样两人交替出牌。出牌时，如果某人打出的牌与桌上某张牌的牌面相同，即
            //可将两张相同的牌及其中间所夹的牌全部取走，并依次放到自己手中牌的末尾。当任意一人
            //    手中的牌全部出完时，游戏结束，对手获胜。
            //
            //假如游戏开始时，小哼手中有 6 张牌，顺序为 2 4 1 2 5 6，小哈手中也有 6 张牌，顺序
            //    为 3 1 3 5 6 4，最终谁会获胜呢？现在你可以拿出纸牌来试一试。接下来请你写一个程序来
            //    自动判断谁将获胜。这里我们做一个约定，小哼和小哈手中牌的牌面只有 1~9。

            int[] arrA = new[] { 2, 4, 1, 2, 5, 6 };
            int[] arrB = new[] { 3, 1, 3, 5, 6, 4 };

            var xiaoMaoDiaoYu = XiaoMaoDiaoYu(arrA, arrB);

            Console.WriteLine(xiaoMaoDiaoYu);
        }

        /// <summary>
        /// 小猫钓鱼(默认A先出牌)
        /// </summary>
        /// <param name="arrA">A手中的扑克牌</param>
        /// <param name="arrB">B手中的扑克牌</param>
        /// <returns></returns>
        private static string XiaoMaoDiaoYu(int[] arrA, int[] arrB)
        {
            // 1. 用 queue stack 现成的数据结构解答
            Queue<int> queueA = new Queue<int>(arrA);
            Queue<int> queueB = new Queue<int>(arrB);
            Stack<int> stack = new Stack<int>();

            int i = 0;
            while (queueA.Count != 0 && queueB.Count != 0)
            {
                // A出牌
                var dequeue = queueA.Dequeue();
                // 是否stack桌面牌中有和A出牌相同的,有就两张相同的牌及其中间所夹的牌全部取走加入A的队尾
                if (stack.Contains(dequeue))
                {
                    queueA.Enqueue(dequeue);
                    while (stack.Peek() != dequeue)
                    {
                        var pop = stack.Pop();
                        queueA.Enqueue(pop);
                    }
                    queueA.Enqueue(stack.Pop());
                }
                else
                {
                    // 否则加入栈顶
                    stack.Push(dequeue);
                }

                // B出牌
                var bDequeue = queueB.Dequeue();
                // 同理判断是否stack桌面牌中有和B出牌相同的,有就两张相同的牌及其中间所夹的牌全部取走加入B的队尾
                if (stack.Contains(bDequeue))
                {
                    queueB.Enqueue(bDequeue);
                    while (stack.Peek() != bDequeue)
                    {
                        queueB.Enqueue(stack.Pop());
                    }
                    queueB.Enqueue(stack.Pop());
                }
                else
                {
                    stack.Push(bDequeue);
                }

                i++;
            }

            Console.WriteLine($"一共进行了 {i} 轮出牌结束游戏");

            if (queueA.Count == 0) return "A 赢了";
            return "B 赢了";
        }
    }
}
