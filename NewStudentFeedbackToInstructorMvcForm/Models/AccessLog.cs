namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessLog")]
    public partial class AccessLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccessLog()
        {
            AccessLogBatches = new HashSet<AccessLogBatch>();
        }

        [Key]
        public int AccessLogKey { get; set; }

        [Required]
        [StringLength(100)]
        public string UserID { get; set; }

        public DateTime AccessDate { get; set; }

        [Required]
        [StringLength(200)]
        public string AccessIP { get; set; }

        public int PresenterXLSTKey { get; set; }

        public virtual PresenterXLST PresenterXLST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccessLogBatch> AccessLogBatches { get; set; }
    }
}
