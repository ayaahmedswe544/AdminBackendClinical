using DomainLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IUnitOfWork : IDisposable
    {
        
        public IVitalSignMasterRepository VitalSignMasterRepository { get; }
        public IApplicationUserRepository ApplicationUserRepository { get; }

         Task<int> SaveChangesAsync();



    }
}
