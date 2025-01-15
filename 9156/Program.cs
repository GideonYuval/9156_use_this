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
            RunTests();
        }

        static void RunTests()
        {
            // Test 1: General case with multiple maxima
            Test("Test 1: General case with multiple maxima",
                new int[] { 5, 7, 1, 2, 3, 6, 4 },
                "7, 6");

            // Test 2: No maxima (null returned)
            Test("Test 2: No maxima (null returned)",
                new int[] { 5, 7, 8 },
                "null");
        }

        static void Test(string testDescription, int[] input, string expected)
        {
            Node<int> head = Arr2List(input);
            Node<int> maxima = GetMaxima(head);

            string result = maxima == null ? "null" : ListToString(maxima);
            Console.WriteLine($"{testDescription}: {(result == expected ? "passed" : $"failed (expected: {expected}, got: {result})")}");
        }

        static string ListToString(Node<int> head)
        {
            if (head == null)
                return "";

            Node<int> current = head;
            string result = "";

            while (current != null)
            {
                result += current.GetValue();
                if (current.GetNext() != null)
                    result += ", ";

                current = current.GetNext();
            }

            return result;
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
