using MyLibraryStore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryStore1.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        Book GetBookById(int Id);

        void CreateBook(Book book);

        void UpdateBook(int? Id, Book book);
        void DeleteBook(int? Id);
    }
}
