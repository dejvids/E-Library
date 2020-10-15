using System;
using System.Collections.Generic;
using System.Text;

namespace E_Library.Application.DTOs
{
    public class BorrowedBookDto
    {
        public int BookCopyId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}
