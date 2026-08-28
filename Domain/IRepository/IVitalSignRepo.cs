using Domain.IRepository;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.IRepository
{
    public interface IVitalSignRepo : IBaseRepository<DomainLayer.Models.VitalSign>
    {
        Task<GeneralResponse<IEnumerable<DomainLayer.Models.VitalSign>>> GetVitalSignsByVitalSignMasterId(Guid vitalSignMasterId);
    }

}
