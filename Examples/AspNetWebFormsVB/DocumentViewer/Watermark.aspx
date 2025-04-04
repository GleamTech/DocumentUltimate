<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Watermark.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.AspNetWebFormsVB.DocumentViewer.WatermarkPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Watermarking pages</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="960" 
        Height="720"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.doc">
        
	    <DocumentOptions>
	        <Watermarks>
	            <GleamTech:TextWatermark 
	                Text="Contoso" 
	                Rotation="-45"
	                Opacity="50" 
	                FontColor="Red"
	                Width="50"
	                Height="50"
	                SizeIsPercentage="True" />
	        
	            <GleamTech:ImageWatermark
	                Image="~/App_Data/contoso-logo.png"
	                HorizontalAlignment="Right"
	                VerticalAlignment="Top"
	                Opacity="50"
	                PageRange="Odd" />
	        </Watermarks>
	    </DocumentOptions>

    </GleamTech:DocumentViewerControl>

</body>
</html>
