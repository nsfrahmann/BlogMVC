using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogMVC.Data;
using BlogMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using BlogMVC.Utilities;
using Microsoft.AspNetCore.Identity;
using static BlogMVC.Areas.Identity.Pages.Account.RegisterModel;

namespace BlogMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post.Include(p => p.Blog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            if (post.Image != null)
            {
                ViewData["Image"] = PostImageHelper.GetImage(post);
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Abstract,Content,Image")] Post post, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                post.IsPublished = true;
                post.Created = DateTime.Now;

                if (image != null)
                {
                    post.FileName = image.FileName;

                    var ms = new MemoryStream();
                    image.CopyTo(ms);
                    post.Image = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                }
                _context.Add(post);
                await _context.SaveChangesAsync();
                var myId = post.Id;
                return RedirectToAction("SinglePost", new { Id = myId });
            }
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Id", post.BlogId);
            return View("Create", post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Id", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlogId,Title,Abstract,Content,Image,Created")] Post post, IFormFile newImage)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (newImage != null)
                    {
                        post.FileName = newImage.FileName;

                        var ms = new MemoryStream();
                        newImage.CopyTo(ms);
                        post.Image = ms.ToArray();

                        ms.Close();
                        ms.Dispose();
                    }
                    post.IsPublished = true;
                    post.Updated = DateTime.Now;
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            var myId = post.Id;
            ViewData["BlogId"] = new SelectList(_context.Blog, "Id", "Id", post.BlogId);
            return RedirectToAction("SinglePost", new { Id = myId });
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }

        public async Task<IActionResult> BlogPosts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewData["PostCount"] = blog.Posts.Count();
            ViewData["BlogName"] = blog.Name;
            ViewData["BlogId"] = blog.Id;

            //only gives posts associated with clicked blog id
            var blogPosts = await _context.Post.Where(p => p.BlogId == id).ToListAsync();
            return View(blogPosts);
        }

        public async Task<IActionResult> SinglePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            
            var post = await _context.Post.Include(p => p.Comments)
                .ThenInclude(c => c.Author)
                .Include(p => p.SubComments)
                .ThenInclude(sc => sc.Author)
                //.Include(p => p.SubComments)
                //.ThenInclude(sc => sc.CommentId)
                .FirstOrDefaultAsync(p => p.Id == id);
            //var comment = await _context.Comment.Include(c => c.SubComments).ThenInclude(s => s.Author).FirstOrDefaultAsync(c => c.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            //How to get most recent await _context.Post.OrderByDescending(p => p.Created).Take(3).ToListAsync()
            return View(post);
        }
    }
}
