using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_project_association")]
public class ProjectAssociation
{
 
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectAssociation_id { get; set; }
 
    [ForeignKey("SubProject")]
    public int SubProject_id { get; set; }
    public virtual SubProject? SubProject { get; set; }
 
 
    [ForeignKey("User")]
    public int User_id { get; set; }
    public virtual User? User { get; set; }
}