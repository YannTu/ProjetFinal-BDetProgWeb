using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Keyless]
public partial class VwDetailsGroupe
{
    [Column("GroupeID")]
    public int GroupeId { get; set; }

    [Column("Nom du groupe")]
    [StringLength(30)]
    public string NomDuGroupe { get; set; } = null!;

    [Column("Nom du chef")]
    [StringLength(31)]
    public string NomDuChef { get; set; } = null!;

    [Column("Nombre d'hommes")]
    public int? NombreDHommes { get; set; }

    [Column("Nombre de femmes")]
    public int? NombreDeFemmes { get; set; }

    [Column("Nombre total de membres")]
    public int? NombreTotalDeMembres { get; set; }

    [Column("PersonnageGroupeID")]
    public int? PersonnageGroupeId { get; set; }

    [Column("PersonnageID")]
    public int? PersonnageId { get; set; }
}
