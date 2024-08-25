using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_location")]
public class Location
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Location_id { get; set; }
 
    [Required(ErrorMessage = "Location Name field is required.")]
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string Location_name { get; set; }
    public bool Sunday { get; set; }
    public bool Monday { get; set; }
    public bool Tuesday { get; set; }
    public bool Wednesday { get; set; }
    public bool Thursday { get; set; }
    public bool Friday { get; set; }
    public bool Saturday { get; set; }
}