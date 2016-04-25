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
    <table border="0">
        <tr>
            <td valign="top">
                @Using (Html.BeginForm("Overview", "DocumentViewer"))

                    @<text>Choose file: </text>@Html.DropDownList("fileSelector", DirectCast(ViewBag.FileList, SelectList), New With {.onchange = "this.form.submit();"})
                    @<br />
                    @<br />
                End Using

            </td>
            <td valign = "top" style="padding-left:50px">
                @Using (Html.BeginForm("Upload", "DocumentViewer", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
                    @<text>or Upload File (Max 10 MB): </text>@<input type="file" name="file" onchange="this.form.submit();" />
                End Using
            </td>
        </tr>
    </table>

    @Html.RenderControl(Model)

</body>
</html>
