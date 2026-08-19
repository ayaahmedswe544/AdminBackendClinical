
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Prescription : BaseModule
{
    public string Notes {get; set;}   


    [Required]
    [ForeignKey("Appointment")]
    public Guid AppointmentId {get; set;}
    public Appointment Appointment {get; set;}
        
    public DateOnly from { get; set; }
    public DateOnly to { get; set; } 
    public int Frequency { get; set; } 
    public int type { get; set; } 

    public int dose { get; set; }


    [Required]
    [ForeignKey("Drug")]
    public Guid DrugId {get; set;}
    public Drug Drug {get; set;}
}
