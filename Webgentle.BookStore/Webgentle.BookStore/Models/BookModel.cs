using System.Web;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
        public int id {get; set;}
        public string Title { get; set;}
        public string Author { get; set;}
        public string description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
    }
}
