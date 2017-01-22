Imports System.Collections.Generic
Imports GleamTech.ExamplesCore

Namespace Models

    Public Class OverviewViewModel
        Public Sub New()
            OutputFormats = New Dictionary(Of String, List(Of SelectListItem))()
        End Sub

        Public Property ExampleFileSelector As ExampleFileSelector

        Public Property InputFormat As String

        Public Property ConvertHandlerUrl As String

        Public Property OutputFormats As Dictionary(Of String, List(Of SelectListItem))
    End Class
End NameSpace