using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.IRepository;
using DomainLayer;

namespace DatabaseLayer
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IVitalSignMasterRepository VitalSignMasterRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public UnitOfWork(AppDbContext context,IVitalSignMasterRepository vitalSignMasterRepository, IApplicationUserRepository applicationUserRepository)
        {
            _context = context;
            VitalSignMasterRepository = vitalSignMasterRepository;
            ApplicationUserRepository = applicationUserRepository;
        }
        public async Task<int> SaveChangesAsync()
        {
  return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
