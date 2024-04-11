using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace Minibox.Presentation.Core.Data.Extension
{
    public static class MigrationExtension
    {
        public static void RunSqlScripts(this MigrationBuilder migrationBuilder, string[] sqlFileNames)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlFiles = assembly.GetManifestResourceNames().Where(file => file.EndsWith(".sql"));
            if (sqlFiles == null || !sqlFiles.Any())
                return;

            foreach (var sqlFileName in sqlFileNames)
            {
                var sqlFile = sqlFiles.FirstOrDefault(x => x.ToLower().EndsWith(sqlFileName.ToLower()));
                if (string.IsNullOrEmpty(sqlFile))
                    throw new Exception($"Sql file {sqlFileName} cannot be found!");

                using Stream stream = assembly.GetManifestResourceStream(sqlFile) ?? throw new Exception($"Assembly cannot be null!");
                using StreamReader reader = new(stream);

                var sqlScript = reader.ReadToEnd();
                migrationBuilder.Sql(sqlScript);
            }
        }
    }
}
