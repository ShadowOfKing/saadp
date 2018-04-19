using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace Lab1
{
    public interface ICloneable<T>
    {
        T Clone();
    }
    public interface Values
    {
        int GetIntValue();
        double GetDoubleValue();
    }

    public interface Initiatiable<T>
    {
        T Init();
    }

    public class WeatherData : IComparable<WeatherData>, ICloneable<WeatherData>, Values, Initiatiable<WeatherData>
    {
        public string Time;
        public int T;
        public int? P0;
        public int? P;
        public int? Pa;
        public int? U;
        public string DD;
        public int? Ff;
        public string N;
        public string WW;
        public string W1;
        public string W2;
        public string Tn;
        public string Tx;
        public string Cl;
        public string Nh;
        public string H;
        public string Cm;
        public string Ch;
        public int? VV;
        public int? Td;
        public int? RRR;
        public int? tR;

        private WeatherData() { }
        public WeatherData(string Time, int T, int? P0, int? P, int? Pa, int? U, string DD, int? Ff, string N, string WW, string W1, string W2, string Tn, string Tx, string Cl, string Nh, string H, string Cm, string Ch, int? VV, int? Td, int? RRR, int? tR)
        {
            this.Time = Time;
            this.T = T;
            this.P0 = P0;
            this.P = P;
            this.Pa = Pa;
            this.U = U;
            this.DD = DD;
            this.Ff = Ff;
            this.N = N;
            this.WW = WW;
            this.W1 = W1;
            this.W2 = W2;
            this.Tn = Tn;
            this.Tx = Tx;
            this.Cl = Cl;
            this.Nh = Nh;
            this.H = H;
            this.Cm = Cm;
            this.Ch = Ch;
            this.VV = VV;
            this.Td = Td;
            this.RRR = RRR;
            this.tR = tR;
        }

        public int CompareTo(WeatherData wd)
        {
            if (T < wd.T) return -1;
            if (T > wd.T) return 1;
            return 0;
        }
        public WeatherData Clone()
        {
            return new WeatherData(Time, T, P0, P, Pa, U, DD, Ff, N, WW, W1, W2, Tn, Tx, Cl, Nh, H, Cm, Ch, VV, Td, RRR, tR);
        }
        public int GetValue()
        {
            return T;
        }
        public int GetIntValue()
        {
            return T;
        }
        public double GetDoubleValue()
        {
            return (double)T;
        }
        public WeatherData Init()
        {
            return new WeatherData();
        }

        public override string ToString()
        {
            return String.Format("{" +
                    "Time: {0}, T: {1}, P0: {2}, P: {3}, Pa: {4}, U: {5}, DD: {6}, Ff: {7}, N: {8}," +
                    " WW: {9}, W1: {10}, W2: {11}, Tn: {12}, Tx: {13}, Cl: {14}, Nh: {15}, H: {16}, Cm: {17}," +
                    " Ch: {18}, W2: {19}, Td: {20}, RRR: {21}, tR: {22}: {23}" +
                "}",
                Time, T, P0, P, Pa, U, DD, Ff, N, WW, W1, W2, Tn, Tx, Cl, Nh, H, Cm, Ch, W2, Td, RRR, tR
            );
        }
    }

    public class BinarySearchTree<T> where T : IComparable<T>, ICloneable<T>
    {
        private Node head;
        private class Node
        {
            public Node Left;
            public Node Right;
            private T val;
            public T Val
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
            public Node(T val)
            {
                this.val = val.Clone();
            }
        }

        private void AddNextElem(Node n, ref List<T> ar)
        {
            if (n != null)
            {
                AddNextElem(n.Left, ref ar);
                ar.Add(n.Val);
                AddNextElem(n.Right, ref ar);
            }
        }
        public List<T> GetElements()
        {
            List<T> ar = new List<T>();
            AddNextElem(head, ref ar);
            return ar;
        }
        private void Insert(ref Node el, T val)
        {
            if (el == null)
            {
                el = new Node(val);
            }
            else
            {
                if (val.CompareTo(el.Val) == -1)
                {
                    Insert(ref el.Left, val);
                }
                else
                {
                    Insert(ref el.Right, val);
                }
            }
        }
        public void Insert(T val)
        {
            if (this.head == null)
            {
                this.head = new Node(val);
                return;
            }
            if (val.CompareTo(head.Val) == -1)
            {
                Insert(ref head.Left, val);
            }
            else
            {
                Insert(ref head.Right, val);
            }
        }
    }

    public static class Sort<T> where T : IComparable<T>, ICloneable<T>, Values
    {
        private static long time;
        private static long iterations;
        private static long swaps;
        private static long assigments;

        public static long Time
        {
            get
            {
                return time;
            }
        }
        public static long Iterations
        {
            get
            {
                return iterations;
            }
        }
        public static long Swaps
        {
            get
            {
                return swaps;
            }
        }
        public static long Assigments
        {
            get
            {
                return assigments;
            }
        }

        private delegate void SortFunc(ref List<T> data);

        private static void Swap(ref List<T> list, int i, int j)
        {
            T t = list[i];
            list[i] = list[j];
            list[j] = t;
            swaps++;
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

        private static void Counting(ref List<T> data, T min, T max)
        {
            var br = new List<T>(data);
            int[] cr = new int[max.GetIntValue() - min.GetIntValue() + 1];
            for (var i = 0; i < cr.Length; i++)
            {
                cr[i] = 0;
                iterations++;
            }
            for (var i = 0; i < data.Count; i++)
            {
                cr[data[i].GetIntValue() - min.GetIntValue()] += 1;
                iterations++;
            }
            for (var i = 1; i < cr.Length; i++)
            {
                cr[i] += cr[i - 1];
                iterations++;
            }
            for (var i = data.Count - 1; i >= 0; i--)
            {
                br[cr[data[i].GetIntValue() - min.GetIntValue()] - 1] = data[i];
                cr[data[i].GetIntValue() - min.GetIntValue()] -= 1;
                iterations++;
                assigments++;
            }
            data = br;
        }
        private static void Merge(ref List<T> data, int left, int mid, int right)
        {
            var it1 = 0;
            var it2 = 0;
            var result = new List<T>(right - left);
            for (var i = 0; i < right - left; i++)
            {
                result.Add(data[0]);
                iterations++;
                assigments++;
            }

            while (left + it1 < mid && mid + it2 < right)
            {
                iterations++;
                if (data[left + it1].CompareTo(data[mid + it2]) == -1)
                {
                    result[it1 + it2] = data[left + it1];
                    it1++;
                    assigments++;
                }
                else
                {
                    result[it1 + it2] = data[mid + it2];
                    it2++;
                    assigments++;
                }
            }
            while (left + it1 < mid)
            {
                result[it1 + it2] = data[left + it1];
                it1++;
                assigments++;
                iterations++;
            }
            while (mid + it2 < right)
            {
                result[it1 + it2] = data[mid + it2];
                it2++;
                assigments++;
                iterations++;
            }
            for (var i = 0; i <= it1 + it2 && i < result.Count; i++)
            {
                data[left + i] = result[i];
                assigments++;
                iterations++;
            }
        }
        private static void Quick(ref List<T> data, int l, int r)
        {
            iterations++;
            if (l < r)
            {
                var m = (l + r) / 2;
                if (data[l].CompareTo(data[m]) == 1)
                {
                    Swap(ref data, l, m);
                }
                if (data[m].CompareTo(data[r]) == 1)
                {
                    Swap(ref data, m, r);

                    if (data[l].CompareTo(data[m]) == 1)
                    {
                        Swap(ref data, l, m);
                    }
                }
                if (r - l < 3)
                {
                    return;
                }
                var v = data[(l + r) / 2].Clone();
                assigments++;
                var i = l + 1;
                var j = r - 1;
                while (i <= j)
                {
                    iterations++;
                    while (data[i].CompareTo(v) == -1 && i < r)
                    {
                        i++;
                        iterations++;
                    }
                    while (data[j].CompareTo(v) > -1 && j > l)
                    {
                        j--;
                        iterations++;
                    }
                    if (i <= j)
                    {
                        Swap(ref data, i++, j--);
                    }
                }
                Quick(ref data, l, j);
                Quick(ref data, j + 1, r);
            }
        }

        private static void ApplyBubble(ref List<T> data)
        {
            int i = 0;
            bool end = false;
            do
            {
                end = true;
                for (var j = 0; j < data.Count - 1; j++)
                {
                    iterations++;
                    if (data[j].CompareTo(data[j + 1]) == 1)
                    {
                        Swap(ref data, j, j + 1);
                        end = false;
                    }
                }
                i++;
            } while (!end);
        }

        private static void ApplyComb(ref List<T> data)
        {
            double fakt = 1.2473309; // фактор уменьшения
            double step = data.Count - 1;

            while (step >= 1)
            {
                for (int i = 0; i + step < data.Count; ++i)
                {
                    iterations++;
                    if (data[i].CompareTo(data[i + (int)step]) == 1)
                    {
                        Swap(ref data, i, i + (int)step);
                    }
                }
                step /= fakt;
            }
            ApplyBubble(ref data);
        }
        private static void ApplyCounting(ref List<T> data)
        {
            var minIndex = data.Count - 1;
            var maxIndex = 0;
            for (int i = 0; i < data.Count; i++)
            {
                iterations++;
                if (data[i].CompareTo(data[maxIndex]) == 1)
                {
                    maxIndex = i;
                }
                if (data[i].CompareTo(data[minIndex]) == -1)
                {
                    minIndex = i;
                }
            }
            Counting(ref data, data[minIndex].Clone(), data[maxIndex].Clone());
        }
        private static void ApplyGnome(ref List<T> data)
        {
            var i = 1;
            var j = 2;
            while (i < data.Count)
            {
                iterations++;
                if (data[i - 1].CompareTo(data[i]) == -1)
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(ref data, i - 1, i);
                    i--;
                }
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
        private static void ApplyInsertion(ref List<T> data)
        {
            for (var i = 1; i < data.Count; i++)
            {
                iterations++;
                for (var j = i - 1; j >= 0 && data[j].CompareTo(data[j + 1]) == 1; j--)
                {
                    iterations++;
                    Swap(ref data, j, j + 1);
                }
                if (data[i - 1].CompareTo(data[i]) == 1)
                {
                    iterations--;
                }
            }
        }
        private static void ApplyMerge(ref List<T> data)
        {
            for (var i = 1; i <= data.Count; i *= 2)
            {
                for (var j = 0; j < data.Count; j += 2 * i)
                {
                    iterations++;
                    Merge(ref data, j, Math.Min(j + i, data.Count), Math.Min(j + 2 * i, data.Count));
                }
            }
        }
        private static void ApplyQuick(ref List<T> data)
        {
            Quick(ref data, 0, data.Count - 1);
        }

        private static void ApplySelection(ref List<T> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Count; j++)
                {
                    iterations++;
                    if (data[j].CompareTo(data[min]) == -1)
                    {
                        min = j;
                    }
                }
                Swap(ref data, min, i);
            }
        }
        private static void ApplyShaker(ref List<T> data)
        {
            var left = 0;
            var right = data.Count - 1;
            var count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    iterations++;
                    count++;
                    if (data[i].CompareTo(data[i + 1]) == 1)
                    {
                        Swap(ref data, i, i + 1);
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    iterations++;
                    count++;
                    if (data[i - 1].CompareTo(data[i]) == 1)
                        Swap(ref data, i - 1, i);
                }
                left++;
            }
        }
        private static void ApplyShells(ref List<T> data)
        {
            T t;
            for (var k = data.Count / 2; k > 0; k /= 2)
            {
                for (var i = k; i < data.Count; i++)
                {
                    t = data[i];
                    assigments++;
                    var j = i;
                    for (; j >= k; j -= k)
                    {
                        iterations++;
                        if (t.CompareTo(data[j - k]) == -1)
                        {
                            data[j] = data[j - k];
                            assigments++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    data[j] = t;
                    assigments++;
                }
            }
        }
        private static void ApplyTree(ref List<T> data)
        {
            var tree = new BinarySearchTree<T>();
            for (var i = 0; i < data.Count(); i++)
            {
                iterations++;
                tree.Insert(data[i]);
                assigments++;
            }
            data = tree.GetElements();
        }

        private static void ApplySort(SortFunc sort, ref List<T> data)
        {
            time = 0;
            iterations = 0;
            swaps = 0;
            assigments = 0;
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();
            sort(ref data);
            swatch.Stop();
            time = swatch.ElapsedMilliseconds;
        }

        public static void Bubble(ref List<T> data)
        {
            ApplySort(ApplyBubble, ref data);
        }

        public static void Comb(ref List<T> data)
        {
            ApplySort(ApplyComb, ref data);
        }
        public static void Counting(ref List<T> data)
        {
            ApplySort(ApplyCounting, ref data);
        }
        public static void Gnome(ref List<T> data)
        {
            ApplySort(ApplyGnome, ref data);
        }
        public static void Insertion(ref List<T> data)
        {
            ApplySort(ApplyInsertion, ref data);
        }
        public static void Merge(ref List<T> data)
        {
            ApplySort(ApplyMerge, ref data);
        }
        public static void Quick(ref List<T> data)
        {
            ApplySort(ApplyQuick, ref data);
        }
        public static void Selection(ref List<T> data)
        {
            ApplySort(ApplySelection, ref data);
        }
        public static void Shaker(ref List<T> data)
        {
            ApplySort(ApplyShaker, ref data);
        }
        public static void Shells(ref List<T> data)
        {
            ApplySort(ApplyShells, ref data);
        }
        public static void Tree(ref List<T> data)
        {
            ApplySort(ApplyTree, ref data);
        }

    }

    public static class OutSort
    {
        private static long time;
        private static int count;
        public static long Time
        {
            get
            {
                return time;
            }
        }
        public static long Count
        {
            get
            {
                return count;
            }
        }

        private delegate void SortFunc(string filename, bool isSimple);
        private static void ApplySort(SortFunc sort, string filename, bool isSimple)
        {
            time = 0;
            count = 0;
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
            swatch.Start();
            sort(filename, isSimple);
            swatch.Stop();
            time = swatch.ElapsedMilliseconds;
        }

        private static void WriteItem(StreamWriter writer, object item, bool isSimple)
        {
            if (isSimple)
            {
                writer.Write(item.ToString());
                writer.Write(' ');
            }
            else
            {
                writer.WriteLine(JsonConvert.SerializeObject((WeatherData)item));
            }
        }
        private static object ReadItem(StreamReader reader, bool isSimple)
        {
            if (reader.EndOfStream)
            {
                return null;
            }
            try {
                if (isSimple)
                {
                    StringBuilder str = new StringBuilder();
                    Char c = ' ';
                    do
                    {
                        c = (Char)reader.Read();
                        str.Append(c);
                    } while (!reader.EndOfStream && c != ' ' && c != '\n' && c != '\t');
                    return double.Parse(str.ToString());
                }
                else
                {
                    return JsonConvert.DeserializeObject<WeatherData>(reader.ReadLine());
                }
            } catch (Exception ex)
            {
                throw new Exception("Невозможно считать элемент из файла. Проверьте корректность входных данных.");
            }
        }
        private static int CompareItem(object item1, object item2, bool isSimple)
        {
            if (isSimple)
            {
                double a = (double)item1;
                double b = (double)item2;
                return (a == b) ? 0 : (a > b) ? 1 : -1;
            }
            else
            {
                return ((WeatherData)item1).CompareTo((WeatherData)item2);
            }
        }

        private static void SimpleSort(string file0, string file1, string file2, bool isSimple)
        {
            SimpleSort(file0, file1, file2, 1, isSimple);
        }

        private static void SimpleSort(string file0, string file1, string file2, int seriesLength, bool isSimple)
        {
            if (seriesLength >= count && count != 0 && seriesLength != 1)
            {
                return;
            }
            using (StreamReader reader = new StreamReader(file0))
            {
                using (StreamWriter writer1 = new StreamWriter(file1))
                {
                    using (StreamWriter writer2 = new StreamWriter(file2))
                    {
                        int length = 0;
                        while (!reader.EndOfStream)
                        {
                            length++;
                            for (var i = 0; i < seriesLength && !reader.EndOfStream; i++) { 
                                var item = ReadItem(reader, isSimple);
                                if (length % 2 == 0)
                                {
                                    WriteItem(writer1, item, isSimple);
                                }
                                else
                                {
                                    WriteItem(writer2, item, isSimple);
                                }
                            }
                        }
                        if (count == 0)
                        {
                            count = length;
                        }
                    }
                }
            }
            var inp = File.Create(file0);
            inp.Close();
            using (StreamWriter writer = new StreamWriter(file0))
            {
                using (StreamReader reader1 = new StreamReader(file1))
                {
                    using (StreamReader reader2 = new StreamReader(file2))
                    {
                        while (!reader1.EndOfStream && !reader2.EndOfStream)
                        {
                            var read1Count = 0;
                            var read2Count = 0;
                            object prevItem1 = null;
                            object prevItem2 = null;
                            while (read1Count < seriesLength && read2Count < seriesLength && !reader1.EndOfStream && !reader2.EndOfStream) { 
                                if (prevItem1 == null)
                                {
                                    prevItem1 = ReadItem(reader1, isSimple);
                                    read1Count++;
                                }
                                if (prevItem2 == null)
                                {
                                    prevItem2 = ReadItem(reader2, isSimple);
                                    read2Count++;
                                }
                                if (CompareItem(prevItem1, prevItem2, isSimple) == -1)
                                {
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                }
                                else
                                {
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                }
                            }
                            if (prevItem1 != null)
                            {
                                while (read2Count < seriesLength && !reader2.EndOfStream)
                                {
                                    prevItem2 = ReadItem(reader2, isSimple);
                                    if (prevItem1 != null && CompareItem(prevItem1, prevItem2, isSimple) == -1)
                                    {
                                        WriteItem(writer, prevItem1, isSimple);
                                        prevItem1 = null;
                                    }
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                    read2Count++;
                                }
                                if (prevItem1 != null) {
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                }
                            } else if (prevItem2 != null)
                            {
                                while (read1Count < seriesLength && !reader1.EndOfStream)
                                {
                                    prevItem1 = ReadItem(reader1, isSimple);
                                    if (prevItem2 != null && CompareItem(prevItem1, prevItem2, isSimple) == 1)
                                    {
                                        WriteItem(writer, prevItem2, isSimple);
                                        prevItem2 = null;
                                    }
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                    read1Count++;
                                }
                                if (prevItem2 != null)
                                {
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                }
                            }
                            while (!reader1.EndOfStream && read1Count < seriesLength)
                            {
                                prevItem1 = ReadItem(reader1, isSimple);
                                WriteItem(writer, prevItem1, isSimple);
                                read1Count++;
                            }
                            while (!reader2.EndOfStream && read2Count < seriesLength)
                            {
                                prevItem2 = ReadItem(reader2, isSimple);
                                WriteItem(writer, prevItem2, isSimple);
                                read2Count++;
                            }

                        }
                        while (!reader1.EndOfStream)
                        {
                            WriteItem(writer, ReadItem(reader1, isSimple), isSimple);
                        }
                        while (!reader2.EndOfStream)
                        {
                            WriteItem(writer, ReadItem(reader2, isSimple), isSimple);
                        }
                    }
                }
            }
            SimpleSort(file0, file1, file2, seriesLength * 2, isSimple);

        }
        private static void NatureSort(string file0, string file1, string file2, bool isSimple)
        {
            bool sorted = true;
            using (StreamReader reader = new StreamReader(file0))
            {
                var item1 = ReadItem(reader, isSimple);
                using (StreamWriter writer1 = new StreamWriter(file1))
                {
                    using (StreamWriter writer2 = new StreamWriter(file2))
                    {
                        while (!reader.EndOfStream)
                        {
                            var item2 = ReadItem(reader, isSimple);
                            if (CompareItem(item1, item2, isSimple) == -1)
                            {
                                WriteItem(writer1, item1, isSimple);
                            }
                            else
                            {
                                WriteItem(writer2, item1, isSimple);
                            }
                            item1 = item2;
                        }
                        if (item1 != null)
                        {
                            WriteItem(writer1, item1, isSimple);
                        }
                    }
                }
            }
            var inp = File.Create(file0);
            inp.Close();
            using (StreamWriter writer = new StreamWriter(file0))
            {
                using (StreamReader reader1 = new StreamReader(file1))
                {
                    using (StreamReader reader2 = new StreamReader(file2))
                    {
                        while (!reader1.EndOfStream && !reader2.EndOfStream)
                        {
                            object prevItem1 = null;
                            object prevItem2 = null;
                            while (read1Count < seriesLength && read2Count < seriesLength && !reader1.EndOfStream && !reader2.EndOfStream)
                            {
                                if (prevItem1 == null)
                                {
                                    prevItem1 = ReadItem(reader1, isSimple);
                                }
                                if (prevItem2 == null)
                                {
                                    prevItem2 = ReadItem(reader2, isSimple);
                                }
                                if (CompareItem(prevItem1, prevItem2, isSimple) == -1)
                                {
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                }
                                else
                                {
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                }
                            }
                            if (prevItem1 != null)
                            {
                                while (read2Count < seriesLength && !reader2.EndOfStream)
                                {
                                    prevItem2 = ReadItem(reader2, isSimple);
                                    if (prevItem1 != null && CompareItem(prevItem1, prevItem2, isSimple) == -1)
                                    {
                                        WriteItem(writer, prevItem1, isSimple);
                                        prevItem1 = null;
                                    }
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                    read2Count++;
                                }
                                if (prevItem1 != null)
                                {
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                }
                            }
                            else if (prevItem2 != null)
                            {
                                while (read1Count < seriesLength && !reader1.EndOfStream)
                                {
                                    prevItem1 = ReadItem(reader1, isSimple);
                                    if (prevItem2 != null && CompareItem(prevItem1, prevItem2, isSimple) == 1)
                                    {
                                        WriteItem(writer, prevItem2, isSimple);
                                        prevItem2 = null;
                                    }
                                    WriteItem(writer, prevItem1, isSimple);
                                    prevItem1 = null;
                                    read1Count++;
                                }
                                if (prevItem2 != null)
                                {
                                    WriteItem(writer, prevItem2, isSimple);
                                    prevItem2 = null;
                                }
                            }
                            while (!reader1.EndOfStream && read1Count < seriesLength)
                            {
                                prevItem1 = ReadItem(reader1, isSimple);
                                WriteItem(writer, prevItem1, isSimple);
                                read1Count++;
                            }
                            while (!reader2.EndOfStream && read2Count < seriesLength)
                            {
                                prevItem2 = ReadItem(reader2, isSimple);
                                WriteItem(writer, prevItem2, isSimple);
                                read2Count++;
                            }

                        }
                        while (!reader1.EndOfStream)
                        {
                            WriteItem(writer, ReadItem(reader1, isSimple), isSimple);
                        }
                        while (!reader2.EndOfStream)
                        {
                            WriteItem(writer, ReadItem(reader2, isSimple), isSimple);
                        }
                    }
                }
            }
            SimpleSort(file0, file1, file2, seriesLength * 2, isSimple);

        }
        private static void ApplySimple(string filename, bool isSimple)
        {
            string copyFileName1 = "Lab1.TempSort1";
            string copyFileName2 = "Lab1.TempSort2";
            var f = File.Create(copyFileName1);
            f.Close();
            f = File.Create(copyFileName2);
            f.Close();
            try { 
                SimpleSort(filename, copyFileName1, copyFileName2, isSimple);
            } finally { 
                File.Delete(copyFileName1);
                File.Delete(copyFileName2);
            }
        }
        private static void ApplyNature(string filename, bool isSimple)
        {
            string copyFileName1 = "Lab1.TempSort1";
            string copyFileName2 = "Lab1.TempSort2";
            var f = File.Create(copyFileName1);
            f.Close();
            f = File.Create(copyFileName2);
            f.Close();
            try
            {
                NatureSort(filename, copyFileName1, copyFileName2, isSimple);
            }
            finally
            {
                File.Delete(copyFileName1);
                File.Delete(copyFileName2);
            }
        }
        private static void ApplyMultiple(string filename, bool isSimple)
        {

        }

        public static void Simple(string filename, bool isSimple)
        {
            ApplySort(ApplySimple, filename, isSimple);
        }
        public static void Nature(string filename, bool isSimple)
        {
            ApplySort(ApplyNature, filename, isSimple);
        }
        public static void Multiple(string filename, bool isSimple)
        {
            ApplySort(ApplyMultiple, filename, isSimple);
        }

    }

    public class Sortes
    {
        public delegate void SortF(ref List<WeatherData> data);
        public delegate void OutSortF(string filename, bool isSimple);
        private static string outFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.json");
        private static void AddToFile(string s)
        {
            StreamWriter writer = new StreamWriter(outFilePath, true);
            writer.WriteLine(s);
            writer.Close();
        }
        private static void ApplySort(List<WeatherData> array, SortF sort, string name, bool print = false, string filename = "")
        {
            var ar = new List<WeatherData>(array);
            sort(ref ar);
            //AddToFile(String.Format("\t\"{0}\":", name));
            //AddToFile("\t{");
            //AddToFile(String.Format("\t\t\"Time\": {0},", Sort<WeatherData>.Time));
            //AddToFile(String.Format("\t\t\"Swaps\": {0},", Sort<WeatherData>.Swaps));
            //AddToFile(String.Format("\t\t\"Iterations\": {0},", Sort<WeatherData>.Iterations));
            //AddToFile(String.Format("\t\t\"Assigments\": {0},", Sort<WeatherData>.Assigments));
            //AddToFile(String.Format("\t\t\"Result\": [{0}]", String.Join(",", ar)))
            //AddToFile("\t},");
            //AddToFile(String.Format("\n\n\"{0}\":", name));
            AddToFile(String.Format("{0};{1};{2};{3};{4}", ar.Count, Sort<WeatherData>.Time, Sort<WeatherData>.Swaps,
                Sort<WeatherData>.Iterations, Sort<WeatherData>.Assigments));
            for (var i = 1; i < ar.Count; i++)
            {
                if (ar[i - 1].CompareTo(ar[i]) == 1)
                {
                    Console.WriteLine("{0} Error!", name);
                    return;
                }
            }
            Console.WriteLine("{0} OK!", name);
            if (print == true && !String.IsNullOrWhiteSpace(filename))
            {
                string output = JsonConvert.SerializeObject(ar);
                string outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                WriteData(output, outPath);
            }
        }

        public static void WriteData(string output, string outPath)
        {
            void WriteTabs(int count, StreamWriter w)
            {
                for (var i = 0; i < count; i++)
                {
                    w.Write('\t');
                }
            }
            using (StreamWriter writer = new StreamWriter(outPath))
            {
                int lvl = 0;
                for (var i = 0; i < output.Length; i++)
                {
                    if (output[i] == '[' || output[i] == '{')
                    {
                        //if (i > 0 && output[i] != ']' && output[i] != '}' && (i < 2 || output[i - 2] != ']' && output[i - 2] != '}')) { 
                        writer.WriteLine();
                        //}
                        WriteTabs(lvl, writer);
                        writer.Write(output[i]);
                        lvl++;
                        writer.WriteLine();
                        WriteTabs(lvl, writer);
                        continue;
                    }
                    if (output[i] == ']' || output[i] == '}')
                    {
                        writer.WriteLine();
                        lvl--;
                        WriteTabs(lvl, writer);
                        writer.Write(output[i]);
                        if (i < output.Length - 1 && output[i + 1] == ',')
                        {
                            writer.WriteLine(',');
                            i++;
                        }
                        else
                        {
                            writer.WriteLine();
                        }
                        WriteTabs(lvl, writer);
                        continue;
                    }
                    writer.Write(output[i]);
                    if (output[i] == ',')
                    {
                        writer.WriteLine();
                        WriteTabs(lvl, writer);
                    }
                }
            }
        }

        public static List<WeatherData> ReadData(string path)
        {
            var str = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<WeatherData>>(str);
        }

        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.json");
            //var arrayT = ReadData(path);
            //var array = new int[arrayT.Length * 10];
            //for (var i = 0; i < array.Length; i++)
            //{
            //    array[i] = arrayT[i % arrayT.Length];
            //}
            //var array = ReadData(path);


            if (File.Exists(outFilePath))
            {
                File.Delete(outFilePath);
            }
            File.Create(outFilePath).Close();
            //AddToFile("{");

            //var ar = ReadData(path);
            //ApplySort(array, Sort<WeatherData>.Bubble, "Bubble");
            //ApplySort(array, Sort<WeatherData>.Shaker, "Shaker");
            //ApplySort(array, Sort<WeatherData>.Comb, "Comb");
            //ApplySort(array, Sort<WeatherData>.Selection, "Selection");
            //ApplySort(array, Sort<WeatherData>.Insertion, "Insertion");
            //ApplySort(array, Sort<WeatherData>.Gnome, "Gnome");
            //ApplySort(array, Sort<WeatherData>.Shells, "Shells");
            //ApplySort(array, Sort<WeatherData>.Counting, "Counting");
            //ApplySort(array, Sort<WeatherData>.Quick, "Quick");
            //ApplySort(array, Sort<WeatherData>.Merge, "Merge");
            //ApplySort(array, Sort<WeatherData>.Tree, "Tree", true, "result.json");

            AddToFile("Количество;Время;Обмены;Итерации;Доп.Присваивания");

            for (var tt = 0; tt < 4; tt++)
            {
                AddToFile(";;;;");
                AddToFile(";;;;");
                switch (tt)
                {
                    case 0:
                        AddToFile("BUBBLE;BUBBLE;BUBBLE;BUBBLE;");
                        break;
                    case 1:
                        AddToFile("GNOME;GNOME;GNOME;GNOME;");
                        break;
                    case 2:
                        AddToFile("SHELLS;SHELLS;SHELLS;SHELLS;");
                        break;
                    case 3:
                        AddToFile("MERGE;MERGE;MERGE;MERGE;");
                        break;
                }
                AddToFile(";;;;");
                var ar = ReadData(path);
                AddToFile(";RAND;;RAND;");
                AddToFile(";;;;");
                for (var i = 1000; i <= ar.Count; i += 1000)
                {
                    Console.Write(String.Format("{1}-{0}: ", i, tt));
                    var array = new List<WeatherData>();
                    for (var j = 0; j < i; j++)
                    {
                        array.Add(ar[j % ar.Count]);
                    }
                    switch (tt)
                    {
                        case 0:
                            ApplySort(array, Sort<WeatherData>.Bubble, "Bubble");
                            break;
                        case 1:
                            ApplySort(array, Sort<WeatherData>.Gnome, "Gnome");
                            break;
                        case 2:
                            ApplySort(array, Sort<WeatherData>.Shells, "Shells");
                            break;
                        case 3:
                            ApplySort(array, Sort<WeatherData>.Merge, "Merge");
                            break;
                    }
                }

                Sort<WeatherData>.Quick(ref ar);

                AddToFile(";;;;");
                AddToFile(";NORM;;NORM;");
                AddToFile(";;;;");
                for (var i = 1000; i <= ar.Count; i += 1000)
                {
                    Console.Write(String.Format("{1}-{0}: ", i, tt));
                    var array = new List<WeatherData>();
                    for (var j = 0; j < i; j++)
                    {
                        array.Add(ar[j % ar.Count]);
                    }
                    switch (tt)
                    {
                        case 0:
                            ApplySort(array, Sort<WeatherData>.Bubble, "Bubble");
                            break;
                        case 1:
                            ApplySort(array, Sort<WeatherData>.Gnome, "Gnome");
                            break;
                        case 2:
                            ApplySort(array, Sort<WeatherData>.Shells, "Shells");
                            break;
                        case 3:
                            ApplySort(array, Sort<WeatherData>.Merge, "Merge");
                            break;
                    }
                }

                AddToFile(";;;;");
                AddToFile(";REVERSE;;REVERSE;");
                AddToFile(";;;;");

                for (var i = 0; i <= ar.Count; i += 1000)
                {
                    Console.Write(String.Format("{1}-{0}: ", i, tt));
                    var array = new List<WeatherData>();
                    for (var j = i - 1; j >= 0; j--)
                    {
                        array.Add(ar[j % ar.Count]);
                    }
                    switch (tt)
                    {
                        case 0:
                            ApplySort(array, Sort<WeatherData>.Bubble, "Bubble");
                            break;
                        case 1:
                            ApplySort(array, Sort<WeatherData>.Gnome, "Gnome");
                            break;
                        case 2:
                            ApplySort(array, Sort<WeatherData>.Shells, "Shells");
                            break;
                        case 3:
                            ApplySort(array, Sort<WeatherData>.Merge, "Merge");
                            break;
                    }
                }
            }
            //AddToFile("}");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    public class SortResult
    {
        public Sortes.SortF SortType { get; }
        public short DataType { get; }
        public long ItemsCount { get; }
        public long Time { get; }
        public long Iterations { get; }
        public long Swaps { get; }
        public long Assigments { get; }

        public SortResult(Sortes.SortF sortType, short dataType, long itemsCount, long time, long iterations, long swaps, long assigments)
        {
            SortType = sortType;
            DataType = dataType;
            ItemsCount = itemsCount;
            Time = time;
            Iterations = iterations;
            Swaps = swaps;
            Assigments = assigments;
        }
    }
}