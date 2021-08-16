<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InnovationScore.aspx.cs" Inherits="RequestComputerSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BRH Design Innovation Contest 2019</title>

    <link rel="shortcut icon" href="image/icons/BRHfavicon.ico" type="image/x-icon">

    <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

  <link href="https://cdn.jsdelivr.net/gh/gitbrent/bootstrap4-toggle@3.6.1/css/bootstrap4-toggle.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/gh/gitbrent/bootstrap4-toggle@3.6.1/js/bootstrap4-toggle.min.js"></script>

  <!-- Custom styles for this template-->
  <link href="css/sb-admin-2.min.css" rel="stylesheet">

</head>
<body>
<div class="alert alert-info" role="alert">
  BRH Design Innovation Contest 2019
</div>
    <form id="form1" runat="server">
        <div style="width:80%; margin-left: auto; margin-right: auto;">
<p><strong>เกณฑ์การตัดสิน Innovation Award</strong></p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
    คณะกรรมการ :<asp:DropDownList CssClass="btn btn-outline-secondary" ID="ddl_Board" OnSelectedIndexChanged="ddl_Board_SelectedIndexChanged" AutoPostBack="true" runat="server">
                <asp:ListItem Text="กรุณาเลือกรายชื่อ" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="นพ.ก้องเกียรติ เกษเพ็ชร์" Value="Board1"></asp:ListItem>
                <asp:ListItem Text="นพ.จารุวัฑ ใช้ความเพียร" Value="Board2"></asp:ListItem>
                <asp:ListItem Text="คุณนคร ตั้งสุจริตพันธ์" Value="Board3"></asp:ListItem>
               </asp:DropDownList>
</p>

<div id="DivBody" runat="server" visible="false">

<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
   หัวข้อ :<asp:DropDownList ID="ddl_story" CssClass="btn btn-outline-secondary" runat="server">
        <asp:ListItem Value="" Text="กรุณาเลือกหัวข้อ Innovation"></asp:ListItem>
        <asp:ListItem Value="S1" Text="1. กางเกงใส่เฝือก"></asp:ListItem>
        <asp:ListItem Value="S2" Text="2. QR Code Project"></asp:ListItem>
        <asp:ListItem Value="S3" Text="3. KPI Online"></asp:ListItem>
        <asp:ListItem Value="S4" Text="4. X-ray หรรษา"></asp:ListItem>
        <asp:ListItem Value="S5" Text="5. Online Data Collection System"></asp:ListItem>
        <asp:ListItem Value="S6" Text="6. วงล้อเมนูอาหารผู้ป่วยหลังผ่าตัดทอนซิล"></asp:ListItem>
        <asp:ListItem Value="S7" Text="7. Digital Learning กับพนักงานยุค Millennial"></asp:ListItem>
    </asp:DropDownList>
</p>
<ol>
<li><strong> Paradigm</strong><strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 3. Position</strong></li>
<li><strong> Product/ Services</strong><strong>&nbsp; &nbsp; 4. Process</strong></li>
</ol>

<div class="card border-info mb-3">
<div class="card-header"><h5>1) ความคิดสร้างสรรค์</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Creative Ability)</h5>
<p class="card-text">
    ความคิดสร้างสรรค์และจินตนาการในด้านต่างๆ ได้แก่ การกำหนดปัญหาและเป้าหมาย แนวทาง/ วิธีการแก้ปัญหา การออกแบบการทดลอง การออกแบบและการสร้างเครื่องมือ/อุปกรณ์/ต้นแบบต่างๆ การวิเคราะห์และการแปลผลข้อมูล เป็นต้น
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL1" class="custom-range" min="0" max="25" step="1" value="0" onchange="updateRange('1');"></td>
            <td width="15%"><center><label id="lbGL1" for="rgGL1">0-25</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>2) ความคิดทางวิทยาศาสตร์หรือเป้าหมายทางวิศวกรรม</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Scientific Thought and Engineering Goals)</h5>
<p class="card-text">
    การกำหนดปัญหาและเป้าหมายชัดเจน มีความเป็นไปได้ใน การพัฒนาและมีประโยชน์ มีการวางแผนในการออกแบบ/ ทดลอง/ทดสอบการใช้งานจริง การกำหนดและควบคุมตัวแปร ถูกต้อง ข้อมูลครบถ้วนเพียงพอที่จะใช้สรุปผล ความเข้าใจใน โครงงานตนเองและงานวิจัยอื่นๆ ที่เกี่ยวข้อง สิ่งที่วางแผน จะพัฒนาเพิ่มเติมต่อไป การอ้างอิงข้อมูล/หลักการทาง วิทยาศาสตร์
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL2" class="custom-range" min="0" max="25" step="1" value="0" onchange="updateRange('2');"></td>
            <td width="15%"><center><label id="lbGL2" for="rgGL2">0-25</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>3) ความละเอียดรอบคอบ</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Thoroughness)</h5>
<p class="card-text">
    ความสมบูรณ์ของโครงงานและการบรรลุตามวัตถุประสงค์และ เป้าหมาย รายละเอียดและความถูกต้องของการบันทึกข้อมูล ในสมุดบันทึกข้อมูลโครงงาน ความรอบรู้ในเรื่องที่เกี่ยวข้อง กับโครงงานที่ทำ
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL3" class="custom-range" min="0" max="12" step="1" value="0" onchange="updateRange('3');"></td>
            <td width="15%"><center><label id="lbGL3" for="rgGL3">0-12</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>4) ทักษะ</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Skill)</h5>
