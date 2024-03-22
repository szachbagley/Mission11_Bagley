using Microsoft.AspNetCore.Mvc;
using Mission11_Bagley.Models;
using Mission11_Bagley.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Bagley.Controllers
{
    public class HomeController : Controller
    {
        
        private IBookstoreRepository _bookstoreRepository;

        public HomeController(IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository; 
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var pageModel = new BookListViewModel
            {
                Books = _bookstoreRepository.Books
                    .OrderBy(x => x.Author)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookstoreRepository.Books.Count()
                }
            };

        return View(pageModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
