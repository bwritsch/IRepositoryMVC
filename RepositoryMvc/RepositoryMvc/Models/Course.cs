using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryMvc.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public Decimal FullPrice { get; set; }
        public int AuthorId { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}