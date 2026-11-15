Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.AspNet.Identity
Imports Owin

<Assembly: OwinStartup(GetType(Startup))>

Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        app.UseCookieAuthentication(New CookieAuthenticationOptions With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .LoginPath = New PathString("/Login.aspx")
        })
    End Sub
End Class