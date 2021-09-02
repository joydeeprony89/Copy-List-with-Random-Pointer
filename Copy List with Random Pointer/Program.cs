using System;

namespace Copy_List_with_Random_Pointer
{
    class Program
    {
        static void Print(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }

        // Definition for a Node.
        // val
        // next
        // random
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }


        static void Main(string[] args)
        {

            Node start = new Node(1);
            start.next = new Node(2);
            start.next.next = new Node(3);
            start.next.next.next = new Node(4);
            start.next.next.next.next = new Node(5);

            // 1's random points to 3  
            start.random = start.next.next;

            // 2's random points to 1  
            start.next.random = start;

            // 3's and 4's random points to 5  
            start.next.next.random = start.next.next.next.next;
            start.next.next.next.random = start.next.next.next.next;

            // 5's random points to 2  
            start.next.next.next.next.random = start.next;

            Console.WriteLine("Original list : ");
            Print(start);

            Console.WriteLine("Cloned list : ");
            Node cloned_list = CopyRandomList(start);
            Print(cloned_list);
        }

        static Node CopyRandomList(Node head)
        {
            // 1. copy values.
            Node temp = head;
            while (temp != null)
            {
                Node next = temp.next;
                temp.next = new Node(temp.val);
                temp.next.next = next;
                temp = next;
            }

            // 2. Copy Random pointers
            temp = head;
            while (temp != null)
            {
                temp.next.random = temp.random.next;
                temp = temp.next.next;
            }

            // 3. Copy next pointers
            temp = head;
            Node copy = temp?.next;
            Node clone = copy;
            while (temp != null && copy != null)
            {
                temp.next = copy.next;
                copy.next = temp.next?.next;
                temp = temp.next;
                copy = copy.next;
            }
            return clone;
        }
    }
}
