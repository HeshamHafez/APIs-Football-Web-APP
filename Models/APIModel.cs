namespace APIs_FinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class APIModel : DbContext
    {
        public APIModel()
            : base("name=APIModel")
        {
        }

        public virtual DbSet<goal> goals { get; set; }
        public virtual DbSet<league> leagues { get; set; }
        public virtual DbSet<match> matches { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<red_cards> red_cards { get; set; }
        public virtual DbSet<tag> tags { get; set; }
        public virtual DbSet<TeamMatch> TeamMatches { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<yellow_cards> yellow_cards { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<league>()
                .HasMany(e => e.teams)
                .WithOptional(e => e.league)
                .WillCascadeOnDelete();

            modelBuilder.Entity<match>()
                .HasMany(e => e.goals)
                .WithOptional(e => e.match)
                .WillCascadeOnDelete();

            modelBuilder.Entity<match>()
                .HasMany(e => e.red_cards)
                .WithOptional(e => e.match)
                .WillCascadeOnDelete();

            modelBuilder.Entity<match>()
                .HasMany(e => e.yellow_cards)
                .WithOptional(e => e.match)
                .WillCascadeOnDelete();

            modelBuilder.Entity<player>()
                .HasMany(e => e.goals)
                .WithOptional(e => e.player)
                .WillCascadeOnDelete();

            modelBuilder.Entity<post>()
                .Property(e => e.post_content)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.players)
                .WithOptional(e => e.team)
                .WillCascadeOnDelete();

            modelBuilder.Entity<team>()
                .HasMany(e => e.red_cards)
                .WithOptional(e => e.team)
                .WillCascadeOnDelete();

            modelBuilder.Entity<team>()
                .HasMany(e => e.yellow_cards)
                .WithOptional(e => e.team)
                .WillCascadeOnDelete();
        }
    }
}
