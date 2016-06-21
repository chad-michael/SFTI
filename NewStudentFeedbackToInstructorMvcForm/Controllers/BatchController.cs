using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewStudentFeedbackToInstructorMvcForm.Models;
using PagedList;

namespace NewStudentFeedbackToInstructorMvcForm.Controllers
{
    public class BatchController : Controller
    {
        private StudentFeedbackToInstructor db = new StudentFeedbackToInstructor();

        // GET: Batch
        //public ActionResult Index(BatchSearch model)
        //{
        //    model.BatchSearchList = db.View_BatchSearch.Where(x =>
        //        (model.FACULTY_FIRST_NAME == null || x.FIRST_NAME.Contains(model.FACULTY_FIRST_NAME))
        //        && (model.FACULTYID == null || x.CSF_FACULTY.Contains(model.FACULTYID))
        //        && (model.FACULTY_LAST_NAME == null || x.LAST_NAME.Contains(model.FACULTY_LAST_NAME))
        //        && (model.DEPARTMENT == null || x.DEPARTMENT_1.Contains(model.DEPARTMENT))
        //        && (model.COURSE_NUMBER == null || x.COURSE_SECTIONS_ID.Contains(model.COURSE_NUMBER))
        //        && (model.SECTION_NUMBER == null || x.SEC_NO.Contains(model.SECTION_NUMBER))
        //        && (model.START_DATE == null || x.SEC_START_DATE.ToString().Contains(model.START_DATE))
        //        && (model.END_DATE == null || x.STATUS_DATE.ToString().Contains(model.END_DATE))
        //        && (model.DATE_SCANNED == null || x.DateScanned.ToString().Contains(model.DATE_SCANNED))
        //        )
        //        .ToList();

        //    model.TotalRecords = 25;
        //    return View(model);
        //}
        public ActionResult Index(string orderBy, string searchField, string searchString, int? page)
        {
            ViewBag.OrderBy = String.IsNullOrEmpty(orderBy) ? "term" : orderBy;
            ViewBag.SearchField = searchField;
            ViewBag.SearchString = searchString;

            var termList = db.View_BatchSearch.Select(x => x.Term).Distinct();
            ViewBag.Term = new SelectList(termList);

            IQueryable<View_BatchSearch> formData = db.View_BatchSearch;
            int pageSize = 50;
            int pageNumber = (page ?? 1);

            searchField = "facultyid";
            searchString = "12345";

            formData = SetSearch(searchField, searchString, formData);
            formData = SetOrderBy(orderBy, formData);
            formData = formData.OrderByDescending(x => x.Term);

            return View(formData.ToPagedList(pageNumber, pageSize));
        }

        private IQueryable<View_BatchSearch> SetSearch(string searchField, string searchString, IQueryable<View_BatchSearch> formData)
        {
            switch (searchField)
            {
                case "facultyid":
                    return formData.Where(s => s.CSF_FACULTY.Contains(searchString));
                case "facultyfname":
                    return formData.Where(s => s.FIRST_NAME.Contains(searchString));
                case "facultylname":
                    return formData.Where(s => s.LAST_NAME.Contains(searchString));
                case "department":
                    return formData.Where(s => s.DEPARTMENT_1.Contains(searchString));
                case "coursenumber":
                    return formData.Where(s => s.COURSE_SECTIONS_ID.Contains(searchString));
                case "sectionnumber":
                    return formData.Where(s => s.SEC_NO.Contains(searchString));
                case "term":
                    return formData.Where(s => s.Term.Contains(searchString));
                case "startafterdate":
                    return formData.Where(s => s.SEC_START_DATE.ToString().Contains(searchString));
                case "startbeforedate":
                    return formData.Where(s => s.STATUS_DATE.ToString().Contains(searchString));
                case "datescanned":
                    return formData.Where(s => s.DateScanned.ToString().Contains(searchString));
            }
            return formData;
        }

        private IQueryable<View_BatchSearch> SetOrderBy(string orderBy, IQueryable<View_BatchSearch> formData)
        {
            switch (orderBy)
            {
                case "facultyid":
                    return formData.OrderBy(s => s.CSF_FACULTY);
                case "facultyfname":
                    return formData.OrderBy(s => s.FIRST_NAME);
                case "facultylname":
                    return formData.OrderBy(s => s.LAST_NAME);
                case "department":
                    return formData.OrderBy(s => s.DEPARTMENT_1);
                case "coursenumber":
                    return formData.OrderBy(s => s.COURSE_SECTIONS_ID);
                case "sectionnumber":
                    return formData.OrderBy(s => s.SEC_NO);
                case "term":
                    return formData.OrderBy(s => s.Term);
                case "startafterdate":
                    return formData.OrderBy(s => s.SEC_START_DATE.ToString());
                case "startbeforedate":
                    return formData.OrderBy(s => s.STATUS_DATE);
                case "datescanned":
                    return formData.OrderBy(s => s.DateScanned);
                default:
                    return formData.OrderBy(s => s.Term);
            }
        }

        protected void BindSearch(View_BatchSearch formData)
        {
            var txtFirstName = formData.CSF_FACULTY;
            var txtFacultyID = formData.FIRST_NAME;
            var txtLastName = formData.LAST_NAME;
            var txtDepartment = formData.DEPARTMENT_1;
            var txtCourseNumber = formData.SEC_COURSE;
            var txtSectionNumber = formData.SEC_NO;
            var txtTerm = formData.Term;
            var txtStartDate = formData.SEC_START_DATE.ToString();
            var txtEndDate = formData.STATUS_DATE.ToString();
            var txtDateScanned = formData.DateScanned.ToString();

            List<View_BatchSearch> listData = new List<View_BatchSearch>();

            listData = BatchSearch.Search(txtFirstName, txtFacultyID, txtLastName, txtDepartment, txtCourseNumber, txtSectionNumber, txtTerm, txtStartDate, txtEndDate, txtDateScanned).ToList();
        }
    }
}