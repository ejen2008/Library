using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.DAL.Entities;
using Library.DAL.EF;

namespace Library.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LibraryContext _db;
        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;
        private bool _disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            _db = new LibraryContext(connectionString);
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_db);
                }
                return _authorRepository;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_db);
                }
                return _bookRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                IfNotDisposed(disposing);
                _disposed = true;
            }
        }
        private void IfNotDisposed(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}