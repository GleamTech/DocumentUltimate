Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.IO
Imports System.Web
Imports GleamTech.DocumentUltimate
Imports GleamTech.DocumentUltimateExamples.Mvc.VB.Models
Imports GleamTech.ExamplesCore
Imports GleamTech.IO
Imports GleamTech.Util
Imports GleamTech.Web

Namespace Controllers
    Partial Public Class  DocumentConverterController
        Inherits Controller
	    Public Function Overview() As ActionResult
		    Dim model = New OverviewViewModel() With {
			    .ExampleFileSelector = New ExampleFileSelector() With {
				    .ID = "exampleFileSelector",
				    .InitialFile = "Default.pdf"
			    }
		    }

		    Dim inputDocument = model.ExampleFileSelector.SelectedFile
		    Dim fileInfo = New FileInfo(inputDocument)
		    Dim inputFormat = DocumentFormatInfo.[Get](inputDocument)
		    model.InputFormat = If(inputFormat IsNot Nothing, inputFormat.Description, "(not supported)")

		    PopulatePossibleOutputFormats(inputDocument, model)

		    model.ConvertHandlerUrl = ExamplesCoreConfiguration.GetDynamicDownloadUrl(ConvertHandlerName, 
                New NameValueCollection() From {
			        {"inputDocument", ExamplesCoreConfiguration.ProtectString(inputDocument)},
			        {"version", fileInfo.LastWriteTimeUtc.Ticks & "-" & fileInfo.Length}
		        })

		    Return View(model)
	    End Function

	    Private Sub PopulatePossibleOutputFormats(inputDocument As String, model As OverviewViewModel)
		    For Each format As DocumentFormat In DocumentConverter.EnumeratePossibleOutputFormats(inputDocument)
			    Dim formatInfo = DocumentFormatInfo.[Get](format)

			    Dim groupData As List(Of SelectListItem) = Nothing
			    If Not model.OutputFormats.TryGetValue(formatInfo.Group.Description, groupData) Then
				    groupData = New List(Of SelectListItem)()
				    model.OutputFormats.Add(formatInfo.Group.Description, groupData)
			    End If
			    groupData.Add(New SelectListItem() With {
				    .Text = formatInfo.Description,
				    .Value = formatInfo.Value.ToString()
			    })
		    Next

		    If model.OutputFormats.Count = 0 Then
			    model.OutputFormats.Add("(not supported)", New List(Of SelectListItem)())
		    End If
	    End Sub

	    Public Shared Sub ConvertHandler(context As HttpContext)
		    Dim result As DocumentConverterResult

		    Try
			    Dim inputDocument = New BackSlashPath(ExamplesCoreConfiguration.UnprotectString(context.Request("inputDocument")))
			    Dim outputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("outputFormat")), DocumentFormat)
			    Dim fileName = inputDocument.FileNameWithoutExtension + "." + DocumentFormatInfo.[Get](outputFormat).DefaultExtension
			    Dim outputPath = ConvertedPath.Append(context.Session.SessionID).Append(fileName)
			    Dim outputDocument = outputPath.Append(fileName)

			    If Directory.Exists(outputPath) Then
				    Directory.Delete(outputPath, True)
			    End If
			    Directory.CreateDirectory(outputPath)
			    result = DocumentConverter.Convert(inputDocument, outputDocument, outputFormat)
		    Catch exception As Exception
			    context.Response.Write("<span style=""color: red; font-weight: bold"">Conversion failed</span><br/>")
			    context.Response.Write(exception.Message)
			    Return
		    End Try

		    context.Response.Write("<span style=""color: green; font-weight: bold"">Conversion successful</span>")
		    context.Response.Write("<br/>Conversion time: " & result.ElapsedTime.ToString())
		    context.Response.Write("<br/>Output files:")

		    If result.OutputFiles.Length > 1 Then
			    context.Response.Write(Convert.ToString(" - ") & GetZipDownloadLink(New FileInfo(result.OutputFiles(0)).Directory))
		    End If

		    context.Response.Write("<br/><ol>")
		    For Each outputFile As String In result.OutputFiles
			    If outputFile.EndsWith("\") Then
				    Dim directoryInfo = New DirectoryInfo(outputFile)
				    context.Response.Write(String.Format("<br/><li><b>{0}\</b> - {1}</li>", directoryInfo.Name, GetZipDownloadLink(directoryInfo)))
			    Else
				    Dim fileInfo = New FileInfo(outputFile)
				    context.Response.Write(String.Format("<br/><li><b>{0}</b> ({1} bytes) - {2}</li>", fileInfo.Name, fileInfo.Length, GetDownloadLink(fileInfo)))
			    End If
		    Next
		    context.Response.Write("<br/></ol>")
	    End Sub

	    Private Shared Function GetDownloadLink(fileInfo As FileInfo) As String
		    Return String.Format("<a href=""{0}"">Download</a>", ExamplesCoreConfiguration.GetDownloadUrl(fileInfo.FullName, fileInfo.LastWriteTimeUtc.Ticks.ToString()))
	    End Function

	    Private Shared Function GetZipDownloadLink(directoryInfo As DirectoryInfo) As String
		    Return String.Format("<a href=""{0}"">Download as Zip</a>", ExamplesCoreConfiguration.GetDynamicDownloadUrl(ZipDownloadHandlerName, New NameValueCollection() From {
			    {"path", ExamplesCoreConfiguration.ProtectString(directoryInfo.FullName)},
			    {"version", directoryInfo.LastWriteTimeUtc.Ticks.ToString()}
		    }))
	    End Function

	    Public Shared Sub ZipDownloadHandler(context As HttpContext)
		    Dim path = New BackSlashPath(ExamplesCoreConfiguration.UnprotectString(context.Request("path"))).RemoveTrailingSlash()

		    Dim fileResponse = New FileResponse(context, 0)
		    fileResponse.Transmit(Sub(targetStream, copyFileCallback) 
		        QuickZip.Zip(targetStream, Directory.EnumerateFileSystemEntries(path))
            End Sub, path.FileName + ".zip", 0)

	    End Sub

	    Private Shared ReadOnly Property ConvertHandlerName() As String
		    Get
			    If m_convertHandlerName Is Nothing Then
				    m_convertHandlerName = "ConvertHandler"
				    ExamplesCoreConfiguration.RegisterDynamicDownloadHandler(m_convertHandlerName, AddressOf ConvertHandler)
			    End If

			    Return m_convertHandlerName
		    End Get
	    End Property
	    Private Shared m_convertHandlerName As String

	    Private Shared ReadOnly Property ZipDownloadHandlerName() As String
		    Get
			    If m_zipDownloadHandlerName Is Nothing Then
				    m_zipDownloadHandlerName = "ZipDownloadHandler"
				    ExamplesCoreConfiguration.RegisterDynamicDownloadHandler(m_zipDownloadHandlerName, AddressOf ZipDownloadHandler)
			    End If

			    Return m_zipDownloadHandlerName
		    End Get
	    End Property
	    Private Shared m_zipDownloadHandlerName As String

	    Private Shared ReadOnly ConvertedPath As BackSlashPath = HostingPathHelper.MapPath("~/App_Data/ConvertedDocuments")
    End Class
End Namespace
