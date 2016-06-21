using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewStudentFeedbackToInstructorMvcForm.Models;
using System.Text;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using LinqKit;


namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    public class BatchSearch
    {
        public string FACULTY_FIRST_NAME { get; set; }
        public string FACULTYID { get; set; }
        public string FACULTY_LAST_NAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string COURSE_NUMBER { get; set; }
        public string SECTION_NUMBER { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public string DATE_SCANNED { get; set; }
        public Int32 Page { get; set; }
        public Int32 PageSize { get; set; }
        public String Sort { get; set; }
        public String SortDir { get; set; }
        public Int32 TotalRecords { get; set; }
        public List<View_BatchSearch> BatchSearchList { get; set; }

        public BatchSearch()
        {
            Page = 1;
            PageSize = 5;
            Sort = "";
            SortDir = "DESC";

            FACULTY_FIRST_NAME = "FACULTY_FIRST_NAME";
            FACULTYID = "FACULTYID";
            FACULTY_LAST_NAME = "FACULTY_LAST_NAME";
            DEPARTMENT = "DEPARTMENT";
            COURSE_NUMBER = "COURSE_NUMBER";
            SECTION_NUMBER = "SECTION_NUMBER";
            START_DATE = "START_DATE";
            END_DATE = "END_DATE";
            DATE_SCANNED = "DATE_SCANNED";
        }

        public static List<View_BatchSearch> Search()
        {
            using (StudentFeedbackToInstructor db = new StudentFeedbackToInstructor())
            {
                return db.View_BatchSearches.ToList();
            }
        }

        public static List<View_BatchSearch> Search(string firstName, string facultyID, string lastName, string department, string courseNumber, string sectionNumber, string startOnOrAfterDate, string endOnOrBeforeDate, string dateScanned, string term)
        {
            using (StudentFeedbackToInstructor db = new StudentFeedbackToInstructor())
            {
                var conditional = PredicateBuilder.True<View_BatchSearch>();

                if (term != "All Terms")
                    conditional = conditional.And(x => x.SEC_TERM == term);
                if (firstName != "")
                    conditional = conditional.And(x => SqlMethods.Like(x.FIRST_NAME.ToUpper(), "%" + firstName.ToUpper() + "%"));
                if (facultyID != "")
                    conditional = conditional.And(x => x.CSF_FACULTY == facultyID);
                if (lastName != "")
                    conditional = conditional.And(x => SqlMethods.Like(x.LAST_NAME.ToUpper(), "%" + lastName.ToUpper() + "%"));
                if (department != "")
                    conditional = conditional.And(x => SqlMethods.Like(x.DEPARTMENT_1, "%" + department + "%"));
                if (courseNumber != "")
                    conditional = conditional.And(x => SqlMethods.Like(x.SEC_COURSE.ToUpper(), "%" + courseNumber.ToUpper() + "%"));
                if (sectionNumber != "")
                    conditional = conditional.And(x => SqlMethods.Like(x.SEC_NO.ToUpper(), "%" + sectionNumber.ToUpper() + "%"));
                if (startOnOrAfterDate != "")
                    conditional = conditional.And(x => x.SEC_START_DATE.Value.Date >= DateTime.Parse(startOnOrAfterDate));
                if (endOnOrBeforeDate != "")
                    conditional = conditional.And(x => x.SEC_START_DATE.Value.Date <= DateTime.Parse(endOnOrBeforeDate));
                if (dateScanned != "")
                    conditional = conditional.And(x => x.DateScanned.Date == DateTime.Parse(dateScanned));

                return db.View_BatchSearches.Where(conditional).Distinct().ToList();
            }
        }

        public static List<View_BatchSearch> GetBatchItems(List<int> batchKeys)
        {
            using (StudentFeedbackToInstructor db = new StudentFeedbackToInstructor())
            {
                return db.View_BatchSearches.Where(x => batchKeys.Contains(x.BatchKey)).Distinct().ToList();
            }
        }
    }
}