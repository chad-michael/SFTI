namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using PagedList;
    using System.ComponentModel;
    using NewStudentFeedbackToInstructorMvcForm;
    public partial class View_BatchSearch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BatchKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string BatchID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime DateScanned { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string UserScanned { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string SheetName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string MachineScannedFrom { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(15)]
        public string Term { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Course { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Section { get; set; }

        [StringLength(7)]
        [DisplayName("Section Term")]
        public string SEC_TERM { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(19)]
        public string COURSE_SECTIONS_ID { get; set; }

        [StringLength(10)]
        [DisplayName("Course Number")]
        public string SEC_COURSE { get; set; }

        [StringLength(21)]
        [DisplayName("Section Name")]
        public string SEC_NAME { get; set; }

        [StringLength(5)]
        public string SEC_CURRENT_STATUS { get; set; }

        [StringLength(32)]
        public string CURRENT_STATUS_DESC { get; set; }

        public DateTime? STATUS_DATE { get; set; }

        [StringLength(10)]
        //[DisplayName("Faculty Id")]
        [Display(Name = "Faculty Id")]
        public string CSF_FACULTY { get; set; }

        [DisplayName("Start Date")]
        public DateTime? SEC_START_DATE { get; set; }

        [StringLength(5)]
        [DisplayName("Section Number")]
        public string SEC_NO { get; set; }

        [StringLength(5)]
        [DisplayName("Department")]
        public string DEPARTMENT_1 { get; set; }

        [StringLength(13)]
        [DisplayName("Course Name")]
        public string SEC_COURSE_NAME { get; set; }

        [StringLength(57)]
        [DisplayName("Faculty Last Name")]
        public string LAST_NAME { get; set; }

        [StringLength(30)]
        [DisplayName("Faculty First Name")]
        public string FIRST_NAME { get; set; }

        [StringLength(88)]
        [DisplayName("Faculty Name")]
        public string FACULTY_NAME { get; set; }
    }
}
