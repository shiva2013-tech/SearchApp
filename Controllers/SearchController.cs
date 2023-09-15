using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultipleSearchApp.DataConnection;
using MultipleSearchApp.Models;
using System.Diagnostics;

namespace MultipleSearchApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ApplicationDbContext _context;

        public SearchController(ILogger<SearchController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            List<string> categoryList = GetUniqueCategories();
            List<string> sizeList = GetUniqueSizes();
            ViewBag.CategoryList = new SelectList(categoryList);
            ViewBag.SizeList = new SelectList(sizeList);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SearchResult(ProductModel productModel)
        {
            var searchResults = await _context.tblProduct
                .FromSqlRaw("EXEC sp_Search @ProductName, @Size, @Category",
                    new SqlParameter("ProductName", productModel.ProductName ?? ""),
                    new SqlParameter("Size", productModel.Size ?? ""),
                    new SqlParameter("Category", productModel.Category ?? ""))
                .ToListAsync();
            return PartialView("_SearchResults", searchResults);
        }

        private List<string> GetUniqueCategories()
        {
            List<string> categories = _context.tblProduct
                .Select(p => p.Category)
                .Distinct()
                .ToList();

            return categories;
        }

        private List<string> GetUniqueSizes()
        {
            List<string> categories = _context.tblProduct
                .Select(p => p.Size)
                .Distinct()
                .ToList();

            return categories;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



