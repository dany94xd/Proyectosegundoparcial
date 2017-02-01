Public Class Candidato1

    Inherits Persona


    Private _elegido As Boolean
    Public Property Elegido() As Boolean
        Get
            Return _elegido
        End Get
        Set(ByVal value As Boolean)
            _elegido = value
        End Set
    End Property


    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    'dignidad cargo por el cual postula: Presidente,asambleista,consejal'
    Private _cargo As String
    Public Property Cargo() As String
        Get
            Return _cargo
        End Get
        Set(ByVal value As String)
            _cargo = value
        End Set
    End Property

    Private _lista As String
    Public Property Lista() As String
        Get
            Return _lista
        End Get
        Set(ByVal value As String)
            _lista = value
        End Set
    End Property


    Private _numerodevotos As Integer
    Public Property NumerodeVotos() As Integer
        Get
            Return _numerodevotos
        End Get
        Set(ByVal value As Integer)
            _numerodevotos = value
        End Set
    End Property


    Public Sub New(id As String, cargo As String)
        Me.ID = id
        Me.Cargo = cargo

    End Sub

    Public Sub New(nombre As String, apellido As String, cargo As String, lista As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Cargo = cargo
        Me.Lista = lista

    End Sub



    Public Sub mostradatosCandi()
        Console.WriteLine(Me.Nombre & vbTab & Me.Apellido & vbTab & Me.Cargo)
    End Sub





End Class
