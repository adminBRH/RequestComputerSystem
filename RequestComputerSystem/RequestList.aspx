<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="RequestComputerSystem.RequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">
    <div class="row">
        <div class="col-12 mb-2 input-group">
            <div class="col-3">
                <asp:DropDownList ID="ddl_status" CssClass="btn btn-outline-primary mb-2" runat="server">
                    <asp:ListItem Text="All ทั้งหมด" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Close Job (จบงาน)" Value="CloseJob"></asp:ListItem>
                    <%--<asp:ListItem Text="Finish (อนุมัติครบ)" Value="Finish"></asp:ListItem>--%>
                    <asp:ListItem Text="Wait (รออนุมัติ)" Value="Wait"></asp:ListItem>
                    <%--<asp:ListItem Text="Approved (อนุมัติแล้ว)" Value="Approved"></asp:ListItem>--%>
                    <asp:ListItem Text="Cancel (ยกเลิก)" Value="Cancel"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddl_system" CssClass="btn btn-outline-primary mb2" runat="server">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <input type="text" id="txtdate" class="form-control" placeholder="yyyy-mm-dd" runat="server" />
            </div>
            <div class="col-3">
                <asp:Button ID="bt_search" CssClass="btn btn-outline-primary float-left" Text="Search" OnClick="bt_search_Click" runat="server" />
            </div>
        </div>
        <div class="card col-12 mb-2 mx-auto">
        <center>
            <asp:GridView ID="GridView1" runat="server" PageSize="20" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
<Columns>
                    <asp:BoundField DataField="rqdateadd" HeaderText="Request Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                    <asp:BoundField DataField="ReqID" HeaderText="Request ID"><ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundField>
                    <asp:BoundField DataField="sysname" HeaderText="Systems"></asp:BoundField>
                    <asp:BoundField DataField="UserReqName" HeaderText="Request for"></asp:BoundField>
                    <asp:BoundField DataField="UserReqDeptName" HeaderText="Department"></asp:BoundField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <img src="image/gif/Alert_Light.gif" alt="Edit" border="0" width="32" data-toggle="tooltip" data-placement="left" title="รอการอนุมัตินานเกิน 7วัน" >
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="apstatus" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField DataField="aplname" HeaderText=""></asp:BoundField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            &nbsp;&nbsp;&nbsp; <a class="btn btn-outline-info" href="DetailSystems.aspx?apid=<%# Eval("apid") %>">Detail</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkapprove" runat="server" CssClass="btn btn-outline-info"
                                CommandName="approve" CommandArgument='<%# Eval("rqsid") %>'><img src="image/icons/approve.png" alt="Edit" border="0" width="25" >
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EditRowStyle BackColor="#2461BF"></EditRowStyle>

<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#2461BF"></PagerStyle>

                <RowStyle BackColor="#EFF3FB"></RowStyle>

                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </center>
        </div>
    </div>
</form>


<script>
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
</script>

</asp:Content>
