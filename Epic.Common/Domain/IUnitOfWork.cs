using System;

namespace Epic.Common.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}