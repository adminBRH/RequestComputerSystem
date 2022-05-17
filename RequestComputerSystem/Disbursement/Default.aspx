<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.Disbursement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-9 mx-auto" id="mainpage" runat="server">
        <div class="card">
            <div class ="card-body">
                <div class="text-center"><img src="img/LOGO-BRH.png" width="250px"/></div>
                <div class="card-header mt-1 text-center rounded" style="background-color:aquamarine"><h3>ประเภทของการขออนุมัติเบิกจ่าย</h3></div>
                <div class="col-12" style="background-color:aliceblue">
                    <div class="row col-12 mx-auto my-5">
                        <asp:Label ID="lbl_rdType" CssClass="row col-12 mx-auto" Text="" runat="server"></asp:Label>
                    </div>   
                    <div hidden="hidden">
                        <input type="text" id="txtH_Type" value="" runat="server" />
                    </div>
                    <script>
                        function getType() {
                            var txtHtype = document.getElementById('<%= txtH_Type.ClientID %>');
                            var rdType = document.getElementsByName('rdType');
                            for (var i = 0; i < rdType.length; i++) {
                                if (rdType[i].checked) {
                                    txtHtype.value = rdType[i].value;
                                }
                            }
                        }
                    </script>

                    <div class="col-12 mx-auto text-center btn btn-success" >
                        <div class="col-12 text-left btn btn-success my-2">
                            <asp:DropDownList ID="ddl_department" CssClass="btn btn-light"  runat="server">
                                <asp:ListItem Text="กรุณาเลือกแผนก" Value="" Selected="True"></asp:ListItem>  
                            </asp:DropDownList>  
                        </div>
                        <div class="col-12 text-left btn btn-success">
                            <asp:FileUpload ID="FileUpload1" CssClass="btn btn-light" AllowMultiple="true" runat="server" />
                        </div>
                        <div class="row col-12 mx-auto my-2">
                            <div class="col-2 mx-auto text-right my-auto">ผู้รับเงิน</div>
                            <div class="col-2 mx-auto">
                                <input type="text" id="txt_forpName" value="" class="form-control" placeholder="คำนำหน้า" runat="server" />
                            </div>
                            <div class="col-4 mx-auto">
                                <input type="text" id="txt_forfName" value="" class="form-control" placeholder="ชื่อ" runat="server" />
                            </div>
                            <div class="col-4 mx-auto">
                                <input type="text" id="txt_forlName" value="" class="form-control" placeholder="นามสกุล" runat="server" />
                            </div>
                        </div>
                    </div>

                    <br />
                            <div class="col-12 mt-3 mx-auto text-center">
                                    <button type="button" class="btn btn-info" id="submit_1" onserverclick="submit_1_ServerClick"  runat="server">SUBMIT</button>
                            </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</form>
</asp:Content>
