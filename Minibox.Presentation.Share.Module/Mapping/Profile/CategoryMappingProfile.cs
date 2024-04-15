using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Share.Module.Mapping.Profile
{
    public class CategoryMappingProfile : AutoMapper.Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
        }
    }
}
