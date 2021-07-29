using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csi_media_test.Models;

namespace csi_media_test.Logic
{
    public class DatabaseService
    {
        public DBO_SortedNumModel ConvertToDBO(SortedNumModel data)
        {
            return new DBO_SortedNumModel(){
                Id = data.Id,
                Number = string.Join(",", data.Number),
                SortType = data.SortType,
            };
        }

        public SortedNumModel ConvertToSortedNum(DBO_SortedNumModel data)
        {
            List<int> temp = new List<int>();
            foreach(var num in data.Number.Split(",")) {
                temp.Add(Convert.ToInt32(num));
            }

            int[] numArray = temp.ToArray();
            return new SortedNumModel(){
                Id = data.Id,
                Number = numArray,
                SortType = data.SortType
            };
        }
    }
}
