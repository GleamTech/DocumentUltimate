Imports System.IO
Imports GleamTech.IO

Namespace DocumentViewer
    Public Class OverviewPage
        Inherits Page

	    Const InitialFile As String = "PDF Document.pdf"
	    Const DocumentsFolder As String = "~/App_Data"
	    Const UploadsFolder As String = "~/App_Data/Uploads"
	    Const UploadedPrefix As String = "Uploaded."

	    Protected Sub Page_Load(sender As Object, e As EventArgs)
		    Dim fileSelectorValue = If(Request("fileSelector"), InitialFile)

		    If Page.IsPostBack Then
			    fileSelectorValue = If(Upload(), fileSelectorValue)
		    End If

		    PopulateFileSelector(fileSelectorValue)

		    Dim currentDocumentPath = If(fileSelectorValue.StartsWith(UploadedPrefix), 
                New ForwardSlashPath(UploadsFolder).Append(Session.SessionID).Append(fileSelectorValue.Substring(UploadedPrefix.Length)), 
                New ForwardSlashPath(DocumentsFolder).Append(fileSelectorValue))

		    documentViewer.DocumentPath = currentDocumentPath
	    End Sub

	    Public Function Upload() As String
		    Dim fileSelectorValue As String = Nothing

		    If file.HasFile AndAlso file.PostedFile.ContentLength > 0 Then
			    Dim folder = New BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID)
			    Directory.CreateDirectory(folder)
			    Dim fileName = New BackSlashPath(file.FileName).FileName
			    file.SaveAs(folder.Append(fileName))

			    fileSelectorValue = UploadedPrefix & fileName
		    End If

		    Return fileSelectorValue
	    End Function

	    Private Sub PopulateFileSelector(fileSelectorValue As String)
		    Dim listItems = From fileInfo In New DirectoryInfo(Server.MapPath(DocumentsFolder)).EnumerateFiles()
                Select New ListItem() With {
			        .Text = fileInfo.Name,
			        .Value = fileInfo.Name
		        }

		    Dim folder = New BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID)
		    If Directory.Exists(folder) Then
			    listItems = listItems.Concat(From fileInfo In New DirectoryInfo(folder).EnumerateFiles()
                                     Select New ListItem() With {
				                        .Text = fileInfo.Name,
				                        .Value = UploadedPrefix & fileInfo.Name
			                        })
		    End If

		    fileSelector.Items.AddRange(listItems.ToArray())
		    fileSelector.SelectedValue = If(fileSelectorValue, InitialFile)
	    End Sub
    End Class
End NameSpace