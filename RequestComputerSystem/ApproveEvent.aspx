<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveEvent.aspx.cs" Inherits="RequestComputerSystem.ApproveEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">
<!-- Page Wrapper -->
  <div id="wrapper">

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

        <!-- Begin Page Content -->
        <div class="container-fluid">

          <!-- Content Row -->
          <div class="row">

            <div class="card shadow h-100 py-2 col-xl-11 mb-6 mx-auto">
                <div class="mb-0 text-gray-800">
                    { <b>Request ID :</b> <asp:Label ID="lb0_0" Text="0" runat="server"></asp:Label> }
                    { <b>ระบบที่ร้องขอ :</b> <asp:Label ID="lb0_1" Text="..................." runat="server"></asp:Label> } 
                    { <b>ผู้ใช้งาน :</b> <asp:Label ID="lb0_2" Text="..................." runat="server"></asp:Label> }

                    { <b>ตำแหน่ง :</b> <asp:Label ID="lb0_3" Text="..................." runat="server"></asp:Label> } 
                    { <b>แผนก :</b> <asp:Label ID="lb0_4" Text="..................." runat="server"></asp:Label> } 
                </div>
            </div>
            
            <!-- Event ผู้ร้องขอ -->
            <div class="col-xl-3 mb-2"> <!-- class="col-xl-3 col-md-6 mb-4" -->
              <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">ผู้ร้องขอ</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb1_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb1_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb1_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <asp:Button ID="bt_edit" type="button" CssClass="btn btn-outline-warning" OnClick="bt_edit_Click" visible="false" runat="server" Text="แก้ไขข้อมูล" />
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-check fa-2x text-success"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event ตรวจสอบโดย(หัวหน้าแผนก) Level 2 -->
            <div class="col-xl-3 mb-2">
              <div class="card border-left-secondary shadow h-100 py-2" id="div2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">ตรวจสอบโดย(หัวหน้าแผนก)</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb2_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb2_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb2_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb2_4" Text="" runat="server"></asp:Label></div>
                     <asp:Button ID="bt_2_1" type="button" CssClass="btn btn-outline-success" OnClick="bt_1_ServerClick" visible="false" runat="server" Text="อนุมัติ" />
                     <a id="bt_2_2" href="#" class="btn btn-outline-danger" onclick="Fn_SetValue('2')" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">ไม่อนุมัติ</a>
                     <asp:Button ID="bt_2_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i2" runat="server" class="fas fa-tag fa-2x text-secondary"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- Event ตรวจสอบโดย(ผู้จัดการสายงาน) Level 3 -->
            <div class="col-xl-3 mb-2">
              <div id="div3" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">ตรวจสอบโดย(ผู้จัดการสายงาน)</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb3_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb3_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb3_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb3_4" Text="" runat="server"></asp:Label></div>
                    <asp:Button ID="bt_3_1" type="button" CssClass="btn btn-outline-success" OnClick="bt_1_ServerClick" visible="false" runat="server" Text="อนุมัติ" />
                    <a id="bt_3_2" class="btn btn-outline-danger" onclick="Fn_SetValue('3')" href="#" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">ไม่อนุมัติ</a>
                    <asp:Button ID="bt_3_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i3" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event ทบทวน/เห็นชอบโดย Level 4 -->
            <div class="col-xl-3 mb-2">
              <div id="div4" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">ทบทวน/เห็นชอบโดย</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb4_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb4_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb4_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb4_4" ForeColor="Red" Text="" runat="server"></asp:Label></div>
                    <%--<asp:Button ID="bt_4_1" type="button" CssClass="btn btn-outline-success" onclick="Fn_SetValue('4')" href="#" data-toggle="modal" data-target="#ApproveModal" visible="false" runat="server" Text="เห็นชอบ" />--%>
                    <a id="bt_4_1" class="btn btn-outline-success" onclick="Fn_SetValue('4')" href="#" data-toggle="modal" data-target="#ApproveModal" visible="false" runat="server">เห็นชอบ</a>
                    <a id="bt_4_2" class="btn btn-outline-danger" onclick="Fn_SetValue('4')" href="#" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">ไม่เห็นชอบ</a>
                    <asp:Button ID="bt_4_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i4" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event เห็นควรอนุมัติโดย Level 5 -->
            <div class="col-xl-6 mb-2">
              <div id="div5" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">เห็นควรอนุมัติโดย</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb5_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb5_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb5_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb5_4" Text="" runat="server"></asp:Label></div>
                    <asp:Button ID="bt_5_1" type="button" CssClass="btn btn-outline-success" OnClick="bt_1_ServerClick" visible="false" runat="server" Text="อนุมัติ" />
                    <a id="bt_5_2" class="btn btn-outline-danger" onclick="Fn_SetValue('5')" href="#" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">ไม่อนุมัติ</a>
                    <asp:Button ID="bt_5_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i5" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event อนุมัติโดย Level 6 -->
            <div class="col-xl-6 mb-2">
              <div id="div6" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">อนุมัติโดย</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb6_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb6_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb6_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb6_4" Text="" runat="server"></asp:Label></div>
                    <asp:Button ID="bt_6_1" type="button" CssClass="btn btn-outline-success" OnClick="bt_1_ServerClick" visible="false" runat="server" Text="อนุมัติ" />
                    <a id="bt_6_2" class="btn btn-outline-danger" onclick="Fn_SetValue('6')" href="#" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">ไม่อนุมัติ</a>
                    <asp:Button ID="bt_6_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i6" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event ผู้ดำเนินการ Level 7 -->
            <div class="col-xl-4 mb-2"> <!-- class="col-xl-3 col-md-6 mb-4" -->
              <div id="div7" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">ผู้ดำเนินการ</div>
                        <hr />
                      <div class="font-weight-normal text-black-50"> <asp:Label ID="lb7_1" Text="......................." runat="server"></asp:Label> </div>
                      <div class="font-weight-normal text-black-50"> <asp:Label ID="lb7_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb7_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb7_4" Text="" runat="server"></asp:Label></div>
                    <asp:Button ID="bt_7_1" type="button" CssClass="btn btn-outline-warning" OnClick="bt_1_ServerClick" visible="false" runat="server" Text="Acknowledge" />
                    <a id="bt_7_2" class="btn btn-outline-danger" onclick="Fn_SetValue('7')" href="#" data-toggle="modal" data-target="#NotApproveModal" visible="false" runat="server">Reject</a>
                    <asp:Button ID="bt_7_3" type="button" CssClass="btn btn-outline-light" OnClick="bt_3_ServerClick" visible="false" runat="server" Text="ยกเลิก" />
                    </div>
                    <div class="col-auto">
                      <i id="i7" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event แจ้งผู้ขอใช้ Level 8 -->
            <div class="col-xl-4 mb-2">
              <div id="div8" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">แจ้งผู้ขอใช้</div>
                        <hr />
                      <div class="font-weight-normal text-black-50">( <asp:Label ID="lb8_1" Text="......................." runat="server"></asp:Label> )</div>
                      <div class="font-weight-normal text-black-50">ตำแหน่ง <asp:Label ID="lb8_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb8_3" Text="......../......../......." runat="server"></asp:Label></div>
                      <a id="bt_8" class="btn btn-outline-danger" onclick="Fn_SetValue('8')" href="#" data-toggle="modal" data-target="#RemarkModal" visible="false" runat="server">Close Job</a>
                    </div>
                    <div class="col-auto">
                      <i id="i8" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Event อื่นๆ/หมายเหตุ -->
            <div class="col-xl-4 mb-2">
              <div id="div9" class="card border-left-secondary shadow h-100 py-2" runat="server">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="h5 mb-0 font-weight-bold text-gray-800">อื่นๆ/หมายเหตุ</div>
                        <hr />
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb9_1" Text="......................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb9_2" Text="..................." runat="server"></asp:Label></div>
                      <div class="font-weight-normal text-black-50"><asp:Label ID="lb9_3" Text="......../......../......." runat="server"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i id="i9" class="fas fa-tag fa-2x text-secondary" runat="server"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

          </div>

        </div>
        <!-- /.container-fluid -->

      </div>
      <!-- End of Main Content -->

    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

  <!-- Not Approve Modal-->
  <div class="modal fade" id="NotApproveModal" tabindex="-1" role="dialog" aria-labelledby="lblNotApproveModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblNotApproveModal">หมายเหตุ ที่ไม่อนุมัติ !!</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body"> <input id="txt_remark" type="text" class="form-control" runat="server" /> </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <asp:Button ID="btn_cancel" CssClass="btn btn-primary" OnClick="bt_2_ServerClick" UseSubmitBehavior="false" data-dismiss="modal" runat="server" Text="Save" />
        </div>
      </div>
    </div>
  </div>

    <div hidden><asp:TextBox ID="txt_level" Text="" runat="server"></asp:TextBox></div>

