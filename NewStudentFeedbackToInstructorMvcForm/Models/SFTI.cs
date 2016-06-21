namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SFTI : DbContext
    {
        public SFTI()
            : base("name=SFTI")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<AccessLogBatch> AccessLogBatches { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<BatchPresentationXLST> BatchPresentationXLSTs { get; set; }
        public virtual DbSet<FeedbackData> FeedbackDatas { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PresentationType> PresentationTypes { get; set; }
        public virtual DbSet<PresenterXLST> PresenterXLSTs { get; set; }
        public virtual DbSet<Sheet> Sheets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TokenPass> TokenPasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLog>()
                .HasMany(e => e.AccessLogBatches)
                .WithRequired(e => e.AccessLog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.AccessLogBatches)
                .WithRequired(e => e.Batch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.BatchPresentationXLSTs)
                .WithRequired(e => e.Batch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.Sheets)
                .WithRequired(e => e.Batch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PresentationType>()
                .HasMany(e => e.PresenterXLSTs)
                .WithRequired(e => e.PresentationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PresenterXLST>()
                .Property(e => e.XLSTContent)
                .IsUnicode(false);

            modelBuilder.Entity<PresenterXLST>()
                .HasMany(e => e.AccessLogs)
                .WithRequired(e => e.PresenterXLST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PresenterXLST>()
                .HasMany(e => e.BatchPresentationXLSTs)
                .WithRequired(e => e.PresenterXLST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sheet>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Sheet)
                .WillCascadeOnDelete(false);
        }
    }
}
