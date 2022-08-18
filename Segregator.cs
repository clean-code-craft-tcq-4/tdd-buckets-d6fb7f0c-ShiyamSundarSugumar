using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp2
{
    class Segregator
    {

        public string find_data(List<int> data)
        {
            int j = 0;
            string ret_data=string.Empty;
            data.Sort();
            var val = find_value(data);

            foreach (var kk in val)
            {
                ret_data += "{" + kk.Key[0].ToString() + "-" + kk.Key[1] + ": " + kk.Value.ToString()+"} ";
                j++;
            }

            return ret_data;
        }

        public Dictionary<List<int>,int> find_value(List<int> arr)
        {
            var val = new Dictionary<List<int>, int>();
            int k = 0;
            object start = null, end = null;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if ((arr[i] == arr[i + 1]) || ((arr[i] + 1) == arr[i + 1]))
                {
                    k++;
                    if (start == null) start = arr[i];
                    if (i == arr.Count - 2)
                    {
                        end = arr[i + 1];
                        k++;
                    }
                }
                else
                {
                    if (start != null)
                    {
                        end = arr[i]; k++;
                    }
                }

                if (end != null)
                {
                    List<int> temp = new List<int>() { (int)start, (int)end };
                    val.Add(temp, k);
                    k = 0;
                    start = end = null;

                }
            }
            return val;
        }
    }
}
