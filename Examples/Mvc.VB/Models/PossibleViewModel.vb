Imports System.Collections.Generic

Namespace Models

    Public Class PossibleViewModel
        Public Sub New()
            InputFormats = New Dictionary(Of String, List(Of SelectListItem))()
            OutputFormats = New Dictionary(Of String, List(Of SelectListItem))()
        End Sub

        Public Property InputFormatCount As Integer

        Public Property OutputFormatCount As Integer

        Public Property ResultHandlerUrl As String

        Public Property InputFormats As Dictionary(Of String, List(Of SelectListItem))

        Public Property OutputFormats As Dictionary(Of String, List(Of SelectListItem))
    End Class
End NameSpace