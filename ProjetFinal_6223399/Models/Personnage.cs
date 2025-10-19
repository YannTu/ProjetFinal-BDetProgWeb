using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Personnage", Schema = "Personnages")]
[Index("Statut", Name = "IX_Personnage_Statut")]
[Index("Identifiant", Name = "UC_Personnage_Identifiant", IsUnique = true)]
public partial class Personnage
{
    [Key]
    [Column("PersonnageID")]
    public int PersonnageId { get; set; }

    [StringLength(15)]
    public string Prenom { get; set; } = null!;

    [StringLength(15)]
    public string? Nom { get; set; }

    [StringLength(10)]
    public string Genre { get; set; } = null!;

    [StringLength(20)]
    public string Ethnicite { get; set; } = null!;

    public int? AgeDebutSerie { get; set; }

    public int? AgeFinSerie { get; set; }

    [StringLength(20)]
    public string Statut { get; set; } = null!;

    public Guid Identifiant { get; set; }

    public byte[]? Image { get; set; }

    [InverseProperty("Personnage")]
    public virtual ICollection<PersonnageEpisode> PersonnageEpisodes { get; set; } = new List<PersonnageEpisode>();

    [InverseProperty("Personnage")]
    public virtual ICollection<PersonnageGroupe> PersonnageGroupes { get; set; } = new List<PersonnageGroupe>();
}
