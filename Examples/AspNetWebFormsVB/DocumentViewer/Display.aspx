<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Display.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsVB.DocumentViewer.DisplayPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Displaying control on demand</title>
</head>
<body style="margin: 20px;">

    1. DocumentViewer instance displayed as inline element:
    <input type="button" value="Show" onclick="documentViewer1.show()" />
    <input type="button" value="Hide" onclick="documentViewer1.hide()" />
    <br /><br />
    <GleamTech:DocumentViewerControl ID="documentViewer1" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.pdf"
        Hidden="True" />

    2. DocumentViewer instance displayed as a modal dialog:
    <input type="button" value="Show" onclick="documentViewer2.show()" />
    <br /><br />
    <GleamTech:DocumentViewerControl ID="documentViewer2" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.pdf"
        Hidden="True"
        DisplayMode="Window"
        WindowOptions-Title="DocumentViewer as a modal dialog"
        WindowOptions-Modal="True"
        WindowOptions-Maximizable="True"
        WindowOptions-Minimizable="True" />

    3. DocumentViewer instance displayed as a panel:
    <input type="button" value="Show" onclick="documentViewer3.show()" />
    <input type="button" value="Hide" onclick="documentViewer3.hide()" />
    <br /><br />
    <GleamTech:DocumentViewerControl ID="documentViewer3" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.pdf"
        Hidden="True"
        DisplayMode="Panel"
        PanelOptions-Title="DocumentViewer as a panel"
        PanelOptions-Collapsible="True" />

</body>
</html>
