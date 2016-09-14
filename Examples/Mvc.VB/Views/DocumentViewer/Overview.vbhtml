@Imports GleamTech.Web
@Imports GleamTech.Web.Mvc
@Imports GleamTech.DocumentUltimate.Web
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Overview</title>
    @Html.RenderCss(Model)
    @Html.RenderJs(Model)
</head>
<body style="margin: 20px;">
    @Html.RenderControl(TryCast(ViewBag.ExampleFileSelector, IHtmlWriterControl))

    @Html.RenderControl(Model)
</body>
</html>
