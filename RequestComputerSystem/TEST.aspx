<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TEST.aspx.cs" Inherits="RequestComputerSystem.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row col-12 bg-danger">
            <div class="col-6 mx-auto">
                <input id="txt_name" value="" class="form-control" runat="server"/>
            </div>
            <div class="col-6 mx-auto">
                <button id="btn_search" class="btn btn-outline-primary" onserverclick="btn_search_ServerClick" runat="server">Search</button>
            </div>
            <div class="col-12 mx-auto">
                <asp:Label ID="lbl_alert" Text="" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
