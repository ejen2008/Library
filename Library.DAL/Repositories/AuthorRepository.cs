﻿using Library.DAL.EF;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private LibraryContext _dbLibrary;

        public AuthorRepository(LibraryContext context)
        {
            _dbLibrary = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbLibrary.Authors;
        }
        public Author Get(int id)
        {
            return _dbLibrary.Authors.Find(id);
        }
        public void Create(Author author)
        {
            _dbLibrary.Authors.Add(author);
        }
        public void Update(Author author)
        {
            _dbLibrary.Entry(author).State = EntityState.Modified;
        }
        public IEnumerable<Author> Find(Func<Author, Boolean> predicate)
        {
            return _dbLibrary.Authors.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Author author = _dbLibrary.Authors.Find(id);
            if (author != null)
            {
                _dbLibrary.Authors.Remove(author);
            }
        }
    }
}