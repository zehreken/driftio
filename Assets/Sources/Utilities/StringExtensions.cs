using UnityEngine;

namespace zehreken.i_cheat.Extensions
{
    public static class StringExtensions
    {
        public static string Italic(this string s)
        {
            return string.Format("<i>{0}</i>", s);
        }

        public static string Bold(this string s)
        {
            return string.Format("<b>{0}</b>", s);
        }

        public static string Color(this string s, Color color)
        {
            return string.Format("<color={0}>{1}</color>", color, s);
        }

        public static string ToString<T>(T obj)
        {
            string s = "";
            var fields = typeof(T).GetFields();
            foreach (var fieldInfo in fields)
            {
                s += fieldInfo.Name + ": " + fieldInfo.GetValue(obj) + "\n";
            }

            return s;
        }
    }
}