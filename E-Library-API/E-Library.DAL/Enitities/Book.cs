using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Library.DAL.Enitities
{
    public class Book :EntityBase
    {
        /// <summary>
        /// Title of book, mandatory
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of book, mandatory
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Total count of copies of this book
        /// </summary>
        public int TotalCount { get; set; }
    }
}
