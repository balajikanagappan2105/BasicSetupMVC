
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortEntry.Models;

[Table("tms_discipline")]
public class Discipline
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Discipline_id { get; set; }
 
    [StringLength(maximumLength: 20, MinimumLength = 2)]
    public required string Discipline_name { get; set; }
    public required string Discipline_remarks { get; set; }
    public required bool Discipline_active { get; set; }
}
