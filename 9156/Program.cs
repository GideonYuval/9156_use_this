using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9156
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> n = Arr2List(new int[] { 5, 7, 1, 2, 3, 6, 4 });
            Console.WriteLine(GetMaxima(n)); //7,6

            n = Arr2List(new int[] { 5, 7, 8 });
            Console.WriteLine(GetMaxima(n));
        }

        static Node<int> Arr2List(int[] arr)
        {
            Node<int> lst = new Node<int>(arr[0]);
            Node<int> last = lst;

            for (int i = 1; i < arr.Length; i++)
            {
                last.SetNext(new Node<int>(arr[i]));
                last = last.GetNext();
            }

            return lst;
        }

        public static Node<int> GetMaxima(Node<int> head)
        {
            Node<int> dummy = new Node<int>(0); // Dummy head for the maxima list
            Node<int> last = dummy;

            // we need 3 pointers: previous, current, next:
            Node<int> prev = head;
            Node<int> current = head.GetNext();
            Node<int> next = current.GetNext();

            while (next != null)
            {
                // Check if the current node is a maximum
                if (current.GetValue() > prev.GetValue() && current.GetValue() > next.GetValue())
                {
                    // Create new node for the maximum value
                    Node<int> newNode = new Node<int>(current.GetValue());

                    // Add the new node to the maxima list
                    last.SetNext(newNode);
                    last = newNode;
                }

                // Move the pointers forward
                prev = current;
                current = next;
                next = next.GetNext();
            }

            return dummy.GetNext(); 
        }


    }
}
