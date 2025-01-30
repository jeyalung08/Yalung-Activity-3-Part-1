using Microsoft.AspNetCore.Mvc;
using Yalung_Activity_3_Part_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Yalung_Activity_3_Part_1.Controllers
{
    public class BooksController : Controller
    {
       
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Метро 2033", Author = "Dmitry Glukhovsky.", Price = 999.99M, PublicationYear = 2005 },
            new Book { Id = 2, Title = "The Lightning Thief", Author = "Rick Riordan", Price = 974.99M, PublicationYear = 2006 },
            new Book { Id = 3, Title = "A Gentle Reminder", Author = "Bianca Sparacino", Price = 500M, PublicationYear = 2020 }
        };

        // List of books
        public IActionResult Index()
        {
            return View(books);  
        }

        // Add button function
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Max(b => b.Id) + 1; // Assigns a new ID 
                books.Add(book);
                return RedirectToAction("Index");  // Exit after magawa
            }
            return View(book);
        }

        // Edit button function
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.Price = book.Price;
                    existingBook.PublicationYear = book.PublicationYear;
                }
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // Delete button function
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction("Index");
        }
    }
}