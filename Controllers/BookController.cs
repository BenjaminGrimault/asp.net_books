﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using books.Models;
using books.Data;

namespace books.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.booksList = dbContext.Books;
            return View();
        }
        
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return View();
        }

        [Route("add")]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid) {
                dbContext.Add<Book>(book);
                dbContext.SaveChanges();
            }
            return View();
        }

        [Route("update/{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (ModelState.IsValid) {
                dbContext.Update(book);
                dbContext.SaveChanges();
            }
            return View();
        }

        [Route("delete/{id}")]
        public IActionResult Delete(Book book)
        {
            if (ModelState.IsValid) {
                dbContext.Remove(book);
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
