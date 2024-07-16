@Imports GleamTech.AspNet.UI
@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate.AspNet.UI
@ModelType DocumentViewer
<!DOCTYPE html>

<html>
<head>
    <title>Client-side events</title>
    @Me.RenderHead(Model)

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
    @Me.RenderBody(TryCast(ViewBag.ExampleFileSelector, Component))

    <p>
        Events:<br />
        <textarea id="LogTextBox" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></textarea>
        <br /><input type="button" value="Clear" onclick="clearLog();" />
    </p>

    @Me.RenderBody(Model)
</body>
</html>
