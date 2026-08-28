using Domain.Response;
using ServiceLayer.VitalSignMaster.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.VitalSignMaster
{
    public interface IVitalSignMasterService
    {
        Task<GeneralResponse<VitalSignMasterWithVitalSignsDto>> GetVitalSignMasterWithVitalSigns(Guid VitalSignMasterID);
    }
}
