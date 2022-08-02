using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTrainingDemo
{
    public delegate bool AnyArgType_ReturnBoolCommandClass<TSource>(TSource item, TSource searchWithChar);

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Royal", "Siemens", "Cerner" };

            //Select name from  names where name ends with "s";
            AnyArgType_ReturnBoolCommandClass<string> _functionCommandObj = new AnyArgType_ReturnBoolCommandClass<string>(Program.Endswith_Any_Predicate);
            IEnumerable<string> resultList = Search<string>(names, _functionCommandObj, "s");
            //display
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }
            _functionCommandObj = new AnyArgType_ReturnBoolCommandClass<string>(Program.Starswith_P_Predicate);
            resultList = Search<string>(names, _functionCommandObj, "C");
            //display

            Console.WriteLine();
            Console.WriteLine();
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }

            int[] numbers = { 1, 2, 3, 4, 5, 8 };
            AnyArgType_ReturnBoolCommandClass<int> _intArgBoolReturnCommandObj = new AnyArgType_ReturnBoolCommandClass<int>(Program.IsEven);
            IEnumerable<int> intResultList = Search<int>(numbers, _intArgBoolReturnCommandObj,0);

            Console.WriteLine();
            Console.WriteLine();
            foreach (int item in intResultList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }

        static bool IsEven(int item, int  a )
        {
            return item % 2 == 0;
        }
        static bool Endswith_Any_Predicate(string item, string searchWithChar)
        {
            return item.EndsWith(searchWithChar);
        }
        //static bool Endswith_r_Predicate(string item)
        //{
        //    return item.EndsWith("r");
        //}
        static bool Starswith_P_Predicate(string item, string searchWithChar)
        {
            return item.StartsWith(searchWithChar);
        }
        //static bool Starswith_S_Predicate(string item)
        //{
        //    return item.StartsWith("S");
        //}

        static IEnumerable<Tsource> Search<Tsource>(IEnumerable<Tsource> source, AnyArgType_ReturnBoolCommandClass<Tsource> predicate, Tsource SWC)
        {
            List<Tsource> resultList = new List<Tsource>();
            //Select name from  names where name ends with "s";

            //IEnumerator<Tsource> iterator= source.GetEnumerator();
            // try
            // {
            //     while (iterator.MoveNext())
            //     {
            //         Tsource currentItem=iterator.Current;
            //         if (predicate(currentItem))
            //         {
            //             resultList.Add(currentItem);
            //         }
            //     }
            // }
            // finally
            // {
            //     if(iterator is IDisposable)
            //     {
            //         iterator.Dispose();
            //     }
            // }

            foreach (Tsource item in source)
            {
                if (predicate.Invoke(item, SWC))
                {
                    resultList.Add(item);

                }
            }
            return resultList;

        }
    }
}
