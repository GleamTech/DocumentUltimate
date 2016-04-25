@Imports GleamTech.Web.Mvc
@Imports GleamTech.DocumentUltimate.Web
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Highlighting keywords</title>
    @Html.RenderCss(Model)
    @Html.RenderJs(Model)
</head>
<body style="margin: 20px;">
    @Html.RenderControl(Model)
</body>
</html>
