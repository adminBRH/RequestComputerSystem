<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RequestComputerSystem.Disbursement.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
       <div class="text-center my-3"> เลือก Status : &nbsp;
            <asp:DropDownList ID="chang_status" AutoPostBack="true" OnSelectedIndexChanged="chang_status_SelectedIndexChanged" runat="server">
                 <asp:ListItem Text="All" Value=""></asp:ListItem>  
                 <asp:ListItem Text="Wait me" Value="waiting" Selected="True"></asp:ListItem>  
                 <asp:ListItem Text="Wait" Value="wait"></asp:ListItem>  
                 <asp:ListItem Text="Finish" Value="approve"></asp:ListItem>  
                 <asp:ListItem Text="Reject" Value="reject"></asp:ListItem>
            </asp:DropDownList>

         &nbsp; เลือกวันที่ : &nbsp; <input type="date" id="date_from" value="" onmouseout="SelectDate()" runat="server" /> ถึง : <input type="date" id="date_to" value="" onmouseout="SelectDate()" runat="server" />
           <asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-primary" OnClick="btn_search_Click" />
        </div>
        
        <div class="col-12 mx-auto">
            <asp:GridView ID="GridView1" CssClass="mx-auto" runat="server" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

                <Columns>
                    <asp:BoundField DataField="dr_id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="dr_datetime" HeaderText="Create date" DataFormatString="{0: dd/MM/yyyy HH:mm}"></asp:BoundField>
                    <asp:BoundField DataField="fullname" HeaderText="Create by"></asp:BoundField>
                    <asp:BoundField DataField="deptname" HeaderText="From department"></asp:BoundField>
                    <asp:BoundField DataField="df_name" HeaderText="Document name"></asp:BoundField> 
                    <asp:BoundField DataField="dr_status" HeaderText="Status"></asp:BoundField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div class="mx-auto my-auto">
                                <a class="btn btn-outline-dark" onmouseover="GetID('<%# Eval("dr_id") %>','<%# Eval("fullname") %>','<%# Eval("dr_datetime") %>','<%# Eval("deptname") %>','<%# Eval("df_name") %>','<%# Eval("dr_status") %>')" data-toggle="modal" data-target="#exampleModal">Detail</a>
                            </div> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="title_bg" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div class="mx-auto my-auto">
                                <a class="btn btn-outline-dark" href="Approve.aspx?id=<%# Eval("dr_id") %>&type=<%# Eval("dr_type") %>">Approve</a>
                            </div>
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

             <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">รายละเอียดการ Request</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">

                           <div class="col-12 text-left btn btn-facebook my-1">
                              <b>ประเภทของการขออนุมัติเบิกจ่าย</b><br />&nbsp;&nbsp;&nbsp;- <asp:label ID="lbl_form" runat="server"></asp:label> 
                          </div>
                          <div class="col-12 text-left btn btn-primary my-1">
                              Department : <asp:label ID="lbl_dept" runat="server"></asp:label> 
                          </div>
                          <div class="col-12 text-left btn btn-info my-1">
                              Request by : <asp:label ID="lbl_fullname" runat="server"></asp:label> 
                              <br />
                              Create Date : <asp:label ID="lbl_datetime" runat="server"></asp:label>
                          </div>                           
                          <div id="div_status" class="col-5 text-left btn btn-light my-1" runat="server" style="color:black;">
                              Status : <asp:label ID="lbl_status" runat="server"></asp:label>
                          </div>

                          <asp:UpdatePanel ID="UpdatePanel_grid" runat="server">
                            <ContentTemplate>
                                <input type="text" id="txtH_id" runat="server" hidden="hidden"/>
                                <div class="row col-12 text-left mx-auto mt-3">
                                    <asp:Button ID="btn_file" CssClass="btn btn-light" Text="Show File" OnClick="btn_file_Click" runat="server"/>
                                    <i class="fas fa-2x fa-file-archive"></i>
                                </div>
                                  <div id="div_file" class="col-10 text-left btn border-info mt-3" runat="server" visible="false">
                                       <asp:label ID="lbl_show_excel" Text="" runat="server"></asp:label>
                                  </div>
                            </ContentTemplate>
                          </asp:UpdatePanel>

                      </div>
                      <div class="modal-footer">                        
                      </div>
                    </div>
                  </div>
                </div>

        <script>
            function GetID(g , name , time , dept , form , status) {
                var txt_getid = document.getElementById('<%= txtH_id.ClientID %>')
                var lbl_fullname = document.getElementById('<%= lbl_fullname.ClientID %>')
                var lbl_datetimes = document.getElementById('<%= lbl_datetime.ClientID %>')
                var lbl_statuss = document.getElementById('<%= lbl_status.ClientID %>')
                var lbl_formn = document.getElementById('<%= lbl_form.ClientID %>')
                var lbl_depts = document.getElementById('<%= lbl_dept.ClientID %>')
                var div_file = document.getElementById('<%= div_file.ClientID %>')
                var btn_file = document.getElementById('<%= btn_file.ClientID %>')
                var div_status = document.getElementById('<%= div_status.ClientID %>')

                txt_getid.value = g;

                lbl_fullname.innerText = name;
                lbl_datetimes.innerText = time;
                lbl_depts.innerText = dept;
                lbl_formn.innerText = form;
                lbl_statuss.innerText = status;

                if (status == 'waiting') {
                    div_status.setAttribute('class', 'col-5 text-left btn btn-warning my-1');
                }
                else if (status == 'approve') {
                    div_status.setAttribute('class', 'col-5 text-left btn btn-success my-1');
                }
                else {
                    div_status.setAttribute('class', 'col-5 text-left btn btn-danger my-1');
                }

                div_file.style.display = "none";
                btn_file.style.display = "block";
            }

            function SelectDate() {
                var d_from = document.getElementById('<%= date_from.ClientID%>');
                var d_to = document.getElementById('<%= date_to.ClientID%>');

                if (d_to.value == '' && d_from.value != '') {
                    d_to.value = d_from.value;
                }

                if (d_to.value < d_from.value) {
                    alert('กรุณาเลือกวันที่ให้ถูกต้อง !!');
                    d_from.value = "";
                    d_to.value = "";
                }

            }

        </script>
        
    </form>

</asp:Content>
