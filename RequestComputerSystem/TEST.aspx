<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TEST.aspx.cs" Inherits="RequestComputerSystem.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@4.0.0/dist/signature_pad.umd.min.js"></script>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <style>
        .fontDash{
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="col-12 mx-auto fontDash">
            <asp:ListView ID="LV_Request" runat="server">
                <LayoutTemplate>
                    <div class="alert alert-primary text-center">
                        Dashboard Strategy Request
                    </div>
                    <div id="itemPlaceholder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="card col-12 mx-auto my-3">
                        <div class="row col-12 mx-auto">
                            <div class="col-6 mx-auto">
                                <%# Eval("receiver_name") %>
                            </div>
                            <div class="col-4 mx-auto">
                                <%# Eval("st_name") %>
                            </div>
                            <div class="col-2 mx-auto">
                                <%# Eval("cnt") %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
