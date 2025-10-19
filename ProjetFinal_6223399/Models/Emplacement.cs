using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Emplacement", Schema = "Groupes")]
public partial class Emplacement
{
    [Key]
    [Column("EmplacementID")]
    public int EmplacementId { get; set; }

    [Column("Emplacement")]
    [StringLength(30)]
    public string Emplacement1 { get; set; } = null!;

    [Column("GroupeID")]
    public int GroupeId { get; set; }

    [ForeignKey("GroupeId")]
    [InverseProperty("Emplacements")]
    public virtual Groupe Groupe { get; set; } = null!;
}
