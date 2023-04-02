using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Infrastructure.Commons
{
    public static class ExceptionHadling
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string HtmlErrorReport(this Exception Ex)
        {
            string OutputHTML = string.Empty;
            var st = new System.Diagnostics.StackTrace(Ex);
            StackFrame[] sfs = st.GetFrames();

            foreach (StackFrame item in sfs)
            {
                OutputHTML += "<i><b><u>For Developer Use Only: </u></b></i>" + "<br>" +
                                                                                                "<br>" +
                           "Project Name:   " + Assembly.GetCallingAssembly().GetName().Name + "<br>" +
                           "File Name:      " + item.GetFileName() + "<br>" +
                           "Class Name:     " + item.GetMethod()?.DeclaringType + "<br>" +
                           "Method Name:    " + item.GetMethod() + "<br>" +
                           "Line Number:    " + item.GetFileLineNumber() + "<br>" +
                           "Line Column:    " + item.GetFileColumnNumber() + "<br>" +
                           "Error Message:  " + Ex.Message + "<br>" +
                           "Inner Message : " + Ex.InnerException?.Message + "<br>";
            }
            return OutputHTML;
        }
    }
}
