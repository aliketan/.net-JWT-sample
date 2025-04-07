namespace API.Persistence.EntityFramework.Mappings
{
    public abstract class BaseMap
    {
        protected static class DbType
        {
            public static string DateTime = "DateTime";

            public static string Bit = "bit";

            public static string Bigint = "bigint";

            public static string Tinyint = "tinyint";

            public static string Int = "int";

            public static string NText = "ntext";

            public static string Text = "text";

            public static string VarBinary = "varbinary";

            public static string UniqueIdentifier = "uniqueidentifier";

            public static string Char(int value) => $"char({value})";

            public static string VarChar(int value) => $"varchar({value})";

            public static string NVarChar(int value) => $"nvarchar({value})";

            public static string Decimal(int decimalNumber) => $"decimal(12,{decimalNumber})";
        }
    }
}
