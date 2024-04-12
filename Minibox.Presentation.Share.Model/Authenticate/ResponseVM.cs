using Minibox.Presentation.Share.Library.Constant;

namespace Minibox.Presentation.Share.Model.Authenticate
{
    public class ResponseVM
    {
        public ResponseVM()
        {
            StatusCode = (int)MiniboxEnums.StatusCode.Success;
        }
        public int? StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Data { get; set; }
    }
}
