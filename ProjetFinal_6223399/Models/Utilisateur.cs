using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_6223399.Models;

[Table("Utilisateur", Schema = "Utilisateurs")]
[Index("Pseudo", Name = "UC_Utilisateur_Pseudo", IsUnique = true)]
public partial class Utilisateur
{
    [Key]
    [Column("UtilisateurID")]
    public int UtilisateurId { get; set; }

    [StringLength(50)]
    public string Pseudo { get; set; } = null!;

    [MaxLength(64)]
    public byte[] MotDePasseHache { get; set; } = null!;

    [MaxLength(16)]
    public byte[] Sel { get; set; } = null!;
}
