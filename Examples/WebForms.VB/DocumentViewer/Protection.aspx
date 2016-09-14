<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Protection.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.ProtectionPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Copy protection (DRM)</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewer ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/PDF Document.pdf"
        DownloadEnabled="False"
        DownloadAsPdfEnabled="False"
        PrintEnabled="False"
        TextSelectionEnabled="False" />

</body>
</html>
