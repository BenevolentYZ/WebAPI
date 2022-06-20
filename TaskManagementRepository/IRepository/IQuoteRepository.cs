using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain;
using TaskManagementDomain.Models;

namespace TaskManagementRepository.IRepository
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        void Update(Quote obj);
    }
}
