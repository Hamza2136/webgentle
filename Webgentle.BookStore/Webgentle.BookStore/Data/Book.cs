using System;

namespace Webgentle.BookStore.Data
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedOn {  get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
