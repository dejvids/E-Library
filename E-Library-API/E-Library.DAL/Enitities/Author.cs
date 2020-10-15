using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Library.DAL.Enitities
{
    [Table("Authors")]
    public class Author:EntityBase
    {
        /// <summary>
        /// Surname of author, mandatory
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Name of author, mandatory
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// List of books related to this author
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
