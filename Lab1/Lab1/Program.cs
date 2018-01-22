using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Lab1
{
    class BinarySearchTree
    {
        private Node head;
        private class Node
        {
            public Node Left;
            public Node Right;
            private int val;
            public int Val
            {
                get
                {
                    return val;
                }
                set
                {
                    val = value;
                }
            }
            public Node(int val)
            {
                this.val = val;
            }
        }
            
        private void AddNextElem(Node n, ref List<int> ar)
        {
            if (n != null)
            {
                AddNextElem(n.Left, ref ar);
                ar.Add(n.Val);
                AddNextElem(n.Right, ref ar);
            }
        }
        public int[] GetElements()
        {
            List<int> ar = new List<int>();
            AddNextElem(head, ref ar);
            return ar.ToArray();
        }
        private void Insert(ref Node el, int val)
        {
            if (el == null)
            {
                el = new Node(val);
            } else
            {
                if (val < el.Val)
                {
                    Insert(ref el.Left, val);
                } else
                {
                    Insert(ref el.Right, val);
                }
            }
        }
        public void Insert(int val)
        {
            if (this.head == null)
            {
                this.head = new Node(val);
                return;
            }
            if (val < head.Val)
            {
                Insert(ref head.Left, val);
            } else
            {
                Insert(ref head.Right, val);
            }
        }
    }

    static class Sort
    {
        private static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        private static int GetMinrun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }
            return n + r;
        }   //FOR Timsort

        private static void Counting(ref int[] ar, int min, int max)
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
        private static void Merge(ref int[] ar, int left, int mid, int right)
        {
            var it1 = 0;
            var it2 = 0;
            var result = new int[right - left];

            while (left + it1 < mid && mid + it2 < right)
            {
                if (ar[left + it1] < ar[mid + it2])
                {
                    result[it1 + it2] = ar[left + it1];
                    it1++;
                }
                else
                {
                    result[it1 + it2] = ar[mid + it2];
                    it2++;
                }
            }
            while (left + it1 < mid)
            {
                result[it1 + it2] = ar[left + it1];
                it1++;
            }
            while (mid + it2 < right)
            {
                result[it1 + it2] = ar[mid + it2];
                it2++;
            }
            for (var i = 0; i <= it1 + it2 && i < result.Length; i++)
            {
                ar[left + i] = result[i];
            }
        }
        private static void Quick(ref int[] ar, int l, int r)
        {
            if (l < r)
            {
                var m = (l + r) / 2;
                if (ar[l] > ar[m])
                {
                    Swap(ref ar[l], ref ar[m]);
                }
                if (ar[m] > ar[r])
                {
                    Swap(ref ar[m], ref ar[r]);

                    if (ar[l] > ar[m])
                    {
                        Swap(ref ar[l], ref ar[m]);
                    }
                }
                if (r - l <= 3)
                {
                    return;
                }
                var v = ar[(l + r) / 2];
                var i = l + 1;
                var j = r - 1;
                while (i <= j)
                {
                    while (ar[i] <= v && i < r)
                    {
                        i++;
                    }
                    while (ar[j] >= v && j > l)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        Swap(ref ar[i++], ref ar[j--]);
                    }
                }
                Quick(ref ar, l, j);
                Quick(ref ar, j + 1, r);
            }
        }

        public static void Bubble(ref int[] ar)
        {
            int i = 0;
            bool end = false;
            do
            {
                end = true;
                for (var j = 0; j < ar.Length - 1; j++)
                {
                    if (ar[j] > ar[j + 1])
                    {
                        Swap(ref ar[j], ref ar[j + 1]);
                        end = false;
                    }
                }
                i++;
            } while (!end);
        }
        public static void Comb(ref int[] ar)
        {
            double fakt = 1.2473309; // фактор уменьшения
            double step = ar.Length - 1;

            while (step >= 1)
            {
                for (int i = 0; i + step < ar.Length; ++i)
                {
                    if (ar[i] > ar[i + (int)step])
                    {
                        Swap(ref ar[i], ref ar[i + (int)step]);
                    }
                }
                step /= fakt;
            }
            Bubble(ref ar);
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
            Counting(ref ar, min, max);
        }
        public static void Gnome(ref int[] ar)
        {
            var i = 1;
            var j = 2;
            while (i < ar.Length)
            {
                if (ar[i - 1] < ar[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(ref ar[i - 1], ref ar[i]);
                    i--;
                }
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
        public static void Insertion(ref int[] ar)
        {
            for (var i = 1; i < ar.Length; i++)
            {
                for (var j = i - 1; j >= 0 && ar[j] > ar[j + 1]; j--)
                {
                    Swap(ref ar[j], ref ar[j + 1]);
                }
            }
        }
        public static void Merge(ref int[] ar)
        {
            for (var i = 1; i <= ar.Length; i *= 2)
            {
                for (var j = 0; j < ar.Length; j += 2 * i)
                {
                    Merge(ref ar, j, Math.Min(j + i, ar.Length), Math.Min(j + 2 * i, ar.Length));
                }
            }
        }
        public static void Quick(ref int[] ar)
        {
            Quick(ref ar, 0, ar.Length - 1);
        }
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
        public static void Shaker(ref int[] ar)
        {
            var left = 0;
            var right = ar.Length - 1;
            var count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (ar[i] > ar[i + 1])
                    {
                        Swap(ref ar[i], ref ar[i + 1]);
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (ar[i - 1] > ar[i])
                        Swap(ref ar[i - 1], ref ar[i]);
                }
                left++;
            }
        }
        public static void Shells(ref int[] ar)
        {
            int t;
            for (var k = ar.Length / 2; k > 0; k /= 2)
            {
                for (var i = k; i < ar.Length; i++)
                {
                    t = ar[i];
                    var j = i;
                    for (; j >= k; j -= k)
                    {
                        if (t < ar[j - k])
                        {
                            ar[j] = ar[j - k];
                        }
                        else
                        {
                            break;
                        }
                    }
                    ar[j] = t;
                }
            }
        }
        public static void Tree(ref int[] ar)
        {
            var tree = new BinarySearchTree();
            for (var i = 0; i < ar.Length; i++)
            {
                tree.Insert(ar[i]);
            }
            ar = tree.GetElements();
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
            //AddToFile(String.Format("\t\t\"Result\": [{0}]", String.Join(",", ar)));
            AddToFile("\t},");
            Console.WriteLine("{0} OK!", name);
        }

        static void Main(string[] args)
        {
            var str = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json"));
            var arrayT = JsonConvert.DeserializeObject<int[]>(str);
            var array = new int[arrayT.Length * 10];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = arrayT[i % arrayT.Length];
            }
            //var array = JsonConvert.DeserializeObject<int[]>(str);
            if (File.Exists(outFilePath))
            {
                File.Delete(outFilePath);
            }
            File.Create(outFilePath).Close();
            AddToFile("{");
            ApplySort(array, Sort.Bubble, "Bubble");
            ApplySort(array, Sort.Shaker, "Shaker");
            ApplySort(array, Sort.Comb, "Comb");
            ApplySort(array, Sort.Selection, "Selection");
            ApplySort(array, Sort.Insertion, "Insertion");
            ApplySort(array, Sort.Gnome, "Gnome");
            ApplySort(array, Sort.Shells, "Shells");
            ApplySort(array, Sort.Counting, "Counting");
            ApplySort(array, Sort.Quick, "Quick");
            ApplySort(array, Sort.Merge, "Merge");
            ApplySort(array, Sort.Tree, "Tree");
            AddToFile("}");
        }
    }
}