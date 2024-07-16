
Imports System.Globalization
Imports GleamTech.DocumentUltimate.AspNet

Namespace DocumentViewer
    Public Class OverviewPage
        Inherits Page

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            documentViewer.Document = exampleFileSelector.SelectedFile.ToString()

            If IsPostBack Then
                documentViewer.DisplayLanguage = LanguageSelector.SelectedValue
                documentViewer.Theme = ThemeSelector.SelectedValue
            Else
                PopulateLanguageSelector()
                PopulateThemeSelector()
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

        Private Sub PopulateThemeSelector()
            Dim themes = New Dictionary(Of String, String)() From {
                {"slate (Dark Mode: classic-dark)", "slate, classic-dark"},
                {"classic-light (Dark Mode: classic-dark)", "classic-light, classic-dark"},
                {"classic-dark", "classic-dark"}
            }

            For Each kvp In themes
                Dim listItem = New ListItem(kvp.Key, kvp.Value)
                If kvp.Value = documentViewer.Theme Then
                    listItem.Selected = True
                End If
                ThemeSelector.Items.Add(listItem)
            Next
        End Sub

    End Class
End Namespace
