using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        void Save();
    }
}