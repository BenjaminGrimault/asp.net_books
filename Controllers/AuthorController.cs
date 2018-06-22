using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using books.Models;
using books.Data;

namespace books.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public AuthorController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.authorsList = dbContext.Authors;
            return View();
        }
        
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return View();
        }

        [Route("add")]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid) {
                dbContext.Add<Author>(author);
                dbContext.SaveChanges();
            }
            return View();
        }

        [Route("update/{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (ModelState.IsValid) {
                dbContext.Update(author);
                dbContext.SaveChanges();
            }
            return View();
        }

        [Route("delete/{id}")]
        public IActionResult Delete(Author author)
        {
            if (ModelState.IsValid) {
                dbContext.Remove(author);
                dbContext.SaveChanges();
            }
            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
