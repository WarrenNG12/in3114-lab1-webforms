Option Strict On

Imports System.Web.UI.WebControls

Public Class Registrar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Verificación de autorización en el código: solo el rol Recepcion
        If Not User.Identity.IsAuthenticated OrElse Not User.IsInRole("Recepcion") Then
            Response.Redirect("~/Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            For Each p As Productor In Productor.Catalogo()
                ddlProductor.Items.Add(New ListItem(p.Descripcion, p.Codigo))
            Next
        End If
    End Sub

    Protected Sub cvBoleta_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvBoleta.ServerValidate
        args.IsValid = Not AlmacenEntregas.ExisteBoleta(args.Value.Trim())
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        lblResultado.Visible = False

        If Not Page.IsValid Then
            Return
        End If

        Dim peso As Integer = Integer.Parse(txtPeso.Text.Trim())
        Dim calidad As String = rblCalidad.SelectedValue

        Dim entrega As New Entrega()
        entrega.Boleta = txtBoleta.Text.Trim()
        entrega.Productor = ddlProductor.SelectedItem.Text
        entrega.PesoKg = peso
        entrega.Calidad = calidad
        entrega.Pago = CalculadoraPago.Calcular(peso, calidad)
        entrega.UsuarioRegistro = User.Identity.Name

        If AlmacenEntregas.Agregar(entrega) = False Then
            cvBoleta.IsValid = False
            Return
        End If

        lblResultado.Text = "Entrega registrada. Boleta " & entrega.Boleta & ", pago: ₡" & entrega.Pago.ToString("N0")
        lblResultado.Visible = True

        txtBoleta.Text = ""
        txtPeso.Text = ""
        ddlProductor.SelectedIndex = 0
        rblCalidad.ClearSelection()
    End Sub
End Class