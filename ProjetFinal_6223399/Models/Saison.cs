using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Saison", Schema = "Saisons")]
public partial class Saison
{
    [Key]
    [Column("SaisonID")]
    public int SaisonId { get; set; }

    public int NumeroSaison { get; set; }

    public DateOnly DateDebut { get; set; }

    public DateOnly DateFin { get; set; }

    public int Profit { get; set; }

    [Column(TypeName = "numeric(3, 1)")]
    public decimal Note { get; set; }

    [InverseProperty("Saison")]
    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}
