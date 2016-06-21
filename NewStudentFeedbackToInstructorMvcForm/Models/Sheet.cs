namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sheet")]
    public partial class Sheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sheet()
        {
            Answers = new HashSet<Answer>();
        }

        [Key]
        public int SheetKey { get; set; }

        public int BatchKey { get; set; }

        public int NumberInBatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Batch Batch { get; set; }
    }
}
