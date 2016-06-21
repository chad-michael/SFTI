using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PagedList;
using NewStudentFeedbackToInstructorMvcForm.Models;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace NewStudentFeedbackToInstructorMvcForm.Controllers
{
    public class HomeController : Controller
    {
        private StudentFeedbackToInstructor db = new StudentFeedbackToInstructor();

        public ActionResult Index()
        {
            ViewBag.SearchResults = new SelectList(GetPageResults());
            ViewBag.Term = new SelectList(Terms_Distinct);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "BatchKey,BatchID,DateScanned,UserScanned,SheetName,MachineScannedFrom,Term,Course,Section,COURSE_SECTIONS_ID,SEC_TERM,SEC_COURSE,SEC_NAME,SEC_CURRENT_STATUS,CURRENT_STATUS_DESC,STATUS_DATE,CSF_FACULTY,SEC_START_DATE,SEC_NO,DEPARTMENT_1,SEC_COURSE_NAME,LAST_NAME,FIRST_NAME,FACULTY_NAME")]
            View_BatchSearch batchModel)
        {
            return RedirectToAction("Index", "SearchResults", batchModel);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

        public IQueryable<string> GetTermListFromDB()
        {
            return db.View_BatchSearch.Select(x => x.Term).Distinct();
        }

        public List<string> GetPageResults()
        {
            return (new List<string>() { "10", "25", "50", "100" } );
        }

        public IQueryable<string> Terms_Distinct => new HomeController().GetTermListFromDB();
    }
}
