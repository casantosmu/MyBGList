using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyBGList.Models;

[Table("board_games")]
public class BoardGame
{
    [Column("board_game_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")] [Required] public string Name { get; set; } = null!;

    [Column("year")] [Required] public int Year { get; set; }

    [Column("min_players")] [Required] public int MinPlayers { get; set; }

    [Column("max_players")] [Required] public int MaxPlayers { get; set; }

    [Column("play_time")] [Required] public int PlayTime { get; set; }

    [Column("min_age")] [Required] public int MinAge { get; set; }

    [Column("users_rated")] [Required] public int UsersRated { get; set; }

    [Column("rating_average")]
    [Required]
    [Precision(4, 2)]
    public decimal RatingAverage { get; set; }

    [Column("bgg_rank")] [Required] public int BggRank { get; set; }

    [Column("complexity_average")]
    [Required]
    [Precision(4, 2)]
    public decimal ComplexityAverage { get; set; }

    [Column("owned_users")] [Required] public int OwnedUsers { get; set; }

    [Column("created_date")] [Required] public DateTime CreatedDate { get; set; }

    [Column("last_modified_date")]
    [Required]
    public DateTime LastModifiedDate { get; set; }

    public ICollection<BoardGamesDomains>? BoardGamesDomains { get; set; }

    public ICollection<BoardGamesMechanics>? BoardGamesMechanics { get; set; }
}