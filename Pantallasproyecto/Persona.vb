Public Class Persona

    'Clase Persona2

    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _sufrago As Boolean
    Public Property Sufrago() As String
        Get
            Return _sufrago
        End Get
        Set(ByVal value As String)
            _sufrago = value
        End Set
    End Property


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

    Public Sub mostrar()
        Console.WriteLine(Me.Cedula & vbTab & Me.Nombre & vbTab & Me.Apellido & vbTab & Me.Sufrago)
    End Sub
End Class
