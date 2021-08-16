<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderRequestPrint.aspx.cs" Inherits="RequestComputerSystem.OrderRequestPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form runat="server">
    <div class="col-11 mx-auto">
        <table width="100%" border="1">
            <tr>
                <td width="20%"><img src="image/BGH_Rayong-Logo.jpg" class="img-fluid" /></td>
                <td width="80%" colspan="2" class="text-center h4">
                    <b>แบบฟอร์มขออนุมัติเปลี่ยนแปลงหรือปรับ Order Items</b>
                </td>
            </tr>
            <tr>
                <td width="20%">วันที่ : &nbsp;<asp:Label ID="lbl_date1" Text="........../........../.........." runat="server"></asp:Label></td>
                <td width="40%">แผนก : &nbsp;<asp:Label ID="lbl_dept" Text=".................................." runat="server"></asp:Label></td>
                <td width="40%">ชื่อผู้ร้องขอ : &nbsp;<asp:Label ID="lbl_empname1" Text=".................................." runat="server"></asp:Label></td>
            </tr>
        </table>

        <b>ส่วนที่ 1 อนุมัติในหลักการ</b>
        <table width="100%" border="1">
            <tr>
                <td colspan="2">
                    <table width="100%" border="0">
                        <tr>
                            <td colspan="3">
                                <u><b>วัตถุประสงค์เพื่อ</b></u>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%"><input type="radio" name="RD_obj" id="RD_obj1" runat="server" disabled="disabled" /> Economic Condition</td>
                            <td width="30%"><input type="radio" name="RD_obj" id="RD_obj2" runat="server" disabled="disabled" /> Annual Reviews</td>
                            <td width="40%"><input type="radio" name="RD_obj" id="RD_obj3" runat="server" disabled="disabled" /> New Department</td>
                        </tr>
                        <tr>
                            <td width="30%"><input type="radio" name="RD_obj" id="RD_obj4" runat="server" disabled="disabled" /> New Product</td>
                            <td width="30%"><input type="radio" name="RD_obj" id="RD_obj5" runat="server" disabled="disabled" /> New Wrok Flow</td>
                            <td width="40%"><input type="radio" name="RD_obj" id="RD_obj6" runat="server" disabled="disabled" /> Other 
                                (<asp:Label ID="lbl_other" Text="" runat="server" Visible="false"></asp:Label>)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <u><b>รายละเอียด</b></u>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%"><input type="radio" name="RD_dt" id="RD_dt1" runat="server" disabled="disabled" /> Set up New Item</td>
                            <td width="70%" colspan="2"><input type="radio" name="RD_dt" id="RD_dt2" runat="server" disabled="disabled" /> Delete Order Items</td>
                        </tr>
                        <tr>
                            <td width="30%"><input type="radio" name="RD_dt" id="RD_dt3" runat="server" disabled="disabled" /> ปรับลดราคา Order Items</td>
                            <td width="70%" colspan="2"><input type="radio" name="RD_dt" id="RD_dt4" runat="server" disabled="disabled" /> ปรับเพิ่มราคา Order Items</td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lbl_Details" Text="" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="text-right">
                                ลงชื่อผู้เสนอ (หัวหน้าแผนก) <asp:Label ID="lbl_empname2" Text="................................." runat="server"></asp:Label><br />
                                <asp:Label ID="lbl_date2" Text="........../........../.........." runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="50%">
                    <table width="100%">
                        <tr>
                            <td class="text-center"><b>ความเห็นผู้จัดการฝ่าย</b></td>
                        </tr>
                        <tr>
                            <td>
                                <input type="radio" name="RD_ap1" id="RD_apy1" runat="server" disabled="disabled" /> อนุมัติ <asp:Label ID="lbl_rm_y1" Text="................................" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="radio" name="RD_ap1" id="RD_apn1" runat="server" disabled="disabled" /> ไม่อนุมัติ <asp:Label ID="lbl_rm_n1" Text="................................" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">
                                (<asp:Label ID="lbl_name_ap1" Text="............................................" runat="server"></asp:Label>)
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">
                                <asp:Label ID="lbl_date_ap1" Text="........../........../.........." runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td width="50%">&nbsp;</td>
                <td width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td width="50%">&nbsp;</td>
                <td width="50%">&nbsp;</td>
            </tr>
        </table>
    </div>
</form>
</asp:Content>
