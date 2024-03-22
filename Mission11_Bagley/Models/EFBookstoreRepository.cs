﻿
namespace Mission11_Bagley.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context;
        
        public EFBookstoreRepository(BookstoreContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
