using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Groupe", Schema = "Groupes")]
public partial class Groupe
{
    [Key]
    [Column("GroupeID")]
    public int GroupeId { get; set; }

    [StringLength(30)]
    public string Nom { get; set; } = null!;

    [StringLength(20)]
    public string PremiereApparition { get; set; } = null!;

    [StringLength(20)]
    public string Statut { get; set; } = null!;

    [InverseProperty("Groupe")]
    public virtual ICollection<Emplacement> Emplacements { get; set; } = new List<Emplacement>();

    [InverseProperty("Groupe")]
    public virtual ICollection<PersonnageGroupe> PersonnageGroupes { get; set; } = new List<PersonnageGroupe>();
}
