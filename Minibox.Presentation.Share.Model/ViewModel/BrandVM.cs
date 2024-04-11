namespace Minibox.Presentation.Share.Model.ViewModel
{
    public class BrandVM
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
