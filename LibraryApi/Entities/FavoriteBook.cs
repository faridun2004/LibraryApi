namespace LibraryApi.Entities
{
    public class FavoriteBook: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
