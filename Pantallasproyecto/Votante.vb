Public Class Votante

    Inherits Persona

    Public Sub New()
        Me.Cedula = ""
        Me.Nombre = ""
        Me.Apellido = ""
        Me.Sufrago = False

    End Sub


    Public Sub New(cedula As String)

        Me.Cedula = cedula
        Me.Nombre = ""
        Me.Apellido = ""
        Me.Sufrago = False



    End Sub



End Class

