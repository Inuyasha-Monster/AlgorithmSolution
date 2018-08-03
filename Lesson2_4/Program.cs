using System;
using System.Collections.Generic;

namespace Lesson2_4
{
    class Program
    {
        /// <summary>
        /// 单链表节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Node<T>
        {
            public int Data { get; set; }
            public Node<T> Next { get; set; }
        }

        /// <summary>
        /// 单链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class SimpleNodeList<T>
        {
            public Node<T> Head;

            public int Count { get; set; } = 0;

            /// <summary>
            /// 添加节点到链表末尾
            /// </summary>
            /// <param name="node"></param>
            public void Add(Node<T> node)
            {
                if (Head == null)
                {
                    Head = node;
                }
                else
                {
                    var temp = Head.Next;
                    if (temp == null)
                    {
                        Head.Next = node;
                    }
                    else
                    {
                        while (temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                        temp.Next = node;
                    }
                }

                Count++;
            }

            /// <summary>
            /// 顺序插入节点
            /// </summary>
            /// <param name="node"></param>
            public void InsertSort(Node<T> node)
            {
                if (Count == 0)
                {
                    Head = node;
                }
                else
                {
                    var temp = Head;
                    while (temp.Data < node.Data)
                    {
                        var pre = temp;
                        temp = temp.Next;
                        if (temp.Data > node.Data)
                        {
                            temp = pre;
                            break;
                        }
                    }
                    if (temp.Next == null)
                    {
                        temp.Next = node;
                    }
                    else
                    {
                        var next = temp.Next;
                        temp.Next = node;
                        node.Next = next;
                    }
                }

                Count++;
            }
        }

        static void Main(string[] args)
        {
            // 模拟顺序单链表的插入逻辑

            //举例:
            //可以输入以下数据进行验证。
            //9
            //2 3 5 8 9 10 18 26 32
            //6
            //运行结果是：
            //2 3 5 6 8 9 10 18 26 32

            int[] arr = new[] { 2, 3, 5, 8, 9, 10, 18, 26, 32 };
            SimpleNodeList<int> simpleNodeList = new SimpleNodeList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                simpleNodeList.Add(new Node<int>() { Data = arr[i], Next = null });
            }

            // 打印输入的链表
            var temp = simpleNodeList.Head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }

            Console.WriteLine("数量:" + simpleNodeList.Count);

            // 插入数字6
            Console.WriteLine();

            simpleNodeList.InsertSort(new Node<int>() { Data = 6 });

            // 再次打印
            var tempAgain = simpleNodeList.Head;
            while (tempAgain != null)
            {
                Console.WriteLine(tempAgain.Data);
                tempAgain = tempAgain.Next;
            }
            Console.WriteLine("数量:" + simpleNodeList.Count);

        }
    }
}
