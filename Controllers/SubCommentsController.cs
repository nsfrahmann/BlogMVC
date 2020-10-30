using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogMVC.Data;
using BlogMVC.Models;

namespace BlogMVC.Controllers
{
    public class SubCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubComment.Include(s => s.Author);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subComment = await _context.SubComment
                .Include(s => s.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subComment == null)
            {
                return NotFound();
            }

            return View(subComment);
        }

        //// GET: SubComments/Create
        //public IActionResult Create()
        //{
        //    ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        // POST: SubComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,PostId,Created,Updated")] SubComment subComment, string subcommentContent, int foo)
        {
            if (ModelState.IsValid)
            {
                subComment.Content = subcommentContent;
                subComment.CommentId = foo;
                

                _context.Add(subComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("SinglePost", "Posts", new { Id = subComment.PostId });
            }
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", subComment.AuthorId);
            return View(subComment);
        }

        // GET: SubComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subComment = await _context.SubComment.FindAsync(id);
            if (subComment == null)
            {
                return NotFound();
            }
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", subComment.AuthorId);
            return View(subComment);
        }

        // POST: SubComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,Content,Created,Updated")] SubComment subComment)
        {
            if (id != subComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCommentExists(subComment.Id))
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
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", subComment.AuthorId);
            return View(subComment);
        }

        // GET: SubComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subComment = await _context.SubComment
                .Include(s => s.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subComment == null)
            {
                return NotFound();
            }

            return View(subComment);
        }

        // POST: SubComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subComment = await _context.SubComment.FindAsync(id);
            _context.SubComment.Remove(subComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCommentExists(int id)
        {
            return _context.SubComment.Any(e => e.Id == id);
        }
    }
}
