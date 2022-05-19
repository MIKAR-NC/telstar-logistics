using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Reflection;

namespace TelstarRoutePlanner.Extensions
{
    public class EnumExtension<TEnum>
    {
        public static string GetDescription(TEnum val)
        {
            FieldInfo fi = typeof(TEnum).GetField(val.ToString());
            DescriptionAttribute[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attrs != null && attrs.Any() ? attrs[0].Description : val.ToString();
        }

        public static List<TEnum> GetEnumValsList()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }

        public static List<SelectListItem> CastEnumSelectList()
        {
            return GetEnumValsList().Select(x => new SelectListItem(GetDescription(x), x.ToString())).ToList();
        }

        public static List<SelectListItem> CastEnumSelectList(TEnum val)
        {
            return GetEnumValsList().Select(x => new SelectListItem(GetDescription(x), x.ToString(), x.Equals(val))).ToList();
        }
    }
}
