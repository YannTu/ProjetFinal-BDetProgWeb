using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Episode", Schema = "Saisons")]
public partial class Episode
{
    [Key]
    [Column("EpisodeID")]
    public int EpisodeId { get; set; }

    public int NumeroEpisode { get; set; }

    [StringLength(50)]
    public string NomEpisode { get; set; } = null!;

    public DateOnly DateTransmission { get; set; }

    public int DureeMinutes { get; set; }

    [Column(TypeName = "numeric(3, 1)")]
    public decimal Note { get; set; }

    [StringLength(30)]
    public string NomRealisateur { get; set; } = null!;

    [Column("SaisonID")]
    public int SaisonId { get; set; }

    [InverseProperty("Episode")]
    public virtual ICollection<PersonnageEpisode> PersonnageEpisodes { get; set; } = new List<PersonnageEpisode>();

    [ForeignKey("SaisonId")]
    [InverseProperty("Episodes")]
    public virtual Saison Saison { get; set; } = null!;
}
