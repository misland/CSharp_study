using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 2, 3, 5, 6, 7, 8, 9, 11, 15, 16, 18, 19, 21 };
            //Console.WriteLine(search(arr, 0, arr.Length - 1, 18));
            //Console.WriteLine(search2(arr, 0, arr.Length - 1, 18));

            String a = new String("abc".ToArray());
            String b = new String("abc".ToArray());
            Console.WriteLine(a == b);

            Console.ReadKey();
        }

        static int search(int[] arr, int start, int end, int target)
        {
            if (start > end)
            {
                return -1;
            }
            int mid = (start + end) / 2;
            if (arr[mid] > target)
            {
                return search(arr, start, mid - 1, target);
            }
            else if (arr[mid] < target)
            {
                return search(arr, mid + 1, end, target);
            }
            else
            {
                return mid;
            }
        }

        static int search2(int[] arr, int start, int end, int target)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] > target)
                {
                    end = mid - 1;
                }
                else if (arr[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
