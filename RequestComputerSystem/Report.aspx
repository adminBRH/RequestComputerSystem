<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="RequestComputerSystem.Report1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="card col-6 mb-auto" style="margin-left: auto; margin-right: auto;">
            <div class="card-header">
                REPORT
            </div>
            <div class="card-body row">
                <div class="col-6 mb-2">
                <a class="btn btn-primary" href="ReportRequest.aspx">1. Report request systems.</a>
                </div>
                <div class="col-6 mb-2">
                <a class="btn btn-primary" href="#">2. Report cancel systems.</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
