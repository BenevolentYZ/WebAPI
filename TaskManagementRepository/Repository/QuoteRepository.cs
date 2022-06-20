using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain;
using TaskManagementDomain.Models;
using TaskManagementRepository.IRepository;

namespace TaskManagementRepository.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        private WebAPIDbContext _context;

        public QuoteRepository(WebAPIDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Quote obj)
        {
            _context.Quotes.Update(obj);
        }
    }
}
