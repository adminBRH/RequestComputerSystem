<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="RequestComputerSystem.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" name="formSystems" class="needs-validation" runat="server">

<style>
    .redBox {
        border: solid;
        border-color: red;
    }
    .greenBox {
        border: solid;
        border-color: green;
    }
    .aspCheckbox{
        border: 0;
        width: 1em;
        height: 1em;
    }
</style>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="row">
<div class="alert alert-primary col-12">
    <h3>ร้องขอใช้งานระบบคอมพิวเตอร์</h3>
</div>

<div class="col-12 mx-auto">
<asp:UpdatePanel ID="UpdatePanel_input" runat="server">
    <ContentTemplate>
        <div class="row col-12 mx-auto">
            <div class="card col-xl-6 col-sm-12 border-primary border-left-primary">
              <h5 class="card-header">ข้อมูลพนักงาน</h5>
              <div class="card-body">
                <table>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">รหัสพนักงาน</label>
                        </td>
                        <td colspan="3">
                            <input id="InUsername" type="text" class="form-control" aria-describedby="Username-addon" runat="server" required>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">คำนำหน้าชื่อ</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_pname" CssClass="form-control" runat="server">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="text-right">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">ชื่อ</label>
                        </td>
                        <td>
                            <input id="InFName" type="text" class="form-control" aria-describedby="FName-addon" runat="server" required>
                        </td>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">สกุล</label>
                        </td>
                        <td>
                            <input id="InLName" type="text" class="form-control" aria-describedby="LName-addon" runat="server" required>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">Name</label>
                        </td>
                        <td>
                            <input id="InFNameEng" type="text" class="form-control" aria-describedby="FNameEng-addon" runat="server">
                        </td>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">Last name</label>
                        </td>
                        <td>
                            <input id="InLNameEng" type="text" class="form-control" aria-describedby="LNameEng-addon" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">ตำแหน่ง</label>
                        </td>
                        <td>
                            <input id="InPost" type="text" class="form-control" aria-describedby="Post-addon" runat="server" required>
                        </td>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">หน่วยงาน</label>
                        </td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>

                                <asp:DropDownList ID="InDept" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="InDept_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>
                                <div>
                                    <asp:Label ID="lbl_approval" Text="" ForeColor="Blue" runat="server" Visible="false"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_approval2" Text="" ForeColor="Blue" runat="server" Visible="false"></asp:Label>
                                </div>

                            <%--</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="InDept" />
                            </Triggers>
                            </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="4" style="text-align:right">
                            <a id="a_hod" href="#" onserverclick="a_hod_ServerClick" runat="server">
                                ดูหัวหน้าแผนก<i class="fas fa-search fa-2" style="color:darkslateblue"></i>
                            </a>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">ฝ่าย</label>
                        </td>
                        <td>
                            <input id="InFaction" type="text" class="form-control" aria-describedby="Faction-addon" runat="server">
                        </td>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">โทรศัพท์ภายใน</label>
                        </td>
                        <td>
                            <input id="InPhone" type="text" class="form-control" aria-describedby="Phone-addon" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td class="border-bottom-secondary" colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">Specailty</label>
                        </td>
                        <td>
                            <input id="Specailty" type="text" class="form-control" aria-describedby="Specailty-addon" value="-" runat="server" required>
                        </td>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">Code Care</label>
                        </td>
                        <td>
                            <input id="CodeCare" type="text" class="form-control" aria-describedby="CodeCare-addon" value="-" runat="server" required>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-right">
                            <label class="badge badge-secondary form-control">Location</label>
                        </td>
                        <td>
                            <input id="Location" type="text" class="form-control" aria-describedby="Location-addon" value="BRH" runat="server" required>
                        </td>
                        <td class="text-right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
              </div>
            </div>
            <!-- ------------------------------- -->
            <div class="card col-xl-6 col-sm-12 border-primary border-left-primary">
            <h5 class="card-header">ข้อมูลระบบ</h5>
            <div class="card-body">
            <div>
                <div class="input-group">
                    <label id="lblCb_Bconnect" for="cb_Bconnect" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_Bconnect" CssClass="btn btn-circle" runat="server" />
                    <label for="cb_Bconnect" class="badge badge-secondary form-control" style="font-size:medium">Arcus Air</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_VPN" for="Cb_VPN" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_VPN" CssClass="btn btn-circle" runat="server" />
                    <label for="Cb_VPN" class="badge badge-secondary form-control" style="font-size:medium">VPN</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_MS" for="Cb_MS" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_MS" CssClass="btn btn-circle" runat="server" />
                    <label for="Cb_MS" class="badge badge-secondary form-control" style="font-size:medium">Microsoft Office</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_SwL" for="Cb_SwL" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_SwL" CssClass="btn btn-circle" runat="server" />
                    <label for="Cb_SwL" class="badge badge-secondary form-control" style="font-size:medium">Software License</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_IPP" for="Cb_IPP" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_IPP" CssClass="btn btn-circle" runat="server" />
                    <label for="Cb_IPP" class="badge badge-secondary form-control" style="font-size:medium">IP Phone</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_Com" for="Cb_Com" style="color:red; font-size: x-large;" runat="server" visible="false">*</label>
                    <asp:CheckBox ID="Cb_Com" CssClass="btn btn-circle" runat="server" />
                    <label for="Cb_Com" class="badge badge-secondary form-control" style="font-size:medium">Computer</label>
                </div>
                <div class="input-group">
                    <label id="lblCb_Email" for="Cb_Email" style="color:red; font-size: x-large; width: 1em; height: 1em;" runat="server" visible="false">*</label>
                    <input type="checkbox" name="cbEmail" id="CbEmail" class="btn btn-cricle mx-3 my-auto" onclick="fn_SelectEmail()" runat="server" />
                    <%--<asp:CheckBox ID="Cb_Email" CssClass="btn btn-circle" runat="server"/>--%>
                    <label for="CbEmail" class="badge badge-secondary form-control" style="font-size:medium">E-mail Address</label>
                    <input type="text" id="txt_Email" class="form-control" value="" placeholder="exSample.a@brh.co.th" runat="server" hidden="hidden" />
                    <%--<a data-toggle="tooltip" data-placement="top" title="Exsample.a@brh.co.th">
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ToolTip="Exsample.a@brh.co.th"></asp:TextBox>
                    </a>
                    <asp:RequiredFieldValidator ID="txtEmailValidator" runat="server" Enabled="false" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <!-- data-toggle="tooltip" data-placement="left" title="Exsample.a@brh.co.th" -->
                </div>
            </div>
            <div>
                <table id="tableEmail" hidden="hidden">
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="input-group mb-3 prg2">
                              <div class="input-group-prepend">
                                <label class="input-group-text" for="select_Quota">New Quota : </label>
                              </div>
                                <asp:DropDownList ID="dd_Quota" runat="server">
                                    <asp:ListItem Text="Choose..." Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="200 M/B" Value="200"></asp:ListItem>
                                    <asp:ListItem Text="500 M/B" Value="500"></asp:ListItem>
                                    <asp:ListItem Text="1 GB" Value="1028"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="dd_QuotaValidator" runat="server" Enabled="false" ControlToValidate="dd_Quota" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="input-group-prepend prg2">
                                <label class="input-group-text" for="select_Quota">E-mail Group : </label>
                                <label id="lblcb_groupmail" for="select_Quota" style="color:red" runat="server" visible="false">*</label>
                              </div>
                            <div class="prg3">
                                <input type="checkbox" id="cb_hod" aria-label="Checkbox for following text input" value="HOD" runat="server">
                                <label for="cb_hod">BRH HOD</label><br />
                                <input type="checkbox" id="cb_staff" aria-label="Checkbox for following text input" value="Staff" runat="server">
                                <label for="cb_staff">BRH Staff</label><br />
                                <div class="input-group">
                                    <asp:CheckBox ID="cb_committee" runat="server"/>
                                    <label for="cb_committee">Committee / Other</label>
                                    <asp:TextBox ID="txt_commmitee" CssClass="form-text" runat="server"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="txt_commmiteeValidator" runat="server" Enabled="false" ControlToValidate="txt_commmitee" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
            </div>
            <!-- ------------------------------- -->
            <div class="col-12 text-center">
                <p><br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
                <a id="btn_submit" class="btn btn-primary" onserverclick="btn_submit_ServerClick" style="cursor: pointer;" runat="server">Submit</a>
                <br />
                <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <script>
            $(function () {
                $('[data-toggle="tooltip"]').tooltip()
            })

            function fn_SelectEmail() {
                var table = document.getElementById('tableEmail');
                var email = document.getElementById('<%= CbEmail.ClientID %>');
                var txtEmail = document.getElementById('<%= txt_Email.ClientID %>');
                if (email.checked) {
                    table.removeAttribute('hidden');
                    txtEmail.removeAttribute('hidden');
                    txtEmail.setAttribute('required', 'required');
                } else {
                    table.setAttribute('hidden', 'hidden');
                    txtEmail.setAttribute('hidden', 'hidden');
                    txtEmail.removeAttribute('required');
                }
            }

            function pageLoad() { fn_SelectEmail(); } 
        </script>

        <asp:Label ID="lbl_script" Text="" runat="server"></asp:Label>

    </ContentTemplate>
</asp:UpdatePanel>
</div>

</div>


<!-- HOD Modal-->
  <div class="modal fade" id="HODModal" tabindex="-1" role="dialog" aria-labelledby="lblHODModal" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="lblHODModal">ข้อมูล</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">
            หัวหน้าแผนก : <asp:Label ID="lbl_hod_dept" Text="" runat="server"></asp:Label>
            ชื่อ : <asp:Label ID="lbl_hod_name" Text="" runat="server"></asp:Label>
            Email : <asp:Label ID="lbl_hod_email" Text="" runat="server"></asp:Label>
        </div>
        <div class="modal-footer">
          <div class="input-group">
              <div><button class="btn btn-secondary" type="button" data-dismiss="modal">Close</button></div>
          </div>
        </div>
      </div>
    </div>
  </div>

</form>

</asp:Content>
