using System;
using Epic.Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace Epic.Interview.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private bool disposed;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Commit()
        {
            context.SaveChanges();
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) context.Dispose();

            disposed = true;
        }
    }
}