using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class classificationMedicalExamination : BaseModule
    {
        public string categoryAr {  get; set; }
        public string categoryNameEn { get; set; }
        public List<medicalExamination> medicalExaminations { get; set; }
    }
}
