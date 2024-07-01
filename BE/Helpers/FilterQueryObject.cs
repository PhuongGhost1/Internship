
namespace BE.Helpers
{
    public class FilterQueryObject
    {
        public string? CategoryName {get; set;} 
        public int? FromPrices {get; set;}
        public int? ToPrices {get; set;}
        public int? Rating {get; set;}
        public int? DifficultLevel {get; set;}
        public int PageNumber {get; set;}
        public int PageSize {get; set;}
    }
}