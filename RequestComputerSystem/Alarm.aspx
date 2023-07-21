<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alarm.aspx.cs" Inherits="RequestComputerSystem.Alarm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row col-12 mx-auto">
        <div id="div_icon" class="col-12 mx-auto text-center">
            <img id="img_icon" src="..." width="250" height="250" runat="server" />
        </div>
        <div class="col-12 mx-auto text-center">
            <asp:Label ID="lbl_topic" Text="" Font-Size="X-Large" Font-Bold="true" runat="server"></asp:Label>
        </div>
        <div class="col-12 mx-auto mt-2 text-center">
            <asp:Label ID="lbl_detail" Text="" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>
