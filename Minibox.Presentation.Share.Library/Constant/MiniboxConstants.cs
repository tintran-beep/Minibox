using System.ComponentModel;
using System.Reflection;

namespace Minibox.Presentation.Share.Library.Constant
{
    public static class MiniboxConstants
    {
        public static class Language
        {
            [Description("English")]
            public const string English = "en";

            [Description("Tiếng Việt")]
            public const string Vietnamese = "vi";

            public static string[] GetSupportedLanguages()
            {
                var languages = typeof(Language).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                                .Where(x => x.IsLiteral && !x.IsInitOnly && x.FieldType == typeof(string))
                                                .Select(x => x.GetRawConstantValue()?.ToString() ?? string.Empty)
                                                .ToArray();

                return languages ?? [];
            }
        }

        public static class DbSchema
        {
            public const string App = "app";
            public const string Dbo = "dbo";
        }
    }
}
