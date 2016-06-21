namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeedbackData
    {
        [Key]
        public int BatchKey { get; set; }

        public string BatchID { get; set; }

        public DateTime DateScanned { get; set; }

        public string UserScanned { get; set; }

        public string SheetName { get; set; }

        public string MachineScannedFrom { get; set; }

        public string Term { get; set; }

        public string Course { get; set; }

        public string Section { get; set; }

        public string SEC_TERM { get; set; }

        public string COURSE_SECTIONS_ID { get; set; }

        public string SEC_COURSE { get; set; }

        public string SEC_NAME { get; set; }

        public string SEC_CURRENT_STATUS { get; set; }

        public string CURRENT_STATUS_DESC { get; set; }

        public DateTime? STATUS_DATE { get; set; }

        public string CSF_FACULTY { get; set; }

        public DateTime? SEC_START_DATE { get; set; }

        public string SEC_NO { get; set; }

        public string DEPARTMENT_1 { get; set; }

        public string SEC_COURSE_NAME { get; set; }

        public string LAST_NAME { get; set; }

        public string FIRST_NAME { get; set; }

        public string FACULTY_NAME { get; set; }
    }
}
