using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Library.DAL.Enitities
{
    [Table("Users")]
    public class User : EntityBase
    {
        [Required]
        public string Login { get; set; }
        public string Email { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public List<BookCopy> BorrowedBooks { get; set; }
        public List<Register> Books { get; set; }
        public List<UsersWhishlist> WishList { get; set; }
    }
}
