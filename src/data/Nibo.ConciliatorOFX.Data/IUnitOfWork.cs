using System;

namespace Nibo.ConciliatorOFX.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
