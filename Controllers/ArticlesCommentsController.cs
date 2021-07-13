using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UJTUT.Data;
using UJTUT.Models;

namespace UJTUT.Controllers
{
    public class ArticlesCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArticlesComments
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticlesCommentss.ToListAsync());
        }

        // GET: ArticlesComments/Details/5
        public async Task<IActionResult> Detai(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesComment = await _context.ArticlesCommentss
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (articlesComment == null)
            {
                return NotFound();
            }

            return View(articlesComment);
        }

        // GET: ArticlesComments/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection form)
        {
            var comment = form["Comment"].ToString();
            var articleId = int.Parse(form["ArticleId"]);
            var rating = int.Parse(form["Rating"]);

            ArticlesComment artComment = new ArticlesComment()
            {
                ArticleID = articleId,
                Comments = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };

            _context.ArticlesCommentss.Add(artComment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Tutors", new { id = articleId });
        }


        // POST: ArticlesComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesComment = await _context.ArticlesCommentss.FindAsync(id);
            if (articlesComment == null)
            {
                return NotFound();
            }
            return View(articlesComment);
        }

        // POST: ArticlesComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: ArticlesComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesComment = await _context.ArticlesCommentss
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (articlesComment == null)
            {
                return NotFound();
            }

            return View(articlesComment);
        }

        // POST: ArticlesComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articlesComment = await _context.ArticlesCommentss.FindAsync(id);
            _context.ArticlesCommentss.Remove(articlesComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesCommentExists(int id)
        {
            return _context.ArticlesCommentss.Any(e => e.CommentId == id);
        }
    }
}
