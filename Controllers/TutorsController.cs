using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UJTUT.Data;
using UJTUT.Models;

namespace UJTUT.Controllers
{

    public class TutorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TutorsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }


        // GET: Tutors
        public async Task<IActionResult> Index()
        {
            //get tutors from db
            var tutors =  _context.Tutor.ToList();

            //do a check if tutors are available then display them, if not return view
            if (tutors.Count > 0)
            {
                return View(tutors);
            }
            else
            {
                return View();
            }
        }

        // GET: Tutors/showsearchform
        public async Task<IActionResult> showsearchform()
        {
            return View();
        }

        // GET: Tutors/showsearchresults
        public async Task<IActionResult> showsearchresults(string SearchPhrase)
        {
            return View("results",await _context.Tutor.Where(j=>j.Modules.Contains(SearchPhrase)).ToListAsync());
        }

        public IActionResult results()
        {
            return View();
        }

        public async Task<IActionResult> showsearchform2()
        {
            return View();
        }

        // GET: Tutors/showsearchresults
        public async Task<IActionResult> showsearchresults2(string SearchPhrase2)
        {
            return View("results2", await _context.Tutor.Where(j => j.password.Contains(SearchPhrase2)).ToListAsync());
        }

        public IActionResult results2()
        {
            return View();
        }

        public async Task<IActionResult> Manage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var tutor = await _context.Tutor
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutor == null)
            {
                return NotFound();
            }
            ViewBag.ArticleId = id.Value;

            var comments = _context.ArticlesCommentss.Where(d => d.ArticleID.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = _context.ArticlesCommentss.Where(d => d.ArticleID.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }



            return View(tutor);
        }













































        // GET: Tutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var tutor = await _context.Tutor
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutor == null)
            {
                return NotFound();
            }
            ViewBag.ArticleId = id.Value;

            var comments = _context.ArticlesCommentss.Where(d => d.ArticleID.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = _context.ArticlesCommentss.Where(d => d.ArticleID.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }



            return View(tutor);
        }





        // GET: Tutors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tutor_name,Modules,bio,cell,email,price,Profile_picture,pic_name,Campus,password")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(tutor.Profile_picture.FileName);
                string extension = Path.GetExtension(tutor.Profile_picture.FileName);
                tutor.pic_name = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/",tutor.pic_name);
                using (var Filestream1= new FileStream(path,FileMode.Create))
                {
                    await tutor.Profile_picture.CopyToAsync(Filestream1);
                }


                _context.Add(tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tutor_name,Profile_picture,Modules,bio,cell,email,price,Campus,password")] Tutor tutor)
        {
            if (id != tutor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorExists(tutor.id))
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
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutor = await _context.Tutor.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", tutor.Modules);
            _context.Tutor.Remove(tutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Any(e => e.id == id);
        }
    }
}
