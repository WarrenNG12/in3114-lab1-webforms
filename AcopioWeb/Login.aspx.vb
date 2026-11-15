Option Strict On

Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim contexto As New ContextoIdentity()
        Dim userManager As New UserManager(Of IdentityUser)(New UserStore(Of IdentityUser)(contexto))

        Dim usuario As IdentityUser = userManager.Find(txtCorreo.Text.Trim(), txtContrasena.Text)

        If usuario Is Nothing Then
            lblMensaje.Text = "Correo o contraseña incorrectos."
            lblMensaje.Visible = True
        Else
            Dim identidad As ClaimsIdentity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie)
            Dim autenticacion As IAuthenticationManager = Context.GetOwinContext().Authentication
            autenticacion.SignIn(New AuthenticationProperties With {.IsPersistent = False}, identidad)
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class