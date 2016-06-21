namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [Key]
        public int MessageKey { get; set; }

        [Required]
        [StringLength(300)]
        public string Subject { get; set; }

        [Column("Message")]
        [Required]
        public string Message1 { get; set; }

        [StringLength(500)]
        public string Recipients { get; set; }
    }
}
