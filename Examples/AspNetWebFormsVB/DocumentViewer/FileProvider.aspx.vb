Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.FileProviders

Namespace DocumentViewer
    Public Class FileProviderPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            documentViewer.Document = New CustomFileProvider() With {
	            .File = "~/App_Data/ExampleFiles/Default.docx",
	            .Parameters = New Dictionary(Of String, String)() From {
		            {"parameter1", "value1"}
		        }
            }

        End Sub
    End Class


	' Implement FileProvider base class to provide a custom way of loading the input files.
	' For the simplicity of this example, we are getting a stream from a file on disk.
	' Otherwise the stream can come from network or a database or even a zip file.
	Public Class CustomFileProvider
		Inherits FileProvider

		Public Overrides Property File As String

		'Return true if DoGetInfo method is implemented, and false if not.
		Public Overrides ReadOnly Property CanGetInfo As Boolean = true

		'Return true if DoOpenRead method is implemented, and false if not.
		Public Overrides ReadOnly Property CanOpenRead As Boolean = true

		'Return true if DoOpenWrite method is implemented, and false if not.
		Public Overrides ReadOnly Property CanOpenWrite As Boolean = false

		'Return true only if File identifier is usable across processes/machines.
		Public Overrides ReadOnly Property CanSerialize As Boolean = false

		Protected Overrides Function DoGetInfo() As FileProviderInfo
			'Return info here which corresponds to the identifier in File property.

			'When this file provider is used in DocumentViewer:
			'This method will be called every time DocumentViewer requests a document.
			'The cache key and document format will be determined according to the info you return here.

			Dim physicalPath = Hosting.ResolvePhysicalPath(File)
			Dim fileInfo = New FileInfo(physicalPath)

			Return New FileProviderInfo(fileInfo.Name, fileInfo.LastWriteTimeUtc, fileInfo.Length)

			'throw new NotImplementedException();
		End Function

		Protected Overrides Function DoOpenRead() As Stream
			'Open and return a readable stream here which corresponds to the identifier in File property.

			'You can make use of Parameters dictionary which was passed when this provider was initialized.
			'var someParameter = Parameters["parameter1"];

			'When this file provider is used in DocumentViewer:
			'This method will be called only when original input document is required, 
			'For example if DocumentViewer already did the required conversions and cached the results, 
			'it will not be called.

			Dim physicalPath = Hosting.ResolvePhysicalPath(File)
			Dim stream = System.IO.File.OpenRead(physicalPath)

			Return stream

			'throw new NotImplementedException();
		End Function

		Protected Overrides Function DoOpenWrite() As Stream
			'Open and return a writable stream here which corresponds to the identifier in File property.

			Throw New NotImplementedException()
		End Function
	End Class

End NameSpace