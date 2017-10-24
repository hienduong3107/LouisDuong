<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        if (!System.IO.File.Exists(Server.MapPath("~/Count_Visited.txt")))
            System.IO.File.WriteAllText(Server.MapPath("~/Count_Visited.txt"), "1000");
        Application["DaTruyCap"] = int.Parse(System.IO.File.ReadAllText(Server.MapPath("~/Count_Visited.txt")));
        Application["DangTruyCap"] = 1; 
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
        Application["DangTruyCap"] = (int)Application["DangTruyCap"] + 1;       
        Application["DaTruyCap"] = (int)Application["DaTruyCap"] + 1;
        System.IO.File.WriteAllText(Server.MapPath("~/Count_Visited.txt"), Application["DaTruyCap"].ToString()); 

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application["DangTruyCap"] = (int)Application["DangTruyCap"] - 1; 
    }
       
</script>
