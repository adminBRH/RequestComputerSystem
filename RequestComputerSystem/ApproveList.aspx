<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveList.aspx.cs" Inherits="RequestComputerSystem.ApproveList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div>
    <form id="form1" runat="server">

    <asp:DropDownList ID="ddl_status" CssClass="btn btn-outline-primary mb-2" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged" AutoPostBack="true" runat="server">
        <asp:ListItem Text="All ทั้งหมด" Value="All" Selected="True"></asp:ListItem>
        <asp:ListItem Text="Close Job (จบงาน)" Value="CloseJob"></asp:ListItem>
        <%--<asp:ListItem Text="Finish (อนุมัติครบ)" Value="Finish"></asp:ListItem>--%>
        <asp:ListItem Text="Wait (รออนุมัติ)" Value="Wait"></asp:ListItem>
        <%--<asp:ListItem Text="Approved (อนุมัติแล้ว)" Value="Approved"></asp:ListItem>--%>
        <asp:ListItem Text="Cancel (ยกเลิก)" Value="Cancel"></asp:ListItem>
    </asp:DropDownList>
    
        <asp:GridView ID="GridView1" CssClass="table" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            PageSize="20" AllowPaging="true" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="apdate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Date request">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:BoundField>
                <asp:BoundField DataField="RequestID" HeaderText="Request [ID] (No.)" />
                <asp:BoundField DataField="sysname" HeaderText="Systems" />
                <asp:BoundField DataField="UserFullName" HeaderText="Request for" />
                <asp:BoundField DataField="deptname" HeaderText="Department" />

                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <img src="image/gif/Alert_Light.gif" alt="Edit" border="0" width="32" data-toggle="tooltip" data-placement="left" title="รอการอนุมัตินานเกิน 7วัน" >
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="apstatus" HeaderText="Status"></asp:BoundField>
                <asp:BoundField DataField="aplname" HeaderText=""></asp:BoundField>

                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        &nbsp;&nbsp;&nbsp; <a class="btn btn-outline-dark" href="DetailSystems.aspx?apid=<%# Eval("apid") %>">Detail</a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:LinkButton ID="lkEdit" runat="server" CssClass="btn btn-outline-info"
                            CommandName="Edit" CommandArgument='<%# Eval("rqsid") %>'><img src="image/icons/edit-icon.png" alt="Edit" border="0" width="32" >
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

    </form>

<script>
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
</script>

</div>

<%--<nav aria-label="Page navigation example">
  <ul class="pagination justify-content-center">
    <li class="page-item disabled">
      <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
    </li>
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item"><a class="page-link" href="#">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item">
      <a class="page-link" href="#">Next</a>
    </li>
  </ul>
</nav>--%>

</asp:Content>
