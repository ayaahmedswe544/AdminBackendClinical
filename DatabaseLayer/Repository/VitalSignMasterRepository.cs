using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Repository
{
    public class VitalSignMasterRepository : BaseRepository<DomainLayer.Models.VitalSignMaster>, DomainLayer.IRepository.IVitalSignMasterRepository
    {
        public VitalSignMasterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
