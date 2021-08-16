<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorList.aspx.cs" Inherits="RequestComputerSystem.VendorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">   
        
        <div class="card ">
        <div class="card-body text-center">
        
            <asp:GridView ID="vd_detail" class="col-12" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>

                    

                    <asp:BoundField DataField="vd_fname" HeaderText="Firstname"></asp:BoundField>
                    <asp:BoundField DataField="vd_lname" HeaderText="Lastname"></asp:BoundField>
                    <asp:BoundField DataField="vd_email" HeaderText="Email"></asp:BoundField>
                    <asp:BoundField DataField="vd_shopname" HeaderText="Shop Name"></asp:BoundField>
                    <asp:BoundField DataField="vd_url" HeaderText="Company URL"></asp:BoundField>
                   
                    <asp:BoundField DataField="vd_pnumber" HeaderText="Phone Number"></asp:BoundField>
                    <asp:BoundField DataField="vd_address" HeaderText="Address"></asp:BoundField>
                    <asp:BoundField DataField="vd_street" HeaderText="Street"></asp:BoundField>
                    <asp:BoundField DataField="vd_district" HeaderText="District"></asp:BoundField>
                    <asp:BoundField DataField="vd_province" HeaderText="Province"></asp:BoundField>
                    <asp:BoundField DataField="vd_zipcode" HeaderText="Zipcode"></asp:BoundField>
           
                    <asp:TemplateField HeaderText="Profile">
                        <ItemTemplate>
                           <a href="VendorEdit.aspx?id=<%# Eval("vd_id") %>">Profile</a> 
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                <RowStyle ForeColor="#000066"></RowStyle>

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
        
        </div>
        </div>
        
    </form>
</asp:Content>
