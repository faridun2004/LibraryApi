using System.Text.Json.Serialization;

namespace LibraryApi.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public string? Role { get; set; }
        [JsonIgnore]
        public bool IsBlocked { get; }
        public List<FavoriteBook> FavoriteBooks { get; set; }
    }
}
