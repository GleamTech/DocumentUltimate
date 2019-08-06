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
        function documentViewerLoaded(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerFailed(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerDocumentLoaded(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPageChanged(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPageRendered(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerRotationChanged(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerDownloading(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrinting(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrintProgress(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrinted(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function logEvent(e) {
            var logTextBox = document.getElementById("LogTextBox");

            var now = new Date().toLocaleTimeString();
            var json = JSON.stringify(e, null, 2);
            logTextBox.value += "[" + now + "]" + "\nEvent arguments: " + json + "\n\n";
            logTextBox.scrollTop = logTextBox.scrollHeight;
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
