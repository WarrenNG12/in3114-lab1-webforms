Option Strict On

Public Class CalculadoraPago
    Public Shared Function PrecioPorKg(calidad As String) As Decimal
        Select Case calidad
            Case "A"
                Return 95D
            Case "B"
                Return 80D
            Case "C"
                Return 60D
            Case Else
                Return 0D
        End Select
    End Function

    Public Shared Function Calcular(pesoKg As Integer, calidad As String) As Decimal
        Return pesoKg * PrecioPorKg(calidad)
    End Function
End Class