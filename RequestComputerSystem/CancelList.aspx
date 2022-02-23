<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelList.aspx.cs" Inherits="RequestComputerSystem.CancelList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
    <div class="row">
        <div class="mx-auto mb-2">
            <div>
                <label for="ddl_search" >Select Status </label>
                <asp:DropDownList ID="ddl_search" CssClass="btn btn-outline-primary" OnSelectedIndexChanged="ddl_search_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="" Text="All" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Waitting process" Text="Waitting process"></asp:ListItem>
                    <asp:ListItem Value="Finish" Text="Finish"></asp:ListItem>
                    <asp:ListItem Value="Reject" Text="Reject"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="cancelID" HeaderText="Cancel ID">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ccsdate" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="sysname" HeaderText="Systems">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ccname" HeaderText="cancel user">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ccsstatus" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ccsremark" HeaderText="Remark">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Event" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="#" class="btn btn-outline-info" onmouseover="fn_AddID('<%# Eval("ccsid") %>')" data-toggle="modal" data-target="#EditModal"><img src="image/icons/edit-icon.png" alt="Edit" border="0" width="22" ></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            </div>
        </div>
    </div>

    <div hidden>
        <asp:TextBox ID="txth_ID" runat="server"></asp:TextBox>
    </div>

<!-- Name Modal-->
  <div class="modal fade" id="EditModal" tabindex="-1" role="dialog" aria-labelledby="lblEditModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblEditModal">Update Status</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">
            <asp:TextBox ID="txt_remark" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="modal-footer">
            <div class="input-group right">
                <asp:Button ID="Btn_success" CssClass="btn btn-primary mr-2" OnClick="Btn_success_Click" Text="Success" runat="server" />
                <asp:Button ID="Btn_reject" CssClass="btn btn-danger mr-2" OnClick="Btn_reject_Click" Text="Reject" runat="server" />
            </div>
        </div>
      </div>
    </div>
  </div>
    
</form>

<script>
    function fn_AddID(id) {
        var ID = id;
        var txthID = document.getElementById("<%= txth_ID.ClientID %>")
        txthID.value = ID;
    }
</script>

</asp:Content>
