using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_project")]
public class Project
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Project_id { get; set; }
 
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string Project_name { get; set; }

    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string Divition_name { get; set; }

    public required string Project_description { get; set; }

    public required bool Project_active { get; set; }
 
}

 