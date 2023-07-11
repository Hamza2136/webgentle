using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public ViewResult allbooks()
        {
            var data = bookRepository.AllBooks();
            return View();
        }
        public BookModel getbook(int id)
        {
            return bookRepository.getbook(id);
        }
        public List<BookModel> searchbook(string title, string author)
        {
            return bookRepository.searchbook(title, author);
        }
    }
}
