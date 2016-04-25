Imports System.IO
Imports GleamTech.DocumentUltimate.Web

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        Public Function Stream() As ActionResult
		    Dim documentViewer = New DocumentViewer() With {
			    .Width = 800,
			    .Height = 600,
			    .Resizable = True
		    }

            'For the simplicity of this example, we are getting a stream from a file on disk.
            'Otherwise the stream can come from network or a database or even a zip file.
		    Dim fileInfo = New FileInfo(Server.MapPath("~/App_Data/DOCX Document.docx"))

		    documentViewer.SetDocumentStream(
                Function() fileInfo.Open(FileMode.Open), 
                fileInfo.Name, 
                fileInfo.Length, 
                fileInfo.LastWriteTimeUtc)

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
