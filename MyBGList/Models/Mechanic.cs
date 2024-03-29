using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models;

[Table("mechanics")]
public class Mechanic
{
    [Column("mechanic_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")] [Required] public string Name { get; set; } = null!;

    [Column("created_date")] [Required] public DateTime CreatedDate { get; set; }

    [Column("last_modified_date")]
    [Required]
    public DateTime LastModifiedDate { get; set; }

    public ICollection<BoardGamesMechanics>? BoardGamesMechanics { get; set; }
}