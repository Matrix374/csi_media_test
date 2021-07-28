using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csi_media_test.Models;

namespace csi_media_test.Logic
{
    public class numbersLogic
    {
        public int[] SortNumbersAscending(int numbers)
        {
            int[] num = SplitNumbersIntoArray(numbers);
            Array.Sort<int>(num);
            return num;
            //throw new NotImplementedException();
        }

        public int[] SortNumbersDescending(int numbers)
        {
            int[] num = SplitNumbersIntoArray(numbers);
            Array.Sort<int>(num);
            Array.Reverse(num);
            return num;
            //throw new NotImplementedException();
        }

        private int[] SplitNumbersIntoArray(int number)
        {
            var numString = number.ToString();
            var temp = numString.ToCharArray();
            int[] digits = Array.ConvertAll(temp, digit => (int)Char.GetNumericValue(digit));

            Debug.WriteLine(String.Format("From Logic SplitNumbers: [{0}]", string.Join(", ",digits)));
            return digits;
            //throw new NotImplementedException();
        }
    }
}
