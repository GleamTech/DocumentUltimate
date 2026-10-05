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
        @<label>Change language: @Html.DropDownList("languageSelector", DirectCast(ViewBag.LanguageList, SelectList), New With {.onchange = "this.form.submit();"})</label>
        @<label style = "margin-left: 20px" > Large UI Sizing: <input type = "checkbox" id="uiSizing" onchange="documentViewer.uiSizing = this.checked ? 'large' : 'normal';"></label>
        @<label style = "margin-left: 20px" >
            Change theme @Html.DropDownList("themeSelector", DirectCast(ViewBag.ThemeList, SelectList), New With
            {
                .onchange = "documentViewer.theme = this.value;",
                .title = "Note that you can emulate prefers-color-scheme via browser's F12 dev tools to test dark mode which is normally activated according to user's OS preferences."
            })
        </label>
        @<br />@<br />

        @Me.RenderBody(TryCast(ViewBag.ExampleFileSelector, Component))
    End Using


    @Me.RenderBody(Model)
</body>
</html>
