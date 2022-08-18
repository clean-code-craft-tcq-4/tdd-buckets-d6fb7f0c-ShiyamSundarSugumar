using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class logic
    {
        public void Seq1(List<int> arr, ref object start, ref object end, ref int i, ref int k)
        {
            if ((arr[i] == arr[i + 1]) || ((arr[i] + 1) == arr[i + 1]))
            {
                Seq2(arr, ref start, ref end, ref i, ref k);
            }
            else
            {
                Seq3(arr, ref start, ref end, ref i, ref k);
            }
        }

        static void Seq2(List<int> arr, ref object start, ref object end, ref int i, ref int k)
        {
            k++;
            if (start == null) start = arr[i];
            if (i == arr.Count - 2)
            {
                end = arr[i + 1];
                k++;
            }
        }

        static void Seq3(List<int> arr, ref object start, ref object end, ref int i, ref int k)
        {
            if (start != null)
            {
                end = arr[i]; k++;
            }
        }
    }
}
