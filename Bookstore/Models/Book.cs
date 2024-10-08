using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Title is required")]
		[StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Author is required")]
		[StringLength(50, ErrorMessage = "Author's name can't be longer than 50 characters")]
		public string Author { get; set; }

		[Required(ErrorMessage = "Price in JD is required")]
		[Range(0.00, 100.00, ErrorMessage = "Price must be between 0.01 and 100 JD")]
		[Display(Name = "Price (JD)")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Genre is required")]
		[StringLength(30, ErrorMessage = "Genre can't be longer than 30 characters")]
		public string Genre { get; set; }

		[StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
		public string Description { get; set; }

		// New property for the book's image URL
		[Display(Name = "Book Cover Image")]
		[StringLength(255, ErrorMessage = "Image URL can't be longer than 255 characters")]
		public string ImageUrl { get; set; }
	}
}
