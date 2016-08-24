using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Data.Entity;

namespace Day1HomeWork.Repositories
{
    interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }

        void Save();
    }
}

