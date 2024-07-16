
Imports System.Linq
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate.AspNet
Imports GleamTech.DocumentUltimate.AspNet.UI
Imports GleamTech.Examples

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        <AcceptVerbs(HttpVerbs.Get Or HttpVerbs.Post)>
	    Public Function Overview(fileSelector As String) As ActionResult
            Dim exampleFileSelector = New ExampleFileSelector() With {
                .Id = "exampleFileSelector",
                .InitialFile = "Default.pdf",
                .FormWrapped = False
            }
            ViewBag.ExampleFileSelector = exampleFileSelector

		    Dim documentViewer = New DocumentViewer() With { 
			    .Width = 800, 
			    .Height = 600,
                .Resizable = True,
			    .Document = exampleFileSelector.SelectedFile.ToString()
		    }

            HandleSelectors(documentViewer)

            Return View(documentViewer)
	    End Function

        Private Sub HandleSelectors(documentViewer As DocumentViewer)
            Dim context = Hosting.GetHttpContext()

            Dim selectedLanguage = context.Request("languageSelector")
            If selectedLanguage IsNot Nothing Then
                documentViewer.DisplayLanguage = selectedLanguage
            Else
                selectedLanguage = documentViewer.DisplayLanguage
            End If
            PopulateLanguageSelector(selectedLanguage)

            Dim selectedTheme = context.Request("themeSelector")
            If selectedTheme IsNot Nothing Then
                documentViewer.Theme = selectedTheme
            Else
                selectedTheme = documentViewer.Theme
            End If
            PopulateThemeSelector(selectedTheme)
        End Sub

        Private Sub PopulateLanguageSelector(selectedLanguage As String)
            ViewBag.LanguageList = New SelectList(
                DocumentUltimateWebConfiguration.AvailableDisplayCultures.Select(Function(culture) New With {
                    .Value = culture.Name,
                    .Text = culture.NativeName + $" ({culture.Name})"
                }),
                "Value",
                "Text",
                selectedLanguage
            )
        End Sub

        Private Sub PopulateThemeSelector(selectedTheme As String)
            ViewBag.ThemeList = New SelectList(
                New Dictionary(Of String, String)() From {
                    {"slate (Dark Mode: classic-dark)", "slate, classic-dark"},
                    {"classic-light (Dark Mode: classic-dark)", "classic-light, classic-dark"},
                    {"classic-dark", "classic-dark"}
                },
                "Value",
                "Key",
                selectedTheme)
        End Sub
    End Class
End Namespace
