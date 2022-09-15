using System;

namespace Current_Sensitivity_Generator_Lib
{
    public class Current_Sensitivity_Generator
    {
        public Current_Sensitivity_Generator()
        {
            //throw new NotImplementedException();
        }

        public int find_ADC_Max_Value(int ADC_Bit_range)
        {
            if(ADC_Bit_range > 0)
            {
                return (int)((Math.Pow(2,ADC_Bit_range))-1);
            }
            return -1;
        }

        public int find_ADC_Value_is_Error(int ADC_Value, int ADC_Max_Value)
        {
            if ((-1 < ADC_Value) && (ADC_Value < ADC_Max_Value))
            {
                return 1;
            }
            return -1;
        }
        public int Conversion_from_ADC_value_to_Ampere_value(int ADC_Value, int current_min_range, int current_max_range, int ADC_Max_Value)
        {
            int current_range = current_max_range - current_min_range;
            if (ADC_Value < ADC_Max_Value)
                return (int) Math.Round(((double)current_range * ((double)ADC_Value / (double) ADC_Max_Value)));
            return -1;                                       // Current value cannot be negative
        }

        public int[] find_Ampere_Value_from_ADC_values_array(int[] ADC_Values, int current_min_range, int current_max_range, int ADC_bit_range)
        {
            int[] Ampere_Data = new int[ADC_Values.Length];
            
            int i = 0;
            if(ADC_Values.Length > 0)
            {
                foreach (int adc_value in ADC_Values)
                {
                    int Ampere_value = check_all_aspects_and_find_ampere_value(adc_value, current_min_range, current_max_range, ADC_bit_range);
                    Ampere_Data[i] = Ampere_value;
                    i++;
                }
                return Ampere_Data;

            }
            Ampere_Data[0] =-1;
            return Ampere_Data;

        }

        public int check_all_aspects_and_find_ampere_value(int adc_value, int current_min_range, int current_max_range, int ADC_bit_range)
        {
            int adc_max_value = find_ADC_Max_Value(ADC_bit_range);
            if(adc_max_value != -1)
            {
                int Adc_value_is_ok = find_ADC_Value_is_Error(adc_value, adc_max_value);
                if(Adc_value_is_ok != -1)
                {
                    int Ampere_value = Conversion_from_ADC_value_to_Ampere_value(adc_value, current_min_range, current_max_range, adc_max_value);
                    return Ampere_value;
                }
                return Adc_value_is_ok;
            }
            return adc_max_value;
            
            

        }

    }
}
