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
                {"#Dy#", new FacerTag("Year", () => DateTime.Now.Year.ToString())},
                {"#Dyy#", new FacerTag("Year", () => DateTime.Now.ToString("yy", _culture))},
                {"#Dyyyy#", new FacerTag("Year", () => DateTime.Now.ToString("yyyy", _culture))},
                {"#DM#", new FacerTag("Month in year", () => DateTime.Now.Month.ToString())},
                {"#DMM#", new FacerTag("Month in year", () => DateTime.Now.ToString("MM", _culture))},
                {"#DMMM#", new FacerTag("Month in year", () => DateTime.Now.ToString("MMM", _culture))},
                {"#DMMMM#", new FacerTag("Month in year", () => DateTime.Now.ToString("MMMM", _culture))},
                {"#DW#", new FacerTag("Week in month", () => DateTime.Now.GetWeekOfMonth().ToString())},
                {"#Dw#", new FacerTag("Week in year", () => DateTime.Now.GetWeekOfYear().ToString())},
                {"#DD#", new FacerTag("Day in year", () => DateTime.Now.GetDayOfYear().ToString())},
                {"#Dd#", new FacerTag("Day in month", () => DateTime.Now.GetDayOfMonth().ToString())},
                {"#DE#", new FacerTag("Day of week", () => DateTime.Now.ToString("ddd", _culture))},
                {"#DEEEE#", new FacerTag("Day of week", () => DateTime.Now.ToString("dddd", _culture))},
                {"#DF#", new FacerTag("Day of week in month", () => DateTime.Now.GetDayOfWeekInMonth().ToString())},
                {"#Da#", new FacerTag("AM/PM marker", () => DateTime.Now.ToString("tt", _culture))},                
                {"#Dh#", new FacerTag("Hour in day AM/PM (1-12)", () => DateTime.Now.ToString("%h", _culture))},
                {"#Dk#", new FacerTag("Hour in day (1-24)", () => (DateTime.Now.Hour + 1).ToString())},
                {"#DH#", new FacerTag("Hour in day (0-23)", () => DateTime.Now.ToString("%H", _culture))},
                {"#DK#", new FacerTag("Hour in day AM/PM (0-11)", () => (int.Parse(DateTime.Now.ToString("%h", _culture)) - 1).ToString())},
                {"#DhZ#", new FacerTag("Hour in day AM/PM (with leading zero) (01-12)", () => DateTime.Now.ToString("hh", _culture))},
                {"#DkZ#", new FacerTag("Hour in day (with leading zero) (01-24)", () => (DateTime.Now.Hour + 1).ToString("00"))},
                {"#DHZ#", new FacerTag("Hour in day (with leading zero) (00-23)", () => DateTime.Now.ToString("HH", _culture))},
                {"#DKZ#", new FacerTag("Hour in day AM/PM (with leading zero) (00-11)", () => (int.Parse(DateTime.Now.ToString("%h", _culture)) - 1).ToString("00"))},
                {"#DhoT#", new FacerTag("Value for hour hand rotation (12 hour)", () => (30 * (DateTime.Now.Hour % 12)).ToString())},
                {"#DhoTb#", new FacerTag("Value for hour hand rotation (24 hour)", () => (15 * DateTime.Now.Hour).ToString())},
                {"#DWFK#", new FacerTag("Rotation value for hour hand (12 hour, wearface)", () => (30 * (DateTime.Now.Hour % 12)).ToString())},
                {"#DWFH#", new FacerTag("Rotation value for hour hand (24 hour, wearface)", () => (15 * DateTime.Now.Hour).ToString())},
                {"#DWFKS#", new FacerTag("Smooth rotation value for hour hand (12 hour, wearface)", () => (30 * (DateTime.Now.GetFloatHour() % 12)).ToString())},
                {"#DWFHS#", new FacerTag("Smooth rotation value for hour hand (24 hour, wearface)", () => (15 * DateTime.Now.GetFloatHour()).ToString())},
                {"#DhT#", new FacerTag("String value for hour (12 hour)", () => (DateTime.Now.Hour % 12).ToWord())},
                {"#DkT#", new FacerTag("String value for hour (24 hour)", () => (DateTime.Now.Hour).ToWord())},
                {"#Dm#", new FacerTag("Minute in hour", () => DateTime.Now.ToString("%m", _culture))},
                {"#DmZ#", new FacerTag("Minute in hour (with leading zero)", () => DateTime.Now.ToString("mm", _culture))},
                {"#DmoT#", new FacerTag("Value for minute hand rotation", () => (6 * DateTime.Now.Minute).ToString())},
                {"#DWFM#", new FacerTag("Rotation value for minute hand. (WearFace Image)", () => (6 * DateTime.Now.Minute).ToString())},
                {"#DmT#", new FacerTag("String value for minutes", () => DateTime.Now.Minute.ToWord().ToUpper())},
                {"#DmMT#", new FacerTag("String value for minutes (tens place)", () => (DateTime.Now.Minute % 10).ToWord())},
                {"#DmST#", new FacerTag("String value for minutes (ones place)", () => (DateTime.Now.Minute / 10).ToWord())},
                {"#Ds#", new FacerTag("Second in minute", () => DateTime.Now.ToString("%s", _culture))},
                {"#DsZ#", new FacerTag("Second in minute (with leading zero)", () => DateTime.Now.ToString("ss", _culture))},
                {"#DseT#", new FacerTag("Value for second hand rotation", () => (6 * DateTime.Now.Second).ToString())},
                {"#DWFS#", new FacerTag("Rotation value for second hand. (WearFace Image)", () => (6 * DateTime.Now.Second).ToString())},
                {"#DWFSS#", new FacerTag("Smooth rotation value for second hand. (WearFace Image)", () => (6 * DateTime.Now.GetFloatSecond()).ToString())},
                {"#Dz#", new FacerTag("Timezone", () => "EST")},
                {"#Dzzz#", new FacerTag("Timezone", () => TimeZone.CurrentTimeZone.StandardName)},

                //BATTERY
                {"Battery", new FacerTag(string.Empty, null)},
                {"#BLP#", new FacerTag("Battery Level Precentage", () => "54%")},
                {"#BLN#", new FacerTag("Battery Level Integer", () => "54")},
                {"#BTC#", new FacerTag("Battery Temperature °C", () => "31°C")},
                {"#BTI#", new FacerTag("Battery Temperature °F", () => "88°C")},
                {"#BTCN#", new FacerTag("Battery Temperature °C (integer)", () => "31")},
                {"#BTIN#", new FacerTag("Battery Temperature °F (integer)", () => "88")},
                {"#BS#", new FacerTag("Battery Charging Status", () => "Not Charging")},

                //WEAR
                {"Wear", new FacerTag(string.Empty, null)},
                {"#ZLP#", new FacerTag("Low Power Mode", () => Properties.Settings.Default.LowPowerMode.ToString())},
                {"#ZSC#", new FacerTag("Step Count", () => "0")},

                //WEATHER
                {"Weather", new FacerTag(string.Empty, null)},
                {"#WLC#", new FacerTag("Weather Location", () => "New York City")},
                {"#WTH#", new FacerTag("Today's High", () => ShowTemp(29))},
                {"#WTL#", new FacerTag("Today's Low", () => ShowTemp(21))},
                {"#WCT#", new FacerTag("Today's Low", () => ShowTemp(27))},
                {"#WCCI#", new FacerTag("Current Condition Icon", () => "01")},
                {"#WCCT#", new FacerTag("Current Condition Text", () => "Fair")},
                {"#WCHN#", new FacerTag("Current Humidity Number", () => "54.0")},
                {"#WCHP#", new FacerTag("Current Humidity Percentage", () => "54.0%")},
                {"#WSUNRISE#", new FacerTag("Sunrise time for your current location", () => "6:40 am")},
                {"#WSUNSET#", new FacerTag("Sunset time for your current location", () => "6:11 pm")},
                {"#WFAH#", new FacerTag("Forecast Day 1 High", () => ShowTemp(29))},
                {"#WFAL#", new FacerTag("Forecast Day 1 Low", () => ShowTemp(19))},
                {"#WFACT#", new FacerTag("Forecast Day 1 Condition Text", () => "Partly Cloudy")},
                {"#WFACI#", new FacerTag("Forecast Day 1 Condition Icon", () => "03")},
                {"#WFBH#", new FacerTag("Forecast Day 2 High", () => ShowTemp(29))},
                {"#WFBL#", new FacerTag("Forecast Day 2 Low", () => ShowTemp(19))},
                {"#WFBCT#", new FacerTag("Forecast Day 2 Condition Text", () => "Partly Cloudy")},
                {"#WFBCI#", new FacerTag("Forecast Day 2 Condition Icon", () => "03")},
                {"#WFCH#", new FacerTag("Forecast Day 3 High", () => ShowTemp(29))},
                {"#WFCL#", new FacerTag("Forecast Day 3 Low", () => ShowTemp(19))},
                {"#WFCCT#", new FacerTag("Forecast Day 3 Condition Text", () => "Partly Cloudy")},
                {"#WFCCI#", new FacerTag("Forecast Day 3 Condition Icon", () => "03")},
                {"#WFDH#", new FacerTag("Forecast Day 4 High", () => ShowTemp(29))},
                {"#WFDL#", new FacerTag("Forecast Day 4 Low", () => ShowTemp(19))},
                {"#WFDCT#", new FacerTag("Forecast Day 4 Condition Text", () => "Partly Cloudy")},
                {"#WFDCI#", new FacerTag("Forecast Day 4 Condition Icon", () => "03")},
                {"#WFEH#", new FacerTag("Forecast Day 5 High", () => ShowTemp(29))},
                {"#WFEL#", new FacerTag("Forecast Day 5 Low", () => ShowTemp(19))},
                {"#WFECT#", new FacerTag("Forecast Day 5 Condition Text", () => "Partly Cloudy")},
                {"#WFECI#", new FacerTag("Forecast Day 5 Condition Icon", () => "03")},
                {"#WFFH#", new FacerTag("Forecast Day 6 High", () => ShowTemp(29))},
                {"#WFFL#", new FacerTag("Forecast Day 6 Low", () => ShowTemp(19))},
                {"#WFFCT#", new FacerTag("Forecast Day 6 Condition Text", () => "Partly Cloudy")},
                {"#WFFCI#", new FacerTag("Forecast Day 6 Condition Icon", () => "03")},
                {"#WFGH#", new FacerTag("Forecast Day 7 High", () => ShowTemp(29))},
                {"#WFGL#", new FacerTag("Forecast Day 7 Low", () => ShowTemp(19))},
                {"#WFGCT#", new FacerTag("Forecast Day 7 Condition Text", () => "Partly Cloudy")},
                {"#WFGCI#", new FacerTag("Forecast Day 7 Condition Icon", () => "03")},

                //META
                {"Meta", new FacerTag(string.Empty, null)},
                {"#ZDEBUG#", new FacerTag("Application Version", () => FacerWatchfaceDescription.AppBuild)}
            };

        }

        public static string ReplaceTag(Match match)
        {
            FacerTag tag = null;
            if (Tags.TryGetValue(match.Value, out tag))
                return tag.Get();
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
        public Func<string> Get;
        public FacerTag(string description, Func<string> get)
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
