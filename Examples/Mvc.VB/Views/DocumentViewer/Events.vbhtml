@Imports GleamTech.Web
@Imports GleamTech.Web.Mvc
@Imports GleamTech.DocumentUltimate.Web
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Events</title>
    @Html.RenderCss(Model)
    @Html.RenderJs(Model)

    <script type="text/javascript">
        function documentViewerLoad(sender, e) {
            log("ClientLoad", "Viewer is loaded");
        }

        function documentViewerError(sender, e) {
            //e.message
            log("ClientError", "An error has occured: " + e.message);
        }

        function documentViewerDocumentLoad(sender, e) {
            log("ClientDocumentLoad", "Document is loaded");
        }

        function documentViewerPageChange(sender, e) {
            //e.pageNumber
            log("ClientPageChange", "Viewing page " + e.pageNumber);
        }

        function documentViewerPageComplete(sender, e) {
            //e.pageNumber
            log("ClientPageComplete", "Rendered page " + e.pageNumber);
        }

        function documentViewerPrint(sender, e) {
            log("ClientPrint", "Print button is clicked");
        }

        function documentViewerDownload(sender, e) {
            log("ClientDownload", "Download button is clicked");
        }

        function documentViewerDownloadAsPdf(sender, e) {
            log("ClientDownloadAsPdf", "DownloadAsPdf button is clicked");
        }

        function documentViewerPrintStart(sender, e) {
            //e.totalPages
            log("ClientPrintStart", "Started printing " + e.totalPages + " pages");
        }

        function documentViewerPrintProgress(sender, e) {
            //e.pageNumber
            //e.printNumber
            //e.totalPages
            log("ClientPrintProgress", "Printing page " + e.pageNumber + " (" + e.printNumber + " of " + e.totalPages + ")");
        }

        var logTextBox;

        function log(type, text) {
            if (!logTextBox)
                logTextBox = document.getElementById("LogTextBox");

            var now = new Date().toLocaleTimeString();
            logTextBox.value += "[" + now + "]" + "[" + type + "]: " + text + "\n";
            logTextBox.scrollTop = logTextBox.scrollHeight;
        }

        function clearLog() {
            logTextBox.value = "";
        }
    </script>

</head>
<body style="margin: 20px;">
    @Html.RenderControl(TryCast(ViewBag.ExampleFileSelector, IHtmlWriterControl))

    <p>
        Events:<br />
        <textarea id="LogTextBox" style="width: 800px; height: 200px;" readonly></textarea><br />
        <button onclick="clearLog()">Clear</button>
    </p>

    @Html.RenderControl(Model)
</body>
</html>
