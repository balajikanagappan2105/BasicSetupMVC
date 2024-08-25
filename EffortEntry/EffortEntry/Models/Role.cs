using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_role")]
public class Role

{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Role_id { get; set; }
 
    [StringLength(maximumLength: 20, MinimumLength = 2)]
    public required string Role_name { get; set; }
    public required string Role_description { get; set; }
 
}

 