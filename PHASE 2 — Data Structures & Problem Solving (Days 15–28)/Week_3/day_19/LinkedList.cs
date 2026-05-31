using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day_19
{
    public class LinkedList
    {
        public Node? Head;
        public Node? Tail;
        public int Count;
        public void Add(int value)
        {
            Node newNode = new Node // the constructor call exisits but we are not using it, so we can use object initializer syntax
            {
                Value = value
            };

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail!.Next = newNode; // the ! is used to tell the compiler that Tail is not null, we can use it because we are sure that Tail is not null at this point
                newNode.Prev = Tail;
                Tail = newNode;
            }
            Count++;
        }
        public void Print()
        {
            Node? current = Head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public void PrintReverse()
        {
            Node? current = Tail;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Prev;
            }
            Console.WriteLine();
        }
        public void ShowHead()
        {
            if (Head != null)
            {
                Console.WriteLine("Head: " + Head.Value);
            }
            else
            {
                Console.WriteLine("Head: null");
            }
        }
        public void ShowTail()
        {
            if (Tail != null) {
                Console.WriteLine("Tail: " + Tail.Value);
            }
            else
            {
                Console.WriteLine("Tail: null");
            }
        }
        public void Remove(int value)
        {
            Node? current = Head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }
                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        Tail = current.Prev;
                    }
                    Console.WriteLine("Removed: " + value);
                    Count--;
                    return;
                }
                current = current.Next;
            }
        } 
        public void Contains(int value)
        {
            Node? current = Head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    Console.WriteLine("The list contains: " + value);
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine("The list does not contain: " + value);
        }
        public void CountNodes()
        {
            Console.WriteLine("Count: " + Count);
        }
    }
}