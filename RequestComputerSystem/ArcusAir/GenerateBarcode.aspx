<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateBarcode.aspx.cs" Inherits="RequestComputerSystem.ArcusAir.GenerateBarcode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .PrintPage {
        width: 65mm;
        height: 20mm;
        margin: auto;
    }

    @page { margin: 0; }

    @media print {
      @page { margin: 0; }
      body { margin: 1.6cm; }
    }
</style>

    <form id="form_AA_barcode" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="mx-auto my-5 text-center">
            <asp:UpdatePanel ID="UpdatePanel_btn" runat="server">
                <ContentTemplate>
                    <div class="row col-12 mx-auto">
                        <div class="col-12 mx-auto">
                            <div class="col-lg-5 col-sm-10 mx-auto my-2">
                                <input type="text" class="form-control" id="txt_user" placeholder="User ArcusAir" required="required" runat="server" />
                            </div>
                            <div class="col-lg-5 col-sm-10 mx-auto my-2">
                                <input type="password" class="form-control" id="txt_pass" placeholder="Password ArcusAir" required="required" runat="server" />
                            </div>
                        </div>
                        <div class="col-12 mx-auto">
                            <div class="col-lg-5 col-sm-10 mx-auto my-2">
                                <asp:Button ID="btnGenBarcode" Text="Gennerate Barcode" CssClass="btn btn-primary" OnClick="btnGenBarcode_Click" runat="server" />
                            </div>
                        </div>
                        <div id="printableArea" class="col-lg-4 col-sm-10 mx-auto my-5 text-center">
                            <table class="PrintPage" style="width: 100%;">
                                <tr>
                                    <td class="text-center" style="width: 100%; margin: auto;">
                                        <img id="img_barcode" src="..." runat="server" style="width: 100%; margin: auto;" />
                                        <br /><asp:Label ID="lbl_script" Text="" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGenBarcode" EventName="click" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="col-12 mx-auto my-3 text-center">
                <input type="button" class="btn btn-outline-info" onclick="printContent('printableArea')" value="PRINT" />
            </div>
        </div>
    </form>

<script>
    function printContent(PrintAreaName) {
        var printContents = document.getElementById(PrintAreaName).innerHTML;
        var originalContents = document.body.innerHTML;
        document.body.innerHTML = printContents;
        window.print();
        document.body.innerHTML = originalContents;
    }
</script>

</asp:Content>
