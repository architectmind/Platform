using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Archimind.Platform.ServiceModel.Security.Host
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                ExceptionPolicyFactory policyFactory = new ExceptionPolicyFactory();
                ExceptionManager exceptionManager = policyFactory.CreateManager();
                ExceptionPolicy.SetExceptionManager(exceptionManager);
            }
            catch (Exception)
            {
                // Ignore.
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}