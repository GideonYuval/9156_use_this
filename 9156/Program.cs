using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9156
{
    internal class Program
    {
        //student code start


        //student code end
        static void Main(string[] args)
        {
            // Test 1: List with multiple maxima
            RunTest(
                testNumber: 1,
                input: new int[] { 5, 7, 1, 2, 3, 6, 4 },
                expected: new int[] { 7, 6 });

            // Test 2: Strictly increasing list (no maxima)
            RunTest(
                testNumber: 2,
                input: new int[] { 5, 7, 8 },
                expected: null);

            // Test 3: Strictly decreasing list (no maxima)
            RunTest(
                testNumber: 3,
                input: new int[] { 9, 7, 5, 3, 1 },
                expected: null);

            // Test 4: List with one maximum
            RunTest(
                testNumber: 4,
                input: new int[] { 3, 6, 1 },
                expected: new int[] { 6 });

            // Test 5: Alternating peaks and valleys
            RunTest(
                testNumber: 5,
                input: new int[] { 1, 3, 2, 4, 1, 5 },
                expected: new int[] { 3, 4 });

            // Test 6: List with negative numbers
            RunTest(
                testNumber: 6,
                input: new int[] { -5, -3, -4, -1, -2 },
                expected: new int[] { -3, -1 });

            // Test 7: Minimum valid size (3 elements)
            RunTest(
                testNumber: 7,
                input: new int[] { 1, 3, 2 },
                expected: new int[] { 3 });
        }

        static void RunTest(int testNumber, int[] input, int[] expected)
        {
            Node<int> n = Arr2List(input);
            Node<int> result = GetMaxima(n);

            int[] resultArray = ListToArray(result);

            if (AreArraysEqual(resultArray, expected))
            {
                Console.WriteLine($"Test {testNumber}: PASS");
            }
            else
            {
                string resultStr = resultArray == null ? "null" : string.Join(",", resultArray);
                string expectedStr = expected == null ? "null" : string.Join(",", expected);
                Console.WriteLine($"Test {testNumber}: FAIL (Returned: {resultStr}, Expected: {expectedStr})");
            }
        }

        static bool AreArraysEqual(int[] arr1, int[] arr2)
        {
            if (arr1 == null && arr2 == null) return true;
            if (arr1 == null || arr2 == null) return false;
            if (arr1.Length != arr2.Length) return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        static int[] ListToArray(Node<int> head)
        {
            if (head == null) return null;

            var list = new System.Collections.Generic.List<int>();
            while (head != null)
            {
                list.Add(head.GetValue());
                head = head.GetNext();
            }

            return list.ToArray();
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
