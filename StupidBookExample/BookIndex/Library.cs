using System;
using System.Collections.Generic;
using System.Linq;

namespace BookIndex
{
    public class Library
    {

        private readonly Book[] AllBooks = new[] {
            new Book { Title = "Modern Uses of SOAP", Keywords = "washing", Authors = "Foo Bar, Soap Bar"},
            new Book { Title = "The Theory and Practice of Oligarchical Collectivism", Authors = "Emmanuel Goldstein", Keywords = "1984"},
            new Book { Title = "The Best of 2600: A Hacker Odyssey", Authors = "Emmanuel Goldstein"},
            new Book { Title = "SOAP & Me", Authors = "Soap Bar", Keywords = "soap,self help"}
        };

        public IOrderedEnumerable<Book> GetAllBooks() {
            return AllBooks.OrderBy(x => x.Title);
        }

        public IEnumerable<Book> FullTextSearch(string searchText) {
            return AllBooks.Where(b =>
                (!String.IsNullOrEmpty(b.Title) && b.Title.Contains(searchText))
                || (!String.IsNullOrEmpty(b.Keywords) && b.Keywords.Contains(searchText))
                || (!String.IsNullOrEmpty(b.Authors) && b.Authors.Contains(searchText)));
        }

        public Book GetBookByTitle(string title) {
            return AllBooks.SingleOrDefault(x => x.Title == title);
        }

    }
}