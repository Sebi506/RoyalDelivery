using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoyalDelivery.Models.DBObjects;

namespace RoyalDelivery.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdresaLivrare> AdresaLivrares { get; set; } = null!;
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Colet> Colets { get; set; } = null!;
        public virtual DbSet<ContactClient> ContactClients { get; set; } = null!;
        public virtual DbSet<DateLivrare> DateLivrares { get; set; } = null!;
        public virtual DbSet<InformatiiPlata> InformatiiPlata { get; set; } = null!;
        public virtual DbSet<Livrator> Livrators { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AdresaLivrare>(entity =>
            {
                entity.HasKey(e => e.IdAdresaLivrare)
                    .HasName("PK__AdresaLi__D454F8B6A39D7CFE");

                entity.ToTable("AdresaLivrare");

                entity.Property(e => e.IdAdresaLivrare)
                    .ValueGeneratedNever()
                    .HasColumnName("id_adresaLivrare");

                entity.Property(e => e.InformatiiAditionale)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("informatii_aditionale");

                entity.Property(e => e.Judet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("judet");

                entity.Property(e => e.Numar)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numar");

                entity.Property(e => e.Oras)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("oras");

                entity.Property(e => e.Strada)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strada");
            });
            /*
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });
            */
            /*
            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });
            */
            /*
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });
            */
            /*
            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });
            */
            /*
            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });
            */
            /*
            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            */
            modelBuilder.Entity<Colet>(entity =>
            {
                entity.HasKey(e => e.IdColet)
                    .HasName("PK__Colet__7CF218C9BF5307B5");

                entity.ToTable("Colet");

                entity.Property(e => e.IdColet)
                    .ValueGeneratedNever()
                    .HasColumnName("id_colet");

                entity.Property(e => e.Awb)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("awb");

                entity.Property(e => e.IdDateLivrare).HasColumnName("id_dateLivrare");

                entity.Property(e => e.IdInformatiiPlata).HasColumnName("id_informatiiPlata");

                entity.Property(e => e.IdLivrator).HasColumnName("id_livrator");

                entity.Property(e => e.LocatieDepozit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("locatie_depozit");

                entity.Property(e => e.StareColet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("stare_colet");

                entity.HasOne(d => d.IdDateLivrareNavigation)
                    .WithMany(p => p.Colets)
                    .HasForeignKey(d => d.IdDateLivrare)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Colet__id_dateLi__5535A963");

                entity.HasOne(d => d.IdInformatiiPlataNavigation)
                    .WithMany(p => p.Colets)
                    .HasForeignKey(d => d.IdInformatiiPlata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Colet__id_inform__5629CD9C");

                entity.HasOne(d => d.IdLivratorNavigation)
                    .WithMany(p => p.Colets)
                    .HasForeignKey(d => d.IdLivrator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Colet__id_livrat__571DF1D5");
            });

            modelBuilder.Entity<ContactClient>(entity =>
            {
                entity.HasKey(e => e.IdContactClient)
                    .HasName("PK__ContactC__2E1C8F0A7841F675");

                entity.ToTable("ContactClient");

                entity.Property(e => e.IdContactClient)
                    .ValueGeneratedNever()
                    .HasColumnName("id_contactClient");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("numar_telefon");

                entity.Property(e => e.Nume)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nume");

                entity.Property(e => e.Prenume)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("prenume");
            });

            modelBuilder.Entity<DateLivrare>(entity =>
            {
                entity.HasKey(e => e.IdDateLivrare)
                    .HasName("PK__DateLivr__55709180799E6F76");

                entity.ToTable("DateLivrare");

                entity.Property(e => e.IdDateLivrare)
                    .ValueGeneratedNever()
                    .HasColumnName("id_dateLivrare");

                entity.Property(e => e.DataLivrare)
                    .HasColumnType("date")
                    .HasColumnName("data_livrare");

                entity.Property(e => e.IdAdresaLivrare).HasColumnName("id_adresaLivrare");

                entity.Property(e => e.IdContactClient).HasColumnName("id_contactClient");

                entity.HasOne(d => d.IdAdresaLivrareNavigation)
                    .WithMany(p => p.DateLivrares)
                    .HasForeignKey(d => d.IdAdresaLivrare)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DateLivra__id_ad__5165187F");

                entity.HasOne(d => d.IdContactClientNavigation)
                    .WithMany(p => p.DateLivrares)
                    .HasForeignKey(d => d.IdContactClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DateLivra__id_co__52593CB8");
            });

            modelBuilder.Entity<InformatiiPlata>(entity =>
            {
                entity.HasKey(e => e.IdInformatiiPlata)
                    .HasName("PK__Informat__1D5591281C4A7C29");

                entity.Property(e => e.IdInformatiiPlata)
                    .ValueGeneratedNever()
                    .HasColumnName("id_informatiiPlata");

                entity.Property(e => e.SumaDatorata).HasColumnName("suma_datorata");

                entity.Property(e => e.TipPlata)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tip_plata");
            });

            modelBuilder.Entity<Livrator>(entity =>
            {
                entity.HasKey(e => e.IdLivrator)
                    .HasName("PK__Livrator__E47285F858BC0149");

                entity.ToTable("Livrator");

                entity.Property(e => e.IdLivrator)
                    .ValueGeneratedNever()
                    .HasColumnName("id_livrator");

                entity.Property(e => e.JudetActivitate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("judet_activitate");

                entity.Property(e => e.Nume)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nume");

                entity.Property(e => e.Prenume)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("prenume");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
