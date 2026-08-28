using Domain.Response;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainLayer; 

namespace DatabaseLayer.Repository
{
    public class VitalSignRepo : BaseRepository<DomainLayer.Models.VitalSign>, DomainLayer.IRepository.IVitalSignRepo
    {
        public VitalSignRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<GeneralResponse<IEnumerable<VitalSign>>> GetVitalSignsByVitalSignMasterId(Guid vitalSignMasterId)
        {
            var exist = await _context.vitalSignMasters.FindAsync(vitalSignMasterId);
            if (exist == null) {


                return new GeneralResponse<IEnumerable<VitalSign>>
                { 
                    Success = false,
                    Message = "no vital signs are found"
                };
            }
           var vitalSigns = _context.vitalSigns.Where(vs => vs.VitalSignMasterId == vitalSignMasterId).ToList();
            if (vitalSigns.Count == 0)
            {
                return new GeneralResponse<IEnumerable<VitalSign>>
                {
                    Success = true,
                    Message = "Vital sign master exists but no vital signs are found"
                };
            }
            var response = new GeneralResponse<IEnumerable<VitalSign>>
            {
                Data = vitalSigns,
                Success = true,
                Message = "Vital signs retrieved successfully."
            };
            return response;
        }
    }
}
