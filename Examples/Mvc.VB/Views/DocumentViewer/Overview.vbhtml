@Imports GleamTech.AspNet.UI
@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate.AspNet.UI
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Overview</title>
    @Me.RenderHead(Model)
</head>
<body style="margin: 20px;">
    @Me.RenderBody(TryCast(ViewBag.ExampleFileSelector, Component))

    @Me.RenderBody(Model)
</body>
</html>
