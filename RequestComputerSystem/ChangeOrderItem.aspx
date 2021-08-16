<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeOrderItem.aspx.cs" Inherits="RequestComputerSystem.OrderItem.InputData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="h3 card card-header alert-primary">
            กรอกข้อมูล
        </div>
        <div class="card card-body">
            <div class="row">
                <div class="col-10">แผนก : 
                    <asp:DropDownList ID="dd_dept" runat="server">
                        
                    </asp:DropDownList>
                </div>
                <br /><br />
                <div class="col-5">ชื่อ : <asp:TextBox ID="txt_fname" Text="" runat="server"></asp:TextBox></div>
                <div class="col-5">นามสกุล : <asp:TextBox ID="txt_lname" Text="" runat="server"></asp:TextBox></div>
                <br /><br />
                <div class="col-5">วัตถุประสงค์เพื่อ : 
                    <asp:DropDownList ID="dd_objective" runat="server">
                        <asp:ListItem Text="Economic Condition" Value="Economic Condition"></asp:ListItem>
                        <asp:ListItem Text="Annual Reviews" Value="Annual Reviews"></asp:ListItem>
                        <asp:ListItem Text="New Department" Value="New Department"></asp:ListItem>
                        <asp:ListItem Text="New Product" Value="New Product"></asp:ListItem>
                        <asp:ListItem Text="New Work Flow" Value="New Work Flow"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList> 
                </div>
            </div>
        </div>
    </form>
</asp:Content>
