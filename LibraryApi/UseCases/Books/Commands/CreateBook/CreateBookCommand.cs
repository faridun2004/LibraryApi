using MediatR;

namespace LibraryApi.UseCases.Books.Commands.CreateBook
{
    public class CreateBookCommand:IRequest<Guid>
    {
        private string _title;
        private string _author;
        public string Title 
        {
            get=>_title; 
            set=>_title=value.Trim().Replace("\n",""); 
        }
        public string Description { get; set; }
        public string Author 
        { 
            get=>_author; set=>_author=value.Trim(); 
        }
        public decimal Price { get; set; }
    }
}
