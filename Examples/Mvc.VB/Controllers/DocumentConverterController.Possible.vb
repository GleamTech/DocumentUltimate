Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Web
Imports GleamTech.DocumentUltimate
Imports GleamTech.DocumentUltimateExamples.Mvc.VB.Models
Imports GleamTech.ExamplesCore

Namespace Controllers
    Partial Public Class  DocumentConverterController
        Inherits Controller

	    Public Function Possible() As ActionResult
		    Dim model = New PossibleViewModel()

		    PopulateInputFormats(model)
		    PopulateOutputFormats(model)

		    model.ResultHandlerUrl = ExamplesCoreConfiguration.GetDynamicDownloadUrl(ResultHandlerName, 
                New NameValueCollection() From {
			        {"version", DateTime.UtcNow.Ticks.ToString()}
		        })

		    Return View(model)
	    End Function

	    Private Sub PopulateInputFormats(model As PossibleViewModel)
		    For Each formatInfo As DocumentFormatInfo In DocumentFormatInfo.Enumerate(DocumentFormatSupport.Load)
			    Dim groupData As List(Of SelectListItem) = Nothing
			    If Not model.InputFormats.TryGetValue(formatInfo.Group.Description, groupData) Then
				    groupData = New List(Of SelectListItem)()
				    model.InputFormats.Add(formatInfo.Group.Description, groupData)
			    End If
			    groupData.Add(New SelectListItem() With {
				    .Text = formatInfo.Description,
				    .Value = formatInfo.Value.ToString()
			    })
			    model.InputFormatCount += 1
		    Next
	    End Sub

	    Private Sub PopulateOutputFormats(model As PossibleViewModel)
		    For Each formatInfo As DocumentFormatInfo In DocumentFormatInfo.Enumerate(DocumentFormatSupport.Save)
			    Dim groupData As List(Of SelectListItem) = Nothing
			    If Not model.OutputFormats.TryGetValue(formatInfo.Group.Description, groupData) Then
				    groupData = New List(Of SelectListItem)()
				    model.OutputFormats.Add(formatInfo.Group.Description, groupData)
			    End If
			    groupData.Add(New SelectListItem() With {
				    .Text = formatInfo.Description,
				    .Value = formatInfo.Value.ToString()
			    })
			    model.OutputFormatCount += 1
		    Next
	    End Sub

	    Public Shared Sub ResultHandler(context As HttpContext)
		    Dim inputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("inputFormat")), DocumentFormat)
		    Dim outputFormat = DirectCast([Enum].Parse(GetType(DocumentFormat), context.Request("outputFormat")), DocumentFormat)

		    context.Response.Write("<center>")

		    If DocumentConverter.CanConvert(inputFormat, outputFormat) Then
			    context.Response.Write(String.Format("<span style=""color: green; font-weight: bold"">Direct conversion from {0} to {1} is possible</span>", inputFormat, outputFormat))

			    For Each engineEnforcement As DocumentEngineEnforcement In [Enum](Of DocumentEngineEnforcement).GetValues()
				    If engineEnforcement = DocumentEngineEnforcement.Auto Then
					    Continue For
				    End If

				    If DocumentConverter.CanConvert(inputFormat, outputFormat, engineEnforcement) Then
					    context.Response.Write(String.Format("<br/><span style=""color: green; font-weight: bold"">Via {0} Engine &#x2713;</span>", engineEnforcement.ToString().Replace("Force", "")))
				    Else
					    context.Response.Write(String.Format("<br/><span style=""color: red; font-weight: bold"">Via {0} Engine &#x2717;</span>", engineEnforcement.ToString().Replace("Force", "")))
				    End If
			    Next
		    Else
			    context.Response.Write(String.Format("<span style=""color: red; font-weight: bold"">Direct conversion from {0} to {1} is not possible</span>", inputFormat, outputFormat))
		    End If

		    context.Response.Write("</center>")
	    End Sub

	    Private Shared ReadOnly Property ResultHandlerName() As String
		    Get
			    If m_resultHandlerName Is Nothing Then
				    m_resultHandlerName = "ResultHandler"
				    ExamplesCoreConfiguration.RegisterDynamicDownloadHandler(m_resultHandlerName, AddressOf ResultHandler)
			    End If

			    Return m_resultHandlerName
		    End Get
	    End Property
	    Private Shared m_resultHandlerName As String
    End Class
End Namespace
