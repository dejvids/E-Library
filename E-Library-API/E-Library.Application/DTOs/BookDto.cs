using System;
using System.Collections.Generic;
using System.Text;

namespace E_Library.Application.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public int TotalCount { get; set; }
        public int FreeCount { get; set; }
        public bool? IsBorrowed { get; set; }
        public bool? IsOnWishlist { get; set; }
    }
}
