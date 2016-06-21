using System;

using Owin;
using Microsoft.IdentityModel.Claims;
using System.Web.Helpers;

namespace NewStudentFeedbackToInstructorMvcForm
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
        }
    }
}