<p class="card-text">
    ทักษะด้านต่างๆ ในการทำโครงงาน เช่น การสังเกต การทำการทดลอง การออกแบบ การคำนวณ เป็นต้น ผู้พัฒนาได้รับความช่วยเหลือจากผู้อื่นในการทำ โครงงานหรือไม่และส่วนใดบ้าง
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL4" class="custom-range" min="0" max="12" step="1" value="0" onchange="updateRange('4');"></td>
            <td width="15%"><center><label id="lbGL4" for="rgGL4">0-12</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>5) ความชัดเจน</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Clarity)</h5>
<p class="card-text">
    ความชัดเจนของข้อมูล/ผลการทดลอง/การอธิบายผลงาน รายงาน/การจัดแสดงผลงาน/การนำเสนอผลงาน ประกอบด้วยเนื้อหาสาระสำคัญตามลำดับขั้นตอน ผู้พัฒนา ได้ทำโครงงานเองทั้งหมดหรือไม่
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL5" class="custom-range" min="0" max="10" step="1" value="0" onchange="updateRange('5');"></td>
            <td width="15%"><center><label id="lbGL5" for="rgGL5">0-10</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>6) การทำงานร่วมกันเป็นทีม</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">(Teamwork) </h5>
<p class="card-text">
    การแบ่งงานและการมีส่วนร่วมในการทำงานของสมาชิก ความร่วมมือและความพยายามในการทำงานร่วมกัน สมาชิกทุกคนรู้ซึ้งและเข้าใจในทุกส่วนของโครงงานที่ทำ
</p>
</div>
<div class="card-footer bg-transparent border-info">
    <table width="100%">
        <tr>
            <td width="85%"><input type="range" id="rgGL6" class="custom-range" min="0" max="16" step="1" value="0" onchange="updateRange('6');"></td>
            <td width="15%"><center><label id="lbGL6" for="rgGL6">0-16</label></center></td>
        </tr>
    </table>
</div>
</div>

<div class="card border-info mb-3">
<div class="card-header"><h5>Score</h5></div>
<div class="card-body text-secondary">
<h5 class="card-title">Summary</h5>
<p class="card-text">
    <center><h3><label id="lbSUM" for="rgGL6">0</label></h3></center>
</p>
</div>
</div>

<p>&nbsp;</p>

            <div class="col-12 text-center">
                <%--<asp:Button runat="server" Text="SUBMIT" ID="BtnSubmit" CssClass="btn btn-primary" OnClick="BtnSubmit_Click" />--%>
                <button id="BtnSubmit" class="btn btn-primary" onmouseover="checkform()" runat="server" onserverclick="BtnSubmit_Click">SUBMIT</button>
            </div>
</div>
        </div>

<div hidden="hidden">
    <asp:TextBox ID="val1" Text="0" runat="server"></asp:TextBox>
    <asp:TextBox ID="val2" Text="0" runat="server"></asp:TextBox>
    <asp:TextBox ID="val3" Text="0" runat="server"></asp:TextBox>
    <asp:TextBox ID="val4" Text="0" runat="server"></asp:TextBox>
    <asp:TextBox ID="val5" Text="0" runat="server"></asp:TextBox>
    <asp:TextBox ID="val6" Text="0" runat="server"></asp:TextBox>

    <asp:TextBox ID="txtBoard" Text="" runat="server"></asp:TextBox>
    <asp:TextBox ID="TxtStory" Text="" runat="server"></asp:TextBox>
</div>
        
    </form>

<script>
    function updateRange(rg) {
        var rgGL = 'rgGL' + rg;
        var amt = document.getElementById(rgGL).value;
        var lbGL = 'lbGL' + rg;
        document.getElementById(lbGL).innerHTML = amt;

        var Txt = 'val' + rg;
        document.getElementById(Txt).value = amt;

        var i;
        var sum = 0;
        for (i = 1; i <= 6; i++) {
            sum += parseInt(document.getElementById('val' + i).value);
        }
        document.getElementById('lbSUM').innerHTML = sum;
    }

    function checkform() {
        if (document.getElementById('ddl_story').value == '') {
            alert('กรุณาเลือกหัวข้อ Innovation !!');
        }
        else {
            var Board = document.getElementById('ddl_Board').value;
            var TxtB = document.getElementById('txtBoard');
            if (Board == 'Board1') { TxtB.value = 'นพ.ก้องเกียรติ เกษเพ็ชร์'; }
            if (Board == 'Board2') { TxtB.value = 'นพ.จารุวัฑ ใช้ความเพียร'; }
            if (Board == 'Board3') { TxtB.value = 'คุณนคร ตั้งสุจริตพันธ์'; }

            var Story = document.getElementById('ddl_story').value;
            var txtS = document.getElementById('TxtStory');
            if (Story == 'S1') { txtS.value = 'กางเกงใส่เฝือก'; }
            if (Story == 'S2') { txtS.value = 'QR Code Project'; }
            if (Story == 'S3') { txtS.value = 'KPI Online'; }
            if (Story == 'S4') { txtS.value = 'X-ray หรรษา'; }
            if (Story == 'S5') { txtS.value = 'Online Data Collection System'; }
            if (Story == 'S6') { txtS.value = 'วงล้อเมนูอาหารผู้ป่วยหลังผ่าตัดทอนซิล'; }
            if (Story == 'S7') { txtS.value = 'Digital Learning กับพนักงานยุค Millennial'; }
        }
    }
</script>
    <p>&nbsp;</p><p>&nbsp;</p>
</body>
</html>