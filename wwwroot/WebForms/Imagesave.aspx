<%@ Page language="c#" Codebehind="Imagesave.aspx.cs" AutoEventWireup="false" Inherits="SaveImg.Imagesave" %>
<!DOCTYPE html>
<HTML smlns="http://www.w3.org/1999/xhtml">
   <HEAD runat="server">
      <title>Save Image</title>
      
   </HEAD>
   <body>
      <form id="form1" method="post" runat="server" EncType="multipart/form-data" action="Imagesave.aspx">
         Image file to upload to the server: 
       <!-- <INPUT id="oFile" type="file" runat="server" NAME="oFile">  -->
        <div>
            Upload Image<asp:FileUpload id="FileImgsave" runat="server"/>        
            <br/>
            <asp:button id="ButtonSave" type="submit" text="Upload" runat="server"/>
            <p><asp:Literal id="LitMsg" runat="server" Text="Button"></asp:Literal></p>
        </div>

      </form>
   </body>
</HTML>