using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class Media : BaseEntity
    {
        public Media() 
        {
            Id = Share.Library.Common.CommonHelper.NewSequenceGuid();
        }

        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}
