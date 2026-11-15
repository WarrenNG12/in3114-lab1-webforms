Option Strict On

Public Class Productor
    Public Property Codigo As String
    Public Property Nombre As String

    Public Sub New(codigo As String, nombre As String)
        Me.Codigo = codigo
        Me.Nombre = nombre
    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Return Codigo & " " & Nombre
        End Get
    End Property

    Public Shared Function Catalogo() As List(Of Productor)
        Dim lista As New List(Of Productor)
        lista.Add(New Productor("P-101", "Finca Los Almendros"))
        lista.Add(New Productor("P-102", "Finca El Progreso"))
        lista.Add(New Productor("P-103", "Finca San Jorge"))
        lista.Add(New Productor("P-104", "Finca La Esperanza"))
        lista.Add(New Productor("P-105", "Finca Río Claro"))
        Return lista
    End Function
End Class