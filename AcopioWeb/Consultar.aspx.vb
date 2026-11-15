Option Strict On

Public Class Consultar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Verificación de autorización en el código: Recepcion o Administrador
        If Not User.Identity.IsAuthenticated OrElse
           (Not User.IsInRole("Recepcion") AndAlso Not User.IsInRole("Administrador")) Then
            Response.Redirect("~/Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            CargarEntregas()
        End If
    End Sub

    Private Sub CargarEntregas()
        Dim lista As List(Of Entrega)

        If User.IsInRole("Administrador") Then
            lista = AlmacenEntregas.ObtenerTodas()
        Else
            lista = AlmacenEntregas.ObtenerPorUsuario(User.Identity.Name)
        End If

        gvEntregas.DataSource = lista
        gvEntregas.DataBind()
    End Sub

    Protected Sub gvEntregas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvEntregas.PageIndexChanging
        gvEntregas.PageIndex = e.NewPageIndex
        CargarEntregas()
    End Sub
End Class