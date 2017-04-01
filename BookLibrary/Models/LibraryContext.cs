using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {
            Database.SetInitializer(new InitLibraryContext());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; } 
    }

    public class InitLibraryContext : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            List<Author> Authors = new List<Author>
            {
                new Author
                {
                    FullName ="Author 1",
                    Books = new List<Book>
                    {
                        new Book{Name="Book1"},
                        new Book{Name="Book2"}
                    }
                },
                new Author
                {
                    FullName ="Author 2",
                    Books = new List<Book>
                    {
                        new Book{Name="Book3"},
                        new Book{Name="Book4"},
                        new Book{Name="Book5"}
                    }
                },
                new Author
                {
                    FullName ="Author 3",
                    Books = new List<Book>
                    {
                        new Book{Name="Book6"},
                    }
                }
            };
            context.Authors.AddRange(Authors);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}