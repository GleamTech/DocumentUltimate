
Imports System.Globalization
Imports GleamTech.DocumentUltimate.AspNet

Namespace DocumentViewer
    Public Class OverviewPage
        Inherits Page

	    Protected Sub Page_Load(sender As Object, e As EventArgs)
		    documentViewer.Document = exampleFileSelector.SelectedFile

	        If IsPostBack Then
	            documentViewer.DisplayLanguage = LanguageSelector.SelectedValue
	        Else
	            PopulateLanguageSelector()
	        End If
	    End Sub

        Private Sub PopulateLanguageSelector()
            For Each cultureInfo As CultureInfo In DocumentUltimateWebConfiguration.AvailableDisplayCultures
                Dim listItem = New ListItem(cultureInfo.NativeName + $" ({cultureInfo.Name})", cultureInfo.Name)
                If cultureInfo.Name = documentViewer.DisplayLanguage Then
                    listItem.Selected = True
                End If
                LanguageSelector.Items.Add(listItem)
            Next
        End Sub
    End Class
End NameSpace