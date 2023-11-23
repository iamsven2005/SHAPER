<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Home", "", "~/index.aspx");
        routes.MapPageRoute("Products", "Shop", "~/BestSeller.aspx");
        routes.MapPageRoute("Cart", "Cart", "~/ViewCart.aspx");
        //services

    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        HttpContext.Current.Response.Redirect("~/index.aspx");
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Get the last error that occurred
        Exception ex = Server.GetLastError();
        Server.ClearError();
        if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404.0)
        {
            Response.Redirect("/");

        }
        else if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 403.0)
        {
            Response.Redirect("/");

        }
        else
        {
            // Handle other errors or log them as needed
            Response.Redirect("/");
        }
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

</script>
