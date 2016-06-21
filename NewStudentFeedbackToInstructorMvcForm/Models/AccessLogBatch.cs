namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessLogBatch")]
    public partial class AccessLogBatch
    {
        [Key]
        public int AccessLogBatchKey { get; set; }

        public int AccessLogKey { get; set; }

        public int BatchKey { get; set; }

        public virtual AccessLog AccessLog { get; set; }

        public virtual Batch Batch { get; set; }
    }
}
