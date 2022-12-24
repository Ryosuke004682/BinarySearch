using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DichotomySearch
{
    internal class Program
    {
        //26と43を探す。
        //serch number "26,43"
        static void Main(string[] args)
        {
            int[] number = {1,8,10,13,15,19,26,28,33,39,43,47,50};
            var   lookingForNumber1 = 26;
            var position = Serch(number , lookingForNumber1);

            Console.WriteLine("Looking For Number" + lookingForNumber1 + " , This Number Position" + position);

            var lookingForNumber2 = 43;
            position = Serch(number , lookingForNumber2);
            Console.WriteLine("Looking For Number" + lookingForNumber2 + " , This Number Position" + position);

            while (true) ;

        }

        static int Serch(int[] array , int value)
        {
            var low = 0;
            var high = array.Length - 1;
            var midle = 0;

            while(low <= high)
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
