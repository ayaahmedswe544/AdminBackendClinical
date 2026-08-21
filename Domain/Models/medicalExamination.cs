using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer.Models
{
    public class medicalExamination : BaseModule
    {
        public string nameAr {  get; set; }
        public string code { get; set; }
        public string nameEn { get; set; }

        [ForeignKey(nameof(classification))]
        public Guid classificationId { get; set; }
        public classificationMedicalExamination classification { get; set; }
    }
}
