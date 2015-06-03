using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DWD.Crawler.Parser {
    public abstract class ParserBase {
        protected DateTime ParseDateWithHour(string dateWithHour) {
            var year = int.Parse(dateWithHour.Substring(0, 4));
            var month = int.Parse(dateWithHour.Substring(4, 2));
            var day = int.Parse(dateWithHour.Substring(6, 2));
            var hour = int.Parse(dateWithHour.Substring(8, 2));

            return new DateTime(year, month, day, hour, 0, 0, DateTimeKind.Utc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected decimal ParseDecimal(string @decimal) {
            return Decimal.Parse(@decimal, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"));
        }
    }
}