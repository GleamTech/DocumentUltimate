<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsCS.DocumentViewer.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Common" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Overview</title>
</head>
<body style="margin: 20px;">
    <form id="form1" runat="server">
        <label>Change language: <asp:DropDownList ID="LanguageSelector" runat="server" AutoPostBack="true"></asp:DropDownList></label>
        <label style="margin-left: 20px">Large UI Sizing: <input type="checkbox" id="uiSizing" onchange="documentViewer.uiSizing = this.checked ? 'large' : 'normal';"></label>
        <label style="margin-left: 20px">
            Change theme: <asp:DropDownList ID="ThemeSelector" runat="server" onchange="documentViewer.theme = this.value;"></asp:DropDownList>
        </label>
        <br /><br />

        <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
            InitialFile="Default.pdf"
            FormWrapped="False" />
    </form>


    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="960" 
        Height="720" 
        Resizable="True" />
</body>
</html>
