Imports System.Data
Imports System.Data.OleDb

Public Class gribpresidentes

    Public strbase As String = "G:\Pantallasproyecto\Pantallasproyecto\Database1.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strbase

    Private dsPersonas As DataSet


    Private Sub Listapresidentes_Loaded(sender As Object, e As RoutedEventArgs) Handles Listapresidentes.Loaded

        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM Candidato"

            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Candidato")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Candidato")

            dataGrid.DataContext = dsPersonas
        End Using

    End Sub
End Class
