using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Day1HomeWork.Models;

namespace Day1HomeWork.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public EFUnitOfWork()
        {
            Context = new Model1();
        }

        public void create()
        {
           
        }
        public void edit()
        {

        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
