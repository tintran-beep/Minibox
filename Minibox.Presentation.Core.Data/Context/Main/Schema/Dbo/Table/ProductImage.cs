using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }
        public bool IsCover { get; set; } = false;
    }
}
