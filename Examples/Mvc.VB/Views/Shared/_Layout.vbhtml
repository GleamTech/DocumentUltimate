<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @If (IsSectionDefined("documentViewerHead")) Then
        @RenderSection("documentViewerHead")
    End If
</head>
<body style="margin: 20px;">
    @RenderBody()
</body>
</html>
