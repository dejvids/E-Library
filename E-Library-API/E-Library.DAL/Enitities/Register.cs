using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Library.DAL.Enitities
{
    [Table("Register")]
    public class Register:EntityBase
    {
        /// <summary>
        /// User who borrowed book
        /// </summary>
        public User User { get; set; }

        [ForeignKey("FK_Register_Users_UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Book copy which was borrowed
        /// </summary>
        public BookCopy BookCopy { get; set; }

        /// <summary>
        /// ForeignKey
        /// </summary>
        [ForeignKey("FK_Register_BookCopy")]
        public int BookCopyId { get; set; }

        /// <summary>
        /// Date when user borrowed the book
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Date when user return the book, null when book is not yet returned
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
