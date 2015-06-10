using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DWD.Crawler.Parser {
    public abstract class ParserBase {
        protected DateTime ParseDate(string dateWithHour) {
            int year = 0, month = 0, day = 1, hour = 0;

            if (dateWithHour.Length >= 4) {
                year = int.Parse(dateWithHour.Substring(0, 4));
            }
            if (dateWithHour.Length >= 6) {
                month = int.Parse(dateWithHour.Substring(4, 2));
            }
            if (dateWithHour.Length >= 8) {
                day = int.Parse(dateWithHour.Substring(6, 2));
            }
            if (dateWithHour.Length == 10) {
                hour = int.Parse(dateWithHour.Substring(8, 2));
            }

            return new DateTime(year, month, day, hour, 0, 0, DateTimeKind.Utc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected decimal ParseDecimal(string @decimal) {
            return Decimal.Parse(@decimal, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"));
        }
    }
}