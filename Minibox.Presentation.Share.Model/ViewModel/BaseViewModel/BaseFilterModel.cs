namespace Minibox.Presentation.Share.Model.ViewModel.BaseViewModel
{
    public class BaseFilterModel
    {
        public string Keyword { get; set; } = string.Empty;
        public FilterColumnModel[] FilterColumns { get; set; } = [];
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class FilterColumnModel
    {
        public string ColumnType { get; set; } = string.Empty;
        public string ColumnName { get; set; } = string.Empty;
        public string ColumnValue { get; set; } = string.Empty;
    }
}
