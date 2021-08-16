<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="RequestComputerSystem.signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <form id="form1" runat="server" class="align-items-center">

        <div class="w-25">

          <img class="center" src="image/iconfinder_Rounded-31_2024644.png" alt="" width="20%" height="10%">
            <hr />
          <label for="inputUser" class="sr-only">User</label>
          <input type="user" id="inputUser" class="form-control" placeholder="User Test" required="" autofocus="" runat="server">
          <label for="inputPassword" class="sr-only">Password</label>
          <input type="password" id="inputPassword" class="form-control" placeholder="Password" required="" runat="server">
          <div class="checkbox mb-3 center">
            <label>
              <input type="checkbox" value="remember-me"> Remember me
            </label>
          </div>
          <asp:Button ID="Button2" class="btn btn-md btn-primary btn-block" runat="server" Text="Sign in" OnClick="Button2_Click" />
        </div>

            <br />
            <%--  --%>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            <asp:Label ID="lblText" runat="server"></asp:Label>

        </form>

</asp:Content>
