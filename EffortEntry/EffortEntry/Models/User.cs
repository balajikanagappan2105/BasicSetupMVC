using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace EffortEntry.Models;
 
[Table("tms_user")]
public class User
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int User_id { get; set; }
 
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string User_name { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 2)]
    public required string User_email { get; set; }
    public required string User_userid { get; set; }
 
    [ForeignKey("Location")]
    public required int Location_id { get; set; }
    public virtual Location? Location { get; set; }
 
    [ForeignKey("Role")]
    public required int Role_id { get; set; }
    public virtual Role? Role { get; set; }
 
    public DateOnly User_start_date { get; set; }
    public DateOnly User_last_date { get; set; }
    public required string User_description { get; set; }
    public required bool User_active { get; set; }
}