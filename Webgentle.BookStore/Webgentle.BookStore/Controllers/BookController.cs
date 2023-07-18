using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;

        public BookController(BookRepository bookrepository)
        {
            bookRepository = bookrepository;
        }

        public async Task<ViewResult> allbooks()
        {
            var data = await bookRepository.AllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public async Task<ViewResult> getbook(int id)
        {
            var data = await bookRepository.getbook(id);
            return View(data);
        }

        public List<BookModel> searchbook(string title, string author)
        {
            return bookRepository.searchbook(title, author);
        }

        public ViewResult Addbook(bool isSuccess=false, int bookid = 0)
        {
            var model = new BookModel()
            {
                Language = "3"
            };
            ViewBag.Language = new SelectList(GetLanguages(),"id","text");
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookid = bookid;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Addbook(BookModel bookmodel)
        {
            if (ModelState.IsValid)
            {
                int id = await bookRepository.AddNewBook(bookmodel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Addbook), new { isSuccess = true, bookid = id });
                }
            }
            ViewBag.Language = new List<string>() { "Urdu", "English", "Japanese" };
            return View();
        }
        
        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() {id=1, text="Urdu"},
                new LanguageModel() {id=2, text="English"},
                new LanguageModel() {id=3, text="Japanese"}
            };
        }
    }
}
