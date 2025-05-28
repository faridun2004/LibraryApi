namespace LibraryApi.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public List<FavoriteBook> FavoriteBooks { get; set; }
    }
}
