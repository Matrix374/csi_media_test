using System;
using System.Diagnostics;

namespace csi_media_test.Logic
{
    public class NumberLogic
    {
        public int[] SortNumbersAscending(int numbers)
        {
            int[] num = SplitNumbersIntoArray(numbers);
            Array.Sort<int>(num);
            return num;
        }

        public int[] SortNumbersDescending(int numbers)
        {
            int[] num = SplitNumbersIntoArray(numbers);
            Array.Sort<int>(num);
            Array.Reverse(num);
            return num;
        }

        private int[] SplitNumbersIntoArray(int number)
        {
            string numString = number.ToString();
            char[] temp = numString.ToCharArray();
            int[] digits = Array.ConvertAll(temp, digit => (int)Char.GetNumericValue(digit));

            Debug.WriteLine(String.Format("From Logic SplitNumbers: [{0}]", string.Join(", ",digits)));
            return digits;
        }
    }
}
