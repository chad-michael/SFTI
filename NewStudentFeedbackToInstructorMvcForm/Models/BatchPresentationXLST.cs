namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BatchPresentationXLST")]
    public partial class BatchPresentationXLST
    {
        [Key]
        public int BatchPresentationXLSTKey { get; set; }

        public int BatchKey { get; set; }

        public int PresenterXLSTKey { get; set; }

        public virtual Batch Batch { get; set; }

        public virtual PresenterXLST PresenterXLST { get; set; }
    }
}
