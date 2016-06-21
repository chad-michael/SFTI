namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PresenterXLST")]
    public partial class PresenterXLST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PresenterXLST()
        {
            AccessLogs = new HashSet<AccessLog>();
            BatchPresentationXLSTs = new HashSet<BatchPresentationXLST>();
        }

        [Key]
        public int PresenterXLSTKey { get; set; }

        public int PresentationTypeKey { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string XLSTContent { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccessLog> AccessLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchPresentationXLST> BatchPresentationXLSTs { get; set; }

        public virtual PresentationType PresentationType { get; set; }
    }
}
