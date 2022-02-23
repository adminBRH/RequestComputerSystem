<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="RequestComputerSystem.Cancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .prg{
        margin-left:10px;
    }
</style>

<form id="form1" class="was-validated" method="post" runat="server">
    <div class="row">

        <div class="card col-6 mx-auto mb-2" style="width: 18rem;">
          <div class="card-header">
            ยกเลิกการใช้งานระบบ
          </div>

          <div class="row col-12 card-body row">

              <div class="col-4 mx-auto mb-2">
                    <div class="input-group">
                        <div class="custom-control custom-switch">
                          <input type="checkbox" class="custom-control-input" id="cb_bconnect" required>
                          <label class="custom-control-label" for="cb_bconnect">Arcus Air</label>
                        </div>
                    </div>
                    <div class="input-group">
                        <div class="custom-control custom-switch">
                          <input type="checkbox" class="custom-control-input" id="cb_VPN" required>
                          <label class="custom-control-label" for="cb_VPN">VPN</label>
                        </div>
                    </div>
                    <div class="input-group">
                        <div class="custom-control custom-switch">
                          <input type="checkbox" class="custom-control-input" id="cb_MS" required>
                          <label class="custom-control-label" for="cb_MS">Microsoft</label>
                        </div>
                    </div>
                    <div class="input-group">
                        <div class="custom-control custom-switch">
                          <input type="checkbox" class="custom-control-input" id="cb_email" required>
                          <label class="custom-control-label" for="cb_email">E-mail Address</label>
                        </div>
                    </div>
                  
              </div>

              <div class="col-8 mx-auto mb-2">
                  <ul class="list-group list-group-flush">
                    <li class="list-group-item">ของพนักงาน รหัส<input type="text" id="txt_userid" class="form-control-plaintext" value="" /> </li>
                    <li class="list-group-item">ชื่อ<input type="text" id="txt_Fname" class="form-control-plaintext" value="" /> </li>
                    <li class="list-group-item">นามสกุล<input type="text" id="txt_Lname" class="form-control-plaintext" value="" /> </li>
                    <li class="list-group-item">&nbsp;</li>
                  </ul>
              </div>
              
          </div>

            <hr />
            <div class="col-2 mx-auto mb-2">
                <a class="btn btn-outline-primary" onclick="ValidateInput()">Submit</a>
            </div>
            <div hidden="hidden">
                <button id="btn_submit" onserverclick="btn_submit_ServerClick" runat="server"></button>
            </div>
        </div>

    </div>
    <div hidden>
        <asp:TextBox ID="txth_bconnect" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_VPN" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_MS" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_email" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_userid" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_Fname" runat="server"></asp:TextBox>
        <asp:TextBox ID="txth_Lname" runat="server"></asp:TextBox>
    </div>
</form>


<script>

    var BID = document.getElementById('cb_bconnect');
    var txthBconnect = document.getElementById("<%= txth_bconnect.ClientID %>");
    var VID = document.getElementById('cb_VPN');
    var txthVPN = document.getElementById("<%= txth_VPN.ClientID %>");
    var MS = document.getElementById('cb_MS');
    var txthMS = document.getElementById("<%= txth_MS.ClientID %>");
    var EID = document.getElementById('cb_email');
    var txthEmail = document.getElementById("<%= txth_email.ClientID %>");

    var txtID = document.getElementById('txt_userid');
    var txthID = document.getElementById("<%= txth_userid.ClientID %>");
    var txtFname = document.getElementById('txt_Fname');
    var txthFname = document.getElementById("<%= txth_Fname.ClientID %>");
    var txtLname = document.getElementById('txt_Lname');
    var txthLname = document.getElementById("<%= txth_Lname.ClientID %>");

    function ValidateInput()
    {
        var al = "";

        if (BID.checked == true || EID.checked == true || VID.checked == true || MS.checked == true)
        {
            al = "N";
            BID.removeAttribute("required", "")
            VID.removeAttribute("required", "")
            EID.removeAttribute("required", "")
            if (BID.checked == true) { txthBconnect.value = "6"; }
            if (VID.checked == true) { txthVPN.value = "3"; }
            if (MS.checked == true) { txthMS.value = "4"; }
            if (EID.checked == true) { txthEmail.value = "2"; }
        }
        else
        {
            al = "Y";
            BID.setAttribute("required", "")
            VID.setAttribute("required", "")
            MS.setAttribute("required", "")
            EID.setAttribute("required", "")
            txthBconnect.value = "";
            txthVPN.value = "";
            txthEmail.value = "";
        }

        if (txtID.value == "") {
            txtID.setAttribute("class", "form-control")
            txtID.setAttribute("required", "")
            txthID.value = "";
            al = "Y";
        }
        else {
            txtID.setAttribute("class", "form-control-plaintext")
            txtID.removeAttribute("required", "")
            txthID.value = txtID.value;
            al = "N";
        }

        if (txtFname.value == "") {
            txtFname.setAttribute("class", "form-control")
            txtFname.setAttribute("required", "")
            txthFname.value = "";
            al = "Y";
        }
        else {
            txtFname.setAttribute("class", "form-control-plaintext")
            txtFname.removeAttribute("required", "")
            txthFname.value = txtFname.value;
            al = "N";
        }

        if (txtLname.value == "") {
            txtLname.setAttribute("class", "form-control")
            txtLname.setAttribute("required", "")
            txthLname.value = "";
            al = "Y";
        }
        else {
            txtLname.setAttribute("class", "form-control-plaintext")
            txtLname.removeAttribute("required", "")
            txthLname.value = txtLname.value;
            al = "N";
        }

        if (al == "Y") {
            alert("กรุณากรอกข้อมูลให้ครบถ้วน !!");
        }else {
            __doPostBack('<%= btn_submit.UniqueID %>', '');
        }

    }
</script>

</asp:Content>
