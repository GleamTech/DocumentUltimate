<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Overview.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.ExamplesCore" Assembly="GleamTech.ExamplesCore" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Overview</title>
</head>
<body style="margin: 20px;">
    <GleamTech:ExampleFileSelector ID="exampleFileSelector" runat="server"
        InitialFile="PDF Document.pdf" />

    <GleamTech:DocumentViewer ID="documentViewer" runat="server" 
        Width="800" 
        Height="600" 
        Resizable="True" />
</body>
</html>
