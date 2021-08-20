using Books.DataAccess.DataContext;
using Books.DataAccess.Repositories.IRepositories;
using Books.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.DataAccess.Repositories
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly DatabaseContext _databaseContext;
        public BooksRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
