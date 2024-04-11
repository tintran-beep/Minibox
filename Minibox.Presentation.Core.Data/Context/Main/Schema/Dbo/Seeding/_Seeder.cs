using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using System.Text.Json;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Seeding
{
    public static class _Seeder
    {
        public static Brand[] Brands()
        {
            using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Brands.json"));
            return JsonSerializer.Deserialize<Brand[]>(reader.ReadToEnd()) ?? [];
        }

        public static Category[] Categories()
        {
            using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Categories.json"));
            return JsonSerializer.Deserialize<Category[]>(reader.ReadToEnd()) ?? [];
        }
    }
}
