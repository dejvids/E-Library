using E_Library.DAL.Enitities;
using Microsoft.EntityFrameworkCore;

namespace E_Library.DAL
{
    public class LibraryDB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UsersWhishlist> UserWhistLists { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }

        public LibraryDB(DbContextOptions<LibraryDB> options)
            :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersWhishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.WishList)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<Register>()
                .HasOne(r => r.BookCopy)
                .WithMany(b => b.Register)
                .HasForeignKey(r => r.BookCopyId);

            modelBuilder.Entity<Register>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Register>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<BookCopy>()
                .HasOne(b => b.BorrowedBy)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(b=>b.BorroweById);

        }
    }
}
