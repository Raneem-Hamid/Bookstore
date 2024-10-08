using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {

		private readonly AppDbContext _context;

		public BookController(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> GetAllBooks()
        {
			var books = await _context.Books.ToListAsync(); 
			if (books == null || !books.Any())
			{
				return NotFound("No Books Stored");
			}

			return View(books);
        }


		public async Task<IActionResult> BookDetails(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
			if (book == null)
			{
				return NotFound("Book Not Found");
			}

			return View(book);
		}

		// GET: View Create Form
		public IActionResult AddBook()
		{
			var book = new Book(); 
			return View(book);
		}


		[HttpPost]
		public async Task<IActionResult> AddBook(Book book)
		{
			if (!ModelState.IsValid)
			{
				return View(book); // Return the same view with the book model if validation fails
			}

			_context.Books.Add(book); // Add the book to the database
			await _context.SaveChangesAsync(); // Save the changes asynchronously

			return RedirectToAction(nameof(GetAllBooks)); // Redirect to the Index page after creation
		}
        public async Task<ActionResult> EditBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound("Book Not Found");
            }

            return View(book); 
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book); 
            }

            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

            if (existingBook == null)
            {
                return NotFound("Book Not Found");
            }

            // Update existing book details
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.Title = book.Title;
            existingBook.Genre = book.Genre;

            await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(GetAllBooks)); 
        }

		// GET: Confirm Delete Book by ID
		public async Task<ActionResult> Delete(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
			if (book == null)
			{
				return NotFound("Book Not Found");
			}

			return View(book); // Return the delete confirmation view
		}

		// POST: Delete Book
		[ValidateAntiForgeryToken]
		[HttpPost, ActionName("Delete")]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
			if (book == null)
			{
				return NotFound("Book Not Found");
			}

			_context.Books.Remove(book); // Remove the book from the context
			await _context.SaveChangesAsync(); // Save changes asynchronously

			return RedirectToAction(nameof(GetAllBooks)); // Redirect to the Index page after deletion
		}


	}
}
