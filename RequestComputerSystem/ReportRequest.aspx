<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportRequest.aspx.cs" Inherits="RequestComputerSystem.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <form id="form1" runat="server">
        <div id="P1" style="width:21cm; margin-left: auto; margin-right: auto;">
<!-- -------------------------------Html Page------------------------------- -->
<table id="printableArea" style="width: 21cm; margin-left: auto; margin-right: auto;" border="0">
<tbody>
<tr>
<td>
<p style="text-align:right"> <asp:Label ID="lb_ID" Text="" runat="server"></asp:Label> </p>
<p><img src="image/LOGO-BRH.png" alt="BRH" width="164" height="59" /></p>
<p style="text-align: center;">แบบฟอร์มการขอใช้งานระบบคอมพิวเตอร์ในโรงพยาบาลกรุงเทพระยอง</p>
<p style="text-align: center;">
    <asp:CheckBox ID="cb_request" runat="server" />ขอใช้งาน...............&nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cb_cancel" runat="server" />ยกเลิกการใช้งาน...............
</p>
<p style="text-align: left;">ข้อมูลพนักงาน :&nbsp;</p>
<table style="width: 95%; margin-left: auto; margin-right: auto;" border="1">
<tbody>
<tr style="height: 18%;">
<td style="width: 16%;">รหัสพนักงาน</td>
<td style="width: 42%;">ชื่อ(ไทย):&nbsp;<asp:Label ID="lb_fname" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">สกุล(ไทย):&nbsp;<asp:Label ID="lb_lname" Text="" runat="server"></asp:Label></td>
</tr>
<tr style="height: 18%;">
<td style="width: 16%; text-align: center;" rowspan="5"><asp:Label ID="lb_EmID" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">ชื่อ(อังกฤษ):&nbsp;<asp:Label ID="lb_fnameeng" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">สกุล(อังกฤษ):&nbsp;<asp:Label ID="lb_lnameeng" Text="" runat="server"></asp:Label></td>
</tr>
<tr style="height: 18%;">
<td style="width: 42%;">ชื่อตำแหน่ง(ไทย):&nbsp;<asp:Label ID="lb_post" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">โทรศัพท์ภายใน:&nbsp;<asp:Label ID="lb_tel" Text="" runat="server"></asp:Label></td>
</tr>
<tr style="height: 18%;">
<td style="width: 42%;">ชื่อ/รหัส หน่วยงาน(ไทย):&nbsp;<asp:Label ID="lb_depart" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">ฝ่าย(ไทย):&nbsp;<asp:Label ID="lb_faction" Text="" runat="server"></asp:Label></td>
</tr>
<tr style="height: 18%;">
<td style="width: 42%;">Specailty:&nbsp;<asp:Label ID="lb_Specailty" Text="" runat="server"></asp:Label></td>
<td style="width: 42%;">Code Care:&nbsp;<asp:Label ID="lb_CodeCare" Text="" runat="server"></asp:Label></td>
</tr>
<tr style="height: 18%;">
<td style="width: 42%;" colspan="2">Location:&nbsp;<asp:Label ID="lb_Location" Text="" runat="server"></asp:Label></td>
</tr>
</tbody>
</table>
<br />
<p style="text-align: left;">ระบบที่ร้องขอ</p>
<p id="P_AA" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_AA" runat="server" />Arcus Air</p>
<p id="P_SWL" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_SWL" runat="server" />Software License</p>
<p id="P_IPPhone" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_IPPhone" runat="server" />IP Phone</p>
<p id="P_Tablet" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_Tablet" runat="server" />Tablet</p>
<p id="P_iPad" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_iPad" runat="server" />iPad</p>
<p id="P_VPN" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_VPN" runat="server" />VPN</p>
<p id="pd_VPN" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp;<asp:Label ID="lbl_VPNAccount" Text="" runat="server"></asp:Label></p>
<p id="P_Printer" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_Printer" runat="server" />Printer</p>
<p id="pd_Printer" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp;<asp:Label ID="lbl_Printer" Text="" runat="server"></asp:Label></p>
<p id="P_Com" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_Com" runat="server" />Computer</p>
<p id="pd_Com" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp;<asp:Label ID="lbl_Com" Text="" runat="server"></asp:Label></p>
<p id="P_email" style="text-align: left;" runat="server" visible="false"><asp:CheckBox ID="cb_email" runat="server" />E-mail Address .....<asp:Label ID="lb_email" runat="server" Text=".................................................."></asp:Label>.....</p>
<p id="pd_email_1" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cb_quota" runat="server" />New Quota :&nbsp; <asp:RadioButton ID="ro_200" runat="server" />200/MB&nbsp; &nbsp;<asp:RadioButton ID="ro_500" runat="server" />500/MB&nbsp; &nbsp;<asp:RadioButton ID="ro_1028" runat="server" />1GB</p>
<p id="pd_email_2" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp;Group name</p>
<p id="pd_email_3" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:CheckBox ID="cb_hod" runat="server" />BRH HOD&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:CheckBox ID="cb_staff" runat="server" />BRH staff</p>
<p id="pd_email_4" style="text-align: left;" runat="server" visible="false">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:CheckBox ID="cb_committee" runat="server" />Committee/Other .....<asp:Label ID="lb_committee" runat="server" Text="................................................................"></asp:Label>.....</p>
<p style="text-align: left;">&nbsp; &nbsp; &nbsp;ข้าพเจ้ารับทราบนโยบายรักษาความมั่นคงปลอดภัยของระบบเทคโนโลยีสารสนเทศและการสื่อสารของโรงพยาบาลและจะปฏิบัติตามทุกประการ</p>
<table style="width: 95%; margin-left: auto; margin-right: auto;" border="1">
<tbody>
<tr style="height: 18%;">
    <td style="width: 25%; text-align: center;">&nbsp;ผู้ร้องขอ</td>
    <td style="width: 50%; text-align: center;">&nbsp;ตรวจสอบโดย(หัวหน้าแผนก/ผู้จัดการสายงาน)</td>
    <td style="width: 25%; text-align: center;">&nbsp;ทบทวน/เห็นชอบโดย</td>
