using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models;

public class Investigation : BaseModule
{
        public string Notes {get; set;}   


        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId {get; set;}
        public Appointment Appointment {get; set;}

        
        [Required]
        [ForeignKey("InvestigationMaster")]
        public Guid InvestigationMasterId {get; set;}
        public InvestigationMaster InvestigationMaster {get; set;}
}
