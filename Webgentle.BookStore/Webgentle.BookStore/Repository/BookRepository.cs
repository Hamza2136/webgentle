using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newbook = new Book()
            {
                Author = model.Author,
                description = model.description,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue? model.TotalPages.Value : 0,
                Category = model.Category,
                Language = model.Language
            };
            await _context.AddAsync(newbook);
            await _context.SaveChangesAsync();
            return newbook.id;

        }
        public async Task<List<BookModel>> AllBooks()
        {
            var Books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    Books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Category = book.Category,
                        description = book.description,
                        CreatedOn = book.CreatedOn,
                        UpdatedOn = book.UpdatedOn,
                        TotalPages = book.TotalPages,
                        Language = book.Language,
                        id = book.id
                    });
                }
            }

            return Books;
        }
        public async Task<BookModel> getbook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookdetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Category = book.Category,
                    description = book.description,
                    CreatedOn = book.CreatedOn,
                    UpdatedOn = book.UpdatedOn,
                    TotalPages = book.TotalPages,
                    Language = book.Language,
                    id = book.id
                };
                return bookdetails;
            }
            return null;
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
