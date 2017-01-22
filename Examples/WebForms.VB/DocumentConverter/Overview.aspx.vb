Imports System.IO
Imports GleamTech.DocumentUltimate
Imports GleamTech.ExamplesCore
Imports GleamTech.IO
Imports GleamTech.Util
Imports GleamTech.Web

Namespace DocumentConverter
    Public Class OverviewPage
        Inherits Page

        Protected InputFormat As String
        Protected ConvertHandlerUrl As String

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Dim inputDocument = exampleFileSelector.SelectedFile
            Dim fileInfo = New FileInfo(inputDocument)

            Dim inputFormat1 = DocumentFormatInfo.[Get](inputDocument)
            InputFormat = If(inputFormat1 IsNot Nothing, inputFormat1.Description, "(not supported)")

            PopulatePossibleOutputFormats(inputDocument)

            ConvertHandlerUrl = ExamplesCoreConfiguration.GetDynamicDownloadUrl(ConvertHandlerName, 
                New NameValueCollection() From {
                    {"inputDocument", ExamplesCoreConfiguration.ProtectString(inputDocument)},
                    {"version", fileInfo.LastWriteTimeUtc.Ticks & "-" & fileInfo.Length}
                })
        End Sub

        Private Sub PopulatePossibleOutputFormats(inputDocument As String)
            Dim outputFormats1 = New Dictionary(Of String, List(Of ListItem))()

            For Each format As DocumentFormat In DocumentUltimate.DocumentConverter.EnumeratePossibleOutputFormats(inputDocument)
                Dim formatInfo = DocumentFormatInfo.[Get](Format)

                Dim groupData As List(Of ListItem) = Nothing
                If Not outputFormats1.TryGetValue(formatInfo.Group.Description, groupData) Then
                    groupData = New List(Of ListItem)()
                    outputFormats1.Add(formatInfo.Group.Description, groupData)
                End If
                groupData.Add(New ListItem(formatInfo.Description, formatInfo.Value.ToString()))
            Next

            If outputFormats1.Count = 0 Then
                outputFormats1.Add("(not supported)", New List(Of ListItem)())
            End If

            OutputFormats.DataSource = outputFormats1
            OutputFormats.DataBind()
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
                result = DocumentUltimate.DocumentConverter.Convert(inputDocument, outputDocument, outputFormat)
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