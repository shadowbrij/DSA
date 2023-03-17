using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace File_IO
{
    class Program
    {
        public static List<ToyoCalender> CalenderCSV = new List<ToyoCalender>();
        static void Main(string[] args)
        {
            string file = @"C:\SNL\Toyo\DBNKBD05.csv";
            LoadCalenderInfoFromCalenderFile(file);

        }
        private static void LoadCalenderInfoFromCalenderFile(string fileSource)
        {
            try
            {
                var rows = File.ReadAllLines(fileSource)
                                 .Select(line => line.Split(new[] { ',' }, StringSplitOptions.None))
                                 .ToList();

                for (int i = 0; i < rows.Count; i++)
                {

                    CalenderCSV.Add(new ToyoCalender()
                    {
                        WeekStartDate = rows[i][1],
                        WeekEndDate = rows[i][2],
                        Monday = rows[i][6],
                        Tuesday = rows[i][8],
                        Wednesday = rows[i][10],
                        Thursday = rows[i][12],
                        Friday = rows[i][14],
                    });
                }
                var today = DateTime.Now.Date;
                var todayRow = CalenderCSV.Where(a => (today.CompareTo(DateTime.ParseExact(a.WeekStartDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Date) > 0 &&
                                                       today.CompareTo(DateTime.ParseExact(a.WeekEndDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Date) < 0
                                                      )
                                                ).Select(b => b).FirstOrDefault();

                var value = todayRow.GetType().GetProperty(today.DayOfWeek.ToString());

                if (value != null && value.GetValue(todayRow).ToString() == "1")
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
