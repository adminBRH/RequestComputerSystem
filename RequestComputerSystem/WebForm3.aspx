<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="RequestComputerSystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <form runat="server">
    <div class="row">
       <div class="card card-header h2 alert-primary col-xl-5 col-md-12">
           Header
       </div>
       <div class="card card-body col-xl-5 col-md-12">
           Body
           <asp:Button ID="xx" Text="SUBMIT" OnClick="xx_Click" runat="server" />
       </div>
       <div class="card card-footer col-xl-5 col-md-12">
           Footer
       </div>
    </div>
    </form>

</asp:Content>
