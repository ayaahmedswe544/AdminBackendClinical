using ServiceLayer.VitalSign.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.VitalSignMaster.DTOs
{
    public class VitalSignMasterWithVitalSignsDto
    {
        public string Name { get; set; }
        public IEnumerable<VitalSignDto> VitalSigns { get; set; }
    }
}
