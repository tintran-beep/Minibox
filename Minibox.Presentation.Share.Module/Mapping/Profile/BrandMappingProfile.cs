﻿using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Share.Module.Mapping.Profile
{
    public class BrandMappingProfile : AutoMapper.Profile
    {
        public BrandMappingProfile() 
        {
            CreateMap<Brand, BrandVM>().ReverseMap();
        }
    }
}
