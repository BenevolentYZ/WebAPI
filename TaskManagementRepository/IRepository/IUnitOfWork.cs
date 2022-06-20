using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementRepository.IRepository
{
    public interface IUnitOfWork
    {
        IQuoteRepository Quote { get; }

        void Save();
    }
}
