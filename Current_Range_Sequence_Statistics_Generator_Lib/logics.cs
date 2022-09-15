using System;
using System.Collections.Generic;
using System.Text;

namespace Current_Range_Sequence_Statistics_Generator_Lib
{
    public class logics
    {
        public void Get_Range_with_Value(List<int> arr, ref object start, ref object end, int index, ref int value)
        {
            if ((arr[index] == arr[index + 1]) || ((arr[index] + 1) == arr[index + 1]))
            {
                Get_Start_of_Range_with_Value(arr, ref start, ref end, index, ref value);
            }
            else
            {
                Get_End_Of_Range_With_Value(arr, start, ref end, index, ref value);
            }
        }

        static void Get_Start_of_Range_with_Value(List<int> arr, ref object start, ref object end, int index, ref int value)
        {
            value++;
            if (start == null) start = arr[index];
            if (index == arr.Count - 2)
            {
                end = arr[index + 1]; value++;
            }
        }
        static void Get_End_Of_Range_With_Value(List<int> arr, object start, ref object end, int index, ref int value)
        {
            if (start != null)
            {
                end = arr[index]; value++;
            }
        }
    }
}
