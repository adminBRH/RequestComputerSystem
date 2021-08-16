<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Innovation.aspx.cs" Inherits="RequestComputerSystem.Innovation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BRH Design Innovation Contest 2019</title>

    <%--<link rel="shortcut icon" href="image/icons/BRHfavicon.ico" type="image/x-icon">--%>

    <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">


  <link href="https://cdn.jsdelivr.net/gh/gitbrent/bootstrap4-toggle@3.6.1/css/bootstrap4-toggle.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/gh/gitbrent/bootstrap4-toggle@3.6.1/js/bootstrap4-toggle.min.js"></script>

  <!-- Custom styles for this template-->
  <link href="css/sb-admin-2.min.css" rel="stylesheet">

<style type="text/css">

</style>

</head>
<body>
<div class="alert alert-info" role="alert">
  BRH Design Innovation Contest 2019
</div>
    <form id="form1" runat="server">
        <div id="bg">
            <center>
                <a href="InnovationScore.aspx">
                    <img width="800px" height="100%" src="image/Innovation2019.jpg" alt="">
                </a>
            </center>
            <br />
            <div class="text-right">
            <asp:Button ID="btn_score" CssClass="btn btn-outline-light" Text="Score Summary" OnClick="btn_score_Click" runat="server" />
            </div>
            <br />
        </div>
    </form>
</body>
</html>
