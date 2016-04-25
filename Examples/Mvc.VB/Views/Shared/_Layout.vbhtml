<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @If (IsSectionDefined("DocumentUltimateCss")) Then
        @RenderSection("DocumentUltimateCss")
    End If
    @If (IsSectionDefined("DocumentUltimateJs")) Then
        @RenderSection("DocumentUltimateJs")
    End If
</head>
<body style="margin: 20px;">
    @RenderBody()
</body>
</html>
