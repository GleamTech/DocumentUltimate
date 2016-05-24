Imports System.IO
Imports GleamTech.DocumentUltimate.Web
Imports GleamTech.IO

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

	    Const InitialFile As String = "PDF Document.pdf"
	    Const DocumentsFolder As String = "~/App_Data"
	    Const UploadsFolder As String = "~/App_Data/Uploads"
	    Const UploadedPrefix As String = "Uploaded."

	    Public Function Overview(fileSelector As String) As ActionResult
		    fileSelector = If(fileSelector, InitialFile)
		    PopulateFileSelector(fileSelector)

		    Dim currentDocumentPath = If(fileSelector.StartsWith(UploadedPrefix), 
                    New ForwardSlashPath(UploadsFolder).Append(Session.SessionID).Append(fileSelector.Substring(UploadedPrefix.Length)), 
                    New ForwardSlashPath(DocumentsFolder).Append(fileSelector))

		    Dim documentViewer = New DocumentViewer() With { 
			    .Width = 800, 
			    .Height = 600, 
			    .DocumentPath = currentDocumentPath 
		    }

		    Return View(documentViewer)
	    End Function

	    <HttpPost> 
	    Public Function Upload(file As HttpPostedFileBase) As ActionResult
		    Dim fileSelector As String = Nothing

		    If file IsNot Nothing AndAlso file.ContentLength > 0 Then
			    Dim folder = New BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID)
			    Directory.CreateDirectory(folder)
			    Dim fileName As String = New BackSlashPath(file.FileName).FileName
			    file.SaveAs(folder.Append(fileName))

                fileSelector = UploadedPrefix & fileName
		    End If

		    Return RedirectToAction("Overview", New With { 
			    .fileSelector = fileSelector 
		    })
	    End Function

	    Private Sub PopulateFileSelector(fileSelector As String)
		    Dim listItems = From fileInfo In New DirectoryInfo(Server.MapPath(DocumentsFolder)).EnumerateFiles()
                            Where fileInfo.Name <> "License.dat"
                            Select New SelectListItem() With { 
			                    .Text = fileInfo.Name, 
			                    .Value = fileInfo.Name 
		                    }

		    Dim folder = New BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID)
		    If Directory.Exists(folder) Then
			    listItems = listItems.Concat(From fileInfo In New DirectoryInfo(folder).EnumerateFiles()
                                     Select New SelectListItem() With { 
				                        .Text = fileInfo.Name, 
				                        .Value = UploadedPrefix & fileInfo.Name
			                        })
		    End If

		    ViewBag.FileList = New SelectList(listItems, "Value", "Text", If(fileSelector, InitialFile))
	    End Sub
    End Class
End Namespace
