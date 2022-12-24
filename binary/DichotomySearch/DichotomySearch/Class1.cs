using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    //マージソートで、未整列の配列を整列して、3、6，9を探したい。

    internal class Class
    {
        static void Main(string[] args)
        {
            int[] number = { 1, 5, 3, 6, 4, 7, 8, 9, 2 };
            var lookNumber1 = 3;
            var lookNumber2 = 6;
            var lookNumber3 = 9;

            Sort(number);

            for (var i = 0; i < number.Length; i++)
            {
                Console.WriteLine(number[i]);
            }

            var position = SerchNumber(number, lookNumber1);
            Console.WriteLine("Looking For Number" + lookNumber1 + " , This Number Position" + position);

            position = SerchNumber(number, lookNumber2);
            Console.WriteLine("Looking For Number" + lookNumber2 + " , This Number Position" + position);

            position = SerchNumber(number, lookNumber3);
            Console.WriteLine("Looking For Number" + lookNumber3 + " , This Number Position" + position);

            while (true);
        }

        private static void Sort(int[] array)
        {
            MergeSort(array, new int[array.Length], 0, array.Length - 1);
        }

        private static void MergeSort(int[] array, int[] tmp, int left, int right)
        {
            if (left < right)
            {
                var center = (left + right) / 2;
            
                MergeSort(array, tmp, left, center);
            
                MergeSort(array, tmp, center + 1, right);

                Merge(array, tmp, left, center + 1, right);

            }
        }

        private static void Merge(int[] array, int[] tmp, int left, int right, int rightEndIndex)
        {
            var leftEndIndex = right - 1;
            var tmpIndex = left;
            var elementsNumber = rightEndIndex - left + 1;

            while (left <= leftEndIndex && right <= rightEndIndex)
            {
                if (array[left] <= array[right])
                    tmp[tmpIndex++] = array[left++];
                else
                    tmp[tmpIndex++] = array[right++];
            }

            while (left <= leftEndIndex)
            {
                tmp[tmpIndex++] = array[left++];
            }

            while (right <= rightEndIndex)
            {
                tmp[tmpIndex++] = array[right++];
            }

            for (var i = 0; i < elementsNumber; i++)
            {
                array[rightEndIndex] = tmp[rightEndIndex];
                rightEndIndex--;
            }
        }

          static int SerchNumber(int[] array , int value)
          {
            var low = 0;
            var high = array.Length - 1;
            var midle = 0;

            while (low <= high)
            {
                midle = (low + high) / 2;

                if (array[midle] == value)
                {
                    return midle;
                }
                else if (array[midle] < value)
                {
                    low = midle + 1;
                }
                else if (array[midle] > value)
                {
                    high = midle - 1;
                }
            }
            return -1;
        }

    }
}
