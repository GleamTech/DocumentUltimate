<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Overview.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsVB.DocumentViewer.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Common" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Overview</title>
</head>
<body style="margin: 20px;">
    <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
        InitialFile="Default.pdf" />

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="800" 
        Height="600" 
        Resizable="True" />
</body>
</html>
