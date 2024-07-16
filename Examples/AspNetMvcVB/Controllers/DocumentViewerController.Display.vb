Imports GleamTech.AspNet.UI
Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        Public Function Display() As ActionResult

            Dim documentViewer1 = New DocumentViewer With {
                .Id = "documentViewer1",
                .Width = 800,
                .Height = 600,
                .Resizable = True,
                .Document = "~/App_Data/ExampleFiles/Default.pdf",
                .Hidden = True
            }

            Dim documentViewer2 = New DocumentViewer With {
                .Id = "documentViewer2",
                .Width = 800,
                .Height = 600,
                .Resizable = True,
                .Document = "~/App_Data/ExampleFiles/Default.pdf",
                .Hidden = True,
                .DisplayMode = DisplayMode.Window,
                .WindowOptions = New WindowOptions With {
                    .Title = "DocumentViewer as a modal dialog",
                    .Modal = True,
                    .Maximizable = True,
                    .Minimizable = True
                }
            }

            Dim documentViewer3 = New DocumentViewer With {
                .Id = "documentViewer3",
                .Width = 800,
                .Height = 600,
                .Resizable = True,
                .Document = "~/App_Data/ExampleFiles/Default.pdf",
                .Hidden = True,
                .DisplayMode = DisplayMode.Panel,
                .PanelOptions = New PanelOptions With {
                    .Title = "DocumentViewer as a panel",
                    .Collapsible = True
                }
            }

            Return View({documentViewer1, documentViewer2, documentViewer3})

        End Function

    End Class
End Namespace
