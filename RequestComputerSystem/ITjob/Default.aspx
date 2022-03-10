<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.ITjob.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form_itjob" runat="server">
        <div class="alert alert-primary col-12">
            <h3>ระบบร้องของาน IT</h3>
        </div>
        <div class="card col-12 mx-auto my-5">
            <div class="row col-12 mx-auto">
                <div class="col-12 mx-auto my-3 h5 text-right">
                    ร้องขอโดย: 
                    <asp:Label ID="lbl_requester" Text="ร้องขอโดย..." runat="server"></asp:Label>
                </div>
                <div class="col-lg-6 col-sm-12 mx-auto my-3" style="border: solid; border-radius: 20px;">
                    <div class="alert alert-info col-12 h5">
                        Select category.
                    </div>
                    <div class="col-12 mx-auto my-2">
                        <asp:DropDownList ID="DD_cate" CssClass="form-control" OnSelectedIndexChanged="DD_cate_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Text="เลือกหมวดหมู่การร้องขอ" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-12 mx-auto my-2">
                        <asp:RadioButtonList ID="RB_subcate" CssClass="col-10 mx-auto my-auto" runat="server">
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-12 mx-auto my-2">
                        <asp:FileUpload ID="File_attach" AllowMultiple="true" CssClass="form-control" runat="server" Visible="false" />
                    </div>
                </div>
                <div class="col-lg-6 col-sm-12 mx-auto my-3" style="border: solid; border-radius: 20px;">
                    <div class="alert alert-info col-12 h5">
                        Details for request.
                    </div>
                    <div class="col-12 mx-auto my-2">
                        <input type="text" id="txt_subject" value="" class="form-control" placeholder="Sebject" runat="server" />
                    </div>
                    <div class="col-12 mx-auto my-2">
                        <textarea id="txt_details" rows="5" class="form-control" placeholder="Details" runat="server"></textarea>
                    </div>
                </div>
                <div class="col-12 mx-auto my-3">
                    <asp:Label ID="lbl_approval" Text="ผู้อนุมัติ..." runat="server" Font-Size="X-Large"></asp:Label>
                </div>
            </div>
            <div class="col-12 mx-auto my-5 text-center">
                <button id="btn_submit" class="btn btn-primary" style="font-size: x-large;" onserverclick="btn_submit_ServerClick" runat="server"> บันทึก </button>
            </div>
        </div>
    </form>
</asp:Content>
