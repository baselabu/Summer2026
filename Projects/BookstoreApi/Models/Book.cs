
namespace BookstoreApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign key
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        // Navigation properties
        public Category Category { get; set; } = null!;
        public Author Author { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        
    }
}