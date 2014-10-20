using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT.Code
{
    public class Support
    {
        public class ColumnTimeline
        {
            public int colspawn { get; set; }
            public string color { get; set; }
            public bool IsTask { get; set; }
        }
        public static List<ColumnTimeline> GetColumnTimeline(DateTime start, DateTime end, DateTime from, DateTime to)
        {
            var list = new List<ColumnTimeline>{};
            //Количество дней до даты С
            list.Add(new ColumnTimeline { color = "white", colspawn = from.Date.Subtract(start).Days });
            //Количество самих дней
            list.Add(new ColumnTimeline { color = "green", colspawn = to.Date.Subtract(from).Days + 1 , IsTask = true});
            //Количество оставшихся дней
            list.Add(new ColumnTimeline { color = "white", colspawn = end.Date.Subtract(to).Days });
            return list;
        }
    }
}