using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeLineBlog.Models;

namespace TimeLineBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly TimeLineBlogContext _context;

        public HomeController(TimeLineBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Article.OrderByDescending(i => i.CreateTime).ToList());
        }

        // GET: Home/ReadArticle/5
        public async Task<IActionResult> ReadArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
