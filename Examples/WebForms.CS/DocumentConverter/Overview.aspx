<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentConverter.OverviewPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.ExamplesCore" Assembly="GleamTech.ExamplesCore" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Overview</title>
</head>
<body style="margin: 20px;">
    <GleamTech:ExampleFileSelector ID="exampleFileSelector" runat="server"
        InitialFile="PDF Document.pdf" />
    
    <form runat="server">
        <p>Input format: <b><%=InputFormat%></b></p>
        <p>
            Choose output format:
            <asp:Repeater ID="TargetFormats" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <select id="<%=TargetFormats.ClientID %>">
                </HeaderTemplate>
                <ItemTemplate>
                        <optgroup label="<%# Eval("Key") %>">
                            <asp:Repeater runat="server" DataSource='<%# Eval("Value") %>'>
                                <ItemTemplate>
                                    <option value="<%# Eval("Value") %>"><%# Eval("Text") %></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </optgroup>
                </ItemTemplate>
                <FooterTemplate>
                    </select>
                </FooterTemplate>
            </asp:Repeater>
        </p>
        <asp:Button runat="server" Text="Convert"/>
    </form>
</body>
</html>
