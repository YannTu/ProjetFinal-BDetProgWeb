using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_6223399.Models;

namespace ProjetFinal_6223399.Data;

public partial class ProjetFinal6223399Context : DbContext
{
    public ProjetFinal6223399Context()
    {
    }

    public ProjetFinal6223399Context(DbContextOptions<ProjetFinal6223399Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Emplacement> Emplacements { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Groupe> Groupes { get; set; }

    public virtual DbSet<Personnage> Personnages { get; set; }

    public virtual DbSet<PersonnageEpisode> PersonnageEpisodes { get; set; }

    public virtual DbSet<PersonnageGroupe> PersonnageGroupes { get; set; }

    public virtual DbSet<Saison> Saisons { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<VwDetailsGroupe> VwDetailsGroupes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ProjetFinal_6223399");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83F4EF7A346");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Emplacement>(entity =>
        {
            entity.HasKey(e => e.EmplacementId).HasName("PK_Emplacement_EmplacementID");

            entity.HasOne(d => d.Groupe).WithMany(p => p.Emplacements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emplacement_GroupeID");
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.EpisodeId).HasName("PK_Episode_EpisodeID");

            entity.HasOne(d => d.Saison).WithMany(p => p.Episodes).HasConstraintName("FK_Episode_SaisonID");
        });

        modelBuilder.Entity<Groupe>(entity =>
        {
            entity.HasKey(e => e.GroupeId).HasName("PK_Groupe_GroupeID");
        });

        modelBuilder.Entity<Personnage>(entity =>
        {
            entity.HasKey(e => e.PersonnageId).HasName("PK_Personnage_PersonnageID");

            entity.Property(e => e.Identifiant).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<PersonnageEpisode>(entity =>
        {
            entity.HasKey(e => e.PersonnageEpisodeId).HasName("PK_PersonnageEpisode_PersonnageEpisodeID");

            entity.HasOne(d => d.Episode).WithMany(p => p.PersonnageEpisodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonnageEpisode_EpisodeID");

            entity.HasOne(d => d.Personnage).WithMany(p => p.PersonnageEpisodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonnageEpisode_PersonnageID");
        });

        modelBuilder.Entity<PersonnageGroupe>(entity =>
        {
            entity.HasKey(e => e.PersonnageGroupeId).HasName("PK_PersonnageGroupe_PersonnageGroupeID");

            entity.HasOne(d => d.Groupe).WithMany(p => p.PersonnageGroupes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonnageGroupe_GroupeID");

            entity.HasOne(d => d.Personnage).WithMany(p => p.PersonnageGroupes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonnageGroupe_PersonnageID");
        });

        modelBuilder.Entity<Saison>(entity =>
        {
            entity.HasKey(e => e.SaisonId).HasName("PK_Saison_SaisonID");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.UtilisateurId).HasName("PK_Utilisateur_UtilisateurID");
        });

        modelBuilder.Entity<VwDetailsGroupe>(entity =>
        {
            entity.ToView("vw_DetailsGroupe", "Groupes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
