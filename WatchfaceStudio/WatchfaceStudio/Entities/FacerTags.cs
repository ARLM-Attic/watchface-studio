using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WatchfaceStudio.Entities
{
    public class FacerTags
    {
        public static Dictionary<string, FacerTag> Tags;
        public static CultureInfo _culture = new CultureInfo("en-us");
        public static Regex TagRegex = new Regex(@"#[DBZW]\w*#");
        
        public static DateTime DateToShow
        {
            get
            {
                return Properties.Settings.Default.ViewCustomDateTime ? Properties.Settings.Default.CustomDateTime : DateTime.Now;
            }
        }

        public static string ShowTemp(int cTemp)
        {
            return ((int)(Properties.Settings.Default.TempUnitsCelsius ? cTemp : cTemp * 1.8 + 32)).ToString();
        }

        static FacerTags()
        {
            Tags = new Dictionary<string, FacerTag>
            {
                //TIME
                {"Time", new FacerTag(string.Empty, null)},
                {"#Dy#", new FacerTag("Year", (t) => t.Year.ToString())},
                {"#Dyy#", new FacerTag("Year", (t) => t.ToString("yy", _culture))},
                {"#Dyyyy#", new FacerTag("Year", (t) => t.ToString("yyyy", _culture))},
                {"#DM#", new FacerTag("Month in year", (t) => t.Month.ToString())},
                {"#DMM#", new FacerTag("Month in year", (t) => t.ToString("MM", _culture))},
                {"#DMMM#", new FacerTag("Month in year", (t) => t.ToString("MMM", _culture))},
                {"#DMMMM#", new FacerTag("Month in year", (t) => t.ToString("MMMM", _culture))},
                {"#DW#", new FacerTag("Week in month", (t) => t.GetWeekOfMonth().ToString())},
                {"#Dw#", new FacerTag("Week in year", (t) => t.GetWeekOfYear().ToString())},
                {"#DD#", new FacerTag("Day in year", (t) => t.GetDayOfYear().ToString())},
                {"#Dd#", new FacerTag("Day in month", (t) => t.GetDayOfMonth().ToString())},
                {"#DE#", new FacerTag("Day of week", (t) => t.ToString("ddd", _culture))},
                {"#DEEEE#", new FacerTag("Day of week", (t) => t.ToString("dddd", _culture))},
                {"#DF#", new FacerTag("Day of week in month", (t) => t.GetDayOfWeekInMonth().ToString())},
                {"#Da#", new FacerTag("AM/PM marker", (t) => t.ToString("tt", _culture))},                
                {"#Dh#", new FacerTag("Hour in day AM/PM (1-12)", (t) => t.ToString("%h", _culture))},
                {"#Dk#", new FacerTag("Hour in day (1-24)", (t) => (t.Hour + 1).ToString())},
                {"#DH#", new FacerTag("Hour in day (0-23)", (t) => t.ToString("%H", _culture))},
                {"#DK#", new FacerTag("Hour in day AM/PM (0-11)", (t) => (int.Parse(t.ToString("%h", _culture)) - 1).ToString())},
                {"#DhZ#", new FacerTag("Hour in day AM/PM (with leading zero) (01-12)", (t) => t.ToString("hh", _culture))},
                {"#DkZ#", new FacerTag("Hour in day (with leading zero) (01-24)", (t) => (t.Hour + 1).ToString("00"))},
                {"#DHZ#", new FacerTag("Hour in day (with leading zero) (00-23)", (t) => t.ToString("HH", _culture))},
                {"#DKZ#", new FacerTag("Hour in day AM/PM (with leading zero) (00-11)", (t) => (int.Parse(t.ToString("%h", _culture)) - 1).ToString("00"))},
                {"#DhoT#", new FacerTag("Value for hour hand rotation (12 hour)", (t) => (30 * (t.Hour % 12)).ToString())},
                {"#DhoTb#", new FacerTag("Value for hour hand rotation (24 hour)", (t) => (15 * t.Hour).ToString())},
                {"#DWFK#", new FacerTag("Rotation value for hour hand (12 hour, wearface)", (t) => (30 * (t.Hour % 12)).ToString())},
                {"#DWFH#", new FacerTag("Rotation value for hour hand (24 hour, wearface)", (t) => (15 * t.Hour).ToString())},
                {"#DWFKS#", new FacerTag("Smooth rotation value for hour hand (12 hour, wearface)", (t) => (30 * (t.GetFloatHour() % 12)).ToString())},
                {"#DWFHS#", new FacerTag("Smooth rotation value for hour hand (24 hour, wearface)", (t) => (15 * t.GetFloatHour()).ToString())},
                {"#DhT#", new FacerTag("String value for hour (12 hour)", (t) => (t.Hour % 12 == 0 ? 12 : t.Hour % 12).ToWord())},
                {"#DkT#", new FacerTag("String value for hour (24 hour)", (t) => (t.Hour).ToWord())},
                {"#Dm#", new FacerTag("Minute in hour", (t) => t.ToString("%m", _culture))},
                {"#DmZ#", new FacerTag("Minute in hour (with leading zero)", (t) => t.ToString("mm", _culture))},
                {"#DmoT#", new FacerTag("Value for minute hand rotation", (t) => (6 * t.Minute).ToString())},
                {"#DWFM#", new FacerTag("Rotation value for minute hand. (WearFace Image)", (t) => (6 * t.Minute).ToString())},
                {"#DmT#", new FacerTag("String value for minutes", (t) => t.Minute.ToWord().ToUpper())},
                {"#DmMT#", new FacerTag("String value for minutes (tens place)", (t) => (t.Minute % 10).ToWord())},
                {"#DmST#", new FacerTag("String value for minutes (ones place)", (t) => (t.Minute / 10).ToWord())},
                {"#Ds#", new FacerTag("Second in minute", (t) => t.ToString("%s", _culture))},
                {"#DsZ#", new FacerTag("Second in minute (with leading zero)", (t) => t.ToString("ss", _culture))},
                {"#DseT#", new FacerTag("Value for second hand rotation", (t) => (6 * t.Second).ToString())},
                {"#DWFS#", new FacerTag("Rotation value for second hand. (WearFace Image)", (t) => (6 * t.Second).ToString())},
                {"#DWFSS#", new FacerTag("Smooth rotation value for second hand. (WearFace Image)", (t) => (6 * t.GetFloatSecond()).ToString())},
                {"#Dz#", new FacerTag("Timezone", (t) => "EST")},
                {"#Dzzz#", new FacerTag("Timezone", (t) => TimeZone.CurrentTimeZone.StandardName)},

                //BATTERY
                {"Battery", new FacerTag(string.Empty, null)},
                {"#BLP#", new FacerTag("Battery Level Precentage", (t) => "54%")},
                {"#BLN#", new FacerTag("Battery Level Integer", (t) => "54")},
                {"#BTC#", new FacerTag("Battery Temperature °C", (t) => "31°C")},
                {"#BTI#", new FacerTag("Battery Temperature °F", (t) => "88°C")},
                {"#BTCN#", new FacerTag("Battery Temperature °C (integer)", (t) => "31")},
                {"#BTIN#", new FacerTag("Battery Temperature °F (integer)", (t) => "88")},
                {"#BS#", new FacerTag("Battery Charging Status", (t) => "Not Charging")},

                //WEAR
                {"Wear", new FacerTag(string.Empty, null)},
                {"#ZLP#", new FacerTag("Low Power Mode", (t) => Properties.Settings.Default.LowPowerMode.ToString())},
                {"#ZSC#", new FacerTag("Step Count", (t) => "0")},

                //WEATHER
                {"Weather", new FacerTag(string.Empty, null)},
                {"#WLC#", new FacerTag("Weather Location", (t) => "New York City")},
                {"#WTH#", new FacerTag("Today's High", (t) => ShowTemp(29))},
                {"#WTL#", new FacerTag("Today's Low", (t) => ShowTemp(21))},
                {"#WCT#", new FacerTag("Today's Low", (t) => ShowTemp(27))},
                {"#WCCI#", new FacerTag("Current Condition Icon", (t) => "01")},
                {"#WCCT#", new FacerTag("Current Condition Text", (t) => "Fair")},
                {"#WCHN#", new FacerTag("Current Humidity Number", (t) => "54.0")},
                {"#WCHP#", new FacerTag("Current Humidity Percentage", (t) => "54.0%")},
                {"#WSUNRISE#", new FacerTag("Sunrise time for your current location", (t) => "6:40 am")},
                {"#WSUNSET#", new FacerTag("Sunset time for your current location", (t) => "6:11 pm")},
                {"#WFAH#", new FacerTag("Forecast Day 1 High", (t) => ShowTemp(29))},
                {"#WFAL#", new FacerTag("Forecast Day 1 Low", (t) => ShowTemp(19))},
                {"#WFACT#", new FacerTag("Forecast Day 1 Condition Text", (t) => "Partly Cloudy")},
                {"#WFACI#", new FacerTag("Forecast Day 1 Condition Icon", (t) => "03")},
                {"#WFBH#", new FacerTag("Forecast Day 2 High", (t) => ShowTemp(29))},
                {"#WFBL#", new FacerTag("Forecast Day 2 Low", (t) => ShowTemp(19))},
                {"#WFBCT#", new FacerTag("Forecast Day 2 Condition Text", (t) => "Partly Cloudy")},
                {"#WFBCI#", new FacerTag("Forecast Day 2 Condition Icon", (t) => "03")},
                {"#WFCH#", new FacerTag("Forecast Day 3 High", (t) => ShowTemp(29))},
                {"#WFCL#", new FacerTag("Forecast Day 3 Low", (t) => ShowTemp(19))},
                {"#WFCCT#", new FacerTag("Forecast Day 3 Condition Text", (t) => "Partly Cloudy")},
                {"#WFCCI#", new FacerTag("Forecast Day 3 Condition Icon", (t) => "03")},
                {"#WFDH#", new FacerTag("Forecast Day 4 High", (t) => ShowTemp(29))},
                {"#WFDL#", new FacerTag("Forecast Day 4 Low", (t) => ShowTemp(19))},
                {"#WFDCT#", new FacerTag("Forecast Day 4 Condition Text", (t) => "Partly Cloudy")},
                {"#WFDCI#", new FacerTag("Forecast Day 4 Condition Icon", (t) => "03")},
                {"#WFEH#", new FacerTag("Forecast Day 5 High", (t) => ShowTemp(29))},
                {"#WFEL#", new FacerTag("Forecast Day 5 Low", (t) => ShowTemp(19))},
                {"#WFECT#", new FacerTag("Forecast Day 5 Condition Text", (t) => "Partly Cloudy")},
                {"#WFECI#", new FacerTag("Forecast Day 5 Condition Icon", (t) => "03")},
                {"#WFFH#", new FacerTag("Forecast Day 6 High", (t) => ShowTemp(29))},
                {"#WFFL#", new FacerTag("Forecast Day 6 Low", (t) => ShowTemp(19))},
                {"#WFFCT#", new FacerTag("Forecast Day 6 Condition Text", (t) => "Partly Cloudy")},
                {"#WFFCI#", new FacerTag("Forecast Day 6 Condition Icon", (t) => "03")},
                {"#WFGH#", new FacerTag("Forecast Day 7 High", (t) => ShowTemp(29))},
                {"#WFGL#", new FacerTag("Forecast Day 7 Low", (t) => ShowTemp(19))},
                {"#WFGCT#", new FacerTag("Forecast Day 7 Condition Text", (t) => "Partly Cloudy")},
                {"#WFGCI#", new FacerTag("Forecast Day 7 Condition Icon", (t) => "03")},

                //META
                {"Meta", new FacerTag(string.Empty, null)},
                {"#ZDEBUG#", new FacerTag("Application Version", (t) => FacerWatchfaceDescription.AppBuild)}
            };

        }

        public static string ReplaceTag(Match match)
        {
            FacerTag tag = null;
            if (Tags.TryGetValue(match.Value, out tag))
                return tag.Get(DateToShow);
            return match.Value;
        }

        public static string ResolveTags(string taggedString)
        {
            return TagRegex.Replace(taggedString, ReplaceTag);
        }
    }

    public class FacerTag
    {
        public string Description;
        public Func<DateTime, string> Get;
        public FacerTag(string description, Func<DateTime, string> get)
        {
            this.Description = description;
            this.Get = get;
        }
    }

    static class DateTimeExtensions
    {
        static GregorianCalendar _gc = new GregorianCalendar();

        public static int GetWeekOfMonth(this DateTime time)
        {
            var first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static int GetDayOfYear(this DateTime time)
        {
            return _gc.GetDayOfYear(time);
        }

        public static int GetDayOfMonth(this DateTime time)
        {
            return _gc.GetDayOfMonth(time);
        }

        public static int GetDayOfWeekInMonth(this DateTime time)
        {
            return (int)((time.Day - 1) / 7 + 1);
        }

        public static float GetFloatHour(this DateTime time)
        {
            var minutes = time.Hour * 60f + time.Minute;
            return (float)minutes / 60f;
        }

        public static float GetFloatSecond(this DateTime time)
        {
            var seconds = time.Second * 1000f + time.Millisecond;
            return (float)seconds / 1000f;
        }
    }

    static class IntegerExtensions
    {
        public static string[] Numbers = { 
            "zero", "one", "two", "three", "four", 
            "five", "six", "seven", "eight", "nine", 
            "ten", "eleven", "tweleve", "thirteen", "fourteen",
            "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };
        public static string[] Tens = {
            "twenty", "thirty", "fourty", "fifty", 
            "sixty", "seventy", "eighty", "ninety", "hundred"
        };
        
        public static string ToWord(this int number)
        {
            if (number < 0 || number > 100) return "N/A";
            if (number < 20) return Numbers[number].ToUpper();
            if (number % 10 == 0) return Tens[(number / 10) - 2].ToUpper();
            return string.Concat(Tens[(int)(Math.Floor((double)number / 10) - 2)], " ", Numbers[number % 10]).ToUpper();
        }
    }
}
