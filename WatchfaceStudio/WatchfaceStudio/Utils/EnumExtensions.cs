using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Utils
{
    public static class EnumExtensions
    {
        public static TE ToggleFlag<TE>(this System.Enum value, TE flag) where TE : struct
        {
            if (((int)(object)value & (int)(object)flag) == (int)(object)flag)
            {
                return (TE)(object)(((int)(object)value & ~(int)(object)flag));
            }
            return (TE)(object)(((int)(object)value | (int)(object)flag));
        }

    }
}
