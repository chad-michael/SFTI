namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TokenPass
    {
        [Key]
        [Column("TokenPass")]
        public Guid TokenPass1 { get; set; }

        public bool Used { get; set; }
    }
}
