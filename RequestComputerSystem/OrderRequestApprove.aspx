<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderRequestApprove.aspx.cs" Inherits="RequestComputerSystem.OrderRequestApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">

        <div class="card card-header bg-gradient-primary h3" style="color:white">
            <div class="row col-12 input-group">
                รายละเอียดการร้องขอ Change Order Items ID : &nbsp;<asp:Label ID="lbl_id" Text="" runat="server"></asp:Label>
            </div>
        </div>

        <div class="card-body h4">
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">วัตถุประสงค์เพื่อ : </div>
                    <div class="col-9">
                        <asp:Label ID="lbl_Obj" Text="" runat="server"></asp:Label>
                        <asp:Label ID="lbl_Other" Text="" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">รายละเอียด : </div>
                    <div class="col-9"><asp:Label ID="lbl_detail" Text="" runat="server"></asp:Label></div>
                    <input type="text" id="txtH_detailOrder" value="" runat="server"  hidden="hidden"/>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">&nbsp;</div>
                    <div class="col-9"><textarea id="txt_details" rows="5" class="form-control" runat="server" disabled="disabled"></textarea></div>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">ไฟล์แนบ : </div>
                    <div class="col-9"><asp:Label ID="lbl_file" Text="" runat="server"></asp:Label></div>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">ผู้ร้องขอ : </div>
                    <div class="col-9"><asp:Label ID="lbl_request" Text="" runat="server"></asp:Label> (<asp:Label ID="lbl_post" Text="" runat="server"></asp:Label>)</div>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">แผนก : </div>
                    <div class="col-9"><asp:Label ID="lbl_dept" Text="" runat="server"></asp:Label></div>
                </div>
            </div>
            <div class="col-10 mb-3">
                <div class="row col-12">
                    <div class="col-3 text-right">วันที่ : </div>
                    <div class="col-9"><asp:Label ID="lbl_datereq" Text="" runat="server"></asp:Label></div>
                </div>
            </div>
        </div>

        <div class="row col-12 mx-auto">

            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    ความเห็นผู้จัดการฝ่าย
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy1" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy1" class="fas fa-check fa-sm" runat="server"></i> อนุมัติ <asp:Label ID="lbl_apy1" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn1" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn1" class="fas fa-check fa-sm" runat="server"></i> ไม่อนุมัติ <asp:Label ID="lbl_apn1" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap1" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap1" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn1" class="row col-12 text-center mb-3" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn1" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('1','No')" runat="server">Reject</a></div>
                        <div class="col-6"><a href="#" id="btn_apy1" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('1','Yes')" runat="server">Approve</a></div>
                    </div>
                </div>
            </div>

            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    ความเห็นของตัวแทนคณะกรรมการ Costing
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy2" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy2" class="fas fa-check fa-sm" runat="server"></i> อนุมัติ <asp:Label ID="lbl_apy2" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn2" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn2" class="fas fa-check fa-sm" runat="server"></i> ไม่อนุมัติ <asp:Label ID="lbl_apn2" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap2" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap2" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn2" class="row col-12 text-center mb-3" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn2" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('2','No')" runat="server">Reject</a></div>
                        <div class="col-6"><a href="#" id="btn_apy2" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('2','Yes')" runat="server">Approve</a></div>
                    </div>
                </div>
            </div>
            
            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    <asp:Label ID="lbl_3" Text="ความเห็นของผู้จัดการฝ่ายบัญชี" runat="server"></asp:Label>
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy3" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy3" class="fas fa-check fa-sm" runat="server"></i> อนุมัติ <asp:Label ID="lbl_apy3" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn3" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn3" class="fas fa-check fa-sm" runat="server"></i> ไม่อนุมัติ <asp:Label ID="lbl_apn3" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap3" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap3" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn3" class="row col-12 text-center mb-3" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn3" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('3','No')" runat="server">Reject</a></div>
                        <div class="col-6"><a href="#" id="btn_apy3" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('3','Yes')" runat="server">Approve</a></div>
                    </div>
                </div>
            </div>
                        
            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    ความเห็นของรองผู้อำนวยการโรงพยาบาล
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy4" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy4" class="fas fa-check fa-sm" runat="server"></i> อนุมัติ <asp:Label ID="lbl_apy4" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn4" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn4" class="fas fa-check fa-sm" runat="server"></i> ไม่อนุมัติ <asp:Label ID="lbl_apn4" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap4" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap4" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn4" class="row col-12 text-center mb-3" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn4" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('4','No')" runat="server">Reject</a></div>
                        <div class="col-6"><a href="#" id="btn_apy4" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('4','Yes')" runat="server">Approve</a></div>
                    </div>
                </div>
            </div>

            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    ความเห็นของฝ่ายกลยุทธ์และสารสนเทศ
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy5" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy5" class="fas fa-check fa-sm" runat="server"></i> อนุมัติ <asp:Label ID="lbl_apy5" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn5" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn5" class="fas fa-check fa-sm" runat="server"></i> ไม่อนุมัติ <asp:Label ID="lbl_apn5" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap5" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap5" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn5" class="row col-12 text-center mb-5" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn5" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('5','No')" runat="server">Reject</a></div>
                        <div class="col-6"><a href="#" id="btn_apy5" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('5','Yes')" runat="server">Approve</a></div>
                    </div>
                </div>
            </div>

            <div class="col-5 mr-3 mb-3">
                <div class="card card-header bg-gradient-primary" style="color:white">
                    ความเห็นของผู้รับผิดชอบดำเนินการแผนก IT
                </div>
                <div class="card-body bg-gradient-light">
                    <div id="div_apy6" class="col-12" runat="server" visible="false" style="color:green;"><i id="apy6" class="fas fa-check fa-sm" runat="server"></i> รับทราบ <asp:Label ID="lbl_apy6" Text=".............................." runat="server"></asp:Label></div>
                    <div id="div_apn6" class="col-12" runat="server" visible="false" style="color:red;"><i id="apn6" class="fas fa-check fa-sm" runat="server"></i> ยกเลิก <asp:Label ID="lbl_apn6" Text=".............................." runat="server"></asp:Label></div>
                    <div class="col-12 text-center">(<asp:Label id="lbl_name_ap6" Text="..............................." runat="server"></asp:Label>)</div>
                    <div class="col-12 text-center"><asp:Label id="lbl_date_ap6" Text="......../......../........" runat="server"></asp:Label></div>
                    <div id="div_btn6" class="row col-12 text-center mb-3" runat="server" visible="false">
                        <div class="col-6"><a href="#" id="btn_apn6" class="btn btn-outline-danger" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('6','No')" runat="server">Cancel</a></div>
                        <div class="col-6"><a href="#" id="btn_apy6" class="btn btn-outline-success" data-toggle="modal" data-target="#ModalInsert" onclick="CheckYN('6','Yes')" runat="server">Acknowledge</a></div>
                    </div>
                </div>
            </div>

        </div>
        
        <div hidden="hidden">
            <input type="text" id="txtH_level" value="" runat="server" />
            <input type="text" id="txtH_YN" value="" runat="server" />
            <script>
                function CheckYN(L, X) {
                    var Level = document.getElementById('<%= txtH_level.ClientID %>');
                    var YN = document.getElementById('<%= txtH_YN.ClientID %>');
                    Level.value = L;
                    YN.value = X;
                }
            </script>
        </div>

<!-- Modal -->
<div class="modal fade" id="ModalInsert" tabindex="-1" role="dialog" aria-labelledby="ModalInsertTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalInsertTitle">หมายเหตุ</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <textarea id="txt_remark" class="form-control" runat="server"></textarea>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button id="btn_submit" type="button" class="btn btn-primary" onserverclick="btn_submit_ServerClick" runat="server">Save changes</button>
      </div>
    </div>
  </div>
</div>

    </form>
</asp:Content>
