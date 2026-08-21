using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer.Models
{
    public class saveExamination :BaseModule
    {
        public string Notes { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey(nameof(medicalExamination))]
        public Guid ExaminationId {  get; set; }
        public medicalExamination medicalExamination { get; set; }

    }
}
