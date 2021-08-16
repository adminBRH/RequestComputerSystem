<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="RequestComputerSystem.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-xl-6 mb-4 mx-auto"> <!-- class="col-xl-3 col-md-6 mb-4" -->
            <div id="div7" class="card border-left-primary shadow h-100 py-2" runat="server">
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="h5 mb-0 font-weight-bold text-gray-800 border-bottom-primary">Settings</div>
                    <p></p>
                    <div class="font-weight-normal text-black-50">
                        <asp:Label ID="lbl1" CssClass="fas fa-book fa-2" Text="Name : " runat="server"></asp:Label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;<a href="#" data-toggle="modal" data-target="#EdNameModal" class="fas fa-external-link-alt fa-2 text-secondary"></a>
                    </div>
                    <hr />
                    <div class="font-weight-normal text-black-50">
                        <asp:Label ID="lbl2" CssClass="fas fa-lock fa-2" Text="Change Password : " runat="server"></asp:Label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;<a href="#" data-toggle="modal" data-target="#EdPassModal" class="fas fa-external-link-alt fa-2 text-secondary"></a>
                    </div>
                    <hr />
                </div>
                <div class="col-auto">
                    <i id="i7" class="fas fa-cogs fa-2x text-secondary" runat="server"></i>
                </div>
                </div>
            </div>
            </div>
        </div>

    </div>

<form id="form1" runat="server">

<!-- Name Modal-->
  <div class="modal fade" id="EdNameModal" tabindex="-1" role="dialog" aria-labelledby="lblEdNameModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblEdNameModal">Edit Name</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body row">
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_tiltle">คำนำหน้า ไทย :</label><asp:TextBox ID="txt_tiltle" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_tiltle_eng">คำนำหน้า อังกฤษ :</label><asp:TextBox ID="txt_tiltle_eng" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_fname">ชื่อ ไทย :</label><asp:TextBox ID="txt_fname" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_fname_eng">ชื่อ อังกฤษ :</label><asp:TextBox ID="txt_fname_eng" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_lname">นามสกุล ไทย :</label><asp:TextBox ID="txt_lname" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col col-sm-10 col-xl-5 input-group mb-3">
                <label for="txt_lname_eng">นามสกุล อังกฤษ :</label><asp:TextBox ID="txt_lname_eng" Text="" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <asp:Button ID="btn_EdName" CssClass="btn btn-primary" OnClick="btn_EdName_Click" UseSubmitBehavior="false" data-dismiss="modal" runat="server" Text="Save" />
        </div>
      </div>
    </div>
  </div>

<!-- Password Modal-->
  <div class="modal fade" id="EdPassModal" tabindex="-1" role="dialog" aria-labelledby="lblEdPassModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblEdPassModal">Change Password</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">
            Old Password : <input id="txt_PassOld" type="password" value="" class="form-control col-6 mx-auto" runat="server" />
            New Password : <input id="txt_PassNew" type="password" value="" class="form-control col-6 mx-auto" runat="server" />
            Confirm Password : <input id="txt_PassConf" type="password" value="" class="form-control col-6 mx-auto" runat="server" />
        </div>
        <div class="modal-footer">
          <div class="input-group">
              <div><button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button></div>
              <div onmouseover="fn_checknull()"><asp:Button ID="btn_EdPass" CssClass="btn btn-primary" OnClick="btn_EdPass_Click" UseSubmitBehavior="false" runat="server" Text="Save" /></div>
          </div>
        </div>
      </div>
    </div>
  </div>

</form>

<script>
    function fn_checknull() {
        var PassOld = document.getElementById("<%= txt_PassOld.ClientID %>");
        var PassNew = document.getElementById("<%= txt_PassNew.ClientID %>");
        var PassConf = document.getElementById("<%= txt_PassConf.ClientID %>");
        if (PassOld.value == "" || PassNew.value == "" || PassConf.value == "") { alert("กรุณากรอกข้อมูลให้ครบถ้วน !!"); }
        else {
            if (PassNew.value != PassConf.value) { alert("New Password กับ Confirm Password ไม่ตรงกัน !!"); }
        }
    }
</script>

</asp:Content>
