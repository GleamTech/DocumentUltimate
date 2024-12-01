<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileProvider.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsCS.DocumentViewer.FileProviderPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Using with a custom FileProvider</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True" />

</body>
</html>
