
Public Class Mega
    Public Shared Function GetUrlInfo(ByVal url As String) As Conexion.InformacionFichero
        Dim FileID As String = URLExtractor.ExtraerFileID(url)
        Dim FileKey As String = URLExtractor.ExtraerFileKey(url)
        Dim Config = New Configuracion()
        Return Conexion.ObtenerInformacionFichero(Config, FileID, FileKey, False)
    End Function

    Public Shared Function GetUrlInfo2(ByVal url As String) As Generic.List(Of Conexion.InformacionFichero)
        Dim links As New Generic.HashSet(Of Conexion.InformacionFichero)
        If URLExtractor.IsMegaFolder(url) Then
            Dim FolderID As String = URLExtractor.ExtraerFileID(url)
            Dim FolderKey As String = URLExtractor.ExtraerFileKey(url)
            For Each FileURL In MegaFolderHelper.RetrieveLinksFromFolder(FolderID, FolderKey)
                links.Add(GetUrlInfo(FileURL.URL))
            Next
        Else
            links.Add(GetUrlInfo(url))
        End If
        Return links.ToList
    End Function

    Public Shared Function GetUrlInfo3(ByVal url As String) As Boolean
        Dim info As Conexion.InformacionFichero
        If URLExtractor.IsMegaFolder(url) Then
            Dim FolderID As String = URLExtractor.ExtraerFileID(url)
            Dim FolderKey As String = URLExtractor.ExtraerFileKey(url)
            For Each FileURL In MegaFolderHelper.RetrieveLinksFromFolder(FolderID, FolderKey)
                info = GetUrlInfo(FileURL.URL)
                Exit For
            Next

        Else
            info = GetUrlInfo(url)
        End If

        If IsNothing(info) Then
            Return False
        End If

        If info.Errtxt = "" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
