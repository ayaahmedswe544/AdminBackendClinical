using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class saveVitalSign : BaseModule
    {
        [Required]
        [ForeignKey(nameof(VitalSign))]
        public Guid VitalSignId { get; set; }
        public VitalSignMaster VitalSign { get; set; }

        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string value { get; set; }
    }
}
