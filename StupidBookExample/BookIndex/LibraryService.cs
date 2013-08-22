using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace BookIndex
{

    [Route("/books")]
    [Route("/books/search")]
    public class BookSearchRequest : IReturn<List<Book>>
    {
        public string Text { get; set; }
    }

    [Route("/books/detail")]
    public class BookDetailRequest : IReturn<Book>
    {
        public string Title { get; set; }
    }

    public class LibrarySearchService : Service
    {

        public Library Library { get; set; } // assigned after construction by IoC

        public List<Book> Any(BookSearchRequest request) {
            if(String.IsNullOrEmpty(request.Text))
                return Library.GetAllBooks().ToList();

            return Library.FullTextSearch(request.Text).ToList();
        }

    }

    public class BookService : Service
    {

        public Library Library { get; set; } // assigned after construction by IoC
        
        public Book Any(BookDetailRequest request) {
            var book = Library.GetBookByTitle(request.Title);
            if(book == null)
                throw new HttpError(HttpStatusCode.NotFound,"no-book","Book not found");

            return book;
        }

    }


}