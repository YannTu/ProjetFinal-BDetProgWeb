using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("PersonnageGroupe", Schema = "Personnages")]
[Index("GroupeId", "PersonnageId", Name = "IX_PersonnageGroupe_GroupeId_PersonnageId")]
public partial class PersonnageGroupe
{
    [Key]
    [Column("PersonnageGroupeID")]
    public int PersonnageGroupeId { get; set; }

    public bool EstChef { get; set; }

    [Column("GroupeID")]
    public int GroupeId { get; set; }

    [Column("PersonnageID")]
    public int PersonnageId { get; set; }

    [ForeignKey("GroupeId")]
    [InverseProperty("PersonnageGroupes")]
    public virtual Groupe Groupe { get; set; } = null!;

    [ForeignKey("PersonnageId")]
    [InverseProperty("PersonnageGroupes")]
    public virtual Personnage Personnage { get; set; } = null!;
}
