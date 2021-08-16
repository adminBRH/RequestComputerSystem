<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestEdit.aspx.cs" Inherits="RequestComputerSystem.RequestEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server" class="needs-validation">
    <div class="h3 alert alert-primary">
        แก้ไขข้อมูล ร้องขอใช้งานระบบคอมพิวเตอร์
    </div>
    <div class="row">
        <div class="card col-10 mx-auto mb-2">
            <div class="h5 card card-header alert alert-primary">
                ข้อมูลพนักงาน
            </div>
            <div class="card card-body mb-3">
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <div class="input-group">
                                <label for="txt_emp" class="btn btn-dark">รหัสพนักงาน</label>
                                <input type="text" id="txt_emp" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                        <td width="50%">
                            <div class="input-group">
                                <label for="ddl_pname" class="btn btn-dark">คำนำหน้าชื่อ</label>
                                <asp:DropDownList ID="ddl_pname" CssClass="form-control mb-2" runat="server">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="txt_fname" class="btn btn-dark">ชื่อ</label>
                                <input type="text" id="txt_fname" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="txt_lname" class="btn btn-dark">สกุล</label>
                                <input type="text" id="txt_lname" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="txt_fnameeng" class="btn btn-dark">Name</label>
                                <input type="text" id="txt_fnameeng" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="txt_lnameeng" class="btn btn-dark">Last name</label>
                                <input type="text" id="txt_lnameeng" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="txt_pos" class="btn btn-dark">ตำแหน่ง</label>
                                <input type="text" id="txt_pos" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="ddl_dept" class="btn btn-dark">หน่วยงาน</label>
                                <asp:DropDownList ID="ddl_dept" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr class="border-bottom-secondary">
                        <td>
                            <div class="input-group">
                                <label for="txt_faction" class="btn btn-dark">ฝ่าย</label>
                                <input type="text" id="txt_faction" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="txt_phone" class="btn btn-dark">โทรศัพท์ภายใน</label>
                                <input type="text" id="txt_phone" class="form-control mb-2 mr-2" runat="server" value="" required />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="txt_specailty" class="btn btn-dark">Specailty</label>
                                <input type="text" id="txt_specailty" class="form-control mb-2 mr-2" runat="server" value="-" required />
                            </div>
                        </td>
                        <td>
                            <div class="input-group">
                                <label for="txt_codecare" class="btn btn-dark">Code Care</label>
                                <input type="text" id="txt_codecare" class="form-control mb-2 mr-2" runat="server" value="-" required />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <label for="txt_location" class="btn btn-dark">Location</label>
                                <input type="text" id="txt_location" class="form-control mb-2 mr-2" runat="server" value="BRH" />
                            </div>
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="card col-10 mx-auto mb-2">
            <div class="h5 card card-header alert alert-primary">
                ข้อมูลระบบ
            </div>
            <div class="card card-body mb-3">
                <table width="100%">
                    <tr>
                        <td width="30%">
                            <div class="input-group">
                                <asp:CheckBox ID="cb_bconnect" CssClass="btn btn-circle" Enabled="false" runat="server" />
                                <label for="cb_bconnect" class="btn btn-dark">B-Connect</label>
                            </div>
                        </td>
                        <td width="60%">&nbsp;</td>
                        <td width="10%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <asp:CheckBox ID="cb_vpn" CssClass="btn btn-circle" Enabled="false" runat="server" />
                                <label for="cb_vpn" class="btn btn-dark">VPN</label>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <asp:CheckBox ID="cb_MS" CssClass="btn btn-circle" Enabled="false" runat="server" />
                                <label for="cb_MS" class="btn btn-dark">Microsoft Office</label>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group">
                                <asp:CheckBox ID="cb_email" CssClass="btn btn-circle" Enabled="false" runat="server" />
                                <label for="cb_email" class="btn btn-dark">E-mail Address</label>
                            </div>
                        </td>
                        <td>
                            <input type="text" id="txt_email" class="form-control mb-2 mr-2" runat="server" value=""  visible="false" />
                        </td>
                        <td>&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="input-group" id="div_quota" runat="server" visible="false">
                                <label for="ddl_quota" class="btn btn-secondary">New Quota :</label>
                                <asp:DropDownList ID="ddl_quota" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Choose..." Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="input-group" id="div_eg" runat="server" visible="false">
                                <label class="btn btn-secondary">Email Group :</label>
                            </div>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="2">
                        <div id="div_emailgroup" runat="server" visible="false">
                            <div class="input-group">
                                <asp:CheckBox ID="cb_hod" CssClass="btn btn-circle" runat="server" />
                                <label for="cb_hod" class="btn">BRH HOD</label>
                            </div>
                            <div class="input-group">
                                <asp:CheckBox ID="cb_staff" CssClass="btn btn-circle" runat="server" />
                                <label for="cb_staff" class="btn">BRH Staff</label>
                            </div>
                            <div class="input-group">
                                <asp:CheckBox ID="cb_committee" CssClass="btn btn-circle" runat="server" />
                                <label for="cb_committee" class="btn mr-2">Committee / Other</label>
                                <input type="text" id="txt_committee" class="form-control mb-2 mr-2" runat="server" value="" />
                            </div>
                        </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>

    <div class="mx-auto" style="text-align:center">
        <asp:Button ID="btn_submit" CssClass="btn btn-primary" Text="Submit" onclick="btn_submit_Click" runat="server" />
    </div>

</form>

</asp:Content>
