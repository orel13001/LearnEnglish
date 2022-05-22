using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnEnglish.WPF.Models.EntityFramework
{
    public partial class LearnEnglishContext : DbContext
    {
        public LearnEnglishContext()
        {
        }

        public LearnEnglishContext(DbContextOptions<LearnEnglishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DictionaryIrregularVerb> DictionaryIrregularVerbs { get; set; } = null!;
        public virtual DbSet<DictionaryPhrase> DictionaryPhrases { get; set; } = null!;
        public virtual DbSet<DictionaryWord> DictionaryWords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LearnEnglish;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryIrregularVerb>(entity =>
            {
                entity.ToTable("Dictionary_irregular_verbs");

                entity.Property(e => e.Future).HasMaxLength(50);

                entity.Property(e => e.FutureTranscription)
                    .HasMaxLength(50)
                    .HasColumnName("Future_Transcription");

                entity.Property(e => e.FutureVois).HasColumnName("Future_Vois");

                entity.Property(e => e.Past).HasMaxLength(50);

                entity.Property(e => e.PastTranscription)
                    .HasMaxLength(50)
                    .HasColumnName("Past_Transcription");

                entity.Property(e => e.PastVois).HasColumnName("Past_Vois");

                entity.Property(e => e.Present).HasMaxLength(50);

                entity.Property(e => e.PresentTranscription)
                    .HasMaxLength(50)
                    .HasColumnName("Present_Transcription");

                entity.Property(e => e.PresentVois).HasColumnName("Present_Vois");

                entity.Property(e => e.Rassian1)
                    .HasMaxLength(50)
                    .HasColumnName("Rassian_1");

                entity.Property(e => e.Rassian2)
                    .HasMaxLength(50)
                    .HasColumnName("Rassian_2");
            });

            modelBuilder.Entity<DictionaryPhrase>(entity =>
            {
                entity.ToTable("Dictionary_Phrase");

                entity.Property(e => e.English).HasMaxLength(500);

                entity.Property(e => e.Russian1)
                    .HasMaxLength(500)
                    .HasColumnName("Russian_1");

                entity.Property(e => e.Russian2)
                    .HasMaxLength(500)
                    .HasColumnName("Russian_2");

                entity.Property(e => e.Russian3)
                    .HasMaxLength(500)
                    .HasColumnName("Russian_3");

                entity.Property(e => e.Transcription).HasMaxLength(500);
            });

            modelBuilder.Entity<DictionaryWord>(entity =>
            {
                entity.ToTable("Dictionary_Word");

                entity.Property(e => e.English).HasMaxLength(50);

                entity.Property(e => e.Russian1)
                    .HasMaxLength(50)
                    .HasColumnName("Russian_1");

                entity.Property(e => e.Russian2)
                    .HasMaxLength(50)
                    .HasColumnName("Russian_2");

                entity.Property(e => e.Russian3)
                    .HasMaxLength(50)
                    .HasColumnName("Russian_3");

                entity.Property(e => e.Transcription).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
