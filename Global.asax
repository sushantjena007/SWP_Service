<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(Object source, EventArgs e)
    {
        ////Get the current http context
        //HttpContext InRequest = HttpContext.Current;
        //var mm = InRequest.Request.ServerVariables["SERVER_NAME"];

        ///*-----------------------------------------------------------------*/
        //////// Get Requested Url (Remote Address) and Service Name.
        ///*-----------------------------------------------------------------*/
        //var serviceName = InRequest.Request.AppRelativeCurrentExecutionFilePath.ToLower();
        //var remoteAddr = Context.Request.ServerVariables["REMOTE_ADDR"];
        //var fullUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        //var pathInfo = HttpContext.Current.Request.PathInfo;
        ////string url1 = Request.Url.Host;
        ////string path = HttpContext.Current.Request.Url.AbsolutePath;
        ////string host = HttpContext.Current.Request.Url.Host;

        //Util.LogRequestResponse("ServiceAccess", "ServiceCalling", "[Service Name]:- " + serviceName + " ---- " + "[Remote Address]:- " + remoteAddr + " ---- " + "[Absolute Uri]:- " + fullUrl);


        ////if (pathInfo.Contains("UnAuthorizeAccess.aspx"))
        ////{
        ////    Response.Clear();
        ////    Response.End();
        ////}

        ///*-----------------------------------------------------------------*/
        /////// List of Authorized Url to Access GOSWIFT_SERVICE
        ///*-----------------------------------------------------------------*/
        //ArrayList arrList = new ArrayList();
        //arrList.Add("192.168.201.66");
        //arrList.Add("192.168.201.126");
        //arrList.Add("192.168.201.129");

        //if (remoteAddr == "192.168.201.219") //// Local Access Granted
        //{
        //    Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Success for local access.");
        //}
        //else
        //{
        //    if (arrList.Contains(remoteAddr)) ///// If requested url is available in the list.
        //    {
        //        ///// Indivisual service and authorized user validation.
        //        if (serviceName == "~/crmservice.svc" && remoteAddr != "192.168.201.66")
        //        {
        //            Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Unsuccess because Method is not allowed.");
        //            Response.Redirect("UnAuthorizeAccess.aspx");
        //        }
        //        else if (serviceName == "~/cnetservice.svc" && remoteAddr != "192.168.201.66")
        //        {
        //            Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Unsuccess because Method is not allowed.");
        //            Response.Redirect("UnAuthorizeAccess.aspx");
        //        }
        //        else if (serviceName == "~/pollutioncontrol.svc" && remoteAddr != "192.168.201.1291")
        //        {
        //            Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Unsuccess because Method is not allowed.");
        //            Response.Redirect("UnAuthorizeAccess.aspx");
        //        }
        //    }
        //    else
        //    {
        //        Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Unsuccess because IP is not allowed.");
        //        Response.Redirect("UnAuthorizeAccess.aspx");
        //    }

        //    Util.LogRequestResponse("ServiceAccess", "ServiceResponse", "[Status]:- Success");
        //}
    }
       
</script>
