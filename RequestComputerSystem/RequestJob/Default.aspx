<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.RequestJob.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div class="row col-12 mx-auto h1 text-center">
            TEST
            <input id="inp_test" value="" runat="server" />
            <button id="btn_test" class="btn btn-outline-danger" onserverclick="btn_test_ServerClick" runat="server">TEST</button>
            <asp:DropDownList ID="dd_test" runat="server">
                <asp:ListItem Text="F 1" Value="1"></asp:ListItem>
                <asp:ListItem Text="F 2" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>

</asp:Content>
