using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
        public int id {get; set;}

        [Required(ErrorMessage = "Please Enter the title of the book")]
        public string Title { get; set;}

        [Required(ErrorMessage = "Please Enter the Author of the book")]
        public string Author { get; set;}

        [StringLength(50, MinimumLength = 10)]
        public string description { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage ="Please Select a Language")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please Enter the number of pages of book")]
        [Display(Name = "Total Pages")]
        public int? TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
