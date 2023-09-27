<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestList.aspx.cs" Inherits="RequestComputerSystem.RequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">

<style>
    .GridPager a, .GridPager span
    {
        display: block;
        height: 30px;
        width: 35px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }
</style>
    <div class="row">
        <script>
            var cookieValue = document.cookie;
            if (cookieValue == "updateData=yes") {
                document.cookie = "updateData=; expires=Thu, 01 Jan 1970 00:00:00 UTC;";
                __doPostBack('<%= bt_search.UniqueID %>', ''); // Search again
            }
        </script>
        <div class="col-4 mx-auto my-2">
            <asp:DropDownList ID="dd_branch" CssClass="form-control" OnSelectedIndexChanged="dd_branch_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        </div>
        <div class="col-4 mx-auto my-2">
            <asp:DropDownList ID="ddl_status" CssClass="form-control" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged" AutoPostBack="true" runat="server">
                <asp:ListItem Text="All ทั้งหมด" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Close Job (จบงาน)" Value="CloseJob"></asp:ListItem>
                <%--<asp:ListItem Text="Finish (อนุมัติครบ)" Value="Finish"></asp:ListItem>--%>
                <asp:ListItem Text="Wait (รออนุมัติ)" Value="Wait"></asp:ListItem>
                <asp:ListItem Text="Wait me (รอฉันอนุมัติ)" Value="Wait me"></asp:ListItem>
                <%--<asp:ListItem Text="Approved (อนุมัติแล้ว)" Value="Approved"></asp:ListItem>--%>
                <asp:ListItem Text="Cancel (ยกเลิก)" Value="Cancel"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-4 mx-auto my-2">
            <asp:DropDownList ID="ddl_system" CssClass="form-control" OnSelectedIndexChanged="ddl_system_SelectedIndexChanged" AutoPostBack="true" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-4 mx-auto my-2">
            <input type="date" id="date_Start" value="" class="form-control" runat="server" />
        </div>
        <div class="col-4 mx-auto my-2">
            <input type="date" id="date_End" value="" class="form-control" runat="server" />
        </div>
        <div class="col-4 mx-auto my-2">
            <asp:Button ID="bt_search" CssClass="btn btn-outline-primary float-left" Text="Search" OnClick="bt_search_Click" runat="server" />
        </div>
        <div class="card col-12 mb-2 mx-auto">
            <div class="col-12 mx-auto">
                <asp:GridView ID="GridView1" CssClass="col-12 mx-auto" runat="server" PageSize="20" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    <Columns>
                        <asp:BoundField DataField="rqdateadd" HeaderText="Request Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                        <asp:BoundField DataField="ReqID" HeaderText="Request ID"><ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundField>
                        <asp:BoundField DataField="SystemName" HeaderText="Systems"></asp:BoundField>
                        <asp:BoundField DataField="ReqForName" HeaderText="Request for"></asp:BoundField>
                        <asp:BoundField DataField="UserReqDeptName" HeaderText="Department"></asp:BoundField>
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <img src="image/gif/Alert_Light.gif" alt="Edit" border="0" width="32" data-toggle="tooltip" data-placement="left" title="รอการอนุมัตินานเกิน 7วัน" >
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="apstatus" HeaderText="Status / Approval"></asp:BoundField>
                        <%--<asp:BoundField DataField="aplname" HeaderText=""></asp:BoundField>--%>
                        <asp:BoundField DataField="UserApprove" HeaderText=""></asp:BoundField>
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

                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" ForeColor="Gray" Font-Size="20px" BackColor="#2461BF"></PagerStyle>
                    <PagerSettings Mode="NumericFirstLast" FirstPageText="<<" LastPageText=">>" />

                    <RowStyle BackColor="#EFF3FB"></RowStyle>

                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</form>


<script>
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
</script>

</asp:Content>
