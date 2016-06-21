using System;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewStudentFeedbackToInstructorMvcForm.Models;
using PagedList;
using System.IO;
using System.Web.UI;

namespace NewStudentFeedbackToInstructorMvcForm.Controllers
{
    public class SearchResultsController : Controller
    {
        private StudentFeedbackToInstructor db = new StudentFeedbackToInstructor();
        private List<View_BatchSearch> batchResults = new List<View_BatchSearch>();

        public ActionResult Index(string orderBy, int? page, View_BatchSearch batchModel)
        {
            #region Form Input Values
            var facultyId = batchModel.CSF_FACULTY;
            var firstName = batchModel.FIRST_NAME;
            var lastName = batchModel.LAST_NAME;
            var department = batchModel.DEPARTMENT_1;
            var courseNumber = batchModel.COURSE_SECTIONS_ID;
            var sectionNumber = batchModel.SEC_NO;
            var term = batchModel.Term;
            var startDate = batchModel.SEC_START_DATE;
            var endDate = batchModel.STATUS_DATE;
            var dateScanned = batchModel.DateScanned;
            #endregion

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (orderBy == null)
                orderBy = "term";

            #region Filter Results
            IQueryable<View_BatchSearch> formData = db.View_BatchSearch;
            formData = SetSearch("facultyid", facultyId, formData);
            formData = SetSearch("facultyfname", firstName, formData);
            formData = SetSearch("facultylname", lastName, formData);
            formData = SetSearch("department", department, formData);
            formData = SetSearch("coursenumber", courseNumber, formData);
            formData = SetSearch("sectionnumber", sectionNumber, formData);
            // TODO: Make a null value in dropdown
            //formData = SetSearch("term", term, formData);
            formData = SetSearch("startdate", startDate.ToString(), formData);
            formData = SetSearch("enddate", endDate.ToString(), formData);
            // TODO: Fix this binding
            //formData = SetSearch("datescanned", dateScanned.ToString(), formData);

            formData = SetOrderBy(orderBy, formData);
            #endregion

            batchResults = formData.ToList();
            TempData["batchSearchResults"] = formData.ToList();

            return View(formData.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: SearchResults       
        public ActionResult Index([Bind(Include = "BatchKey,BatchID,DateScanned,UserScanned,SheetName,MachineScannedFrom,Term,Course,Section,COURSE_SECTIONS_ID,SEC_TERM,SEC_COURSE,SEC_NAME,SEC_CURRENT_STATUS,CURRENT_STATUS_DESC,STATUS_DATE,CSF_FACULTY,SEC_START_DATE,SEC_NO,DEPARTMENT_1,SEC_COURSE_NAME,LAST_NAME,FIRST_NAME,FACULTY_NAME")]
            View_BatchSearch batchModel, string orderBy, int? page)
        {
            #region Possibly Remove Later
            //ViewBag.OrderBy = String.IsNullOrEmpty(orderBy) ? "term" : orderBy;
            //ViewBag.FacultyId = batchModel.CSF_FACULTY;
            //ViewBag.FirstName = batchModel.FIRST_NAME;
            //ViewBag.Term = batchModel.Term;

            //var results = db.View_BatchSearch
            //    .Where(x => x.CSF_FACULTY == batchModel.CSF_FACULTY);
            //var pageNumber = (page ?? 1);
            //var pageSize = 10;
            //if (ViewBag.PageResults != null)
            //{
            //    pageSize = ViewBag.PageResults;
            //}

            //return View(results.ToPagedList(pageNumber, pageSize));
            #endregion

            return View();
        }

        public ActionResult ToSinglePage()
        {
            throw new NotImplementedException();
        }

        public ActionResult ToMultiPage()
        {
            throw new NotImplementedException();
        }

        public ActionResult ToExcel()
        {
            throw new NotImplementedException();
        }

        public ActionResult ToRaw()
        {
            throw new NotImplementedException();
        }

        public ActionResult ToRecap()
        {
            throw new NotImplementedException();
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

        private IQueryable<View_BatchSearch> SetSearch(string searchField, string searchString, IQueryable<View_BatchSearch> formData)
        {
            if (formData != null)
            {
                switch (searchField)
                {
                    case "facultyid":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.CSF_FACULTY == searchString);
                        }
                        else
                            return formData;
                    case "facultyfname":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.FIRST_NAME.Contains(searchString));
                        }
                        else
                            return formData;
                    case "facultylname":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.LAST_NAME.Contains(searchString));
                        }
                        else
                            return formData;
                    case "department":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.DEPARTMENT_1.Contains(searchString));
                        }
                        else
                            return formData;
                    case "coursenumber":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.COURSE_SECTIONS_ID.Contains(searchString));
                        }
                        else
                            return formData;
                    case "sectionnumber":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.SEC_NO.Contains(searchString));
                        }
                        else
                            return formData;
                    case "term":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.Term.Contains(searchString));
                        }
                        else
                            return formData;
                    case "startafterdate":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.SEC_START_DATE.ToString().Contains(searchString));
                        }
                        else
                            return formData;
                    case "startbeforedate":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.STATUS_DATE.ToString().Contains(searchString));
                        }
                        else
                            return formData;
                    case "datescanned":
                        if (searchString != null)
                        {
                            return formData.Where(s => s.DateScanned.ToString().Contains(searchString));
                        }
                        else
                            return formData;
                }
            }
            return formData;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<View_BatchSearch> selectedBatchesList = new List<View_BatchSearch>();

        [HttpPost]
        public ActionResult AddChecked(string[] batchIds)
        {
            selectedBatchesList.Clear();
            foreach (var batchId in batchIds)
            {
                selectedBatchesList.Add(db.View_BatchSearch.First(x => x.BatchID == batchId));
            }

            return null;
        }
    }
}
