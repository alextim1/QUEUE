using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class QueueNode<T>
    {
      public T Data { get; }

        public QueueNode<T> Next { get; set; }

        public QueueNode (T data)
        {
            Data = data;
            Next = null;
        }

    }

    class QueueR<T>
    {
        QueueNode<T> _head;
        QueueNode<T> _tail;
        int _amount;

        public QueueR ()
        {
            _head = _tail = null;
            _amount = 0;
        }

        public void Enqueue(T data)
        {
            if (_head==null)
            {
                _head = _tail = new QueueNode<T>(data);
                _amount++;
            }
            else
            {
                _tail.Next = new QueueNode<T>(data);
                _tail = _tail.Next;
                _amount++;
            }
        }

        public T Dequeue()
        {
            if (_head==null)
            {
                throw new IndexOutOfRangeException("Queue is emphty");
            }
            else
            {
                T data = _head.Data;
                _head = _head.Next;
                
                _amount--;

                return data;
            }
        }

        public int Count() { return _amount; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            QueueR<int> currentQueue = new QueueR<int>();
            for (int i=0;i<10; i++)
            {
                currentQueue.Enqueue(i);
            }

            while (currentQueue.Count()>0)
            {
                Console.WriteLine(currentQueue.Dequeue());
            }

            Console.ReadKey();
            currentQueue.Dequeue();
        }
    }
}
