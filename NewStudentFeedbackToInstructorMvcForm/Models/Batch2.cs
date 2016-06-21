using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewStudentFeedbackToInstructorMvcForm.Models
{
    public class Batch2
    {
        //private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        [Key]
        public int _BatchKey { get; set; }

        public string _BatchID { get; set; }

        public DateTime _DateScanned { get; set; }

        public string _UserScanned { get; set; }

        public string _SheetName { get; set; }

        public string _MachineScannedFrom { get; set; }

        public string _Term { get; set; }

        public string _Course { get; set; }

        public string _Section { get; set; }

        public EntitySet<View_BatchSearch> View_BatchSearch { get; set; }

        public EntitySet<AccessLogBatch> _AccessLogBatches { get; set; }

        public EntitySet<BatchPresentationXLST> _BatchPresentationXLSTs { get; set; }

        public EntitySet<Sheet> _Sheets { get; set; }
    }
}