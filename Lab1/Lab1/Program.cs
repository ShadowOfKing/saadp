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
        public static void Radix(ref int[] ar, int min, int max)
        {
            int[] br = new int[ar.Length];
            Array.Copy(ar, br, ar.Length);
            int[] cr = new int[max - min + 1];
            for (var i = 0; i < cr.Length; i++)
                cr[i] = 0;
            for (var i = 0; i < ar.Length; i++)
                cr[ar[i] - min] += 1;
            for (var i = 1; i < cr.Length; i++)
                cr[i] += cr[i - 1];
            for (var i = ar.Length - 1; i >= 0; i--)
            {
                br[cr[ar[i] - min] - 1] = ar[i];
                cr[ar[i] - min] -= 1;
            }
            ar = br;
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
            Array.Copy(array, resArray, array.Length);
            var min = int.MaxValue;
            var max = int.MinValue;
            for (int i = 0; i < resArray.Length; i++)
            {
                if (resArray[i] > max)
                {
                    max = resArray[i];
                }
                if (resArray[i] < min)
                {
                    min = resArray[i];
                }
            }
            swatch = new System.Diagnostics.Stopwatch();
            Console.ReadKey();
            Sort.Radix(ref resArray, min, max);
            swatch.Stop();
            var radixTime = swatch.ElapsedMilliseconds.ToString() + "ms";
            Console.WriteLine(String.Format("Radix: {0}", String.Join(",", resArray)));
            Console.WriteLine(String.Format("Selection time: {0}", selectTime));
            Console.WriteLine(String.Format("Radix time: {0}", radixTime));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
