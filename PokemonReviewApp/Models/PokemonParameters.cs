namespace PokemonReviewApp.Models
{
    public class PokemonParameters
    {
        const int maxPageSize = 1;
        public int PageNumber { get; set; } = 1;
        private int _pageSize=10;
        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}
