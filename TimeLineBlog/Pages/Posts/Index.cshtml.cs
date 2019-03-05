using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeLineBlog.Models;
using TimeLineBlog.Pages.Models;

namespace TimeLineBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly TimeLineBlog.Models.TimeLineBlogContext _context;

        public IndexModel(TimeLineBlog.Models.TimeLineBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article.ToListAsync();
        }
    }
}
