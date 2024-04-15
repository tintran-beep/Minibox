using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibox.Presentation.Share.Model.ViewModel
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CategoryVM>? Children { get; set; }
    }
}
