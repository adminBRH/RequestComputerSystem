<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RequestComputerSystem.Disbursement.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

        <div class="col-12 mx-auto">
            <asp:GridView ID="GridView1" CssClass="mx-auto" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

                <Columns>
                    <asp:BoundField DataField="type" HeaderText="Type"></asp:BoundField>
                    <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="d_datetime" HeaderText="CreateDate"></asp:BoundField>
                    <asp:BoundField DataField="d_empid" HeaderText="Emp_id"></asp:BoundField>
                    <asp:BoundField DataField="d_status" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="d_deptcode" HeaderText="Department"></asp:BoundField>
                    <asp:BoundField DataField="d_formid" HeaderText="formid"></asp:BoundField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            &nbsp;&nbsp;&nbsp; <a class="btn btn-outline-dark" href="List.aspx?id=<%# Eval("id") %>&form=<%# Eval("d_formid") %>">Detail</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>

                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>

                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#000065"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>

    </form>

</asp:Content>
