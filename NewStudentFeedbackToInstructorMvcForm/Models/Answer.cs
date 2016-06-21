namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        [Key]
        public int AnswerKey { get; set; }

        public int SheetKey { get; set; }

        public int AnswerNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string AnswerValue { get; set; }

        public virtual Sheet Sheet { get; set; }
    }
}
