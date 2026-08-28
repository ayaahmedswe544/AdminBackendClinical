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

        private readonly IUnitOfWork _Unit;
        public VitalSignMasterService(IUnitOfWork unit)
        {

            _Unit = unit;
        }

        public async Task<GeneralResponse<IEnumerable<VitalSignMasterWithVitalSignsDto>>> GetVitalSignMastersAsync()
        {
            var VitalSignMasters = await _Unit.VitalSignMasterRepository.GetAllAsync();
            var VitalSignMastersDto = VitalSignMasters.Select(vm => new VitalSignMasterDto()
            {
                ID=vm.Id,
                Name=vm.Name
                
            });
            List<VitalSignMasterWithVitalSignsDto> VitalSignMastersWithVitalSignsDto = new List<VitalSignMasterWithVitalSignsDto>();

           foreach(var vm in VitalSignMastersDto)
            {
                var VitalSigns = await _Unit.VitalSignRepo.GetVitalSignsByVitalSignMasterId(vm.ID);
                if (VitalSigns.Success == false)
                {
                    return new GeneralResponse<IEnumerable<VitalSignMasterWithVitalSignsDto>>()
                    {
                        Success = false,
                        Message = "Failed to retrieve vital signs for Vital Sign Master ID: " + vm.ID
                    };
                }
                var vitalsignsdto = VitalSigns.Data.Select(v => new VitalSignDto()
                {
                    ID = v.Id,
                    name = v.name,
                    dataTypeName = v.dataTypeName,
                    description = v.description,
                    listValues = v.listValues,
                    maxValue = v.maxValue,
                    minValue = v.minValue,
                    VitalSignMasterId = vm.ID,
                }).ToList();
                var dto = new VitalSignMasterWithVitalSignsDto()
                {
                    ID = vm.ID,
                    Name = vm.Name,
                    VitalSigns = vitalsignsdto
                };
                VitalSignMastersWithVitalSignsDto.Add(dto);
            }
            return new GeneralResponse<IEnumerable<VitalSignMasterWithVitalSignsDto>>()
            {
                Success = true,
                Message = "Vital Sign Masters with Vital Signs retrieved successfully",
                Data = VitalSignMastersWithVitalSignsDto
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
            var VitalSigns = await _Unit.VitalSignRepo.GetVitalSignsByVitalSignMasterId(VitalSignMasterID);
            if(VitalSigns.Success==false)
            {
                return new GeneralResponse<VitalSignMasterWithVitalSignsDto>()
                {
                    Success = false,
                    Message="Failed to retrieve vital signs"

                };
            }
            var VitalSignMaster = await _Unit.VitalSignMasterRepository.FindAsync(v => v.Id == VitalSignMasterID);
            var vitalsignsdto=VitalSigns.Data.Select(v => new VitalSignDto()
            {
                ID = v.Id,
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
                ID = VitalSignMaster.Id,
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
