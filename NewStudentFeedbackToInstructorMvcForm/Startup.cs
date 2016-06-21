using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewStudentFeedbackToInstructorMvcForm.Startup))]
namespace NewStudentFeedbackToInstructorMvcForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
