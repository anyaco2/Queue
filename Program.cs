using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1_попытка2
{

    class Queue
    {
        private int[] data;
        private int head;
        private int tail;
        private int size;

        public Queue(int capacity)
        {
            size = capacity + 1;
            data = new int[size];
            head = 0;
            tail = size - 1;
        }

        public bool Empty()
        {
            return Next(tail) == head;
        }

        private int Next(int n)
        {
            return (n + 1) % size;
        }

        public void Add(int value)
        {
            if (Next(Next(tail)) == head)
            {
                Console.WriteLine("Queue overflow");
            }
            else
            {
                tail = Next(tail);
                data[tail] = value;
            }
        }

        public void PrintQueue()
        {
            if (Empty())
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                int current = head;
                while (current != tail)
                {
                    Console.Write(data[current] + " ");
                    current = Next(current);
                }
                Console.WriteLine(data[tail]);
            }
        }

        public int Del()
        {
                int d = data[head];
                head = (head + 1) % size;  
                return d;
        }

        public void NullQueue()
        {
            head = 0;
            tail = size - 1;
        }

        public int Findmin()
        {
            int min = int.MaxValue;
            int current = head;
            while (current != tail)
            {
                if (data[current] < min)
                {
                    min = data[current];
                }
                current = Next(current);
            }

            if (data[tail] < min)
            {
                min = data[tail];
            }

            return min;
        }

        /*public Stack<int> CreateStack(Queue queue)
        {
            int min = Findmin();
            Stack<int> stack = new Stack<int>();

            while (!Empty())
            {
                int num = Del();

                if (num % queue.Findmin() == 0)
                {
                    stack.Push(num);
                }
            }

            return stack;
        }

        public void PrintStack(Stack<int> stack)
        {
            foreach (int num in stack)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }*/
    }

    class Stack
    {
        private int top;
        private int[] data;
        public Stack(int capa)
        {
            top = -1;
            data = new int[capa];

        }
        public bool Empty()
        {
            return top == -1;
        }
        private void Push(int value)
        {
            data[++top] = value;
        }
        public void AddStack(Queue queue1, Queue queue2, Stack stack)
        {
            int min = queue2.Findmin();
            while (!queue1.Empty())
            {
                int num = queue1.Del();
                if (num % min == 0)
                {
                    stack.Push(num);
                }
            }

        }
        public void PrintStack(Stack<int> stack)
        {

            foreach (int num in stack)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
    class Queue2
    {
        private class Node
        {
            public int data;
            public Node next;
        }

        private Node head, tail;
        private Random random;

        public Queue2()
        {
            head = null;
            tail = null;
            random = new Random();
        }

        public bool Empty()
        {
            return head == null;
        }

        public void Add(int value)
        {
            if (Empty())
            {
                head = new Node();
                head.data = value;
                head.next = null;
                tail = head;
            }
            else
            {
                tail.next = new Node();
                tail = tail.next;
                tail.data = value;
                tail.next = null;
            }
        }

        public void GenerateRandomQueue()
        {
            int size = random.Next(3, 27); 
            for (int i = 0; i < size; i++)
            {
                int value = random.Next(1, 100); 
                Add(value);
            }
        }

        public void GenerateRandomQueue1()
        {
            int size = random.Next(3, 15); 
            for (int i = 0; i < size; i++)
            {
                int value = random.Next(2, 20); 
                Add(value);
            }
        }



        public void PrintQueue()
        {
            if (Empty())
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                Node current = head;
                while (current != null)
                {
                    Console.Write(current.data + " ");
                    current = current.next;
                }
                Console.WriteLine();
            }
        }

        public int Findmin()
        {
            if (Empty())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }

            int min = head.data;
            Node current = head.next;

            while (current != null)
            {
                if (current.data < min)
                {
                    min = current.data;
                }
                current = current.next;
            }

            return min;
        }

        public Stack<int> CreateStack(Queue2 queue)
        {
            int min = Findmin();

            Node current = head;
            Stack<int> stack = new Stack<int>();
            while (current != null)
            {
                if (current.data % queue.Findmin() == 0)
                {
                    stack.Push(current.data);
                }

                current = current.next;
            }
            return stack;
        }

        public void PrintStack(Stack<int> stack)
        {
            foreach (int num in stack)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public int Del()
        {
            if (Empty())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            else
            {
                int d = head.data;
                Node tmp = head;
                head = head.next;
                tmp = null;
                return d;
            }
        }

        public void NullQueue()
        {
            while (!Empty())
            {
                Node tmp = head;
                head = head.next;
                tmp = null;
            }
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите способ реализации : 1 - массив, 2 - динамический список");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("------------------------------------------------");
                    Random rnd = new Random();
                    int capacity1 = rnd.Next(10, 30);
                    int capacity2 = rnd.Next(10, 20);

                    Queue myQueue1 = new Queue(capacity1); // создаем очередь с вместимостью 10
                    Queue myQueue2 = new Queue(capacity2);
                    // Добавляем элементы в очередь
                    for (int i = 0; i < capacity1; i++)
                    {
                        int elem = rnd.Next(1, 50);
                        myQueue1.Add(elem);
                    }

                    for (int i = 0; i < capacity2; i++)
                    {
                        int elem = rnd.Next(2, 20);
                        myQueue2.Add(elem);
                    }

                    Console.Write("Первая очередь: ");
                    myQueue1.PrintQueue();
                    Console.Write("Вторая очередь: ");
                    myQueue2.PrintQueue();

                    Console.WriteLine("------------------------------------------------");

                    int min = myQueue2.Findmin();
                    Console.WriteLine("Минимальный элемент второй очереди: " + min);

                    Console.WriteLine("------------------------------------------------");

                    Console.Write("Стэк: ");
                    
                    Stack<int> stack = new Stack<int>(capacity1);

                    stack.AddStack(myQueue1, myQueue2, stack);
                    myQueue1.PrintStack(stack);

                    Console.WriteLine("----------------------------------------------------");

                    myQueue1.NullQueue();
                    myQueue2.NullQueue();

                    bool isEmpty = myQueue1.Empty();
                    Console.WriteLine("Очередь 1 пуста: " + isEmpty);
                    bool isEmpty2 = myQueue2.Empty();
                    Console.WriteLine("Очередь 2 пуста: " + isEmpty2);

                    Console.WriteLine("----------------------------------------------------");

                    Console.Write("Первая очередь: ");
                    myQueue1.PrintQueue();
                    Console.Write("Вторая очередь: ");
                    myQueue2.PrintQueue();
                    break;


                case 2:
                    Console.WriteLine("------------------------------------------------");
                    Queue2 queue1 = new Queue2();
                    Queue2 queue2 = new Queue2();

                    queue1.GenerateRandomQueue();
                    queue2.GenerateRandomQueue1();

                    Console.Write("Первая очередь: ");
                    queue1.PrintQueue();

                    Console.Write("Вторая очередь: ");
                    queue2.PrintQueue();

                    Console.WriteLine("----------------------------------------------");

                    Console.Write("Минимальный элемент второй очереди: ");
                    int minimum = queue2.Findmin();
                    Console.WriteLine(minimum);

                    Console.WriteLine("----------------------------------------------");

                    Console.Write("Стек: ");
                    Stack<int> stack2 = queue1.CreateStack(queue2);
                    queue1.PrintStack(stack2);

                    Console.WriteLine("----------------------------------------------");

                    queue1.GenerateRandomQueue();
                    queue2.GenerateRandomQueue1();

                    Console.Write("Первая очередь после добавления новых элементов: ");
                    queue1.PrintQueue();

                    Console.Write("Вторая очередь после добавления новых элементов: ");
                    queue2.PrintQueue();

                    Console.WriteLine("----------------------------------------------");
                    
                    queue1.NullQueue();
                    Console.Write("Очередь 1 пуста:");
                    queue1.PrintQueue();
                    queue2.NullQueue();
                    Console.Write("Очередь 2 пуста: ");
                    queue2.PrintQueue();

                    break;
            }
        }
    }

}
