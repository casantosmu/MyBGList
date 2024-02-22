using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models;

[Table("board_games_mechanics")]
public class BoardGamesMechanics
{
    [Column("board_game_id")]
    [Key]
    [Required]
    public int BoardGameId { get; set; }

    [Column("mechanic_id")]
    [Key]
    [Required]
    public int MechanicId { get; set; }

    [Column("created_date")] [Required] public DateTime CreatedDate { get; set; }

    public BoardGame? BoardGame { get; set; }

    public Mechanic? Mechanic { get; set; }
}