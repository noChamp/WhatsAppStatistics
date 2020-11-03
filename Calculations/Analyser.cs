using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Analyser
    {
        public Dictionary<string, int> Analyse(IEnumerable<string> lines)
        {
            return
            lines.
                Where(line =>
                {
                    int index = line.IndexOf(',');

                    if (index == -1)
                        return false;

                    string date = line.Substring(0, index);
                    //bool success = DateTime.TryParse(date, out DateTime result);
                    //bool success = DateTime.TryParseExact(date, "M/dd/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
                    var parts = date.Split('/', '.');

                    if (parts.Count() != 3)
                        return false;

                    if (
                        !int.TryParse(parts[0], out int month) ||
                        !int.TryParse(parts[1], out int day)   ||
                        !int.TryParse(parts[2], out int year)
                    )
                        return false;

                    return true;
                }).
                Select(line =>
                {
                    int index = line.IndexOf(',');
                    string date = line.Substring(0, index);
                    return new { Date = date, Line = line };
                }).
                GroupBy(record => record.Date, record => record).
                ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
