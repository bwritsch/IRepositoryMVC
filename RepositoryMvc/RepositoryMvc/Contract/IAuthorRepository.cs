using RepositoryMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryMvc.Contract
{
    public interface IAuthorRepository
    {

        List<Author> GeAuthorList();

    }
}