using System;
using Xunit;
using Current_Range_Sequence_Statistics_Generator_Lib;
using System.Linq;
using System.Collections.Generic;
using Current_Sensitivity_Generator_Lib;


namespace Current_Range_Sequence_Statistics.Tests
{
    public class Current_Sequence_Statistics_Test_Suite
    {
        [Fact]
        public void Statistics_Generator_Object_Creation_Testing()
        {
            Current_Range_Sequence_Statistics_Generator statistics_Generator = new Current_Range_Sequence_Statistics_Generator();
            Assert.NotNull(statistics_Generator);
        }

        [Fact]
        public void Empty_Array_Testing()
        {
            Current_Range_Sequence_Statistics_Generator statistics_Generator = new Current_Range_Sequence_Statistics_Generator();
            
            Assert.True(statistics_Generator.IsArrayEmpty(new List<int>()));
            Assert.False(statistics_Generator.IsArrayEmpty(new List<int>() { 1,2,3 }));
        }

        [Fact]
        public void Array_Only_Has_Integer_Testing()
        {
            Current_Range_Sequence_Statistics_Generator statistics_Generator = new Current_Range_Sequence_Statistics_Generator();
            
            Assert.True(statistics_Generator.IsArrayHasOnlyInteger(new List<object>() { 1, 2, 3 }));
            Assert.False(statistics_Generator.IsArrayHasOnlyInteger(new List<object>() { 1, 2.2, 3 }));
        }



        [Fact]
        public void Given_input_sequence_when_get_Statistics_called_then_should_valid_Return_csv_formatted_output()
        {
            Current_Range_Sequence_Statistics_Generator statistics_Generator = new Current_Range_Sequence_Statistics_Generator();

            List<int> input_Seq1 = new List<int>() { 3 };
            string Expected_Result1 = statistics_Generator.Get_Statistics(input_Seq1);
            Console.WriteLine(Expected_Result1);
            Assert.True(Expected_Result1 == "{3-3, 1} ");

            List<int> input_Seq2 = new List<int>() { 3, 3, 3, 3 };
            string Expected_Result2 = statistics_Generator.Get_Statistics(input_Seq2);
            Console.WriteLine(Expected_Result2);
            Assert.True(Expected_Result2 == "{3-3, 4} ");


            List<int> input_Seq3 = new List<int>() { 3, 4, 5, 6, 9, 12, 7, 7, 4 };
            string Expected_Result3 = statistics_Generator.Get_Statistics(input_Seq3);
            Console.WriteLine(Expected_Result3);
            Assert.True(Expected_Result3 == "{3-7, 7} ");


            List<int> input_Seq4 = new List<int>() { 3, 27, 3, 4, 26, 5, 6, 7, 7, 20, 21, 21, 22, 23, 24, 25 };
            string Expected_Result = statistics_Generator.Get_Statistics(input_Seq4);
            Console.WriteLine(Expected_Result);
            Assert.True(Expected_Result == "{3-7, 7} {20-27, 9} ");


        }
        
        public class Current_sensitivity_Generator_Test_Suite
        {
            Current_Sensitivity_Generator current_Sensitivity_Generator = new Current_Sensitivity_Generator();
            [Fact]
            public void Current_Sensitivity_Generator_Object_Creation()
            {
                Current_Sensitivity_Generator current_Sensitivity_Generator1 = new Current_Sensitivity_Generator();
                Assert.NotNull(current_Sensitivity_Generator1);
            }

            [Fact]
            public void Given_input_sequence_when_Current_sensitivity_Generator_Called_should_return_Ampere_as_string()
            {
                //Current_Sensitivity_Generator current_Sensitivity_Generator = new Current_Sensitivity_Generator();
                
                
            }

            [Fact]
            public void ADC_Bit_Max_Value_Testing()
            {
                const int ADC_12_bit = 12, ADC_10_bit = 10;
                Assert.Equal(4095,current_Sensitivity_Generator.find_ADC_Max_Value(ADC_12_bit));
                Assert.Equal(1023,current_Sensitivity_Generator.find_ADC_Max_Value(ADC_10_bit));
                Assert.Equal(-1,current_Sensitivity_Generator.find_ADC_Max_Value(0));
            }

            [Fact]
            public void ADC_Value_Error_or_Not_Testing()
            {
                int[] ADC_Values = { 1095, 895, 4095, 1023, 0, -5 };
                const int Max_Value_12_bit = 4095, Max_Value_10_bit = 1023;
                const int Test_Pass = 1, Test_Fail = -1;
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[0], Max_Value_12_bit), Test_Pass);
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[1], Max_Value_10_bit), Test_Pass);
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[2], Max_Value_12_bit), Test_Fail);
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[3], Max_Value_10_bit), Test_Fail);
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[4], Max_Value_12_bit), Test_Pass);
                Assert.Equal(current_Sensitivity_Generator.find_ADC_Value_is_Error(ADC_Values[5], Max_Value_10_bit), Test_Fail);
            }

            [Fact]
            public void Conversion_from_ADC_value_to_Ampere_value_testing()
            {
                int[] ADC_Values = { 1080, 512, 2048, 4000, 280, 140 };
                const int Max_Value_12_bit = 4095, Max_Value_10_bit = 1023;
                Assert.Equal(3,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[0],0,10, Max_Value_12_bit));
                Assert.Equal(5,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[1],0,10, Max_Value_10_bit));
                Assert.Equal(5,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[2],0,10, Max_Value_12_bit));
                Assert.Equal(10,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[3],0,10, Max_Value_12_bit));
                Assert.Equal(3,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[4],0,10, Max_Value_10_bit));
                Assert.Equal(1,current_Sensitivity_Generator.Conversion_from_ADC_value_to_Ampere_value(ADC_Values[5],0,10, Max_Value_10_bit));
            }

            [Fact]
            public void find_Ampere_Value_from_ADC_values_array_testing()
            {
                
                const int ADC_12_bit = 12, ADC_10_bit = 10;
                
                int[] ADC_Values_for_12bit = { 1080, 280, 140, 4095, 6000 };
                Assert.Equal(current_Sensitivity_Generator.find_Ampere_Value_from_ADC_values_array(ADC_Values_for_12bit, 0, 10, ADC_12_bit),new int[] { 3, 1, 0, -1, -1} );

                int[] ADC_Values_for_10bit = { 1000, 280, 140, 4095, 1023 };
                Assert.Equal(current_Sensitivity_Generator.find_Ampere_Value_from_ADC_values_array(ADC_Values_for_10bit, 0, 10, ADC_10_bit), new int[] { 10, 3, 1, -1, -1 });



            }

        }


    }




    
}
