@Imports GleamTech.AspNet.UI
@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate.AspNet.UI
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Overview</title>
    @Me.RenderHead(Model)

    @*
        If you prefer, JS can also be rendered at the bottom of the page,
        by first calling RenderHeadWithoutJs in <head>:

        @this.RenderHeadWithoutJs(Model)

        and then calling RenderJs before the closing </body> tag:

        @this.RenderJs(Model)
    *@
</head>
<body style="margin: 20px;">
    @Using (Html.BeginForm())
        @<text>Change language: </text>@Html.DropDownList("languageSelector", DirectCast(ViewBag.LanguageList, SelectList), New With {.onchange = "this.form.submit();"})
        @<br />@<br />
    End Using

    @Me.RenderBody(TryCast(ViewBag.ExampleFileSelector, Component))

    @Me.RenderBody(Model)
</body>
</html>
