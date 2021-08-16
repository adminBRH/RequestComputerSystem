<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PayOvertimeDetail.aspx.cs" Inherits="RequestComputerSystem.PayOvertimeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-11 mx-auto" id="mainpage" runat="server">
        <div class="card">
            <div class ="card-body">
                <div class="text-center"><img src="image/LOGO-BRH.png" width="250px"/></div>
                <div class="card-header mt-1 text-center bg-gradient-primary" style="color:white"><h3>Details of document id <asp:Label ID="lbl_id" Text="" runat="server"></asp:Label></h3></div>
                <div class="col-12" style="background-color:aliceblue">

                    <div class="row col-12">
                        <div class="col-12 mb-3">
                            <div class="card card-header bg-gradient-primary mt-3">
                                <div class="row col-12" style="color:white">
                                    <div class="col-6 text-left">Created</div>
                                    <div class="col-6 text-right"><asp:Label ID="pttime" runat="server"></asp:Label></div>
                                </div>
                            </div>
                            <div class="card card-body">
                                <div class="col-12 row">
                                    <div class="col-6 text-left">
                                        <asp:Label ID="username1" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-right">
                                        Month request : <asp:Label ID="reqdate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-6 mb-3">
                            <div class="card card-header bg-gradient-primary">
                                <div class="row col-12" style="color:white">
                                    <div class="col-6 text-left">HOD</div>
                                    <div class="col-6 text-right"><asp:Label ID="Label1" runat="server"></asp:Label></div>
                                </div>
                            </div>
                            <div class="card card-body">
                                <asp:Label ID="hodstatus" runat="server"></asp:Label>
                                <asp:Label ID="hod_name1" runat="server"></asp:Label>
                                <asp:Label ID="hodremark" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-6 mb-3">
                            <div class="card card-header bg-gradient-primary">
                                <div class="row col-12" style="color:white">
                                    <div class="col-6 text-left">HR</div>
                                    <div class="col-6 text-right"><asp:Label ID="Label2" runat="server"></asp:Label></div>
                                </div>
                            </div>
                            <div class="card card-body">
                                <asp:Label ID="hrstatus" runat="server"></asp:Label>
                                <asp:Label ID="hrname1" runat="server"></asp:Label>
                                <asp:Label ID="hrremark" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-12 my-5">
                            <h5>Attachment :
                            <asp:Label ID="fileshow" runat="server"></asp:Label>
                            </h5>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</form>
</asp:Content>
