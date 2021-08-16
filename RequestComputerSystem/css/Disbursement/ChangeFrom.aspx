<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeFrom.aspx.cs" Inherits="RequestComputerSystem.Disbursement.ChangeFrom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-9 mx-auto" id="mainpage" runat="server">
        <div class="card">
            <div class ="card-body">
                <div class="text-center"><img src="img/LOGO-BRH.png" width="250px"/></div>
                <div class="card-header mt-1 text-center" style="background-color:aquamarine"><h3>แบบฟอร์มการเบิก</h3></div>
                <div class="col-12 mx-auto text-center" style="background-color:aliceblue">
                    <div class="mx-auto text-center mt-5">
                        <asp:DropDownList CssClass="btn btn-light" ID="ddl_form" AutoPostBack="true" OnSelectedIndexChanged="ddl_form_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="กรุณาเลือกแบบฟอร์ม" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="แบบบันทึกการขออนุมัติเบิก-จ่ายเงิน Internal Routing Slip" Value="1"></asp:ListItem>
                            <asp:ListItem Text="แบบบันทึกการขออนุมัติเบิก-จ่ายเงินค่าเดินทางสำหรับแพทย์ (Internal Routing Slip)" Value="2"></asp:ListItem>
                            <asp:ListItem Text="แบบบันทึกการขออนุมัติเบิก-จ่ายเงิน (การจ่ายคืน Deposit) Internal Routing Slip" Value="3"></asp:ListItem>
                            <asp:ListItem Text="แบบบันทึกขออนุมัติยกเลิกค่าแพทย์" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
            </div>
        </div>
    </div>
</form>
</asp:Content>
