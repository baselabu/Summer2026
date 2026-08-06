using BookstoreApi.Data;
using Microsoft.EntityFrameworkCore;
using BookstoreApi.Models;

namespace BookstoreApi.Repositories
{
    public class BookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> GetAllBooksAsync()
        {
            return _context.Books.AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .ToListAsync();
        
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _context.Books.AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}