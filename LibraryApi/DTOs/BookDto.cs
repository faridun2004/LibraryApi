﻿namespace LibraryApi.DTOs
{
    public class BookDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }  
}
