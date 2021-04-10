<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false"
   Inherits="Howto.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
   <HEAD>
      <title>WebForm1</title>
      <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
      <meta name="CODE_LANGUAGE" Content="C#">
      <meta name="vs_defaultClientScript" content="JavaScript">
      <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
   </HEAD>
   <body MS_POSITIONING="GridLayout">
      <form id="Form1" method="post" runat="server" EncType="multipart/form-data" action="WebForm1.aspx">
         Image file to upload to the server: <INPUT id="oFile" type="file" runat="server" NAME="oFile">
         <asp:button id="btnUpload" type="submit" text="Upload" runat="server"></asp:button>
         <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
            <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
         </asp:Panel>
      </form>
   </body>
</HTML>