<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InnovationSummary.aspx.cs" Inherits="RequestComputerSystem.InnovationSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Score Summary BRH Innovation Contest 2019</title>

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
  Score Summary BRH Innovation Contest 2019
</div>
    <form id="form1" runat="server">
<p>&nbsp;</p>
        <div style="width:80%; margin-left: auto; margin-right: auto;">
<center>
<table class="table table-hover">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">หัวข้อ Innovation Contest</th>
      <th scope="col">นพ.ก้องเกียรติ เกษเพ็ชร์</th>
      <th scope="col">นพ.จารุวัฑ ใช้ความเพียร</th>
      <th scope="col">คุณนคร ตั้งสุจริตพันธ์</th>
      <th>รวม</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>กางเกงใส่เฝือก</td>
      <td><asp:Label ID="lb_S1B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S1B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S1B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S1Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>QR Code Project</td>
      <td><asp:Label ID="lb_S2B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S2B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S2B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S2Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>KPI Online</td>
      <td><asp:Label ID="lb_S3B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S3B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S3B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S3Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">4</th>
      <td>X-ray หรรษา</td>
      <td><asp:Label ID="lb_S4B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S4B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S4B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S4Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">5</th>
      <td>Online Data Collection System</td>
      <td><asp:Label ID="lb_S5B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S5B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S5B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S5Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">6</th>
      <td>วงล้อเมนูอาหารผู้ป่วยหลังผ่าตัดทอนซิล</td>
      <td><asp:Label ID="lb_S6B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S6B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S6B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S6Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
    <tr>
      <th scope="row">7</th>
      <td>Digital Learning กับพนักงานยุค Millennial</td>
      <td><asp:Label ID="lb_S7B1" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S7B2" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S7B3" runat="server" Text="0"></asp:Label></td>
      <td><asp:Label ID="lb_S7Sum" runat="server" Text="0"></asp:Label></td>
    </tr>
  </tbody>
</table>
</center>
        </div>
    </form>
</body>
</html>
