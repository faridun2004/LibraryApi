﻿namespace LibraryApi.Entities
{
    public class Book: BaseEntity
    {  
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }  
        public decimal Price {  get; set; }
    }
}
