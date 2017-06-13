﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Watermark.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.WatermarkPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Watermarking pages</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewer ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.doc">

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
                ImageFile="~/App_Data/contoso-logo.png"
                HorizontalAlignment="Right"
                VerticalAlignment="Top"
                Opacity="50"
                PageRange="Odd" />
        </Watermarks>

    </GleamTech:DocumentViewer>

</body>
</html>
