using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.VitalSign.DTOs
{
    public class VitalSignDto
    {
        public Guid ID { get; set; }
        public Guid VitalSignMasterId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dataTypeName { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public List<string> listValues { get; set; }
    }
}
