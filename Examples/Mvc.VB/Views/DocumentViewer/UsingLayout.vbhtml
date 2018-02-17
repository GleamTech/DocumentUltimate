@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate.AspNet.UI
@ModelType DocumentViewer

@Code
    ViewBag.Title = "UsingLayout"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section LayoutHead
    @Me.RenderHead(Model)
End Section

@Me.RenderBody(Model)
