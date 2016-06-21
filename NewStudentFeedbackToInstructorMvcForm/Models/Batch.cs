namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Batch")]
    public partial class Batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batch()
        {
            AccessLogBatches = new HashSet<AccessLogBatch>();
            BatchPresentationXLSTs = new HashSet<BatchPresentationXLST>();
            Sheets = new HashSet<Sheet>();
        }

        [Key]
        public int BatchKey { get; set; }

        [Required]
        [StringLength(100)]
        public string BatchID { get; set; }

        public DateTime DateScanned { get; set; }

        [Required]
        [StringLength(100)]
        public string UserScanned { get; set; }

        [Required]
        [StringLength(50)]
        public string SheetName { get; set; }

        [Required]
        [StringLength(100)]
        public string MachineScannedFrom { get; set; }

        [Required]
        [StringLength(15)]
        public string Term { get; set; }

        [Required]
        [StringLength(50)]
        public string Course { get; set; }

        [Required]
        [StringLength(50)]
        public string Section { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccessLogBatch> AccessLogBatches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchPresentationXLST> BatchPresentationXLSTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sheet> Sheets { get; set; }
    }
}
