Imports System.Configuration

Module Proyecto
    
    Public Dim ConnectionString as String  = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
    Property Votante() As Integer

    Public sub Connect()
        Try
            Dim appSettings = ConfigurationManager.AppSettings

            If appSettings.Count = 0 Then
                Console.WriteLine("AppSettings is empty.")
            Else
                For Each key As String In appSettings.AllKeys

                    If key = "RutaAccess" Then
                        ConnectionString += appSettings(key)
                    End If

                    Console.WriteLine("Key: {0} Value: {1}", key, appSettings(key))
                Next
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app settings")
        End Try
    End Sub

End Module
