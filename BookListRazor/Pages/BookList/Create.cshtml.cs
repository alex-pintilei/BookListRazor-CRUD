using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] // it is automatically assumed that on the post method, you will be getting this book right here
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            // IActionResult -> redirecting to a new page

            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); // added to queue
                await _db.SaveChangesAsync(); // data will be pushed to the database
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
