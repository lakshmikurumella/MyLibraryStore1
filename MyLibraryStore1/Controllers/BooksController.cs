using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibraryStore1.Models;
using MyLibraryStore1.Repository;

namespace MyLibraryStore1.Controllers
{
    public class BooksController : Controller
    {

        private IBookRepository _bookRepos = null;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepos = bookRepository;
        }
        public IActionResult Index()
        {
            var books = _bookRepos.GetBooks();
            return View(books);
        }


        public IActionResult Details(int id)
        {
            var book = _bookRepos.GetBookById(id);
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _bookRepos.CreateBook(book);

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, Book books)
        {
            if (books != null)
            {
                books.BookName = books.BookName;
                books.Author = books.Author;
                books.ISBN = books.ISBN;
                books.PublishedDate = books.PublishedDate;
            }
            return RedirectToAction("Index", "Book");
        }
    }
}