<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderRequestList.aspx.cs" Inherits="RequestComputerSystem.OrderRequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form runat="server">
    <div class="card card-header h1 text-center bg-gradient-primary" style="color:white">
        รายการ Change Order Items ที่ร้องขอเข้ามา
    </div>
    <div class="card col-lg-10 col-sm-12 bg-light mx-auto">
        <div class="row col-12 mx-auto">
            <div class="col-6 mx-auto my-3">
                เลือกโรงพยาบาล
                <asp:DropDownList ID="DD_branch" CssClass="form-control" OnSelectedIndexChanged="DD_branch_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
            </div>
            <div class="col-6 mx-auto my-3">
                เลือกสถานะ
                <asp:DropDownList ID="DD_Status" CssClass="form-control" OnSelectedIndexChanged="DD_Status_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-12 mx-auto">
                <asp:GridView ID="GridView1" CssClass="col-12 mx-auto" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">
                    <Columns>
                        <asp:BoundField DataField="rqid" HeaderText="RequestID" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0: dd/MMM/yyyy}"></asp:BoundField>
                        <asp:BoundField DataField="empname" HeaderText="Request By"></asp:BoundField>
                        <asp:BoundField DataField="deptid" HeaderText="Depart ID"></asp:BoundField>
                        <asp:BoundField DataField="deptname" HeaderText="Depart Name"></asp:BoundField>
                        <asp:BoundField DataField="status" HeaderText="Status"></asp:BoundField>
                        <asp:BoundField DataField="Approvename" HeaderText="Approval"></asp:BoundField>
                        <asp:TemplateField HeaderText="Approve" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a class="btn btn-outline-primary" href="OrderRequestApprove.aspx?id=<%# Eval("rqid") %>">
                                    <img src="image/icons/approve.png" alt="DetailApprove" border="0" width="25"></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Print" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a class="btn btn-outline-primary" href="OrderRequestPrint.aspx?id=<%# Eval("rqid") %>">
                                    <img src="image/icons/print-icon.png" alt="Print" border="0" width="25"></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"></FooterStyle>
                    <HeaderStyle CssClass="bg-gradient-primary" Font-Bold="True" ForeColor="#E7E7FF" HorizontalAlign="Center"></HeaderStyle>
                    <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black"></PagerStyle>
                    <RowStyle CssClass="bg-gradient-light" ForeColor="Black"></RowStyle>
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#594B9C"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#33276A"></SortedDescendingHeaderStyle>
            </asp:GridView>
            </div>
        </div>
    </div>
</form>
</asp:Content>

