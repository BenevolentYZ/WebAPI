using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain;
using TaskManagementRepository.IRepository;

namespace TaskManagementRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebAPIDbContext _context;

        public UnitOfWork(WebAPIDbContext db)
        {
            _context = db;
            Quote = new QuoteRepository(_context);
        }
        public IQuoteRepository Quote { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
