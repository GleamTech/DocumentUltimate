<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Overview.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Overview</title>
</head>
<body style="margin: 20px;">
    <form id="form1" runat="server">
        <table border="0">
            <tr>
                <td valign="top">
                    Choose file: <asp:DropDownList runat="server" ID="fileSelector" AutoPostBack="true" EnableViewState="False" />
                    <br />
                    <br />
                </td>
                <td valign="top" style="padding-left:50px">
                    or Upload File (Max 10 MB): <asp:FileUpload ID="file" runat="server" onchange="this.form.submit();" />
                </td>
            </tr>
        </table>
    </form>

    <GleamTech:DocumentViewer ID="documentViewer" runat="server" 
        Width="800" 
        Height="600" 
        Resizable="True" />

</body>
</html>