</tr>
<tr>
    <td style="width: 25%; text-align: center;">
        <p>&nbsp;(<asp:Label ID="lb_lv1" runat="server" Text="........................."></asp:Label>)</p>
        <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos1" runat="server" Text="..."></asp:Label></p>
        <p><asp:Label ID="lb_date1" runat="server" Text="...../...../........"></asp:Label></p>
    </td>
    <td style="width: 50%;">
        <table style="width: 100%;">
        <tbody>
        <tr>
        <td style="width: 50%; text-align: center;">
        <p>&nbsp;(<asp:Label ID="lb_lv2" runat="server" Text="........................."></asp:Label>)</p>
        <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos2" runat="server" Text="..."></asp:Label></p>
        <p><asp:Label ID="lb_date2" runat="server" Text="...../...../........"></asp:Label></p>
        </td>
        <td style="text-align: center;">
        <p>&nbsp;(<asp:Label ID="lb_lv3" runat="server" Text="........................."></asp:Label>)</p>
        <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos3" runat="server" Text="..."></asp:Label></p>
        <p><asp:Label ID="lb_date3" runat="server" Text="...../...../........"></asp:Label></p>
        </td>
        </tr>
        </tbody>
        </table>
    </td>
    <td style="width: 25%; text-align: center;">(<i id="ck4_1" class="fas fa-check fa-sm" runat="server" visible="false"></i>)เห็นชอบ (<i id="ck4_2" class="fas fa-check fa-sm" runat="server" visible="false"></i>)ไม่เห็นชอบ&nbsp;
        <p>&nbsp;(<asp:Label ID="lb_lv4" runat="server" Text="........................."></asp:Label>)</p>
        <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos4" runat="server" Text="..."></asp:Label></p>
        <p><asp:Label ID="lb_remark4" CssClass="text-danger" runat="server" Text=""></asp:Label></p>
        <p><asp:Label ID="lb_date4" runat="server" Text="...../...../........"></asp:Label></p>
    </td>
