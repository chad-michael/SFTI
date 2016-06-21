using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewStudentFeedbackToInstructorMvcForm
{
    public static class LocalExtenstions
    {
        public static string convertToString(this List<int> inputList)
        {
            string outputString = "";
            foreach (int thisItem in inputList)
            {
                outputString += thisItem.ToString() + ",";
            }
            return outputString.TrimEnd(',');
        }

        public static string convertToString(this ListItemCollection inputList)
        {
            string outputString = "";
            foreach (ListItem thisItem in inputList)
            {
                outputString += thisItem.Text + ",";
            }
            return outputString.TrimEnd(',');
        }

        public static T FindTypedControl<T>(this System.Web.UI.Control Container, string ControlName) where T : System.Web.UI.Control
        {
            T temp = (T)Container.FindControl(ControlName);
            return temp;
        }
    }
}