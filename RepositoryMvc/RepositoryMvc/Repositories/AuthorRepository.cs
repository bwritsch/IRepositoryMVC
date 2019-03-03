using RepositoryMvc.Contract;
using RepositoryMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryMvc.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        IRepository<Author> authorContext;

       
        public AuthorRepository(IRepository<Author> authorRepository)
        {
            authorContext = authorRepository;
        }


        public List<Author> GeAuthorList()
        {
            var authors = authorContext.GetAll().ToList();

            return authors;
        }
    }
}