</tr>
<tr>
<td style="width: 25%; text-align: center;" colspan="3">
    <table style="width: 100%; border: medium;">
    <tbody>
    <tr style="height: 50%;">
    <td style="width: 50%; border-bottom: 1px solid black;">&nbsp;เห็นควรอนุมัติโดย</td>
    <td style="width: 50%; border-left: 1px solid black; border-bottom: 1px solid black;">อนุมัติโดย&nbsp;</td>
    </tr>
    <tr style="height: 50%;">
    <td style="width: 50%;">&nbsp;(<i id="ck5_1" class="fas fa-check fa-sm" runat="server" visible="false"></i>)เห็นควรอนุมัติ&nbsp; (<i id="ck5_2" class="fas fa-check fa-sm" runat="server" visible="false"></i>)ไม่เห็นควรอนุมัติ
    <p>(<asp:Label ID="lb_lv5" runat="server" Text="........................."></asp:Label>)</p>
    <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos5" runat="server" Text="..."></asp:Label></p>
    <p><asp:Label ID="lb_date5" runat="server" Text="...../...../........"></asp:Label></p>
    </td>
    <td style="width: 50%; border-left: 1px solid black;">(<i id="ck6_1" class="fas fa-check fa-sm" runat="server" visible="false"></i>)อนุมัติ&nbsp; &nbsp; &nbsp; (<i id="ck6_2" class="fas fa-check fa-sm" runat="server" visible="false"></i>)ไม่อนุมัติ&nbsp;
    <p>(<asp:Label ID="lb_lv6" runat="server" Text="........................."></asp:Label>)</p>
    <p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos6" runat="server" Text="..."></asp:Label></p>
    <p><asp:Label ID="lb_date6" runat="server" Text="...../...../........"></asp:Label></p>
    </td>
    </tr>
    </tbody>
    </table>
</td>
</tr>
<tr>
<td style="width: 25%; text-align: center;">&nbsp;ผู้ดำเนินการ</td>
<td style="width: 50%; text-align: center;">แจ้งผู้ขอใช้&nbsp;</td>
<td style="width: 25%; text-align: center;">&nbsp;อื่นๆ/หมายเหตุ</td>
</tr>
<tr>
<td style="width: 25%; text-align: center;">&nbsp;
<p>(<asp:Label ID="lb_lv7" runat="server" Text="........................."></asp:Label>)</p>
<p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos7" runat="server" Text="..."></asp:Label></p>
<p><asp:Label ID="lb_date7" runat="server" Text="...../...../........"></asp:Label></p>
</td>
<td style="width: 50%; text-align: center;">&nbsp;
<p>(<asp:Label ID="lb_lv8" runat="server" Text="........................."></asp:Label>)</p>
<p>ตำแหน่ง&nbsp;<asp:Label ID="lb_pos8" runat="server" Text="..."></asp:Label></p>
<p><asp:Label ID="lb_date8" runat="server" Text="...../...../........"></asp:Label></p>
</td>
<td style="width: 25%; text-align: center;">&nbsp;
<p>(<asp:Label ID="lb_remarkactor" runat="server" Text="........................."></asp:Label>)</p>
<p><asp:Label ID="lb_remark" runat="server" Text="..."></asp:Label></p>
<p><asp:Label ID="lb_dateremark" runat="server" Text="...../...../........"></asp:Label></p>
</td>
</tr>
</tbody>
</table>
    <p>&nbsp;</p>
    <p style="text-align:right"> <asp:Label ID="lb_date" Text="..." runat="server"></asp:Label> </p>
</td>
</tr>
</tbody>
</table>
<!-- -------------------------------Html Page------------------------------- -->

        </div>
         <br />
         <center><input type="button" class="btn btn-outline-info" onclick="printDiv('printableArea')" value="PRINT" /></center>
    </form>

<script>
document.onkeydown = function (e) {
    if (e.ctrlKey &&
        (e.keyCode === 67 ||
            e.keyCode === 86 ||
            e.keyCode === 85 ||
            e.keyCode === 117)) {
        return false;
    } else {
        return true;
    }
};
$(document).keypress("u", function (e) {
    if (e.ctrlKey) {
        return false;
    }
    else {
        return true;
    }
});
</script>
<!-- //// -->

<!-- F12 Prevent script -->

<script language="JavaScript">
    document.onkeypress = function (event) {
        event = (event || window.event);
        if (event.keyCode == 123) {
            //alert('No F-12');
            return false;
        }
    }
    document.onmousedown = function (event) {
        event = (event || window.event);
        if (event.keyCode == 123) {
            //alert('No F-keys');
            return false;
        }
    }
    document.onkeydown = function (event) {
        event = (event || window.event);
        if (event.keyCode == 123) {
            //alert('No F-keys');
            return false;
        }
    }


    document.addEventListener('contextmenu', event => event.preventDefault());

    //print();

    function printDiv(divPrintName) {
        var printContents = document.getElementById(divPrintName).innerHTML;
        var originalContents = document.body.innerHTML;
        document.body.innerHTML = printContents;
        window.print();
        document.body.innerHTML = originalContents;
    }


</script>

</asp:Content>