<!-- Approve Modal -->
  <div class="modal fade" id="ApproveModal" tabindex="-1" role="dialog" aria-labelledby="lblApproveModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblApproveModal">หมายเหตุ เพิ่มเติม !!</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body"> <input id="txt_remarkApprove" type="text" class="form-control" runat="server" /> </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <asp:Button ID="Button1" CssClass="btn btn-primary" OnClick="bt_1_ServerClick" UseSubmitBehavior="false" data-dismiss="modal" runat="server" Text="Save" />
        </div>
      </div>
    </div>
  </div>

<!-- Remark Modal-->
  <div class="modal fade" id="RemarkModal" tabindex="-1" role="dialog" aria-labelledby="lblRemarkModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblRemarkModal">ข้อมูลที่ต้องการแจ้งไปยัง ผู้ร้องขอ</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body"> 
            ข้อความสำคัญ : <input id="txt_actor" type="text" class="form-control" runat="server" />
            <br />  
            อื่นๆ/หมายเหตุ : <input id="txt_other" type="text" class="form-control" runat="server" /> 
        </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <asp:Button ID="bt_8_1" CssClass="btn btn-primary" OnClick="bt_1_ServerClick" UseSubmitBehavior="false" data-dismiss="modal" runat="server" Text="Save" />
        </div>
      </div>
    </div>
  </div>

</form>

<div class="col-xl-10 mb-4 mx-auto">
    หมายเหตุ : สำหรับการร้องขอระบบ B-Connectเมื่ออนุมัติถึงระดับ "ทบทวน/เห็นชอบโดย" จะถือว่าเสร็จสิ้นกระบวนการการร้องขอ และรอเจ้าหน้าที่ IT ดำเนินการ และแจ้งผู้ขอใช้ได้เลย
    <hr />
    <asp:Label ID="lbl_alert" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>

<script type="text/javascript">
    function Fn_SetValue(x)
    {
        MyTextBox = document.getElementById("<%= txt_level.ClientID %>");
        MyTextBox.value = x;
    }
</script>

</asp:Content>
