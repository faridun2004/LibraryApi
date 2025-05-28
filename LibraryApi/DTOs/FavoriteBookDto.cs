using LibraryApi.Entities;

namespace LibraryApi.DTOs
{
    public class FavoriteBookDto: BaseDto
    {
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookDescription { get; set; }
        public decimal BookPrice {  get; set; }
    }
}
