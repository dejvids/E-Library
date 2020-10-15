using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Library.DAL.Enitities
{
    [Table("BookCopy")]
    public class BookCopy:EntityBase
    {
        /// <summary>
        /// Book which this copy relates to
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// ISBN number of this book copy
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Date of publication
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Name of city where book copy was published
        /// </summary>
        public string PublicationPlace { get; set; }

        /// <summary>
        /// Date when book was entered to system
        /// </summary>
        public DateTime ActiveFrom { get; set; }

        /// <summary>
        /// Date when book was deleted from system, due to being lost or destoryed
        /// </summary>
        public DateTime? ActiveTo { get; set; }

        /// <summary>
        /// Determines if book is currently in use by library (true when ActiveTo is not set)
        /// </summary>
        public bool IsActive { get; set; }


        //[ForeignKey("FK_BookCopy_Users")]
        public int? BorroweById { get; set; }

        /// <summary>
        /// Ther user who borrowed the book as the last one
        /// </summary>
        public User BorrowedBy { get; set; }

        /// <summary>
        /// History of book copy
        /// </summary>
        public List<Register> Register { get; set; }

    }
}
