@Imports GleamTech.Web.Mvc
@Imports GleamTech.DocumentUltimate.Web
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Copy protection (DRM)</title>
    @Html.RenderCss(Model)
    @Html.RenderJs(Model)
</head>
<body style="margin: 20px;">
    @Html.RenderControl(Model)
</body>
</html>
