Option Strict On

Public Class AlmacenEntregas
    Private Shared ReadOnly entregas As New List(Of Entrega)
    Private Shared ReadOnly candado As New Object()

    Public Shared Function ExisteBoleta(boleta As String) As Boolean
        Dim existe As Boolean = False
        SyncLock candado
            For Each e As Entrega In entregas
                If e.Boleta = boleta Then
                    existe = True
                End If
            Next
        End SyncLock
        Return existe
    End Function

    Public Shared Function Agregar(entrega As Entrega) As Boolean
        Dim agregada As Boolean = False
        SyncLock candado
            If ExisteBoleta(entrega.Boleta) = False Then
                entregas.Add(entrega)
                agregada = True
            End If
        End SyncLock
        Return agregada
    End Function

    Public Shared Function ObtenerTodas() As List(Of Entrega)
        Dim copia As New List(Of Entrega)
        SyncLock candado
            For Each e As Entrega In entregas
                copia.Add(e)
            Next
        End SyncLock
        Return copia
    End Function

    Public Shared Function ObtenerPorUsuario(usuario As String) As List(Of Entrega)
        Dim copia As New List(Of Entrega)
        SyncLock candado
            For Each e As Entrega In entregas
                If e.UsuarioRegistro = usuario Then
                    copia.Add(e)
                End If
            Next
        End SyncLock
        Return copia
    End Function
End Class