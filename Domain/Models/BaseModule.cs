using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class BaseModule
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set ; }
    public DateTime? UpdatedAt { get; set;}
    public bool IsUpdated { get; set;}
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    
   
    [ForeignKey("Created")]
    public string? CreatedBy { get; set; }
    public ApplicationUser? Created { get; set; }

    

    [ForeignKey("Updated")]
    public string? UpdatedBy { get; set; }
    public ApplicationUser? Updated { get; set; }



    [ForeignKey("Deleted")]
    public string? DeletedBy { get; set; }
    public ApplicationUser? Deleted { get; set; }


    public bool IsActive { get; set; } // Default to active
   
    public void Create(Guid userId)
    {
        Id= Guid.NewGuid();
        IsUpdated = false;
        IsActive = false;
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
        CreatedBy =Convert.ToString(userId);
    }
   
    public void MarkAsUpdated(Guid userId)
    {
        IsUpdated = true;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = Convert.ToString(userId);
    }

    
    
    public void MarkAsDeleted(Guid userId){
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = Convert.ToString(userId);
    }

}
