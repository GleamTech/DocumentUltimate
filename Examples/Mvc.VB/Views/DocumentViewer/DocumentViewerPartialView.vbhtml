@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate.AspNet.UI
@ModelType DocumentViewer

Partial view rendered at @DateTime.Now.ToString("T")

@Me.RenderBody(Model)
