<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Protection.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsVB.DocumentViewer.ProtectionPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Copy protection (DRM)</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.pdf"
        DeniedPermissions="Download, DownloadAsPdf, Print, SelectText" />

</body>
</html>
