
Public Class Mega
    Public Shared Function GetUrlInfo(ByVal url As String) As Conexion.InformacionFichero
        Dim FileID As String = URLExtractor.ExtraerFileID(url)
        Dim FileKey As String = URLExtractor.ExtraerFileKey(url)
        Dim Config = New Configuracion()
        Return Conexion.ObtenerInformacionFichero(Config, FileID, FileKey, False)
    End Function
End Class
