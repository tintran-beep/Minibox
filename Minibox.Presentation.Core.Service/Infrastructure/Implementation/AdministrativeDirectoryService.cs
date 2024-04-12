using AutoMapper;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context.Main;
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
        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
