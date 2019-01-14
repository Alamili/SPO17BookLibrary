using Books.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class AuthorBookDTO
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
    }
}
