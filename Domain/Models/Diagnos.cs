using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Models;

public class Diagnos : BaseModule
{
        public string Notes {get; set;}   


        [Required]
        [ForeignKey("Appointment")]
        public Guid AppointmentId {get; set;}
        public Appointment Appointment {get; set;}

        
        [Required]
        [ForeignKey("DiagnosMaster")]
        public Guid DiagnosMasterId {get; set;}
        public DiagnosMaster DiagnosMaster {get; set;}
}
