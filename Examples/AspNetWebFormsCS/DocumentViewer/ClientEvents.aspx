<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientEvents.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsCS.DocumentViewer.ClientEventsPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Common" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Client-side events</title>
    
    <script type="text/javascript">
        function documentViewerLoaded(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerFailed(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerDocumentLoaded(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerPageChanged(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerPageRendered(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerRotationChanged(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerDownloading(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerPrinting(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerPrinted(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerTextSelected(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function documentViewerTextCopied(e) {
            var documentViewer = e.target;

            logEvent(e.detail);
        }

        function logEvent(detail) {
            var logTextBox = document.getElementById("LogTextBox");

            var now = new Date().toLocaleTimeString();
            var json = JSON.stringify(detail, null, 2);
            logTextBox.value = "[" + now + "]" + "\nEvent arguments: " + json + "\n\n" + logTextBox.value;
            logTextBox.scrollTop = 0;
        }

        function clearLog() {
            var logTextBox = document.getElementById("LogTextBox");

            logTextBox.value = "";
        }
    </script>
</head>
<body style="margin: 20px;">
    <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
        InitialFile="Default.pdf" />

    <p>
        Events:<br/>
        <textarea id="LogTextBox" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></textarea>
        <br /><input type="button" value="Clear" onclick="clearLog();" />
    </p>

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True">
        
        <ClientEvents Loaded="documentViewerLoaded"
                      Failed="documentViewerFailed"
                      DocumentLoaded="documentViewerDocumentLoaded"
                      PageChanged="documentViewerPageChanged"
                      PageRendered="documentViewerPageRendered"
                      RotationChanged="documentViewerRotationChanged"
                      Downloading="documentViewerDownloading"
                      Printing="documentViewerPrinting"
                      Printed="documentViewerPrinted"
                      TextSelected="documentViewerTextSelected" 
                      TextCopied="documentViewerTextCopied" />

    </GleamTech:DocumentViewerControl>
    
</body>
</html>
