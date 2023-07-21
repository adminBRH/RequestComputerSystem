<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayOvertimeList.aspx.cs" Inherits="RequestComputerSystem.PayOvertimeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card ">
        <div class="card-body">
            <h3>PayOvertime List</h3>
            <br />               
            เลือกโรงพยาบาล
            <asp:DropDownList ID="DD_branch" AutoPostBack="true" OnSelectedIndexChanged="DD_branch_SelectedIndexChanged" runat="server">
            </asp:DropDownList>

            เลือก Status เอกสารของท่าน: 
            <asp:DropDownList ID="select_status" AutoPostBack="true" OnSelectedIndexChanged="select_status_SelectedIndexChanged" runat="server">
            <asp:ListItem Text="All" Value=""></asp:ListItem>  
            <asp:ListItem Text="Wait" Value="wait" Selected="True"></asp:ListItem>  
            <asp:ListItem Text="Finish" Value="finish"></asp:ListItem>  
            <asp:ListItem Text="Reject" Value="reject"></asp:ListItem>                          
            </asp:DropDownList>
            
            <asp:GridView ID="Pay_list" class="col-12 mx-auto bg-light" runat="server"  OnRowDataBound="Pay_list_RowDataBound" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="pt_id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="pt_time" HeaderText="Create date" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="date_request" HeaderText="For month" DataFormatString="{0:MMMM}"></asp:BoundField>
                    <asp:BoundField DataField="username" HeaderText="Employee"></asp:BoundField>
                    <asp:BoundField DataField="deptname" HeaderText="Department"></asp:BoundField> 
                    <asp:BoundField DataField="hod_status" HeaderText="Manager Status"></asp:BoundField>
                    <asp:BoundField DataField="hodname" HeaderText="Manager"></asp:BoundField>
                    <asp:BoundField DataField="hr_status" HeaderText="HR Status"></asp:BoundField>
                    <asp:BoundField DataField="hrname" HeaderText="HR"></asp:BoundField>
                    <asp:BoundField DataField="hod_id" HeaderText=""></asp:BoundField>
                    <asp:BoundField DataField="hr_id" HeaderText=""></asp:BoundField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <button type="button" data-toggle="modal" data-target="#exampleModal" onmouseover="InputKey(<%# Eval("pt_id") %>)"><img src="image/icons/approve.png" alt="DetailApprove" border="0" width="25"></button>
                        </ItemTemplate>                  
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">                      
                            <ItemTemplate>
                             <%--<asp:LinkButton ID="btn_detail" runat="server" CssClass="btn btn-outline-info" OnClick="btn_detail_Click"
                                    CommandName="DetailDocument" data-toggle="modal" data-target="#exampleModa2" CommandArgument='<%# Eval("pt_id") %>'><img src="image/icons/re-prot.png" alt="Edit" border="0" width="25" >
                                </asp:LinkButton>--%>
                                <%--<button type="button" id="btnDetail" data-toggle="modal" data-target="#exampleModa2" onmouseover="InputKey(<%# Eval("pt_id") %>)" onclick="IDtoModal(CallServerMethod(<%# Eval("pt_id") %>))"><img src="image/icons/re-prot.png" alt="Detail" border="0" width="25" runat="server"></button>--%>
                                <button type="button" data-toggle="modal" data-target="#exampleModa2"  onmouseover="InputKey(<%# Eval("pt_id") %>)" "><img src="image/icons/re-prot.png" alt="Detail" border="0" width="25" runat="server"></a></button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

                <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
            </asp:GridView>



            </div>
        </div>

        <div hidden="hidden">
            <input id="txtH_id" type="text" value="" runat="server" />
        </div>
            <!-- Modal Ap And Rj -->
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">คุณต้องการ Approve ใช่หรือไม่</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">
                          <input type="text" class="form-control" placeholder="หมายเหตุ" value="" id="txt_remark" runat="server" />
                      </div>
                      <div class="modal-footer">
                        <button type="button" id="btn_reject" onserverclick="btn_reject_ServerClick" class="btn btn-danger" runat="server">Reject</button>
                        <button type="button" id="btn_approve" onserverclick="btn_approve_ServerClick" class="btn btn-primary" runat="server">Approve</button>
                      </div>
                    </div>
                  </div>
                </div>
          <!-- End Modal -->

         <!-- Modal Remark -->
                <div class="modal fade" id="exampleModa2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel2">View Detail</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">
                          <asp:Label id="txt_rmk" Text="" runat="server">กด View เพื่อดู Detail เอกสารไฟล์แนบ!</asp:Label>
                          <%--<input type="text" class="form-control" placeholder="Detail" value="" id="txt_detail_remark" runat="server" />--%>
                      </div>
                      <div class="modal-footer mx-auto">
                        <%--<button type="button" id="Button1" onserverclick="btn_reject_ServerClick" class="btn btn-danger" runat="server">Reject</button>--%>
                        <button type="button" id="ViewDetail" onserverclick="ViewDetail_ServerClick" class="btn btn-primary" runat="server">View</button>
                      </div>
                    </div>
                  </div>
                </div>
          <!-- End Modal -->

      <script>
            var txt = document.getElementById('<%=  txtH_id.ClientID %>');

            function InputKey(id) {
                txt.value = id;
            }

            var rmk = document.getElementById('<%=  txt_rmk.ClientID %>');

            function IDtoModal() {
                rmk.innerText = txt.value;
            }

            //function CallServerMethod(id) {
            //    var Call = "<" + "%" + "SelectRemark(" + id +")" + "%" + ">";
            //    rmk.innerText = call;
            //}
        </script>

        </form>
</asp:Content>
