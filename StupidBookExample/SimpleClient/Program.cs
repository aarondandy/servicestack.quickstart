using System;
using System.Collections.Generic;
using ServiceStack.ServiceClient.Web;
using SharedStuff;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args) {

            var client = new JsonServiceClient("http://localhost:1031/");
            var allBooks = client.Get<List<Book>>("/books");
            foreach (var book in allBooks) {
                Console.WriteLine(book.Title);
            }
            Console.ReadKey();
        }
    }
}
