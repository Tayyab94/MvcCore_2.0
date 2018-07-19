using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booklist.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DemoContext _Context;

        public DefaultController(DemoContext db)
        {
            _Context = db;
        }

        protected override void Dispose(bool disposing)
        {
          if(disposing)
            {
                _Context.Dispose();
            }
        }
        public IActionResult Index()
        {
            return View(_Context.Books.ToList());
        }


        //GEt : Default/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookClass obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }
            else
            {
                _Context.Books.Add(obj);
                await _Context.SaveChangesAsync();

                //return RedirectToAction("Index","Default");
            }

            return RedirectToAction(nameof(Index), "Default");
        }

        //Get BookDetail
        [HttpGet]
        public async Task<IActionResult> Detail(int? id )
        {
            if(id==null)
            {
                return NotFound();
            }
            var book =await _Context.Books.SingleOrDefaultAsync(m => m.id == id);
            if(book==null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id==null)
            {
                return NotFound();

            }
            var book = await _Context.Books.Where(a => a.id == id).SingleOrDefaultAsync();
            if(book==null)
            {
                return NotFound();
            }
            return View(book);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,BookClass obj)
        {
            if (id != obj.id)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                _Context.Update(obj);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        //get: Book/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var book = await _Context.Books.Where(a => a.id == id).SingleOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);

        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var book = await _Context.Books.Where(a => a.id == id).SingleOrDefaultAsync();
            _Context.Remove(book);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}