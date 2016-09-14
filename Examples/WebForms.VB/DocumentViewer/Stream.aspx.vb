Imports System.IO
Imports GleamTech.DocumentUltimate.Web

Namespace DocumentViewer
    Public Class StreamPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'For the simplicity of this example, we are getting a stream from a file on disk.
            'Otherwise the stream can come from network or a database or even a zip file.
		    Dim fileInfo = New FileInfo(Server.MapPath("~/App_Data/ExampleFiles/DOCX Document.docx"))

		    documentViewer.Document = new DocumentSource(
                Function() fileInfo.Open(FileMode.Open), 
                fileInfo.Name, 
                fileInfo.Length, 
                fileInfo.LastWriteTimeUtc)
        End Sub

    End Class
End NameSpace