namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Linq;

    public partial class StudentFeedbackToInstructor : DbContext
    {
        public StudentFeedbackToInstructor()
            : base("name=StudentFeedbackToInstructor")
        {
        }
        public virtual DbSet<View_BatchSearch> View_BatchSearch { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_TERM)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.COURSE_SECTIONS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_COURSE)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_CURRENT_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.CURRENT_STATUS_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.CSF_FACULTY)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_NO)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.DEPARTMENT_1)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.SEC_COURSE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<View_BatchSearch>()
                .Property(e => e.FACULTY_NAME)
                .IsUnicode(false);
        }
    }
}
