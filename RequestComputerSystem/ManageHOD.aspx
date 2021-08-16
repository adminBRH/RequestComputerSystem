<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageHOD.aspx.cs" Inherits="RequestComputerSystem.ManageHOD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="col-12 mx-auto">
        <asp:GridView ID="GridView1" CssClass="mx-auto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="deptid" HeaderText="รหัสแผนก"></asp:BoundField>
                <asp:BoundField DataField="deptname" HeaderText="ชื่อแผนก"></asp:BoundField>
                <asp:BoundField DataField="depthod1" HeaderText="รหัสหัวหน้าแผนก"></asp:BoundField>
                <asp:BoundField DataField="HOD1" HeaderText="ชื่อหัวหน้าแผนก"></asp:BoundField>
                <asp:BoundField DataField="depthod2" HeaderText="รหัสหัวหน้าฝ่าย"></asp:BoundField>
                <asp:BoundField DataField="HOD2" HeaderText="ชื่อฟัวหน้าฝ่าย"></asp:BoundField>
                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <a href="#" class="btn btn-outline-danger" onmouseover="FixID('<%# Eval("deptid") %>')" data-toggle="modal" data-target="#alertModal">edit</a>
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
    
    <!-- Modal -->
    <div class="modal fade" id="alertModal" tabindex="-1" role="dialog" aria-labelledby="alertModalTitle" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="alertModalTitle">ยืนยันคำสั่ง</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">

              <div class="row col-12">
                  คุณต้องการแก้ไขข้อมูลแผนกรหัส&nbsp;&nbsp;(<asp:Label ID="lbl_deptid" Text="" runat="server"></asp:Label>)&nbsp;&nbsp;?
              </div>

          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" id="btn_edit" class="btn btn-warning" data-dismiss="modal" data-toggle="modal" data-target="#editModal" onserverclick="btn_edit_ServerClick" runat="server">Confirm</button>
          </div>
        </div>
      </div>
    </div>


        <div hidden="hidden">
                <input type="text" id="txtH_ID" value="" runat="server" />
            </div>


        <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalTitle" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editModalTitle">แก้ไขลำดับ HOD</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">

              <asp:UpdatePanel ID="UpdatePanel_edit" runat="server">
                <ContentTemplate>
                    <div id="div_edit" class="row col-12" runat="server" visible="false">
                        <div class="col-4 text-right">แผนก : </div>
                        <div class="col-8 text-left"><asp:Label ID="lbl_deptname" Text="" runat="server"></asp:Label></div>
                        <div class="col-4 text-right">รหัสหัวหน้าแผนก : </div>
                        <div class="col-8 text-left"><input id="txt_hod1id" class="col-4 form-control" value="" runat="server" /></div>
                        <div class="col-4 text-right">ชื่อหัวหน้าแผนก : </div>
                        <div class="col-8 text-left"><input id="txt_hod1name" class="col-8 form-control" value="" runat="server" disabled="disabled" /></div>
                        <div class="col-4 text-right">รหัสหัวหน้าฝ่าย : </div>
                        <div class="col-8 text-left"><input id="txt_hod2id" class="col-4 form-control" value="" runat="server" /></div>
                        <div class="col-4 text-right">ชื่อหัวหน้าฝ่าย : </div>
                        <div class="col-8 text-left"><input id="txt_hod2name" class="col-8 form-control" value="" runat="server" disabled="disabled" /></div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btn_edit" EventName="serverclick" />
                </Triggers>
            </asp:UpdatePanel>

          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" id="Button1" class="btn btn-primary" runat="server">Save changes</button>
          </div>
        </div>
      </div>
    </div>
        
    </form>

    <script>
        function FixID(x) {
            var id = document.getElementById("<%= txtH_ID.ClientID %>");
            var lblid = document.getElementById("<%= lbl_deptid.ClientID %>");
            id.value = x;
            lblid.innerText = x;
        }
    </script>

</asp:Content>
