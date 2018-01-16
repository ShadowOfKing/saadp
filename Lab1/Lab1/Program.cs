using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Lab1
{
    static class Sort
    {
        public static void Selection(ref int[] ar)
        {
            int i, j, mx, nmx;
            int size = ar.Length;
            for (i = 0; i < size - 1; i++)
            {
                mx = ar[i];
                nmx = i;
                for (j = i + 1; j < size; j++)
                {
                    if (ar[j] < mx)
                    {
                        mx = ar[j];
                        nmx = j;
                    }
                }
                ar[nmx] = ar[i];
                ar[i] = mx;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var str = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json"));
            //var array = JsonConvert.DeserializeObject<int[]>(str);
            var array = new int[] { 1, 3, 9, 2, 7, 4, 5, 1, 0 };
            int[] resArray = new int[array.Length];
            Array.Copy(array, resArray, array.Length);
            Sort.Selection(ref resArray);
            Console.WriteLine(String.Format("Selection: {0}", String.Join(",", resArray)));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
