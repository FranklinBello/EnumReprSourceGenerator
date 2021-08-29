using System;

namespace EnumExtension
{
    public static partial class EnumRepr
    {
        public static string Repr(this Enum value) => value.ToString();
    }
}
