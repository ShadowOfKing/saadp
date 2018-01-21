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

        private static void CountingSort(ref int[] ar, int min, int max)
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
        public static void Counting(ref int[] ar)
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max)
                {
                    max = ar[i];
                }
                if (ar[i] < min)
                {
                    min = ar[i];
                }
            }
            CountingSort(ref ar, min, max);
        }
    }
    class Program
    {
        private delegate void SortF(ref int[] ar);
        private static string outFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.json");
        private static void AddToFile(string s)
        {
            StreamWriter writer = new StreamWriter(outFilePath, true);
            writer.WriteLine(s);
            writer.Close();
        }
        private static void ApplySort(int[] array, SortF sort, string name)
        {
            var ar = new int[array.Length];
            Array.Copy(array, ar, array.Length);
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();
            sort(ref ar);
            swatch.Stop();
            AddToFile(String.Format("\t\"{0}\":", name));
            AddToFile("\t{");
            AddToFile(String.Format("\t\t\"Time\": {0},", swatch.ElapsedMilliseconds));
            AddToFile(String.Format("\t\t\"Result\": [{0}]", String.Join(",", ar)));
            AddToFile("\t},");
            Console.WriteLine("{0} OK!", name);
        }

        static void Main(string[] args)
        {
            var str = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json"));
            var array = JsonConvert.DeserializeObject<int[]>(str);
            if (File.Exists(outFilePath))
            {
                File.Delete(outFilePath);
            }
            File.Create(outFilePath).Close();
            AddToFile("{");
            ApplySort(array, Sort.Selection, "Selection");
            ApplySort(array, Sort.Counting, "Counting");
            AddToFile("}");
        }
    }
}
