
using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainLayer.Models;

public class Appointment : BaseModule
{

        [Required]
        [ForeignKey("Doctor")]
        public Guid DoctorId {get; set;}
        
        public Doctor Doctor { get; set; }
        


        [Required]
        [ForeignKey("Patient")]
        public Guid PatientId {get; set;}
        
        
        public Patient Patient { get; set; }
        

        [Required]
        public DateOnly AppointmentDate { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; 
        
        [StringLength(500)]
        public string? Notes { get; set; }
        [Required]
        public double Deposit {get; set;}
        //public Prescription? Prescription {get; set;}
        // public List<VitalSign>? VitalSigns { get; set; } 
}
