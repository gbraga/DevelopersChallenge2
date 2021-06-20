using System;

namespace Nibo.ConciliatorOFX.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConciliatorOFXContext _context;

        public UnitOfWork(ConciliatorOFXContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
            Dispose();
        }

        public void Dispose() => _context.Dispose();
    }
}
