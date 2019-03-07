using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeLineBlog.Models;
using Markdig;

namespace TimeLineBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly TimeLineBlogContext _context;

        public PostController(TimeLineBlogContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var articles = await _context.Article.OrderByDescending(m => m.CreateTime).ToListAsync();
            return View(articles);
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
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

            var comments = from c in _context.Comment
                           where c.ArticleID == article.ID
                           orderby c.CreateTime descending
                           select c;

            var post = new Post { Article = article, Comments = await comments.ToListAsync() };

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,CreateTime,LastModifyTime,MarkdownContent,HTMLContent")] Article article)
        {
            if (ModelState.IsValid)
            {
                // 设置时间
                DateTime now = DateTime.Now;
                article.CreateTime = now;
                article.LastModifyTime = now;

                // 生成 HTML
                BuildArticle(article);

                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,CreateTime,LastModifyTime,MarkdownContent,HTMLContent")] Article article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 更新修改时间
                    article.LastModifyTime = DateTime.Now;
                    // 重新生成 HTML
                    BuildArticle(article);
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCommentConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = comment.ArticleID });
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.ID == id);
        }

        private void BuildArticle(Article article)
        {
            // 也可以做一些屏蔽词过滤的代码
            var pipeline = new MarkdownPipelineBuilder()
                .UseBootstrap()
                .UseEmojiAndSmiley()
                .UseEmphasisExtras()
                .UseSoftlineBreakAsHardlineBreak()
                .Build();
            article.HTMLContent = Markdown.ToHtml(article.MarkdownContent, pipeline);
            article.PlainContent = Markdown.ToPlainText(article.MarkdownContent, pipeline);
        }
    }
}
