<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailSystems.aspx.cs" Inherits="RequestComputerSystem.DetailSystems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form id="form1" runat="server">
    <div class="row">

        <div class="col-xl-6 mb-2 mx-auto">
            <div class="card border-left-primary shadow h-100 py-2">
            <div class="card-header alert-primary h5 font-weight-bold text-gray-800">
                Detail of system
            </div>
            <div class="card-body">
                <div class="row no-gutters align-items-center">
                <div class="col mr-2">
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_systems" Text="System name......." runat="server"></asp:Label> </div>
                    <div id="div_email" runat="server" visible="false">
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_email" Text="Email......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50 prg2"> <asp:Label ID="lbl_quota" Text="Quota......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50 prg2"> <asp:Label ID="lbl_Groupmail" Text="Group Mail :" runat="server"></asp:Label> </div>
                        <div id="div_hod" class="font-weight-normal text-black-50 prg4" runat="server" visible="false"> <asp:Label ID="lbl_hod" Text="Group HOD......." runat="server"></asp:Label> </div>
                        <div id="div_staff" class="font-weight-normal text-black-50 prg4" runat="server" visible="false"> <asp:Label ID="lbl_staff" Text="Group Staff......." runat="server"></asp:Label> </div>
                        <div id="div_committee" class="font-weight-normal text-black-50 prg4" runat="server" visible="false"> <asp:Label ID="lbl_committee" Text="Group Committee/Other......." runat="server"></asp:Label> </div>
                    </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_userreq" Text="User name......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_userid" Text="User id......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_post" Text="Position......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_spec" Text="Specailty......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_care" Text="Code Care......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lo" Text="Location......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_remark" Text="Remark......." runat="server"></asp:Label> </div>
                </div>
                <div class="col-auto">
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_status" Text="Status......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_by" Text="By......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_bypost" Text="ตำแหน่ง......." runat="server"></asp:Label> </div>
                    <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_datetime" Text="Date time......." runat="server"></asp:Label> </div>
                        <hr />
                    <div id="div_laststatus" runat="server" visible="false">
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lastStatus" Text="Last Status......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50"> &nbsp;&nbsp;<asp:Label ID="lbl_lastaction" Text="......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lastby" Text="By......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lastbypost" Text="ตำแหน่ง......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lastdatetime" Text="Date time......." runat="server"></asp:Label> </div>
                        <div class="font-weight-normal text-black-50"> <asp:Label ID="lbl_lastremark" Text="Remark......." runat="server"></asp:Label> </div>
                    </div>
                </div>
                </div>
            </div>
            </div>
            <div class="col-auto">
                <div hidden="hidden"><asp:TextBox ID="txt_rqsid" Text="" runat="server"></asp:TextBox></div>
                <button class="btn btn-outline-info" id="btn_print" onclick="fn_print()">REPORT <i class="fas fa-file fa-2x"></i> </button>
                <div hidden="hidden"><asp:TextBox ID="txt_rqid" Text="" runat="server"></asp:TextBox></div>
                <button class="btn btn-outline-warning" id="btn_edit" onserverclick="btn_edit_ServerClick" runat="server" visible="false">Edit <i class="fas fa-edit fa-2x"></i> </button>
            </div>
        </div>

    </div>
</form>
<script>
    function fn_print() {
        var rqsid = document.getElementById("<%= txt_rqsid.ClientID %>").value;
        setTimeout(function () { window.location.href = 'ReportRequest.aspx?rqsid=' + rqsid }, 0);
    }
</script>

</asp:Content>
