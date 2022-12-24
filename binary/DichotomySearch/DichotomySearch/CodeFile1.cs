using System;
using System.Reflection;

    ////未整列の配列をマージソートで直し、3、6、9を探したい。
    //class SampleBinary
    //{
    //    static void Main(string[] ages)
    //    {
    //        int[] number = {1,2,6,5,8,9,7,4,3,10};
    //        Sort(number);

    //        for(var i = 0; i < number.Length; i++)
    //        {
    //            Console.WriteLine(number[i]);
    //        }


    //    }

    //    private static void Sort(int[] array)
    //    {
    //        MargeSort(array , new int[array.Length] , 0 , array.Length - 1);
    //    }

    //    private static void MargeSort(int[] array , int[] template , int left , int right)
    //    {
    //        if(left < right)
    //        {
    //            var center = (left + right) / 2;

    //            MargeSort(array , template , left , center);
    //            MargeSort(array, template, center + 1 , right);
    //            Marge(array , template , left , center + 1 ,right);
    //        }
    //    }

    //    private static void Marge(int[] array, int[] template , int left , int rigth , int rigthEnd)
    //    {
    //        var leftEnd = rigth - 1;
    //        var tempIndex = left;
    //        var elementNumber = rigthEnd - left + 1;


    //        while(left <= leftEnd && rigth <= rigthEnd)
    //        {
    //            if (array[left] <= array[rigth])
    //                template[tempIndex++] = array[left++];

    //            else
    //                template[tempIndex++] = array[rigth++];
    //        }

    //        while (left <= leftEnd)
    //        {
    //            template[tempIndex++] = array[left++];
    //        }

    //        while (rigth <= rigthEnd)
    //        {
    //            template[tempIndex++] = array[rigth++];
    //        }


    //        for(var i = 0; i < elementNumber; i++)
    //        {
    //            array[rigthEnd] = template[rigthEnd];
    //            rigthEnd--;
    //        }
    //    }

    //}

    internal class Program
    {
        static void main(string[] args)
        {
            int[] number = { 1, 5, 3, 6, 4, 7, 8, 9, 2 };
            Sort(number);

            for (var i = 0; i < number.Length; i++)
            {
                Console.WriteLine(number[i]);
            }
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
                //左側
                MergeSort(array, tmp, left, center);

                //右側（配列が奇数だからcenterに1を加算しとく）
                MergeSort(array, tmp, center + 1, right);

                //順序づけられた配列をマージするとこ
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

            //左に要素があるかどうか
            while (left <= leftEndIndex)
            {
                tmp[tmpIndex++] = array[left++];
            }

            //右に要素があるかどうか
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
    }