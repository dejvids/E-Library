using System.ComponentModel.DataAnnotations.Schema;

namespace E_Library.DAL.Enitities
{
    [Table("UsersWishlist ")]
    public class UsersWhishlist : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
