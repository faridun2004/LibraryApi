namespace LibraryApi.DTOs
{
    public class UserDto:BaseDto
    {
        public string Name { get; set; }
        public List<string> FavoriteBooks { get; set; }
    }
}
