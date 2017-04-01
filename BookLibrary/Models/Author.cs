﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}