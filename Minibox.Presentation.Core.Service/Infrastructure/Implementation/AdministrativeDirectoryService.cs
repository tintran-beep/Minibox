using AutoMapper;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context.Main;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table.AdministrativeDirectory.Seeding;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;
using Minibox.Presentation.Share.Model;

namespace Minibox.Presentation.Core.Service.Infrastructure.Implementation
{
    public class AdministrativeDirectoryService(
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IUnitOfWork<MainDbContext> mainUnitOfWork)
        : BaseService(mapper, appSettings, mainUnitOfWork), IAdministrativeDirectoryService
    {
        public async Task SeedAsync()
        {
            var isSaveChange = false;
            if (!await _mainUnitOfWork.GetRepo<Country>().AnyAsync())
            {
                isSaveChange = true;
                _mainUnitOfWork.GetRepo<Country>().Insert(Seeder.Countries());
            }

            if (!await _mainUnitOfWork.GetRepo<Province>().AnyAsync())
            {
                isSaveChange = true;
                _mainUnitOfWork.GetRepo<Province>().Insert(Seeder.Provinces());
            }

            if (!await _mainUnitOfWork.GetRepo<District>().AnyAsync())
            {
                isSaveChange = true;
                _mainUnitOfWork.GetRepo<District>().Insert(Seeder.Districts());
            }

            if (!await _mainUnitOfWork.GetRepo<Ward>().AnyAsync())
            {
                isSaveChange = true;
                _mainUnitOfWork.GetRepo<Ward>().Insert(Seeder.Wards());
            }

            if (isSaveChange)
                await _mainUnitOfWork.BulkSaveChangesAsync();
        }
    }
}
