<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="RequestComputerSystem.Disbursement.Approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">

    <div class="row col-12 mx-auto">
        <div class="col-12 card card-header bg-primary" style="color:white;">
            อนุมัติโดย
        </div>
        <div class="col-12 card card-body">
            <div class="row col-12 mx-auto">

                <!-- Subject & Details -->
                <div class="col-12 my-1">
                    <div class="col-lg-3 col-sm-6 btn btn-warning text-left" style="color: black;">
                        <b>Request ID : <asp:label ID="lbl_reqid" runat="server"></asp:label> </b>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-12 text-left btn btn-facebook mx-auto my-1">
                    <b>ประเภทของการขออนุมัติเบิกจ่าย</b><br />&nbsp;&nbsp;&nbsp;- 
                    <asp:label ID="lbl_form" runat="server"></asp:label> 
                </div>
                <div class="col-lg-5 col-sm-12 text-left btn btn-primary mx-auto my-1">
                    <div class="row col-12 mx-auto">
                        <div class="col-6 mx-auto">
                            <b>Hospital</b><br />&nbsp;&nbsp;&nbsp;
                            <asp:label ID="lbl_branch" runat="server"></asp:label>
                        </div>
                        <div class="col-6 mx-auto">
                            <b>Department</b><br />&nbsp;&nbsp;&nbsp;
                            <asp:label ID="lbl_dept" runat="server"></asp:label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-sm-12 text-left btn btn-info mx-auto my-1">
                    <b>Request by</b><br />&nbsp;&nbsp;&nbsp;
                    <asp:label ID="lbl_reqname" runat="server"></asp:label> 
                </div>
                <div class="col-lg-5 col-sm-12 text-left btn btn-info mx-auto my-1">
                    <b>Create Date</b><br />&nbsp;&nbsp;&nbsp;
                    <asp:label ID="lbl_reqdatetime" runat="server"></asp:label>
                </div>
                <div class="col-9 mx-auto mt-3">
                    <i class="fas fa-2x fa-file-archive"></i>
                </div>
                <div class="col-10 text-left btn border-info mx-auto mb-3">
                    <asp:label ID="lbl_show_file" Text="" runat="server"></asp:label>
                </div>

                <%--<asp:Label ID="lbl_CardApprove" Text="" runat="server"></asp:Label>--%>

                <!-- Card 1 -->
                <div class="col-4 mx-auto my-3">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos1" Text="หัวหน้าแผนก" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon1" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_1" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_1" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','1')">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#" id="btn_rej_1" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','1')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv1" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap1" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date1" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark1" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 2 -->
                <div class="col-4 mx-auto my-3">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos2" Text="ผู้จัดการฝ่าย" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon2" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_2" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_2" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','2')">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#" id="btn_rej_2" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','2')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv2" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap2" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date2" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark2" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 3 -->
                <div class="col-4 mx-auto my-3">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos3" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon3" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_3" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_3" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','3')">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#" id="btn_rej_3" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','3')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv3" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap3" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date3" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark3" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 4 -->
                <div class="col-4 mx-auto">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos4" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon4" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_4" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_4" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','4')">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#" id="btn_rej_4" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','4')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv4" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap4" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date4" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark4" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 5 -->
                <div class="col-4 mx-auto">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos5" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon5" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_5" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_5" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','5')">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#" id="btn_rej_5" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','5')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv5" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap5" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date5" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark5" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 6 -->
                <div class="col-4 mx-auto">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos6" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon6" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_6" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_6" class="btn btn-primary"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','6')">Acknowledge</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a hidden="hidden" href="#" id="btn_rej_6" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','6')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv6" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap6" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date6" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark6" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

                <!-- Card 7 -->
                <div class="col-4 mx-auto mt-3">
                    <div class="card card-header bg-gradient-light">
                        <div class="row col-12 mx-auto">
                            <div class="col-10 text-left">
                                <asp:Label ID="lbl_pos7" Text="" runat="server"></asp:Label>
                            </div>
                            <div class="col-2 text-right">
                                <asp:Label ID="lbl_icon7" CssClass="fas fa-tag fa-2x text-secondary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card card-body text-center">
                        <asp:Panel ID="pn_7" CssClass="col-12 mb-3" runat="server">
                            <a href="#" id="btn_apv_7" class="btn btn-primary"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('approve','7')">Acknowledge</a>&nbsp;&nbsp;&nbsp;&nbsp;
                            <a hidden="hidden" href="#" id="btn_rej_7" class="btn btn-danger"  data-toggle="modal" data-target="#exampleModal" onclick="fnevent('reject','7')">Reject</a>
                        </asp:Panel>
                        <asp:Label ID="lbl_apv7" Text="………………………………………………" runat="server"></asp:Label>
                        <asp:Label ID="lbl_ap7" Text="(………………………………………………)" runat="server"></asp:Label>
                        <asp:Label ID="lbl_date7" Text="วันที่........./.........../..........." runat="server"></asp:Label>
                        <asp:Label ID="lbl_remark7" Text="" ForeColor="Blue" runat="server"></asp:Label>
                    </div>
                </div>

            </div>
        </div>
    </div>

<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">หมายเหตุ</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <div class="col-12">            
                <input type="text" class="form-control" id="ip_remark" text="หมายเหตุ" runat="server" />
          </div>
      </div>
        <div hidden="hidden">
        <input type="text" id="txtH_event" runat="server" />
        <input type="text" id="txtH_level" runat="server" />
        </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">X</button>
        <button type="button" id="btn_submit" class="btn btn-primary" onserverclick="btn_submit_ServerClick" data-dismiss="modal" runat="server">Save</button>
      </div>
    </div>
  </div>
</div>
    <script>
        function fnevent(event ,level) {
            var txt_event = document.getElementById('<%= txtH_event.ClientID %>')
            var txt_level = document.getElementById('<%= txtH_level.ClientID %>')

            txt_event.value = event;
            txt_level.value = level;
        }

    </script>

</form>

</asp:Content>
