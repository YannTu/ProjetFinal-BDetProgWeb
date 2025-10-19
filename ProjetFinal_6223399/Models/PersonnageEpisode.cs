using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("PersonnageEpisode", Schema = "Personnages")]
[Index("Acteur", Name = "UC_PersonnageEpisode_Acteur", IsUnique = true)]
public partial class PersonnageEpisode
{
    [Key]
    [Column("PersonnageEpisodeID")]
    public int PersonnageEpisodeId { get; set; }

    [StringLength(30)]
    public string Acteur { get; set; } = null!;

    [StringLength(20)]
    public string PremiereApparition { get; set; } = null!;

    [Column("EpisodeID")]
    public int EpisodeId { get; set; }

    [Column("PersonnageID")]
    public int PersonnageId { get; set; }

    [ForeignKey("EpisodeId")]
    [InverseProperty("PersonnageEpisodes")]
    public virtual Episode Episode { get; set; } = null!;

    [ForeignKey("PersonnageId")]
    [InverseProperty("PersonnageEpisodes")]
    public virtual Personnage Personnage { get; set; } = null!;
}
