using System.Collections.Generic;
using System.Linq;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> AllBooks()
        {
            return DataSource();
        }
        public BookModel getbook(int id)
        {
            return DataSource().Where(x=> x.id == id).FirstOrDefault();
        }
        public List<BookModel> searchbook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList();
        }
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {id = 1, Title = "Java", Author = "Hamza", description="This is the description of Java Book",Category="Coding", Language="English",TotalPages=570},
                new  BookModel(){id = 2, Title = "Python", Author = "Ahmer", description="This is the description of Python Book",Category="Coding", Language="English",TotalPages=570},
                new BookModel() {id = 3, Title = "C#", Author = "Hassan", description="This is the description of C# Book",Category="Coding", Language="English",TotalPages=570},
                new BookModel() {id = 4, Title = "Dot Net Core", Author = "Ishaq", description="This is the description of Dot net Core Book",Category="Coding", Language="English",TotalPages=570},
                new BookModel() {id = 5, Title = "JavaScript", Author="Riaz", description="This is the description of JavaScript Book",Category="Coding", Language="English",TotalPages=570},
                new BookModel() {id = 6, Title = "C++", Author="Ahmad", description="This is the description of C++ Book",Category="Coding", Language="English",TotalPages=570},
            };
        }
    }
}
