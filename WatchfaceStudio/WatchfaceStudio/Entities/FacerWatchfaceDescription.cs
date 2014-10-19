using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchfaceStudio.Editor;

namespace WatchfaceStudio.Entities
{
    public class FacerWatchfaceDescription
    {
        public static string AppBuild = "0.90.1";

        private string _id;
        private string _title;
        private string _build = AppBuild;
        private int? _build_int = 50;
        private int? _watch_type;
        private bool? _is_beta;
        private int? _created_at;
        private int? _edited_at;
        private string _creator;

        public string id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public string build { get { return _build; } set { _build = value; } }
        public int? build_int { get { return _build_int; } set { _build_int = value; } }
        
        public bool? is_beta { get { return _is_beta; } set { _is_beta = value; } }
        [TypeConverter(typeof(EnumTypeConverter<int, EWatchType>))]
        public int? watch_type { get { return _watch_type; } set { _watch_type = value; } }
        [ReadOnly(true), TypeConverter(typeof(IntDateTimeTypeConverter))]
        public int? created_at { get { return _created_at; } set { _created_at = value; } }
        [ReadOnly(true), TypeConverter(typeof(IntDateTimeTypeConverter))]
        public int? edited_at { get { return _edited_at; } set { _edited_at = value; } }
        public string creator { get { return _creator; } set { _creator = value; } }
    }
}
