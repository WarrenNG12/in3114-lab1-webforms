Option Strict On

Imports Microsoft.AspNet.Identity

Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim autenticado As Boolean = Context.User.Identity.IsAuthenticated

        pnlAnonimo.Visible = Not autenticado
        pnlSesion.Visible = autenticado
        pnlRecepcion.Visible = autenticado AndAlso Context.User.IsInRole("Recepcion")
        pnlAdmin.Visible = autenticado AndAlso Context.User.IsInRole("Administrador")

        If autenticado Then
            lblUsuario.Text = Context.User.Identity.Name
        End If
    End Sub

    Protected Sub lnkCerrarSesion_Click(sender As Object, e As EventArgs) Handles lnkCerrarSesion.Click
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        Response.Redirect("~/Login.aspx")
    End Sub
End Class