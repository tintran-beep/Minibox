//using Newtonsoft.Json;
using System.Text.Json;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Seeding
{
    public static class Seeder
    {
        public static Brand[] Brands()
        {
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Brands.json");
            //return JsonConvert.DeserializeObject<Brand[]>(File.ReadAllText(filePath)) ?? [];
            using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Brands.json"));
            return JsonSerializer.Deserialize<Brand[]>(reader.ReadToEnd()) ?? [];
        }

        public static Category[] Categories()
        {
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Categories.json");
            //return JsonConvert.DeserializeObject<Category[]>(File.ReadAllText(filePath)) ?? [];
            using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Seeding", "Categories.json"));
            return JsonSerializer.Deserialize<Category[]>(reader.ReadToEnd()) ?? [];
        }
    }
}
