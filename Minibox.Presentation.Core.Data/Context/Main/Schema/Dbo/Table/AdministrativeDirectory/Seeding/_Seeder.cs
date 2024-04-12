using Newtonsoft.Json;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory.Seeding
{
    public static class Seeder
    {
        public static Country[] Countries()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Table\AdministrativeDirectory\Seeding", "Countries.json");
            return JsonConvert.DeserializeObject<Country[]>(File.ReadAllText(filePath)) ?? [];
        }

        public static Province[] Provinces()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Table\AdministrativeDirectory\Seeding", "Provinces.json");
            return JsonConvert.DeserializeObject<Province[]>(File.ReadAllText(filePath)) ?? [];
        }

        public static District[] Districts()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Table\AdministrativeDirectory\Seeding", "Districts.json");
            return JsonConvert.DeserializeObject<District[]>(File.ReadAllText(filePath)) ?? [];
        }

        public static Ward[] Wards()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Context\Main\Schema\Dbo\Table\AdministrativeDirectory\Seeding", "Wards.json");
            return JsonConvert.DeserializeObject<Ward[]>(File.ReadAllText(filePath)) ?? [];
        }
    }
}
