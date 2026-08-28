using Domain.Response;
using DomainLayer.Models;
using ServiceLayer.VitalSignMaster.DTOs;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.VitalSignMaster
{
    public interface IVitalSignMasterService
    {
        Task<GeneralResponse<VitalSignMasterWithVitalSignsDto>> GetVitalSignMasterWithVitalSigns(Guid VitalSignMasterID);
        Task<GeneralResponse<IEnumerable<VitalSignMasterWithVitalSignsDto>>> GetVitalSignMastersAsync();
    }
}
