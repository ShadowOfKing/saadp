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
            var array = JsonConvert.DeserializeObject<int[]>(str);
            int[] resArray = new int[array.Length];
            Array.Copy(array, resArray, array.Length);
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();
            Sort.Selection(ref resArray);
            swatch.Stop();
            var selectTime = swatch.ElapsedMilliseconds.ToString() + "ms";
            Console.WriteLine(String.Format("Selection: {0}", String.Join(",", resArray)));
            Console.WriteLine(String.Format("Selection time: {0}", selectTime));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
