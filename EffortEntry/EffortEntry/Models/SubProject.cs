using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortEntry.Models;
 
[Table("tms_subproject")]
public class SubProject

{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubProject_id { get; set; }

    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string SubProject_name { get; set; }
 
    [ForeignKey("Project")]
    public required int Project_id { get; set; }
    public virtual Project? Project { get; set; }
 
    public required string SubProject_description { get; set; }
    public required bool SubProject_active { get; set; }
 
}

 