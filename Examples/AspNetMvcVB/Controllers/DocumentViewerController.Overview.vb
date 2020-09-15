
Imports System.Linq
Imports GleamTech.DocumentUltimate.AspNet
Imports GleamTech.DocumentUltimate.AspNet.UI
Imports GleamTech.Examples

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        <AcceptVerbs(HttpVerbs.Get Or HttpVerbs.Post)>
	    Public Function Overview(fileSelector As String) As ActionResult
            Dim exampleFileSelector =  new ExampleFileSelector() With {
                .Id = "exampleFileSelector",
                .InitialFile = "Default.pdf"
            }
            ViewBag.ExampleFileSelector = exampleFileSelector

		    Dim documentViewer = New DocumentViewer() With { 
			    .Width = 800, 
			    .Height = 600,
                .Resizable = True,
			    .Document = exampleFileSelector.SelectedFile
		    }

            HandleLanguage(documentViewer)

		    Return View(documentViewer)
	    End Function

        Private Sub HandleLanguage(documentViewer As DocumentViewer)
            Dim selectedLanguage = Request("languageSelector")

            If selectedLanguage IsNot Nothing Then
                documentViewer.DisplayLanguage = selectedLanguage
            Else
                selectedLanguage = documentViewer.DisplayLanguage
            End If

            PopulateLanguageSelector(selectedLanguage)
        End Sub

        Private Sub PopulateLanguageSelector(selectedLanguage As String)
            ViewBag.LanguageList = New SelectList(
                DocumentUltimateWebConfiguration.AvailableDisplayCultures, 
                "Name", 
                "NativeName", 
                selectedLanguage
            )
        End Sub
    End Class
End Namespace
