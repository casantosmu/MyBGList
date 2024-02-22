using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models;

[Table("board_games_domains")]
public class BoardGamesDomains
{
    [Column("board_game_id")]
    [Key]
    [Required]
    public int BoardGameId { get; set; }

    [Column("domain_id")] [Key] [Required] public int DomainId { get; set; }

    [Column("created_date")] [Required] public DateTime CreatedDate { get; set; }

    public BoardGame? BoardGame { get; set; }

    public Domain? Domain { get; set; }
}