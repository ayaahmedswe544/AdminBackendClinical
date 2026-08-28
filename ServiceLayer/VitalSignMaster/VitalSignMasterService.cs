using Domain.Response;
using DomainLayer;
using DomainLayer.IRepository;
using DomainLayer.Models;
using ServiceLayer.VitalSign.DTOs;
using ServiceLayer.VitalSignMaster.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.VitalSignMaster
{
    public class VitalSignMasterService:IVitalSignMasterService
    {
        private readonly IVitalSignMasterRepository _MasterRepo;
        private readonly IVitalSignRepo _SignRepo;
        private readonly IUnitOfWork _Unit;
        public VitalSignMasterService(IVitalSignMasterRepository masterRepo, IVitalSignRepo signRepo,IUnitOfWork unit)
        {
            _MasterRepo = masterRepo;
            _SignRepo = signRepo;
            _Unit = unit;
        }

        public async Task<GeneralResponse<IEnumerable<VitalSignMasterDto>>> GetVitalSignMastersAsync()
        {
            var VitalSignMasters = _MasterRepo.GetAll();
            var VitalSignMastersDto = VitalSignMasters.Select(vm => new VitalSignMasterDto()
            {
                ID=vm.Id,
                Name=vm.Name
                
            });
            if (VitalSignMasters == null)
            {
                return new GeneralResponse<IEnumerable<VitalSignMasterDto>>()
                {
                    Success = false,
                    Message = "There is no Vital sign masters"
                };
            }
            return new GeneralResponse<IEnumerable<VitalSignMasterDto>>()
            {
                Success = true,
                Message = "Vital sign masters are retrieved successfuly",
                Data=VitalSignMastersDto
            };

        }

        public async Task<GeneralResponse<VitalSignMasterWithVitalSignsDto>> GetVitalSignMasterWithVitalSigns(Guid VitalSignMasterID)
        {
            if(VitalSignMasterID== Guid.Empty)
            {
                return new GeneralResponse<VitalSignMasterWithVitalSignsDto>()
                {
                    Success = false,
                    Message="Vital Sign Master ID is empty"

                };
            }
            var VitalSigns = await _SignRepo.GetVitalSignsByVitalSignMasterId(VitalSignMasterID);
            if(VitalSigns.Success==false)
            {
                return new GeneralResponse<VitalSignMasterWithVitalSignsDto>()
                {
                    Success = false,
                    Message="Failed to retrieve vital signs"

                };
            }
            var VitalSignMaster = await _MasterRepo.FindAsync(v => v.Id == VitalSignMasterID);
            var vitalsignsdto=VitalSigns.Data.Select(v => new VitalSignDto()
            {
                name = v.name,
                dataTypeName = v.dataTypeName,
                description = v.description,
                listValues = v.listValues,
                maxValue = v.maxValue,
                minValue = v.minValue,
                VitalSignMasterId=VitalSignMasterID,
            }).ToList();
            var dto = new VitalSignMasterWithVitalSignsDto()
            {
                Name = VitalSignMaster.Name,
                VitalSigns = vitalsignsdto
            };

            return new GeneralResponse<VitalSignMasterWithVitalSignsDto>()
            {
                Success = true,
                Message = "Vital Sign Master with Vital Signs retrieved successfully",
                Data = dto
            };
        }
    }
}
