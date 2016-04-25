<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Protection.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer.ProtectionPage" %>
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
        DocumentPath="~/App_Data/PDF Document.pdf"
        DisableDownload="True"
        DisablePrint="True"
        DisableTextSelection="True" />

</body>
</html>
