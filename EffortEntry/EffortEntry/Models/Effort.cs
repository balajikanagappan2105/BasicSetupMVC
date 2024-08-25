using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_effort")]
public class Effort
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Effort_id { get; set; }
    [ForeignKey("Project")]
    public required int Project_id { get; set; }
    public virtual Project? Project { get; set; }
 
    [ForeignKey("SubProject")]
    public int SubProject_id { get; set; }
    public virtual SubProject? SubProject { get; set; }
 
    [ForeignKey("User")]
    public int User_id { get; set; }
    public virtual User? User { get; set; }
 
    public DateOnly Effort_date { get; set; }
    public int Effort_effort_hrs { get; set; }
 
}