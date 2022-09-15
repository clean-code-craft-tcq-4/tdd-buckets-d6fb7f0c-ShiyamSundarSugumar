using System;
using System.Collections.Generic;

namespace Current_Range_Sequence_Statistics_Generator_Lib
{

    public class Current_Range_Sequence_Statistics_Generator: logics
    {
        Range_And_Value range_And_Value = new Range_And_Value();
        public Current_Range_Sequence_Statistics_Generator()
        {
            //throw new NotImplementedException();
        }

        sealed internal class Range_And_Value
        {
            public List<int> Start = new List<int>();
            public List<int> End = new List<int>();
            public List<int> Value = new List<int>();
        }

        public string Get_Statistics(List<int> data)
        {
            
            string ret_data = string.Empty;
            data.Sort();
            range_And_Value = RangeAndValueStatisticsGenerator(data);

            for(int index =0; index < range_And_Value.Start.Count; index++)
            {
                ret_data += "{" + range_And_Value.Start[index].ToString() + "-" + range_And_Value.End[index] + ", " + range_And_Value.Value[index].ToString() + "} ";
                
            }

            return ret_data;

        }

        public bool IsArrayEmpty(List<int> data)
        {
            if(data.Count == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsArrayHasOnlyInteger(List<object> data)
        {
            foreach(var Val in data)
            {
                if(!(Val.GetType() == typeof(int)))
                {
                    return false;
                }
            }
            return true;
                    

            
        }

        private Range_And_Value  RangeAndValueStatisticsGenerator(List<int> arr)
        {
            Range_And_Value range_and_value = new Range_And_Value();
            
            int value = 0;
            object start = null, end = null;

            if(arr.Count == 1)
            {
                range_and_value.Start.Add(arr[0]);
                range_and_value.End.Add(arr[0]);
                range_and_value.Value.Add(1);
            }
            else
            {
                for (int index = 0; index < arr.Count - 1; index++)
                {

                    Get_Range_with_Value(arr, ref start, ref end, index, ref value);

                    if (end != null)
                    {

                        range_and_value.Start.Add((int)start);
                        range_and_value.End.Add((int)end);
                        range_and_value.Value.Add(value);

                        value = 0;
                        start = end = null;

                    }
                }           
            }
            return range_and_value;
        }
    }
}
