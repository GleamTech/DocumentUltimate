<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Highlight.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer.HighlightPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Highlighting keywords</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewer ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True"
        DocumentPath="~/App_Data/DOC Document.doc" />

</body>
</html>
