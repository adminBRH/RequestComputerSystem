<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceiveList.aspx.cs" Inherits="RequestComputerSystem.StrategyService.ReceiveList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row col-12 mx-auto">

        <div class="col-5 mx-auto">
            Date from:
            <input type="date" id="date_from" class="form-control" runat="server" />
        </div>
        <div class="col-5 mx-auto">
            'Date to:
            <input type="date" id="date_to" class="form-control" runat="server" />
        </div>
        <div class="col-2 mx-auto">
            <button id="btn_search" class="btn btn-success">Search</button>
        </div>

        <div class="col-12 mx-auto">
            <asp:ListView ID="LV_job" runat="server">
                <LayoutTemplate>
                    <div class="row col-12 mx-auto">
                        <div class="col-2 mx-auto text-center">Request ID</div>
                        <div class="col-3 mx-auto text-center">User Request</div>
                        <div class="col-2 mx-auto text-center">Request date</div>
                        <div class="col-4 mx-auto text-center">Subject</div>
                        <div class="col-2 mx-auto text-center">Status</div>
                        <div class="col-2 mx-auto text-center">Final date</div>
                        <div class="col-2 mx-auto text-center">Finish date</div>
                    </div>
                    <div id="itemPlaceholder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row col-12 mx-auto">
                        <div class="col-2 mx-auto text-center"><a class="btn btn-outline-info" onclick="" style="cursor: pointer;"><%# Eval("Request_ID") %></a></div>
                        <div class="col-3 mx-auto text-center"><%# Eval("CUser") %></div>
                        <div class="col-2 mx-auto text-center"><%# Eval("CDate") %></div>
                        <div class="col-4 mx-auto text-center"><%# Eval("Subject") %></div>
                        <div class="col-2 mx-auto text-center"><%# Eval("status") %></div>
                        <div class="col-2 mx-auto text-center"><%# Eval("ActualDate") %></div>
                        <div class="col-2 mx-auto text-center"><%# Eval("FinishDate") %></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>

</asp:Content>
